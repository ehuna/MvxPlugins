﻿using Cirrious.CrossCore;
using Cirrious.MvvmCross.Views;
using MobiliTips.MvxPlugins.MvxForms.Sample.WindowsCommon.Presenters;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MobiliTips.MvxPlugins.MvxForms.Sample.WindowsCommon
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsWindowsPhoneViewPresenter;
            if (presenter == null) return;

            LoadApplication(presenter.MvxFormsApp);
        }
    }
}
