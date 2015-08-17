using System;
using System.IO;
using System.Reflection;

namespace DeepLinkBackdoor.UITest
{
    /// <summary>
    /// Main configuration file for local UI testing. This implementation should cover most cases. 
    /// 
    /// More advance usage scenarios might include multiple configurations for
    /// multiple conditional app builds (e.g., one for TEST env, another for QA, etc...).
    /// </summary>
    internal class MainLocalConfiguration : IUITestConfiguration
    {
        public string API_KEY => "";
        public string PathToAPK => Path.Combine(SlnPath, "DeeplinkBackdoorTest", "bin", "Release", "DeeplinkBackdoorTest.DeeplinkBackdoorTest-Signed.apk");
        public string AndroidPackageName => "com.DeepLinkBackdoor";

        private string _slnPath = null;
        private string SlnPath
        {
            get
            {
                if (_slnPath != null)
                    return _slnPath;

                string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                FileInfo fi = new FileInfo(currentFile);
                _slnPath = fi.Directory.Parent.Parent.Parent.FullName;

                return _slnPath;
            }
        }
    }
}

