using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.GZip
{
	[Serializable]
	[ComVisible(false)]
	public class GZipException : SharpZipBaseException
	{
		protected GZipException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public GZipException()
		{
		}

		public GZipException(string message)
			: base(message)
		{
		}

		public GZipException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
