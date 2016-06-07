using MvvmCross.Core.ViewModels;
using System;

namespace SMDemoData
{
	public class DummyCarouselTileViewModel : MvxViewModel
    {
		public string Title { get; set; }
		public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }

		public DummyCarouselTileViewModel()
		{
		}
	}
}

