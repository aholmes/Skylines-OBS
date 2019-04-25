using System;

namespace CitiesStats.Config
{
	public interface IConfigurationProvider<T>
		where T : class, SkyTools.Configuration.IConfiguration, new()
	{
		T Configuration { get; }
		bool IsDefault { get; }

		event EventHandler Changed;

		void LoadDefaultConfiguration();
		void SaveDefaultConfiguration();
	}
}