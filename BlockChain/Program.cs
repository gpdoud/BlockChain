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

			Console.WriteLine($"Start {DateTime.Now}");
			BlockChain reg = new BlockChain();
			reg.CreateBlock(new AccountRegisterData(0, 1000, 1000));
			reg.CreateBlock(new AccountRegisterData(1000, -100, 900));
			reg.CreateBlock(new AccountRegisterData(900, 500, 1400));
			Console.WriteLine($"End {DateTime.Now}");
			//reg.PrintBlockChain();
			//reg.ValidateBlockChain();
			reg.Serialize();
			reg.Dispose();

			BlockChain bc = new BlockChain();
			bc.CreateBlock(new AccountRegisterData(1400, -200, 1200));
			bc.PrintBlockChain();
			bc.Dispose();

			Console.Write("Press any key ...");
			Console.ReadKey();
		}
	}
}
