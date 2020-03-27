using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public delegate void ProgressHandler(object sender, ProgressEventArgs e);
}
