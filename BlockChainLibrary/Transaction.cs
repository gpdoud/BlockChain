using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainLibrary {
	class Transaction {

		public string TxId { get; set; } // transaction id
		public string Version { get; set; } // transaction version number
		public IDictionary<int, TransactionDetail> Input { get; set; } // transaction output
		public IDictionary<int, TransactionDetail> Output { get; set; } // transaction output

		public Transaction() {
			Input = new Dictionary<int, TransactionDetail>();
			Output = new Dictionary<int, TransactionDetail>();
		}
	}
}
