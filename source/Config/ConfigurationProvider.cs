using System;

namespace CitiesStats.Config
{
	public class ConfigurationProvider<T> : IConfigurationProvider<T>
		where T : class, SkyTools.Configuration.IConfiguration, new()
	{
		private readonly SkyTools.Configuration.ConfigurationProvider<T> _configProvider;

		public ConfigurationProvider(SkyTools.Configuration.ConfigurationProvider<T> configProvider)
		{
			_configProvider = configProvider;
		}

        public ConfigurationProvider(string storageId, string modName, Func<T> configurationFactory)
		{
			_configProvider = new SkyTools.Configuration.ConfigurationProvider<T>(storageId, modName, configurationFactory);
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

	public class ConfigurationProviderProxy<T>
	{
		private T _obj;

		public ConfigurationProviderProxy(T obj)
		{
			_obj = obj;
		}

		public static ConfigurationProviderProxy<T> Proxy(T obj)
		{
			return new ConfigurationProviderProxy<T>(obj);
		}
	}
}
