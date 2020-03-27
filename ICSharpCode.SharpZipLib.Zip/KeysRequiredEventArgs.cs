using System;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public class KeysRequiredEventArgs : EventArgs
	{
		private string fileName;

		private byte[] key;

		public string FileName => fileName;

		public byte[] Key
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
			}
		}

		public KeysRequiredEventArgs(string name)
		{
			fileName = name;
		}

		public KeysRequiredEventArgs(string name, byte[] keyValue)
		{
			fileName = name;
			key = keyValue;
		}
	}
}
