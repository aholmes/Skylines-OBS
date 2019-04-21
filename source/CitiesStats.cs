using System.Linq;
using ICities;
using System.IO;
using UnityEngine;
using System.Globalization;

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

		public void OnSettingsUI(UIHelperBase helper)
		{
			var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
				.Intersect(CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures));
			var currentCulture = new[] { CultureInfo.CurrentCulture };
			var cultureDisplayNames = currentCulture.Concat(cultures.Except(currentCulture))
				.Select(o => o.Name + " - " + o.NativeName + " / " + o.EnglishName)
				.ToArray();

			//var userSettings = helper.AddGroup("User Settings");
			//userSettings.AddDropdown("Culture / Language", cultureDisplayNames, 0, index => Debug.Log(index));

			var modSettings = helper.AddGroup("Mod Settings");
			modSettings.AddTextfield("File Directory", @"C:\", changedText => Debug.Log(changedText), textSubmitted => Debug.Log(textSubmitted));
		}
	}
}