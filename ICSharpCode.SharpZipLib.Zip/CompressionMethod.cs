using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public enum CompressionMethod
	{
		Stored = 0,
		Deflated = 8,
		Deflate64 = 9,
		BZip2 = 11,
		WinZipAES = 99
	}
}
