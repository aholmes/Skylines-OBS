using ICities;
using System;
using System.Linq;

namespace CitiesStats
{
	public class UserMod : IUserMod
	{
		public string Name
		{
			get
			{
				return "Cities Stats";
			}
		}

		public string Description
		{
			get
			{
				return "Dump game stats to text files.";
			}
		}

		public void OnSettingUI(UIHelperBase helper)
		{
			var cultures = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.InstalledWin32Cultures);
			var currentCulture = new[] { System.Globalization.CultureInfo.CurrentCulture };
			var cultureDisplayNames = currentCulture.Concat(cultures.Except(currentCulture))
				.Select(o => o.Name + " - " + o.NativeName + " / " + o.EnglishName)
				.ToArray();

			var group = helper.AddGroup("User settings");
			group.AddDropdown("Culture / Language", cultureDisplayNames, 0, index => System.Diagnostics.Debug.WriteLine(index));
		}
	}
}