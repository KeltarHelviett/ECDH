using System.Numerics;

namespace ECDH
{
	public struct Point
	{
		private BigInteger y;
		private BigInteger x;

		public BigInteger X
		{
			get => x;
			set => x = value;
		}

		public BigInteger Y
		{
			get => y;
			set => y = value;
		}

		public Point(BigInteger x, BigInteger y)
		{
			this.y = y;
			this.x = x;
		}

		public static Point operator +(Point lhs, Point rhs) => new Point(lhs.x + rhs.x, lhs.y + rhs.y);

		public static bool operator ==(Point lhs, Point rhs) => lhs.x == rhs.x && lhs.y == rhs.y;

		public static bool operator !=(Point lhs, Point rhs) => !(lhs == rhs);

		public static Point Infinity => new Point(-1, -1);

		public bool IsInfinity => x == -1 && y == -1;
	}
}
