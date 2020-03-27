using ICSharpCode.SharpZipLib.Core;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public interface IEntryFactory
	{
		INameTransform NameTransform
		{
			get;
			set;
		}

		ZipEntry MakeFileEntry(string fileName);

		ZipEntry MakeFileEntry(string fileName, bool useFileSystem);

		ZipEntry MakeDirectoryEntry(string directoryName);

		ZipEntry MakeDirectoryEntry(string directoryName, bool useFileSystem);
	}
}
