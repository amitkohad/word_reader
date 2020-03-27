using System.IO;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public interface IDynamicDataSource
	{
		Stream GetSource(ZipEntry entry, string name);
	}
}
