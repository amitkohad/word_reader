using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	[Serializable]
	[ComVisible(false)]
	public class SharpZipBaseException : ApplicationException
	{
		protected SharpZipBaseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public SharpZipBaseException()
		{
		}

		public SharpZipBaseException(string message)
			: base(message)
		{
		}

		public SharpZipBaseException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
