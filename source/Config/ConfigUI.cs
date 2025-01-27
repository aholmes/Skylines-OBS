﻿using System;
using ICities;
using System.IO;

namespace CitiesStats.Config
{
	public sealed class ConfigUI: IDisposable
	{
		public static ConfigUI Create(IConfigurationProvider<CitiesStatsConfig> configProvider, UIHelperBase helper)
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

		private static void CreateViewItems(IConfigurationProvider<CitiesStatsConfig> configProvider, UIHelperBase helper)
		{
			var modSettings = helper.AddGroup("Mod Settings");

			var dataFileDirectory = configProvider.Configuration.DataFileDirectory;
			modSettings.AddTextfield("Data File Directory", dataFileDirectory,
				changedText =>
				{
					configProvider.Configuration.DataFileDirectory = changedText;
					configProvider.SaveDefaultConfiguration();
					System.Diagnostics.Debug.WriteLine(changedText);
				});
		}

		private readonly IConfigurationProvider<CitiesStatsConfig> _configProvider;

		public ConfigUI(IConfigurationProvider<CitiesStatsConfig> configProvider)
		{
			_configProvider = configProvider;
			_configProvider.Changed += ConfigProviderChanged;
		}

		private void ResetToDefaults()
		{
			_configProvider.Configuration.ResetToDefaults();
			RefreshAllItems();
		}

		private void UseForNewGames()
		{
			_configProvider.SaveDefaultConfiguration();
		}

		private void ConfigProviderChanged(object sender, EventArgs e)
		{
			RefreshAllItems();
		}

		private void RefreshAllItems()
		{
			_configProvider.SaveDefaultConfiguration();
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
				_configProvider.Changed -= ConfigProviderChanged;
			}

			_disposed = true;
		}
	}
}
