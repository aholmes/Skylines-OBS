using System.Linq;
using ICities;
using System.IO;
using UnityEngine;
using System.Globalization;
using SkyTools.Configuration;
using System;

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
		}
	}
}