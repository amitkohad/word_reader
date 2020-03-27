using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public delegate void CompletedFileHandler(object sender, ScanEventArgs e);
}
