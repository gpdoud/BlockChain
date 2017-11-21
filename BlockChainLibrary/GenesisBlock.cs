using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainLibrary {

	public class GenesisBlock{

		public const string Genesis = "Genesis: Initial block on the chain.";

		public static Transactions GetGenesisBlockData() {
			Transactions txs = new Transactions();
			Transaction txout = new Transaction();
			txout.AddOutputTransaction("Greg", 100.0m);
			txs.Add(txout);
			return txs;
		}

	}
}
