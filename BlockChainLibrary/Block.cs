using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainLibrary {

	public class Block {

		public string PrevHash { get; set; }
		public int Index { get; set; }
		public DateTime Timestamp { get; set; }
		public Transactions Data { get; set; }
		public string Hash { get; set; }
		public int Nonce { get; set; }

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.Append(string.Format("PHash: {0}\n", PrevHash));
			sb.Append(String.Format("Trans: {0}\n", Data.ToString()));
			sb.Append(String.Format("Index: {0}\n", Index));
			sb.Append(String.Format("Stamp: {0}\n", Timestamp));
			sb.Append(String.Format("Nonce: {0}\n", Nonce));
			sb.Append(string.Format("Hash : {0}\n", Hash));
			sb.Append("+----------------------------------------------------------------------+");
			return sb.ToString();
		}
		public Block(Transactions data) {
			this.PrevHash = "0";
			this.Index = 0;
			this.Timestamp = DateTime.Now;
			this.Data = data;
			this.Hash = "0";
			this.Nonce = 0;
		}
		public string ToHashString() {
			return $"{Index}{PrevHash}{Timestamp}{Data}{Nonce}";
		}
	}
}
