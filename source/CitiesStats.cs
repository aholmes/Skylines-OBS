using System.Linq;
using ICities;
using System.IO;
using UnityEngine;
using System.Globalization;
using System;
using CitiesStats.Config;
//using SkyTools.Localization;
using ColossalFramework.Plugins;

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
		private readonly string _modPath = GetModPath();

		private IConfigurationProvider<CitiesStatsConfig> _configProvider;
		//private LocalizationProvider _localizationProvider;
		private ConfigUI _configUI;

		private static string GetModPath()
		{
			PluginManager.PluginInfo pluginInfo = PluginManager.instance.GetPluginsInfo()
				.FirstOrDefault(pi => pi.publishedFileID.AsUInt64 == _workshopId);

			return pluginInfo == null ? string.Empty : pluginInfo.modPath;
		}

		public void OnEnabled()
		{
			_configProvider = new ConfigurationProvider<CitiesStatsConfig>(CitiesStatsConfig.StorageId, Name, () => new CitiesStatsConfig(true));
			_configProvider.LoadDefaultConfiguration();
			//_localizationProvider = new LocalizationProvider(Name, _modPath);
		}

		public void OnSettingsUI(UIHelperBase helper)
		{
			if (helper == null || _configProvider ==  null) return;

			if (_configProvider.Configuration == null)
			{
				SkyTools.Tools.Log.Warning("'Cities Stats' wants to display the configuration page, but the configuration is unexpectedly missing.");
				_configProvider.LoadDefaultConfiguration();
			}

			CloseConfigUI();
			_configUI = ConfigUI.Create(_configProvider, helper);
		}

		private void CloseConfigUI()
		{
			if (_configUI != null)
			{
				_configUI.Dispose();
				_configUI = null;
			}
		}
	}
}