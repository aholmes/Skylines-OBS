using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using ICities;
using Moq;
using Test.Utils;
using Xunit;

namespace CitiesStats.Tests
{
	public class UserMod
	{
		private CitiesStats _modInstance;

		public UserMod()
		{
			_modInstance = new CitiesStats();
		}

		[Fact]
		public void OnEnabled_Does_Not_Crash()
		{
			_modInstance.OnEnabled();
		}

		[Theory, AutoMoqData]
		public void OnSettingsUI_Does_Not_Crash(Mock<UIHelperBase> mockUiHelperBase)
		{
			_modInstance.OnSettingsUI(mockUiHelperBase.Object);
		}
	}
}
