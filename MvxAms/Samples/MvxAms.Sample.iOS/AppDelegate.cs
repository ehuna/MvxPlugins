﻿using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.ViewModels;
using Foundation;
using MobiliTips.MvxPlugins.MvxAms.Touch;
using UIKit;

namespace MvxAms.Sample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        UIWindow _window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, _window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            _window.MakeKeyAndVisible();

            Mvx.RegisterSingleton<IMvxAmsTouchTopViewController>(new MvxAmsTouchTopViewController(_window.RootViewController));

            return true;
        }
    }
}