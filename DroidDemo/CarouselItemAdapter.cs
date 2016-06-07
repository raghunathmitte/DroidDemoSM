using System;
using Android.Support.V7.Widget;
using Android.Content;
using Android.Views;
using Android.App;
using System.Collections.Generic;
using System.Windows.Input;
using SMDemoData;

namespace DroidDemo
{

	/*
	 * Adapter used by horizontal lists of carousel tiles
	 * Capable of display simple lists, or indexing masonary lists
	 */
	public class CarouselItemAdapter : BaseCarouselAdapter<DummyCarouselTileViewModel>
	{
		protected DummyCarouselViewModel _viewModel;

		public CarouselItemAdapter(Context ctx) : base(ctx)
		{
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View v = (Ctx as Activity).LayoutInflater.Inflate(Resource.Layout.carousel_item, (ViewGroup) parent, false);
			return new SimpleCarouselItemViewHolder(v);
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			DummyCarouselTileViewModel ctvm = GetItemAt(position);
            SimpleCarouselItemViewHolder viewHolder = holder as SimpleCarouselItemViewHolder;
            viewHolder.SetTile(ctvm);
		}

		public override int GetItemViewType(int position)
		{
			return 0;
		}

		public void SetCarousel(DummyCarouselViewModel carousel)
		{
			_viewModel = carousel;
			Add(carousel.Tiles);
		}

		public override void OnViewAttachedToWindow(Java.Lang.Object holder)
		{
			base.OnViewAttachedToWindow(holder);
			if(holder is BaseCarouselItemViewHolder)
			{
				(holder as BaseCarouselItemViewHolder).OnAttachedToWindow();
			}
		}

		public override void OnViewDetachedFromWindow(Java.Lang.Object holder)
		{
			base.OnViewDetachedFromWindow(holder);
			if(holder is BaseCarouselItemViewHolder)
			{
				(holder as BaseCarouselItemViewHolder).OnDetachedFromWindow();
			}
		}
	}
}

