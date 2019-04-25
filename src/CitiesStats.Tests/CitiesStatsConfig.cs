using CitiesStats.Config;
using ICities;
using Moq;
using Test.Utils;
using Xunit;

namespace CitiesStats.Tests
{
	public class CitiesStatsConfig
	{
		private CitiesStats _modInstance;

		public CitiesStatsConfig()
		{
			_modInstance = new CitiesStats();
		}

		[Theory, AutoMoqData]
		public void ConfigUI_Does_Not_Crash(Mock<IConfigurationProvider<Config.CitiesStatsConfig>> mockConfigurationProvider, Mock<UIHelperBase> mockUiHelperBase)
		{
			var x = ConfigUI.Create(mockConfigurationProvider.Object, mockUiHelperBase.Object);
		}
	}
}
