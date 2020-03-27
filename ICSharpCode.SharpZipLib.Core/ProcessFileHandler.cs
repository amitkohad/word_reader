using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public delegate void ProcessFileHandler(object sender, ScanEventArgs e);
}
