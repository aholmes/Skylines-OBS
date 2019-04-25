using System;
using SkyTools.Configuration;

namespace CitiesStats.Config
{
	public class ConfigurationProvider<T> : IConfigurationProvider<T>
		where T : class, SkyTools.Configuration.IConfiguration, new()
	{
		private readonly SkyTools.Configuration.ConfigurationProvider<T> _configProvider;

		private ConfigurationProvider(SkyTools.Configuration.ConfigurationProvider<T> configProvider)
		{
			_configProvider = configProvider;
		}

        private ConfigurationProvider(string storageId, string modName, Func<T> configurationFactory)
		{
			_configProvider = new SkyTools.Configuration.ConfigurationProvider<T>(storageId, modName, configurationFactory);
		}

		public static ConfigurationProvider<T> Instance { get; private set; }
		public static ConfigurationProvider<T> Create(string storageId, string modName, Func<T> configurationFactory)
		{
			if (Instance != null) return Instance;

			Instance = new ConfigurationProvider<T>(storageId, modName, configurationFactory);
			return Instance;
		}

        public event EventHandler Changed
		{
			add {_configProvider.Changed += value; }
			remove { _configProvider.Changed -= value;  }
		}

        public T Configuration { get { return _configProvider.Configuration; } }
        public bool IsDefault { get { return _configProvider.IsDefault; } }

        public void LoadDefaultConfiguration()
		{
			_configProvider.LoadDefaultConfiguration();
		}

        public void SaveDefaultConfiguration()
		{
			_configProvider.SaveDefaultConfiguration();
		}

		public override bool Equals(object obj)
		{
			return _configProvider.Equals(obj);
		}

		public override int GetHashCode()
		{
			return _configProvider.GetHashCode();
		}

		public override string ToString()
		{
			return _configProvider.ToString();
		}
	}
}
