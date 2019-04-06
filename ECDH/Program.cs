using System;
using System.Numerics;

namespace ECDH
{
	class Program
	{
		static void Main(string[] args)
		{
			var alice = new Alice();
			var bob = new Bob();
			alice.SendG(bob);
			alice.SendH(bob);
			bob.SendH(alice);
		}
	}
}
