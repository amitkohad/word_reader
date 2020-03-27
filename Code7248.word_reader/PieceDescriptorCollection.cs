using System.Collections;
using System.IO;

namespace Code7248.word_reader
{
	internal class PieceDescriptorCollection
	{
		private int _Offset;

		private uint _Length;

		private PieceDescriptor[] _Descriptors;

		private FileOffsetCollection _DescriptorOffsets;

		public int Count => _Descriptors.Length;

		public PieceDescriptorCollection(int offset, uint length)
		{
			_Offset = offset;
			_Length = length;
		}

		private int GetOffsetsCount(int size, int structureSize)
		{
			return GetDescriptorsCount(size, structureSize) + 1;
		}

		private int GetDescriptorsCount(int size, int structureSize)
		{
			int num = 4;
			return (size - num) / (structureSize + num);
		}

		private PieceDescriptor[] ReadDescriptors(BinaryReader reader, int count)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < count; i++)
			{
				PieceDescriptor pieceDescriptor = new PieceDescriptor();
				pieceDescriptor.Read(reader);
				arrayList.Add(pieceDescriptor);
			}
			return (PieceDescriptor[])arrayList.ToArray(typeof(PieceDescriptor));
		}

		public void Read(BinaryReader reader)
		{
			reader.BaseStream.Seek(_Offset, SeekOrigin.Begin);
			while (reader.BaseStream.Position < _Offset + _Length)
			{
				switch (reader.ReadByte())
				{
				case 0:
					reader.ReadByte();
					break;
				case 1:
				{
					short count = reader.ReadInt16();
					byte[] array = reader.ReadBytes(count);
					break;
				}
				case 2:
				{
					int size = reader.ReadInt32();
					_DescriptorOffsets = new FileOffsetCollection();
					_DescriptorOffsets.Read(reader, GetOffsetsCount(size, PieceDescriptor.Size));
					_Descriptors = ReadDescriptors(reader, GetDescriptorsCount(size, PieceDescriptor.Size));
					break;
				}
				}
			}
		}

		public bool GetPieceFileBounds(int piece, out uint start, out uint end)
		{
			start = uint.MaxValue;
			end = uint.MaxValue;
			PieceDescriptor pieceDescriptor = _Descriptors[piece];
			uint fc = pieceDescriptor.Fc;
			bool flag = FileOffset.IsUnicode(fc);
			start = FileOffset.NormalizeFc(fc);
			uint num = _DescriptorOffsets[piece + 1].Value - _DescriptorOffsets[piece].Value;
			end = start + num * FileOffset.GetFcDelta(flag);
			return flag;
		}
	}
}
