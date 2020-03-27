using System;

namespace Code7248.word_reader.Native
{
	internal class tagRemSNB
	{
		public uint ulCntStr;

		public uint ulCntChar;

		public IntPtr rgString;

		public tagRemSNB(IntPtr rgString, uint ulCntStr, uint ulCntChar)
		{
			this.rgString = rgString;
			this.ulCntStr = ulCntStr;
			this.ulCntChar = ulCntChar;
		}
	}
}
