using System.Runtime.InteropServices;

namespace Code7248.word_reader.Native
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("0000000d-0000-0000-c000-000000000046")]
	internal interface IEnumSTATSTG
	{
		int Next(uint celt, out STATSTG rgelt, out uint pceltFetched);

		int RemoteNext(uint celt, out STATSTG rgelt, out uint pceltFetched);

		int Skip(uint celt);

		int Reset();

		int Clone(out IEnumSTATSTG ppenum);
	}
}
