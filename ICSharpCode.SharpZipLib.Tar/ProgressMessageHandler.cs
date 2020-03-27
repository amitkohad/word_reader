using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Tar
{
	[ComVisible(false)]
	public delegate void ProgressMessageHandler(TarArchive archive, TarEntry entry, string message);
}
