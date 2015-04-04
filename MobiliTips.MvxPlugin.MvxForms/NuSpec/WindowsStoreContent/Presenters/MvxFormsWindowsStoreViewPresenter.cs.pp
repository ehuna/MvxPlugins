// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MvxFormsWindowsPhoneViewPresenter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Cirrious.MvvmCross.WindowsCommon.Views;
using Xamarin.Forms;

namespace $rootnamespace$.Presenters
{
    /// <summary>
    /// Defines the MvxFormsWindowsPhoneViewPresenter type.
    /// </summary>
    public class MvxFormsWindowsStoreViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxWindowsViewPresenter
    {
        private readonly IMvxWindowsFrame _rootFrame;

        public MvxFormsWindowsStoreViewPresenter(MvxFormsApp mvxFormsApp, IMvxWindowsFrame rootFrame, string viewSuffix = "View")
            : base(mvxFormsApp, viewSuffix)
        {
            _rootFrame = rootFrame;
        }

        protected override void CustomPlatformInitialization(NavigationPage mainPage)
        {
            _rootFrame.Navigate(typeof(MainPage), null);
        }
    }
}
