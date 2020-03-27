using System.Collections;
using System.IO;

namespace Code7248.word_reader
{
	internal class FileOffsetCollection : CollectionBase
	{
		public FileOffset this[int index]
		{
			get
			{
				return (FileOffset)base.InnerList[index];
			}
			set
			{
				base.InnerList[index] = value;
			}
		}

		public int Add(FileOffset offset)
		{
			return base.InnerList.Add(offset);
		}

		public int Add(uint offset)
		{
			return Add(new FileOffset(offset));
		}

		public void AddRange(FileOffsetCollection offsets)
		{
			base.InnerList.AddRange(offsets);
		}

		public void Remove(FileOffset offset)
		{
			base.InnerList.Remove(offset);
		}

		public void Read(BinaryReader reader, int count)
		{
			if (reader != null)
			{
				Clear();
				for (int i = 0; i < count; i++)
				{
					FileOffset fileOffset = new FileOffset();
					fileOffset.Read(reader);
					Add(fileOffset);
				}
			}
		}

		public void Write(BinaryWriter writer)
		{
			if (writer != null)
			{
				int count = base.Count;
				for (int i = 0; i < count; i++)
				{
					this[i].Write(writer);
				}
			}
		}
	}
}
