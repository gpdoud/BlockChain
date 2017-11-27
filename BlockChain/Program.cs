using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BlockChainLibrary;

namespace BlockChainProgram {
	class Program {
		void run() { 

			Console.WriteLine($"Start {DateTime.Now}");
			BlockChain reg = new BlockChain();
			// create the transaction
			Transaction t0 = new Transaction();
			t0.Ver = "1.0";
			t0.TxIdIn = "-1";
			// create simple transaction detail
			t0.AddInputTransaction("Joe", 1.0005m);
			t0.AddOutputTransaction("Alice", 1.0m);
			// Alice pays 0.0150 to Bob
			Transaction t1 = new Transaction();
			t1.AddSimpleTransaction("Alice", "Bob", 0.015m);
			Transaction t2 = new Transaction();
			t2.AddSimpleTransaction("Bob", "Gopesh", 0.01m);
			Transactions txs = new Transactions();
			txs.AddRange(new Transaction[] { t0, t1, t2 });
			reg.CreateBlock(txs);
			reg.PrintBlockChain();
			reg.Serialize();
			reg.Dispose();

			Console.Write("Press any key ...");
			Console.ReadKey();
		}
		static void Main(string[] args) {
			new Program().run();
		}
	}
}
