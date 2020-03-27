using System.IO;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public interface IStaticDataSource
	{
		Stream GetSource();
	}
}
