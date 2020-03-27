using System.IO;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public class PathFilter : IScanFilter
	{
		private NameFilter nameFilter_;

		public PathFilter(string filter)
		{
			nameFilter_ = new NameFilter(filter);
		}

		public virtual bool IsMatch(string name)
		{
			bool result = false;
			if (name != null)
			{
				string name2 = (name.Length > 0) ? Path.GetFullPath(name) : "";
				result = nameFilter_.IsMatch(name2);
			}
			return result;
		}
	}
}
