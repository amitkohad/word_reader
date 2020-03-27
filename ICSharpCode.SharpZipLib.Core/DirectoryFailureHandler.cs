using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public delegate void DirectoryFailureHandler(object sender, ScanFailureEventArgs e);
}
