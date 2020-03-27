using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public interface INameTransform
	{
		string TransformFile(string name);

		string TransformDirectory(string name);
	}
}
