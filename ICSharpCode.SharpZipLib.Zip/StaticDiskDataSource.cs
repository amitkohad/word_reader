using System.IO;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public class StaticDiskDataSource : IStaticDataSource
	{
		private string fileName_;

		public StaticDiskDataSource(string fileName)
		{
			fileName_ = fileName;
		}

		public Stream GetSource()
		{
			return File.Open(fileName_, FileMode.Open, FileAccess.Read, FileShare.Read);
		}
	}
}
