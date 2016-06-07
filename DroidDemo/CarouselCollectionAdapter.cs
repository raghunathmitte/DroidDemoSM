using System;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.App;
using Android.Content;
using SMDemoData;

namespace DroidDemo
{
	/*
	 * Adapter used by vertical lists of child carousels
	 */
	public class CarouselCollectionAdapter : BaseCarouselAdapter<DummyCarouselViewModel>
	{
		public CarouselCollectionAdapter(Context ctx) : base(ctx)
		{
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			return new TitleCarouselViewHolder(Ctx, 
			                                   (Ctx as Activity).LayoutInflater.Inflate(Resource.Layout.TitleCarousel,
			                                                                            (ViewGroup) parent,
			                                                                            false)
			);
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			DummyCarouselViewModel cvm = GetItemAt(position);
			(holder as TitleCarouselViewHolder).SetTitle(cvm.Title);
			(holder as TitleCarouselViewHolder).SetCarousel(cvm);
		}
	}
}

