using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.BZip2
{
	[Serializable]
	[ComVisible(false)]
	public class BZip2Exception : SharpZipBaseException
	{
		protected BZip2Exception(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public BZip2Exception()
		{
		}

		public BZip2Exception(string message)
			: base(message)
		{
		}

		public BZip2Exception(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}
