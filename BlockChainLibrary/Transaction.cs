﻿using System;
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
		public decimal TxFee { get; private set; } // transaction fee

		private TransactionDetail GetOutputTransactionDetailForAddress(string Address, decimal Amount) {
			return new TransactionDetail();
		}
		public void AddSimpleTransaction(string InAddress, string OutAddress, decimal OutAmount, decimal TxFee) {
			var TxDetOut = GetOutputTransactionDetailForAddress(InAddress, OutAmount);
			AddInputTransaction(InAddress, TxDetOut.Amount + TxFee);
			AddOutputTransaction(OutAddress, OutAmount);
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