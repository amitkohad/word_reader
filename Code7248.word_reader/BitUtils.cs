namespace Code7248.word_reader
{
	public class BitUtils
	{
		protected BitUtils()
		{
		}

		public static bool IsSet(ushort target, byte bit)
		{
			return (target & (1 << (int)bit)) > 0;
		}
	}
}
