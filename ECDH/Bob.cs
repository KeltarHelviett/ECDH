using System;
using System.Numerics;

namespace ECDH
{
	public class Bob
	{
		private IEllipticCurve ellipticCurve;
		private readonly BigInteger d;
		private Point s;

		public Point G;
		public Point H;

		public Bob()
		{
			ellipticCurve = new Curve25519();
			d = Utilities.RandomIntegerInRange(0,
				BigInteger.Parse("7237005577332262213973186563042994240857116359379907606001950938285454250989"));
		}

		public void CalculateS(Point h)
		{
			H = ellipticCurve.Multiply(G, d);
			s = ellipticCurve.Multiply(h, d);
			Console.WriteLine($"{s.X} {s.Y}");
		}

		public void SendH(Alice alice)
		{
			alice.CalculateS(H);
		}
	}
}
