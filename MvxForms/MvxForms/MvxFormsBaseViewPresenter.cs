﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Xamarin.Forms;

namespace MobiliTips.MvxPlugins.MvxForms
{
    public abstract class MvxFormsBaseViewPresenter
        : IMvxViewPresenter
    {
        private readonly string _viewSuffix;
        public readonly MvxFormsApp MvxFormsApp;

        protected MvxFormsBaseViewPresenter(MvxFormsApp mvxFormsApp, string viewSuffix = "View")
        {
            MvxFormsApp = mvxFormsApp;
            _viewSuffix = viewSuffix;
        }

        public async virtual void ChangePresentation(MvxPresentationHint hint)
        {
            if (!(hint is MvxClosePresentationHint)) return;

            var mainPage = MvxFormsApp.MainPage as NavigationPage;

            if (mainPage == null)
            {
                Mvx.TaggedTrace("MvxFormsViewPresenter:ChangePresentation()", "Shit, son! Don't know what to do");
            }
            else
            {
                // TODO - perhaps we should do more here... also async void is a boo boo
                await mainPage.PopAsync();
            }
        }

        public async virtual void Show(MvxViewModelRequest request)
        {
            if (await TryShowPage(request)) return;

            Mvx.Error("Skipping request for {0}", request.ViewModelType.Name);
        }

        private async Task<bool> TryShowPage(MvxViewModelRequest request)
        {
            var viewModelName = request.ViewModelType.Name;
            var viewName = viewModelName.Replace("ViewModel", _viewSuffix);
            var view = request.ViewModelType.GetTypeInfo().Assembly.DefinedTypes.FirstOrDefault(x => x.Name == viewName);
            if (view == null)
            {
                Mvx.Trace("View not found for {0}", viewName);
                return false;
            }

            var page = Activator.CreateInstance(view.AsType()) as ContentPage;
            if (page == null)
            {
                Mvx.Error("Failed to create ContentPage for {0}", viewName);
            }
            if (page == null)
                return false;

            var viewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();
            var viewModel = viewModelLoader.LoadViewModel(request, null);

            var mainPage = MvxFormsApp.MainPage as NavigationPage;

            if (mainPage == null)
            {
                MvxFormsApp.MainPage = new NavigationPage(page);
                mainPage = (NavigationPage)MvxFormsApp.MainPage;
                CustomPlatformInitialization(mainPage);
            }
            else
            {
                await mainPage.PushAsync(page);
            }

            page.BindingContext = viewModel;
            return true;
        }

        protected virtual void CustomPlatformInitialization(NavigationPage mainPage)
        {
        }
    }
}
