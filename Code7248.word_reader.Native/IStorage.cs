using System;
using System.Runtime.InteropServices;

namespace Code7248.word_reader.Native
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComConversionLoss]
	[Guid("0000000b-0000-0000-c000-000000000046")]
	internal interface IStorage
	{
		int CreateStream(string pwcsName, int grfMode, int reserved1, int reserved2, out UCOMIStream ppstm);

		int OpenStream(string pwcsName, IntPtr reserved1, int grfMode, int reserved2, out UCOMIStream ppstm);

		int CreateStorage(string pwcsName, int grfMode, int reserved1, int reserved2, out IStorage ppstg);

		int OpenStorage(string pwcsName, IStorage pstgPriority, int grfMode, tagRemSNB snbExclude, int reserved, out IStorage ppstg);

		int CopyTo(int ciidExclude, ref Guid rgiidExclude, ref tagRemSNB snbExclude, IStorage pstgDest);

		int MoveElementTo(string pwcsName, IStorage pstgDest, string pwcsNewName, int grfFlags);

		int Commit(int grfCommitFlags);

		int Revert();

		int EnumElements(int reserved1, IntPtr reserved2, int reserved3, out IEnumSTATSTG ppenum);

		int DestroyElement(string pwcsName);

		int RenameElement(string pwcsOldName, string pwcsNewName);

		int SetElementTimes(string pwcsName, ref FILETIME pctime, ref FILETIME patime, ref FILETIME pmtime);

		int SetClass(ref Guid clsid);

		int SetStateBits(int grfStateBits, int grfMask);

		int Stat(out STATSTG pstatstg, int grfStatFlag);
	}
}
