using ICSharpCode.SharpZipLib.Checksums;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	[ComVisible(false)]
	public abstract class PkzipClassic : SymmetricAlgorithm
	{
		public static byte[] GenerateKeys(byte[] seed)
		{
			if (seed == null)
			{
				throw new ArgumentNullException("seed");
			}
			if (seed.Length == 0)
			{
				throw new ArgumentException("Length is zero", "seed");
			}
			uint[] array = new uint[3]
			{
				305419896u,
				591751049u,
				878082192u
			};
			for (int i = 0; i < seed.Length; i++)
			{
				array[0] = Crc32.ComputeCrc32(array[0], seed[i]);
				array[1] = array[1] + (byte)array[0];
				array[1] = array[1] * 134775813 + 1;
				array[2] = Crc32.ComputeCrc32(array[2], (byte)(array[1] >> 24));
			}
			return new byte[12]
			{
				(byte)(array[0] & 0xFF),
				(byte)((array[0] >> 8) & 0xFF),
				(byte)((array[0] >> 16) & 0xFF),
				(byte)((array[0] >> 24) & 0xFF),
				(byte)(array[1] & 0xFF),
				(byte)((array[1] >> 8) & 0xFF),
				(byte)((array[1] >> 16) & 0xFF),
				(byte)((array[1] >> 24) & 0xFF),
				(byte)(array[2] & 0xFF),
				(byte)((array[2] >> 8) & 0xFF),
				(byte)((array[2] >> 16) & 0xFF),
				(byte)((array[2] >> 24) & 0xFF)
			};
		}
	}
}
