using Code7248.word_reader.Native;
using Code7248.word_reader.Ole;
using System.IO;
using System.Text;

namespace Code7248.word_reader
{
	internal class doc_reader
	{
		private string _Path;

		private static readonly Encoding encoder = new UnicodeEncoding();

		public doc_reader(string path)
		{
			_Path = path;
		}

		private BinaryReader GetReader(OleStream stream)
		{
			if (stream == null)
			{
				return null;
			}
			byte[] buffer = stream.ReadToEnd();
			MemoryStream input = new MemoryStream(buffer);
			return new BinaryReader(input);
		}

		private BinaryReader GetStreamReader(OleStorage storage, string streamName)
		{
			OleStream oleStream = storage.OpenStream(streamName);
			if (oleStream == null)
			{
				return null;
			}
			return GetReader(oleStream);
		}

		private BinaryReader GetDocumentStreamReader(OleStorage storage)
		{
			return GetStreamReader(storage, "WordDocument");
		}

		private BinaryReader GetTableStreamReader(OleStorage storage, string tableName)
		{
			return GetStreamReader(storage, tableName);
		}

		private void GetDataFromFib(BinaryReader reader, out string tableName, out int pdcOffset, out uint pdcLength)
		{
			reader.BaseStream.Seek(10L, SeekOrigin.Begin);
			ushort target = reader.ReadUInt16();
			tableName = (BitUtils.IsSet(target, 9) ? "1Table" : "0Table");
			reader.BaseStream.Seek(418L, SeekOrigin.Begin);
			pdcOffset = reader.ReadInt32();
			pdcLength = reader.ReadUInt32();
		}

		private PieceDescriptorCollection GetPieceDescriptors(BinaryReader reader, int offset, uint length)
		{
			PieceDescriptorCollection pieceDescriptorCollection = new PieceDescriptorCollection(offset, length);
			pieceDescriptorCollection.Read(reader);
			return pieceDescriptorCollection;
		}

		private string ReadString(BinaryReader reader, uint length, bool isUnicode)
		{
			if (length == 0)
			{
				return string.Empty;
			}
			if (isUnicode)
			{
				length /= 2u;
			}
			StringBuilder stringBuilder = new StringBuilder((int)length);
			try
			{
				if (isUnicode)
				{
					byte[] bytes = reader.ReadBytes((int)length);
					stringBuilder.Append(encoder.GetString(bytes));
				}
				else
				{
					for (int i = 0; i < length; i++)
					{
						byte iValue = reader.ReadByte();
						stringBuilder.Append(CharFromByte(iValue));
					}
				}
				return stringBuilder.ToString();
			}
			finally
			{
				stringBuilder.Length = 0;
			}
		}

		private static char CharFromByte(byte iValue)
		{
			switch (iValue)
			{
			case 58:
				return ':';
			case 128:
				return '€';
			case 130:
				return '‚';
			case 131:
				return 'ƒ';
			case 132:
				return '„';
			case 133:
				return '…';
			case 134:
				return '†';
			case 135:
				return '‡';
			case 136:
				return '\u02c6';
			case 137:
				return '‰';
			case 138:
				return 'Š';
			case 139:
				return '‹';
			case 140:
				return 'Œ';
			case 142:
				return 'Ž';
			case 145:
				return '‘';
			case 146:
				return '’';
			case 147:
				return '“';
			case 148:
				return '”';
			case 149:
				return '•';
			case 150:
				return '–';
			case 151:
				return '—';
			case 152:
				return '\u02dc';
			case 153:
				return '™';
			case 154:
				return 'š';
			case 155:
				return '›';
			case 156:
				return 'œ';
			case 158:
				return 'ž';
			case 159:
				return 'Ÿ';
			default:
				return (char)iValue;
			}
		}

		private bool LoadText(OleStorage storage, out string text)
		{
			text = string.Empty;
			if (storage == null)
			{
				return false;
			}
			BinaryReader documentStreamReader = GetDocumentStreamReader(storage);
			if (documentStreamReader == null)
			{
				return false;
			}
			GetDataFromFib(documentStreamReader, out string tableName, out int pdcOffset, out uint pdcLength);
			BinaryReader tableStreamReader = GetTableStreamReader(storage, tableName);
			if (tableStreamReader == null)
			{
				return false;
			}
			PieceDescriptorCollection pieceDescriptors = GetPieceDescriptors(tableStreamReader, pdcOffset, pdcLength);
			if (pieceDescriptors == null)
			{
				return false;
			}
			int count = pieceDescriptors.Count;
			for (int i = 0; i < count; i++)
			{
				uint start;
				uint end;
				bool pieceFileBounds = pieceDescriptors.GetPieceFileBounds(i, out start, out end);
				documentStreamReader.BaseStream.Seek(start, SeekOrigin.Begin);
				text += ReadString(documentStreamReader, end - start, pieceFileBounds);
			}
			return true;
		}

		private bool LoadText(out string text)
		{
			text = string.Empty;
			if (NativeMethods.StgIsStorageFile(_Path) != 0)
			{
				return false;
			}
			OleStorage oleStorage = OleStorage.CreateInstance(_Path);
			try
			{
				return LoadText(oleStorage, out text);
			}
			finally
			{
				oleStorage.Close();
			}
		}

		public string ExtractText()
		{
			string text = null;
			if (!LoadText(out text))
			{
				return text;
			}
			return text;
		}
	}
}
