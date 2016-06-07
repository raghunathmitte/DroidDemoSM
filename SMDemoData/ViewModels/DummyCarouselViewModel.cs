using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace SMDemoData
{
	public class DummyCarouselViewModel : MvxViewModel
	{
		public string Title { get; set; }
		public List<DummyCarouselTileViewModel> Tiles { get; set; }

		public DummyCarouselViewModel()
		{
		}
	}
}

