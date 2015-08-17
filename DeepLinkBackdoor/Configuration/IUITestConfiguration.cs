using System;

namespace DeepLinkBackdoor.UITest
{
    public interface IUITestConfiguration
    {
        /// <summary>
        /// API Key used in the UITest framework. 
        /// If you're using Test Cloud, this is your User ID hash.
        /// </summary>
        string API_KEY { get; }

        /// <summary>
        /// Full path to the .APK file.
        /// </summary>
        string PathToAPK { get; }

        /// <summary>
        /// Full path to the .APP iOS app file.
        /// </summary>

        string AndroidPackageName { get; }
    }
}

