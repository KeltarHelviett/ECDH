using System.Numerics;

namespace ECDH
{
	public interface IEllipticCurve
	{
		Point Add(Point lhs, Point rhs);
		Point Multiply(Point point, BigInteger multiplier);
	}
}
