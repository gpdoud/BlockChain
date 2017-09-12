using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockChainLibrary;

namespace BlockChainProgram {

	public class BlockData : IBlockChainData {

		public string message { get; set; }

		public string ToTextData() {
			return $"{message}";
		}

		public BlockData(string message) {
			this.message = message;
		}
	}
}
