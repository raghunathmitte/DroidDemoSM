using System;
using Android.Support.V7.Widget;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android;
using System.Linq;
using SMDemoData;

namespace DroidDemo
{
	/*
	 * View holder for a child carousel with title
	 */
	public class TitleCarouselViewHolder : RecyclerView.ViewHolder
	{
		private RecyclerView _carouselView;
		private TextView _titleView;
		private CarouselItemAdapter _carouselAdapter;
		private DummyCarouselViewModel _dataContext;

		public TitleCarouselViewHolder() : base(null)
		{
		}

		public TitleCarouselViewHolder(Context ctx, View v) : base(v)
		{
			// hold the views
			_titleView = v.FindViewById<TextView>(Resource.Id.carouselTitle);
			_carouselView = v.FindViewById<RecyclerView>(Resource.Id.carouselRow);

			// setup the carousel
			_carouselView.SetLayoutManager(new LinearLayoutManager(ctx, LinearLayoutManager.Horizontal, false));
			_carouselAdapter = new CarouselItemAdapter(ctx);
			_carouselView.SetAdapter(_carouselAdapter);
		}

		public void SetTitle(string title)
		{
			_titleView.Text = title;
		}

		public void SetCarousel(DummyCarouselViewModel carousel)
		{
			_dataContext = carousel;
			_carouselAdapter.Clear();
			_carouselAdapter.SetCarousel(carousel);
			_carouselAdapter.NotifyDataSetChanged();
		}
	}
}

