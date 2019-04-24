using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ICities;
using SkyTools.Configuration;
using UnityEngine;

namespace CitiesStats.Config
{
	internal sealed class ConfigUI: IDisposable
	{
		private readonly ConfigurationProvider<Config.CitiesStatsConfig> configProvider;

		public static ConfigUI Create(ConfigurationProvider<Config.CitiesStatsConfig> configProvider, UIHelperBase helper)
		{
			if (configProvider == null) throw new ArgumentNullException("configProvider");
			if (helper == null) throw new ArgumentNullException("helper");

			if (configProvider.Configuration == null)
			{
				throw new InvalidOperationException("The configuration provider has no configuration yet.");
			}

			CreateViewItems(configProvider, helper);

			return new ConfigUI(configProvider);
		}

		private static void CreateViewItems(ConfigurationProvider<Config.CitiesStatsConfig> configProvider, UIHelperBase helper)
		{
			var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
			var currentCulture = new[] { CultureInfo.CurrentCulture };
			var orderedCultures = currentCulture.Concat(cultures.Except(currentCulture)).ToArray();
			var cultureDisplayNames = new string[orderedCultures.Length];
			for(var i = 0; i < orderedCultures.Length; i++)
			{
				var culture = orderedCultures[i];
				cultureDisplayNames[i] = culture.Name + " - " + culture.NativeName + " / " + culture.EnglishName;
			}

			var userSettings = helper.AddGroup("User Settings");
			userSettings.AddDropdown("Culture / Language", cultureDisplayNames, 0, index => Debug.Log(index));

			var modSettings = helper.AddGroup("Mod Settings");
			modSettings.AddTextfield("File Directory", @"C:\", changedText => Debug.Log(changedText), textSubmitted => Debug.Log(textSubmitted));
		}

		private ConfigurationProvider<CitiesStatsConfig> _configProvider;

		public ConfigUI(ConfigurationProvider<CitiesStatsConfig> configProvider)
		{
			_configProvider = configProvider;
			_configProvider.Changed += ConfigProviderChanged;
		}

		private void ResetToDefaults()
		{
			configProvider.Configuration.ResetToDefaults();
			RefreshAllItems();
		}

		private void UseForNewGames()
		{
			configProvider.SaveDefaultConfiguration();
		}

		private void ConfigProviderChanged(object sender, EventArgs e)
		{
			RefreshAllItems();
		}

		private void RefreshAllItems()
		{

		}

		private bool _disposed;

		public void Dispose()
		{
			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (_disposed) return;

			if (disposing)
			{
				configProvider.Changed -= ConfigProviderChanged;
			}

			_disposed = true;
		}
	}
}
