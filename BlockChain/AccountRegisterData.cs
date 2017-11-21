using BlockChainLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainProgram {

	public class AccountRegisterData {

		public int PrevBalance { get; set; }
		public int Change { get; set; }
		public int NewBalance { get; set; }

		public string ToTextData() {
			return $"PrevBal:{PrevBalance};Chg:{Change};NewBal:{NewBalance}";
		}

		public AccountRegisterData(int prevBalance, int change, int newBalance) {
			PrevBalance = prevBalance;
			Change = change;
			NewBalance = newBalance;
		}
	}
}
