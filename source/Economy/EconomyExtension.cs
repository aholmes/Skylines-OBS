using System;
using System.Collections.Generic;
using System.Text;
using CitiesStats.Config;
using ICities;

namespace CitiesStats.Economy
{
	public class EconomyExtension : EconomyExtensionBase
	{
		private string dataPath
		{
			get
			{
				return ConfigurationProvider<CitiesStatsConfig>.Instance.Configuration.DataFileDirectory;
			}
		}

		public override long OnUpdateMoneyAmount(long internalMoneyAmount)
		{
			System.IO.File.WriteAllText(System.IO.Path.Combine(dataPath, "currentMoneyAmount"), (internalMoneyAmount / 100M).ToString("#,#.00#"));
			return base.OnUpdateMoneyAmount(internalMoneyAmount);
		}

		//public override int OnFetchResource(EconomyResource resource, int amount, Service service, SubService subService, Level level)
		//{
		//	System.IO.File.WriteAllText(System.IO.Path.Combine(dataPath, resource.ToString()), (amount / 100M).ToString("#,#.00#"));
		//	return base.OnFetchResource(resource, amount, service, subService, level);
		//}
	}
}
