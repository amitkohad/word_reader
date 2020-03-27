using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Tar
{
	[Serializable]
	[ComVisible(false)]
	public class InvalidHeaderException : TarException
	{
		protected InvalidHeaderException(SerializationInfo information, StreamingContext context)
			: base(information, context)
		{
		}

		public InvalidHeaderException()
		{
		}

		public InvalidHeaderException(string message)
			: base(message)
		{
		}

		public InvalidHeaderException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}
