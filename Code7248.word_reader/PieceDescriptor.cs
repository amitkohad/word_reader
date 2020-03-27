using System.IO;

namespace Code7248.word_reader
{
	internal class PieceDescriptor
	{
		private const int strSize = 8;

		private byte _Flags;

		private byte _Fn;

		private uint _Fc;

		private short _Prm;

		public static int Size => 8;

		public uint Fc
		{
			get
			{
				return _Fc;
			}
			set
			{
				_Fc = value;
			}
		}

		public short Prm
		{
			get
			{
				return _Prm;
			}
			set
			{
				_Prm = value;
			}
		}

		public void Read(BinaryReader reader)
		{
			_Flags = reader.ReadByte();
			_Fn = reader.ReadByte();
			_Fc = reader.ReadUInt32();
			_Prm = reader.ReadInt16();
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(_Flags);
			writer.Write(_Fn);
			writer.Write(_Fc);
			writer.Write(_Prm);
		}
	}
}
