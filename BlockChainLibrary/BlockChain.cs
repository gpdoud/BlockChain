using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainLibrary {

	public class BlockChain {

		public static List<Block> Blocks;

		public void ValidateBlockChain() {
			foreach(var block in Blocks) {
				if(!BlockChainLibrary.Crypto.Sha256.CalcHash(block.ToHashString()).Equals(block.Hash)) {
					Console.WriteLine($"Block {block.Index} is corrupt.");
				}
			}
		}
		public void PrintBlockChain() {
			foreach(var block in Blocks) {
				Console.WriteLine(block.ToString());
			}
		}
		public void CreateBlock(IBlockChainData data) {
			Block block = new Block(data.ToTextData());
			if (GetLastBlock() != null) {
				block.PrevHash = GetLastBlock().Hash;
				block.Index = GetLastBlock().Index + 1;
			}
			do {
				block.Nonce++;
				block.Hash = BlockChainLibrary.Crypto.Sha256.CalcHash(block.ToHashString());
			} while (!BlockChainLibrary.Crypto.Sha256.IsValidHash(block.Hash));
			Blocks.Add(block);
		}

		private Block GetLastBlock() {
			if (Blocks.Count == 0) {
				return null;
			} else {
				return Blocks[Blocks.Count - 1];
			}
		}
		public BlockChain() {
			Blocks = new List<Block>();
			CreateBlock(new GenesisBlock());
		}
	}
}
