using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainLibrary {

	public class BlockChain : IDisposable {

		public static List<Block> Blocks;
		private static string SerializedBlocksFileName = "blockchain.bin";

		public static void GetBlocksContainingAddress(string Address) {
			foreach(var block in  Blocks) {

			}
		}
		public void Serialize() {
			var BlocksSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(Blocks);
			var path = System.IO.Directory.GetCurrentDirectory();
			var outputPath = System.IO.Path.Combine(path, SerializedBlocksFileName);
			System.IO.File.WriteAllText(outputPath, BlocksSerialized);
		}
		public void Deserialize() {
			var path = System.IO.Directory.GetCurrentDirectory();
			var inputPath = System.IO.Path.Combine(path, SerializedBlocksFileName);
			var BlocksSerialized = System.IO.File.ReadAllText(inputPath);
			Blocks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Block>>(BlocksSerialized);
		}

		public (bool, string) ValidateBlockChain() {
			bool rc = true;
			string msg = "Validated";
			foreach (var block in Blocks) {
				if(!BlockChainLibrary.Crypto.Sha256.CalcHash(block.ToHashString()).Equals(block.Hash)) {
					rc = false;
					msg = $"Block index {block.Index} is corrupt.";
					break;
				}
			}
			return (rc, msg);
		}
		public void PrintBlockChain() {
			foreach(var block in Blocks) {
				Console.WriteLine(block.ToString());
			}
		}
		public void CreateBlock(Transactions data) {
			Block block = new Block(data);
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
		private void InitializeBlocks() {
			Blocks = new List<Block>();
			CreateBlock(GenesisBlock.GetGenesisBlockData());
		}
		private Block GetLastBlock() {
			if (Blocks.Count == 0) {
				return null;
			} else {
				return Blocks[Blocks.Count - 1];
			}
		}
		public BlockChain() {
			var path = System.IO.Directory.GetCurrentDirectory();
			var inputPath = System.IO.Path.Combine(path, SerializedBlocksFileName);
			if (System.IO.File.Exists(inputPath)) {
				Deserialize();
			} else {
				InitializeBlocks();
			}
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing) {
			if (!disposedValue) {
				if (disposing) {
					// dispose managed state (managed objects).
					Serialize();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~BlockChain() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose() {
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
