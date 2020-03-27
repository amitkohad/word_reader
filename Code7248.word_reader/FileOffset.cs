using System.IO;

namespace Code7248.word_reader
{
	internal class FileOffset
	{
		public static readonly int Size = 4;

		private static readonly uint UnicodeMask = 1073741824u;

		private uint value;

		public uint Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}

		public FileOffset()
			: this(0u)
		{
		}

		public FileOffset(uint value)
		{
			this.value = value;
		}

		public void Read(BinaryReader reader)
		{
			value = reader.ReadUInt32();
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(value);
		}

		public static bool IsUnicode(uint fc)
		{
			return (fc & UnicodeMask) == 0;
		}

		public static uint NormalizeFc(uint fc)
		{
			if ((fc & UnicodeMask) == 0)
			{
				return fc;
			}
			return (fc & ~UnicodeMask) / 2u;
		}

		public static uint GetFcDelta(bool isUnicode)
		{
			return (!isUnicode) ? 1u : 2u;
		}
	}
}
