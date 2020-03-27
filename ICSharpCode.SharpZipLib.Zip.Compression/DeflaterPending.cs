using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	[ComVisible(false)]
	public class DeflaterPending : PendingBuffer
	{
		public DeflaterPending()
			: base(65536)
		{
		}
	}
}
