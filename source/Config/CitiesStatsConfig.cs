using ColossalFramework.Plugins;
using SkyTools.Configuration;
using SkyTools.UI;
using System.Linq;

namespace CitiesStats.Config
{
	public sealed class CitiesStatsConfig : IConfiguration
	{
		public const string StorageId = "CitiesStatsConfig";

		private const int LatestVersion = 0;

		public CitiesStatsConfig()
		{
			ResetToDefaults();
		}

		public CitiesStatsConfig(bool isLatestVersion)
			: this()
		{
			if (isLatestVersion)
			{
				Version = LatestVersion;
			}
		}

		public void MigrateWhenNecessary()
		{
			if (Version == 0)
			{
				ResetToDefaults();
			}

			Version = LatestVersion;
		}

		public void Validate()
		{
			try
			{
				if (!System.IO.Directory.Exists(DataFileDirectory))
				{
					System.IO.Directory.CreateDirectory(DataFileDirectory);
				}
				System.IO.Directory.GetAccessControl(DataFileDirectory);
			}
			catch
			{
				System.Diagnostics.Debug.WriteLine("Directory '"+DataFileDirectory+"' does not exists, or is not accessible.");
			}
		}

		public int Version { get; set; }

		[ConfigItem("DataFileDirectory", 0)]
		public string DataFileDirectory { get; set; }

		public void ResetToDefaults()
		{
			DataFileDirectory = System.IO.Path.Combine(ModPath, "Data");
		}

		private static string GetModPath()
		{
			var pluginInfo = PluginManager.instance.GetPluginsInfo()
				.FirstOrDefault(pi => pi.publishedFileID.AsUInt64 == 0);

			if (pluginInfo == null)
			{
				pluginInfo = PluginManager.instance.FindPluginInfo(System.Reflection.Assembly.GetCallingAssembly());
			}

			return pluginInfo == null ? string.Empty : pluginInfo.modPath;
		}

		private string _modPath;
		public string ModPath
		{
			get
			{
				if (!string.IsNullOrEmpty(_modPath)) return _modPath;

				_modPath = GetModPath();

				return _modPath;
			}
		}

	}
}