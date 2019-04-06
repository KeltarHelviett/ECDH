using System;
using System.Numerics;

namespace ECDH
{
	public class Alice
	{
		private IEllipticCurve ellipticCurve;
		private BigInteger d;
		private Point s;

		public Point G;
		public Point H;
		

		public Alice()
		{
			ellipticCurve = new Curve25519();
			G = Curve25519.BasePoint;
			d = Utilities.RandomIntegerInRange(0,
				BigInteger.Parse("7237005577332262213973186563042994240857116359379907606001950938285454250989"));
			H = ellipticCurve.Multiply(G, d);
		}

		public void SendG(Bob bob)
		{
			bob.G = G;
		}

		public void SendH(Bob bob)
		{
			bob.CalculateS(H);
		}

		public void CalculateS(Point h)
		{
			s = ellipticCurve.Multiply(h, d);
			Console.WriteLine($"{s.X} {s.Y}");
		}
	}
}
