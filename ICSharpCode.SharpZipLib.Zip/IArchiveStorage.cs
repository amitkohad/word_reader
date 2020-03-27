using System.IO;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public interface IArchiveStorage
	{
		FileUpdateMode UpdateMode
		{
			get;
		}

		Stream GetTemporaryOutput();

		Stream ConvertTemporaryToFinal();

		Stream MakeTemporaryCopy(Stream stream);

		Stream OpenForDirectUpdate(Stream stream);

		void Dispose();
	}
}
