using System.Linq;
using ICities;
using System.IO;
using UnityEngine;
using System.Globalization;
using System;
using CitiesStats.Config;
//using SkyTools.Localization;
using ColossalFramework.Plugins;
using System.Collections.Generic;
using SkyTools.Storage;

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

		private const ulong _workshopId = 0;

		private IConfigurationProvider<CitiesStatsConfig> _configProvider;
		//private LocalizationProvider _localizationProvider;
		private ConfigUI _configUI;

		public void OnEnabled()
		{
			_configProvider = ConfigurationProvider<CitiesStatsConfig>.Create(CitiesStatsConfig.StorageId, Name, () => new CitiesStatsConfig(true));
			_configProvider.LoadDefaultConfiguration();
			//_localizationProvider = new LocalizationProvider(Name, _modPath);
		}

		public void OnSettingsUI(UIHelperBase helper)
		{
			if (helper == null || _configProvider ==  null) return;

			if (_configProvider.Configuration == null)
			{
				System.Diagnostics.Debug.WriteLine("'Cities Stats' wants to display the configuration page, but the configuration is unexpectedly missing.");
				_configProvider.LoadDefaultConfiguration();
			}

			CloseConfigUI();
			_configUI = ConfigUI.Create(_configProvider, helper);
		}

		private static void LoadStorageData(IEnumerable<IStorageData> storageData, StorageBase storage)
		{
			foreach (var item in storageData)
			{
				storage.Deserialize(item);
			}
		}

		private void CloseConfigUI()
		{
			if (_configUI != null)
			{
				_configProvider.SaveDefaultConfiguration();

				_configUI.Dispose();
				_configUI = null;
			}
		}
	}
}