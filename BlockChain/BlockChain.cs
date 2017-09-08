using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain {
	class BlockChain {
		public static List<Block> Blocks;

		public void PrintBlockChain() {
			foreach(var block in Blocks) {
				Console.WriteLine(block.ToString());
			}
		}
		public void CreateBlock(string message) {
			Block block = new Block(message);
			if (GetLastBlock() != null) {
				block.PrevHash = GetLastBlock().Hash;
				block.Index = GetLastBlock().Index + 1;
			}
			do {
				block.Nonce++;
				block.Hash = Block.CalcSHA245Hash(block.ToHashString());
			} while (!IsValidHash(block.Hash));
			Blocks.Add(block);
		}
		private bool IsValidHash(string Hash, int Difficulty = 4) {
			var hashPrefix = "0000000000".Substring(0, Difficulty);
			return Hash.StartsWith(hashPrefix);
		}
		public static Block GetLastBlock() {
			if (Blocks.Count == 0) {
				return null;
			} else {
				return Blocks[Blocks.Count - 1];
			}
		}
		public BlockChain() {
			Blocks = new List<Block>();
			CreateBlock("Genesis");
		}
	}
}
