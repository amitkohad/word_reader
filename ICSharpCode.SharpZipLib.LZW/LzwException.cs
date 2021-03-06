using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.LZW
{
	[Serializable]
	[ComVisible(false)]
	public class LzwException : SharpZipBaseException
	{
		protected LzwException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public LzwException()
		{
		}

		public LzwException(string message)
			: base(message)
		{
		}

		public LzwException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
