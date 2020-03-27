using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public interface ITaggedData
	{
		short TagID
		{
			get;
		}

		void SetData(byte[] data, int offset, int count);

		byte[] GetData();
	}
}
