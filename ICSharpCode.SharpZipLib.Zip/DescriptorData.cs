using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public class DescriptorData
	{
		private long size;

		private long compressedSize;

		private long crc;

		public long CompressedSize
		{
			get
			{
				return compressedSize;
			}
			set
			{
				compressedSize = value;
			}
		}

		public long Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
			}
		}

		public long Crc
		{
			get
			{
				return crc;
			}
			set
			{
				crc = (value & uint.MaxValue);
			}
		}
	}
}
