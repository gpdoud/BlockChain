using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain {
	class Program {
		static void Main(string[] args) {
			BlockChain bc = new BlockChain();
			bc.CreateBlock("ABC123");
			bc.CreateBlock("XYZ789");
			bc.CreateBlock("Hello, world!");
			bc.CreateBlock("This is BlockChain in action");
			bc.CreateBlock("Received $200 from X");
			bc.CreateBlock("Paid $100 to Y");
			bc.PrintBlockChain();

			Console.Write("Press any key ...");
			Console.ReadKey();
		}
	}
}
