﻿using System;
using System.Drawing;
using System.Numerics;

namespace ECDH
{
	class EllipticCurve
	{
		public BigInteger A { get; }
		public BigInteger B { get; }
		public BigInteger P { get; }

		public EllipticCurve(BigInteger a, BigInteger b, BigInteger p)
		{
			if ((4 * BigInteger.ModPow(a, 3, p) + 27 * BigInteger.ModPow(b, 2, p)) % p == 0) {
				throw new ArgumentException("Elliptic curve with singularity");
			}
			A = a;
			B = b;
			P = p;
		}

		public Point Add(Point lhs, Point rhs)
		{
			if (lhs.IsInfinity || rhs.IsInfinity) {
				return lhs.IsInfinity ? rhs : lhs;
			} 
		    var m = lhs == rhs ? (3 * lhs.X.Sqr() + A) * (2 * lhs.Y).ModInverse(P, true) :
				(lhs.Y - rhs.Y) * (lhs.X - rhs.X).ModInverse(P, true);
			m = m.EuclideanMod(P);
			if (m == 0) {
				return Point.Infinity;
			}
			var x = (BigInteger.ModPow(m, 2, P) - lhs.X - rhs.X).EuclideanMod(P);
			return new Point(x, (-((lhs.Y + m * (x - lhs.X)) % P)).EuclideanMod(P));
		}
	}
}
