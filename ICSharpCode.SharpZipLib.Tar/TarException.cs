using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Tar
{
	[Serializable]
	[ComVisible(false)]
	public class TarException : SharpZipBaseException
	{
		protected TarException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public TarException()
		{
		}

		public TarException(string message)
			: base(message)
		{
		}

		public TarException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}
