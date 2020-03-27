using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public delegate void ZipTestResultHandler(TestStatus status, string message);
}
