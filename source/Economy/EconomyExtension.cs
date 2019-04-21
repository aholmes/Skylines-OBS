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

		public override int OnFetchResource(EconomyResource resource, int amount, Service service, SubService subService, Level level)
		{
			System.IO.File.WriteAllText(@"C:\Users\Aaron\skylinesmod\" + resource.ToString(), (amount / 100M).ToString("#,#.00#"));
			return base.OnFetchResource(resource, amount, service, subService, level);
		}
	}
}
