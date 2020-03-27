using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Checksums
{
	[ComVisible(false)]
	public interface IChecksum
	{
		long Value
		{
			get;
		}

		void Reset();

		void Update(int value);

		void Update(byte[] buffer);

		void Update(byte[] buffer, int offset, int count);
	}
}
