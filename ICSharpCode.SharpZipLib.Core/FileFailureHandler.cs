using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public delegate void FileFailureHandler(object sender, ScanFailureEventArgs e);
}
