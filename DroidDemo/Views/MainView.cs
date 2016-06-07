using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System;
using MvvmCross.Droid.Views;
using MvvmCross.Core.ViewModels;
using SMDemoData.ViewModels;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Platform;
using MvvmCross.Binding.BindingContext;

namespace DroidDemo
{
	[Activity(Label = "View for MainViewModel")]
	[MvxViewFor(typeof(MainViewModel))]
	public class MainView : MvxActivity
	{
		private RecyclerView _carouselCollectionView;
		private CarouselCollectionAdapter _carouselCollectionAdapter;
        private MainViewModel _viewModel;
        private IMvxMessenger _messenger;
        private MvxSubscriptionToken _messengerToken;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

            // setup the vertical carousel which holds all the child carousels
            _carouselCollectionView = FindViewById<RecyclerView>(Resource.Id.carouselCollection);
            _carouselCollectionView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Vertical, false));
            _carouselCollectionAdapter = new CarouselCollectionAdapter(this);
            _carouselCollectionView.SetAdapter(_carouselCollectionAdapter);
            _viewModel = ViewModel as MainViewModel;
            _messenger = Mvx.Resolve<IMvxMessenger>();
            _messengerToken = _messenger.SubscribeOnMainThread<CustomMessage>(LoadData);
            this.CreateBindingSet<MainView, MainViewModel>();
        }

        private void LoadData(CustomMessage message)
        {
            RunOnUiThread(() => {
                _carouselCollectionAdapter.Clear();
                _carouselCollectionAdapter.Add(_viewModel.DummyCarouselViewModel);
                _carouselCollectionAdapter.NotifyDataSetChanged();
                });
        }
    }
}


