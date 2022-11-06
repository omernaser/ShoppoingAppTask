using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ShoppoingAppTask.Base
{
    public class BaseContentPage : ContentPage
    {
    }
    public class BaseContentPage<T> : BaseContentPage where T : BaseNotifiedModel, new()
    {

        protected T _viewModel;

        public T ViewModel
        {
            get
            {
                return _viewModel ?? (_viewModel = new T());
            }
        }

        ~BaseContentPage()
        {
            _viewModel = null;
        }

        public BaseContentPage()
        {
            Init();
        }

        public BaseContentPage(T viewModel)
        {
            _viewModel = viewModel;
            Init();
        }

        private void Init()
        {
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!IsFirstTimeAppearing)
            {
                OnFirstAppearing();
                IsFirstTimeAppearing = true;
            }
        }


        bool isFirstTimeAppearing;
        public bool IsFirstTimeAppearing
        {
            get { return isFirstTimeAppearing; }
            set
            {
                isFirstTimeAppearing = value;
                OnPropertyChanged(nameof(IsFirstTimeAppearing));
            }
        }

        protected virtual void OnFirstAppearing()
        {

        }
    }
}
