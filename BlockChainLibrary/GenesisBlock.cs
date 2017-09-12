using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainLibrary {

	public class GenesisBlock : IBlockChainData {

		public const string Genesis = "Genesis: Initial block on the chain.";

		public string ToTextData() {
			return $"{Genesis}";
		}
	}
}
