using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public interface IScanFilter
	{
		bool IsMatch(string name);
	}
}
