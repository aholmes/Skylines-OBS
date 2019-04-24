using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SkyTools.Configuration;
using SkyTools.UI;
using UnityEngine;

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
				UserCultureName = System.Globalization.CultureInfo.CurrentCulture.Name;
			}

			Version = LatestVersion;
		}

		public void Validate()
		{
			try
			{
				CultureInfo.CreateSpecificCulture(UserCultureName);
			}
			catch
			{
				Debug.Log("Culture with name '"+UserCultureName+"' could not be found.");
			}
		}

		public int Version { get; set; }

		[ConfigItem("UserCultureName", 0)]
		public string UserCultureName { get; set; }

		public void ResetToDefaults()
		{

		}
	}
}