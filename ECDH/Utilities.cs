using System.Numerics;
using System.Security.Cryptography;

namespace ECDH
{
	public static class Utilities
	{
		private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

		public static BigInteger RandomIntegerInRange(BigInteger lower, BigInteger upper)
		{
			var bytes = upper.ToByteArray();
			BigInteger res;
			do {
				Rng.GetBytes(bytes);
				bytes[bytes.Length - 1] &= 0x7F;
				res = new BigInteger(bytes);
			} while (res >= upper || res <= lower);

			return res;
		}
	}
}
