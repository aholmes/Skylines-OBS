using ICities;

namespace LiveTwitchMod
{
	public class LiveTwitchMod : EconomyExtensionBase, IUserMod
	{
		public string Name
		{
			get
			{
				return "Some Name";
			}
		}

		public string Description
		{
			get
			{
				return "This is the awesome description!";
			}
		}

		public override long OnUpdateMoneyAmount(long internalMoneyAmount)
		{
			System.IO.File.WriteAllText(@"C:\Users\Aaron\skylinesmod\currentMoneyAmount", (internalMoneyAmount / 100M).ToString("#,#.00#"));
			return base.OnUpdateMoneyAmount(internalMoneyAmount);
		}
	}
}