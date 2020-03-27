using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public delegate void ProcessDirectoryHandler(object sender, DirectoryEventArgs e);
}
