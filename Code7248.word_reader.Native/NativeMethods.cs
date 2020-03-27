using System;
using System.Runtime.InteropServices;

namespace Code7248.word_reader.Native
{
	internal class NativeMethods
	{
		private const string Ole32Dll = "ole32.dll";

		private NativeMethods()
		{
		}

		[DllImport("ole32.dll", CharSet = CharSet.Unicode)]
		public static extern int StgOpenStorage(string pwcsName, IStorage pstgPriority, int grfMode, IntPtr snbExclude, int reserved, out IStorage ppstgOpen);

		[DllImport("ole32.dll", CharSet = CharSet.Unicode)]
		public static extern int StgIsStorageFile(string pwcsName);
	}
}
