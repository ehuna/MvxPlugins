// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MvxFormsWindowsPhoneViewPresenter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using Xamarin.Forms;

namespace MobiliTips.MvxPlugin.MvxForms.WindowsPhone
{
    /// <summary>
    /// Defines the MvxFormsWindowsPhoneViewPresenter type.
    /// </summary>
    public class MvxFormsWindowsPhoneViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxPhoneViewPresenter
    {
        private readonly PhoneApplicationFrame _rootFrame;

        public MvxFormsWindowsPhoneViewPresenter(Application mvxFormsApp, PhoneApplicationFrame rootFrame, string viewSuffix = "View")
            : base(mvxFormsApp, viewSuffix)
        {
            _rootFrame = rootFrame;
        }

        protected override void CustomPlatformInitialization(NavigationPage mainPage)
        {
            _rootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
