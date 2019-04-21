using System.Linq;
using ICities;
//using System;
using System.IO;

namespace CitiesStats
{
	public class CitiesStats : IUserMod
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

		public void OnEnabled()
		{
			System.Diagnostics.Debug.WriteLine(Directory.GetCurrentDirectory());
//			var config = new ConfigurationBuilder()
		}

		public void OnSettingUI(UIHelperBase helper)
		{
			var cultures = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.InstalledWin32Cultures);
			var currentCulture = new[] { System.Globalization.CultureInfo.CurrentCulture };
			var cultureDisplayNames = currentCulture.Concat(cultures.Except(currentCulture))
				.Select(o => o.Name + " - " + o.NativeName + " / " + o.EnglishName)
				.ToArray();

			var userSettings = helper.AddGroup("User Settings");
			userSettings.AddDropdown("Culture / Language", cultureDisplayNames, 0, index => System.Diagnostics.Debug.WriteLine(index));

			var modSettings = helper.AddGroup("Mod Settings");
			modSettings.AddTextfield("File Directory", string.Empty, changedText => { }, textSubmitted => { });
		}
	}
}