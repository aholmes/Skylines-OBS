using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using ICities;
using Moq;
using Xunit;

namespace CitiesStats.Tests
{
	public class AutoMoqDataAttribute : AutoDataAttribute
	{
		public AutoMoqDataAttribute()
			: base(() => new Fixture().Customize(new AutoMoqCustomization()))
		{
		}
	}

	public class UserMod
	{
		private CitiesStats _modInstance;

		public UserMod()
		{
			_modInstance = new CitiesStats();
		}

		[Theory, AutoMoqData]
		public void OnSettingsUI_Does_Not_Crash(Mock<UIHelperBase> uiHelperBaseMock)
		{
			_modInstance.OnSettingsUI(uiHelperBaseMock.Object);
		}
	}
}
