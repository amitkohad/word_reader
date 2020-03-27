using System.IO;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public abstract class BaseArchiveStorage : IArchiveStorage
	{
		private FileUpdateMode updateMode_;

		public FileUpdateMode UpdateMode => updateMode_;

		protected BaseArchiveStorage(FileUpdateMode updateMode)
		{
			updateMode_ = updateMode;
		}

		public abstract Stream GetTemporaryOutput();

		public abstract Stream ConvertTemporaryToFinal();

		public abstract Stream MakeTemporaryCopy(Stream stream);

		public abstract Stream OpenForDirectUpdate(Stream stream);

		public abstract void Dispose();
	}
}
