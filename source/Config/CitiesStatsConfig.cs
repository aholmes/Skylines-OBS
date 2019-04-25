using SkyTools.Configuration;
using SkyTools.Tools;
using SkyTools.UI;

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
				System.IO.Directory.Exists(DataFileDirectory);
				System.IO.Directory.GetAccessControl(DataFileDirectory);
			}
			catch
			{
				Log.Error("Directory '"+DataFileDirectory+"' does not exists, or is not accessible.");
			}
		}

		public int Version { get; set; }

		[ConfigItem("DataFileDirectory", 0)]
		public string DataFileDirectory { get; set; }

		public void ResetToDefaults()
		{
			DataFileDirectory = "CitiesStats";
		}
	}
}