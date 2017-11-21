using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainLibrary {
	public class Transactions : List<Transaction> {

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			foreach (var tx in this) {
				sb.Append($"Tx: {tx.ToString()}\n");
			}
			return sb.ToString();
		}
		public Transactions() : base() {

		}
	}
}
