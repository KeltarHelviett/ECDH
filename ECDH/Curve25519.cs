using System.Numerics;

namespace ECDH
{
	public class Curve25519 : MontgomeryEllipticCurve
	{
		public Curve25519(BigInteger a, BigInteger b, BigInteger p) : 
			base(486662, 1, BigInteger.Parse("57896044618658097711785492504343953926634992332820282019728792003956564819949"))
		{

		}

		public Curve25519() : base(486662, 1, BigInteger.Parse("57896044618658097711785492504343953926634992332820282019728792003956564819949"))
		{

		}
	}
}
