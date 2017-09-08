using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainLibrary.Crypto {

	public static class Sha256 {

		public static string CalcHash(string message) {
			SHA256 sham256 = SHA256Managed.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(message);
			byte[] hashedBytes = sham256.ComputeHash(bytes);
			StringBuilder sb = new StringBuilder();
			foreach (var b in hashedBytes) {
				sb.Append(b.ToString("x2"));
			}
			return sb.ToString();
		}
		public static bool IsValidHash(string Hash, int Difficulty = 4) {
			var hashPrefix = "0000000000".Substring(0, Difficulty);
			return Hash.StartsWith(hashPrefix);
		}
	}
}
