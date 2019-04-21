using System;
using System.Collections.Generic;
using System.Text;
using ICities;

namespace CitiesStats.Economy
{
	public class EconomyExtension : EconomyExtensionBase
	{
		public override long OnUpdateMoneyAmount(long internalMoneyAmount)
		{
			System.IO.File.WriteAllText(@"C:\Users\Aaron\skylinesmod\currentMoneyAmount", (internalMoneyAmount / 100M).ToString("#,#.00#"));
			return base.OnUpdateMoneyAmount(internalMoneyAmount);
		}
	}
}
