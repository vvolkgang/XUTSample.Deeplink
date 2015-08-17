using NUnit.Framework;
using System;
using Xamarin.UITest.Android;
using System.Reflection;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Linq;
using System.Diagnostics;

namespace DeepLinkBackdoor.UITest
{
    [TestFixture]
    public abstract class BaseTestFixture
    {
        protected IApp _app;
        private IUITestConfiguration _config;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _config = new MainLocalConfiguration();
        }

        [SetUp]
        public void SetUp()
        {
            switch (TestEnvironment.Platform)
            {
                case TestPlatform.TestCloudiOS:
                    _app = ConfigureApp.iOS.StartApp();
                    break;

                case TestPlatform.TestCloudAndroid:
                    _app = ConfigureApp.Android.StartApp();
                    break;

                case TestPlatform.Local:
#if __IOS__
                    throw new NotImplementedException("Try to implement this functionality"));
#elif __ANDROID__
                    _app = ConfigureApp
                              .Android
                              .ApkFile(_config.PathToAPK)
                              .ApiKey(_config.API_KEY)
                              .StartApp();
#elif __IOS_DEVICE__

                    throw new NotImplementedException("Try to implement this functionality"));
#endif
                    break;
                default:
                    throw new NotImplementedException(String.Format("I don't know this platform {0}", TestEnvironment.Platform));
            }
        }
    }
}

