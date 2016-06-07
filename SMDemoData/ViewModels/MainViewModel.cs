using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Newtonsoft.Json;
using SMDemoData;
using SMDemoData.Interfaces;
using SMDemoData.Models;
using System;
using System.Collections.Generic;

namespace SMDemoData.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private Results _results = null;
        
        public Results Results
        {
            get { return _results; }
        }

        private readonly ILoggingService _loggingService;
        private readonly IDownloadService _downloadService;
        private readonly IMvxMessenger _messenger;

        public MainViewModel(ILoggingService loggingService, IDownloadService downloadService,
            IMvxMessenger messenger)
        {
            _loggingService = loggingService;
            _downloadService = downloadService;
            _messenger = messenger;
        }


        public async void Init()
        {
            _loggingService.Log("[MainViewModel] - Init");
            string result = await _downloadService.GetData("http://peter.switchmedia.asia/api/download-v1/listAssets/");
            if (result != null)
            {
                _loggingService.Log("[MainViewModel] - result exists load view data");
                _results = JsonConvert.DeserializeObject<Results>(result);
                LoadViewModelData(_results);
            }
        }

        public override void Start()
        {
            base.Start();
            _loggingService.Log("[MainViewModel] - Start");
        }
        
        private IList<DummyCarouselViewModel> _dummyCarouselViewModel;
        public IList<DummyCarouselViewModel> DummyCarouselViewModel
        {
            get { return _dummyCarouselViewModel; }
            set
            {
                _dummyCarouselViewModel = value;
                RaisePropertyChanged(()=> DummyCarouselViewModel);
            }
        }

        private bool _isBusy = true;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public void LoadViewModelData(Results results)
        {
            if (results != null)
            {
                // dummy data
                _dummyCarouselViewModel = new List<DummyCarouselViewModel>();
                foreach (var verticalItem in results.VerticalTiles)
                {
                    if (verticalItem != null)
                    {
                        _dummyCarouselViewModel.Add(new DummyCarouselViewModel()
                        {
                            Title = string.Format("{0}", verticalItem.Title),
                            Tiles = InitTiles(verticalItem)
                        });
                    }
                }
                _messenger.Publish(new CustomMessage(this, true));
                IsBusy = false;
            }
            else
            {
                //could not load data
                _loggingService.Log("Could not load data ");
            }
        }

        private List<DummyCarouselTileViewModel> InitTiles(Result verticalItem)
        {
            List<DummyCarouselTileViewModel> horizontaldata = new List<DummyCarouselTileViewModel>();
            foreach (var rowItem in verticalItem.Tiles)
            {
                horizontaldata.Add(new DummyCarouselTileViewModel()
                {
                    Title = string.Format("{0}", rowItem.Title),
                    ImageUrl = string.Format("{0}", rowItem.ImageUrl),
                    VideoUrl = string.Format("{0}", rowItem.VideoUrl)
                });
            }
            return horizontaldata;
        }
    }

    public class CustomMessage : MvxMessage
    {
        bool _isDataLoaded;
        public CustomMessage(object sender, bool isDataLoaded) : base(sender)
        {
            _isDataLoaded = isDataLoaded;
        }

        public bool IsDataLoaded
        {
            get { return _isDataLoaded; }
            set { _isDataLoaded = value; }
        }
    }
}
