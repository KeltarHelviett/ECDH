using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace ECDH
{
	// By^2 = x^3 + Ax^2 + x
	public class MontgomeryEllipticCurve : IEllipticCurve
	{
		public BigInteger B { get; }
		public BigInteger A { get; }
		public BigInteger P { get; }

		public MontgomeryEllipticCurve(BigInteger a, BigInteger b, BigInteger p)
		{
			B = b;
			A = a;
			P = p;
		}

		public Point Add(Point lhs, Point rhs)
		{
			if (lhs.IsInfinity || rhs.IsInfinity) {
				return lhs.IsInfinity ? rhs : lhs;
			}
			BigInteger x, y;
			if (lhs == rhs) {
				var l = ((3 * lhs.X.Sqr() + 2 * A * lhs.X + 1).EuclideanMod(P) * (2 * B * lhs.Y).ModInverse(P)).EuclideanMod(P);
				x = (B * l.Sqr() - A - 2 * lhs.X).ModInverse(P);
				y = ((2 * lhs.X + lhs.X + A) * l - B * BigInteger.ModPow(l, 3, P) - lhs.Y).ModInverse(P);
				return new Point(x, y);
			}
			if (lhs.X == rhs.X) {
				return  Point.Infinity;
			}
			x = (B * (rhs.X * lhs.Y - lhs.X * rhs.Y).Sqr()).EuclideanMod(P);
			var denominator = rhs.X - lhs.X;
			var inverse = denominator.ModInverse(P, true);
			x = (x * (lhs.X * rhs.X * denominator.Sqr()).ModInverse(P, true)).EuclideanMod(P);
			y = ((2 * lhs.X + rhs.X + A) * (rhs.Y - lhs.Y)).EuclideanMod(P);
			y = (y * inverse).EuclideanMod(P);
			y = y - B * BigInteger.ModPow(((rhs.Y - lhs.Y) * inverse), 3, P) - lhs.Y;
			return new Point(x, y.EuclideanMod(P));
		}
	}
}
