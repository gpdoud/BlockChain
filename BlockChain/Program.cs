using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BlockChainLibrary;

namespace BlockChainProgram {
	class Program {
		static void Main(string[] args) {
			BlockChain bc = new BlockChain();
			bc.CreateBlock(new BlockData("ABC123"));
			bc.CreateBlock(new BlockData("XYZ789"));
			bc.CreateBlock(new BlockData("Hello, world!"));
			bc.CreateBlock(new BlockData("This is BlockChain in action"));
			bc.CreateBlock(new BlockData("Received $200 from X"));
			bc.CreateBlock(new BlockData("Paid $100 to Y"));
			bc.PrintBlockChain();
			bc.ValidateBlockChain();

			BlockChain reg = new BlockChain();
			reg.CreateBlock(new AccountRegisterData(0, 1000, 1000));
			reg.PrintBlockChain();

			Console.Write("Press any key ...");
			Console.ReadKey();
		}
	}
}
