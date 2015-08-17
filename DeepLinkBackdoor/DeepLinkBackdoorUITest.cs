using NUnit.Framework;
using System;
using Xamarin.UITest.Android;
using System.Reflection;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Linq;
using DeepLinkBackdoor;

namespace DeepLinkBackdoor.UITest
{
    [TestFixture]
    public class DeepLinkBackdoorUITest : BaseTestFixture
    {
        [Test]
        public void Deeplink_Test()
        {
            _app.WaitForElement("StatusView");
            _app.Screenshot("Given the app is in the Main view");

            _app.Invoke("InvokeDeepLink");
            _app.WaitForElement("StatusView");
            _app.Screenshot("After I tap the button, the deeplink is activated and I can see the new button text");

        }

    }
}

