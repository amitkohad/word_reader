using System;
using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Core
{
	[ComVisible(false)]
	public class ScanEventArgs : EventArgs
	{
		private string name_;

		private bool continueRunning_ = true;

		public string Name => name_;

		public bool ContinueRunning
		{
			get
			{
				return continueRunning_;
			}
			set
			{
				continueRunning_ = value;
			}
		}

		public ScanEventArgs(string name)
		{
			name_ = name;
		}
	}
}
