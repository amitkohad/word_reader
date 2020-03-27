using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Zip
{
	[Serializable]
	[ComVisible(false)]
	public class ZipException : SharpZipBaseException
	{
		protected ZipException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public ZipException()
		{
		}

		public ZipException(string message)
			: base(message)
		{
		}

		public ZipException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}
