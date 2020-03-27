using System.IO;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public class DynamicDiskDataSource : IDynamicDataSource
	{
		public Stream GetSource(ZipEntry entry, string name)
		{
			Stream result = null;
			if (name != null)
			{
				result = File.Open(name, FileMode.Open, FileAccess.Read, FileShare.Read);
			}
			return result;
		}
	}
}
