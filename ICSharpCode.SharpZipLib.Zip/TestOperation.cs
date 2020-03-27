using System.Runtime.InteropServices;

namespace ICSharpCode.SharpZipLib.Zip
{
	[ComVisible(false)]
	public enum TestOperation
	{
		Initialising,
		EntryHeader,
		EntryData,
		EntryComplete,
		MiscellaneousTests,
		Complete
	}
}
