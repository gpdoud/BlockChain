using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainLibrary {
	public class Transaction {

		public string TxId { get; set; } // transaction id
		public string Ver { get; set; } // transaction version number
		public string TxIdIn { get; set; } // transaction providing output for this transaction input
		private IList<TransactionDetail> Input { get; set; } // transaction output
		private IList<TransactionDetail> Output { get; set; } // transaction output
		public decimal TxFee { get; private set; } = 0.0005m; // transaction fee

		/// <summary>
		/// Retrieves and output amount >= Amount from Address
		/// </summary>
		/// <param name="Address"></param>
		/// <param name="Amount"></param>
		/// <returns></returns>
		private TransactionDetail GetOutputTransactionDetailForAddress(string Address, decimal Amount) {
			List<TransactionDetail> AddressTrans = new List<TransactionDetail>();
			Blocks blocks = BlockChain.Blocks;
			foreach(var block in blocks) {
				foreach(var transaction in block.Data) {
					foreach(var outputTrans in transaction.Output) {
						if(outputTrans.Address.ToLower().Equals(Address.ToLower())) {
							AddressTrans.Add(outputTrans);
						}
					}
				}
			}
			return new TransactionDetail();
		}
		public void AddSimpleTransaction(string InAddress, string OutAddress, decimal Amount) {
			var TxDetOut = GetOutputTransactionDetailForAddress(InAddress, Amount);
			AddInputTransaction(InAddress, TxDetOut.Amount + TxFee);
			AddOutputTransaction(OutAddress, Amount);
			if(TxDetOut.Amount > Amount) {
				AddOutputTransaction(InAddress, TxDetOut.Amount - Amount - TxFee);
			}
		}

		public void AddInputTransaction(string Address, decimal Amount) {
			AddTransaction(Address, Amount, Input);
		}

		public void AddOutputTransaction(string Address, decimal Amount) {
			AddTransaction(Address, Amount, Output);
		}

		private void AddTransaction(string Address, decimal Amount, IList<TransactionDetail> InOut) {
			InOut.Add(new TransactionDetail {
				Address = Address,
				Amount = Amount,
				Index = InOut.Count // count is the next index
			});
			CalcTxFee();
		}

		private void CalcTxFee() {
			var sumInputs = Input.Sum(t => t.Amount);
			var sumOutputs = Output.Sum(t => t.Amount);
			TxFee = sumInputs - sumOutputs;
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.Append($"Txid: {TxId}\n");
			sb.Append($"Ver : {Ver}\n");
			sb.Append($"TxIdIn: {TxIdIn}\n");
			var maxlen = (Input.Count < Output.Count) ? Output.Count : Input.Count;
			for (var idx = 0; idx < maxlen; idx++) {
				// print input
				var str = string.Empty;
				if (idx < Input.Count) {
					str += ($"\tInput #{Input[idx].Index} {Input[idx].Address} {Input[idx].Amount} ");
				}
				if (idx < Output.Count) {
					str += ($"\tOutput #{Output[idx].Index} {Output[idx].Address} {Output[idx].Amount} ");
				}
				sb.Append(str);
			}
		
			return sb.ToString();
		}

		public Transaction() {
			Ver = "1.0";
			TxIdIn = null;
			Input = new List<TransactionDetail>();
			Output = new List<TransactionDetail>();
			TxFee = 0.0m;
		}
	}
}
