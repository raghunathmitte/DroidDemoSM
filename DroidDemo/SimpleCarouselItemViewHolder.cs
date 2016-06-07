using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using Android.Graphics;
using SMDemoData;
using SMDemoData.ViewModels;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Binding.BindingContext;
using Android.Media;
using Android.App;

namespace DroidDemo
{
	/*
	 * Simple view holder for a single carousel tile
	 */
	public class SimpleCarouselItemViewHolder : BaseCarouselItemViewHolder
	{
		// views
		private MvxImageView _imageView;
		private TextView _line1;
		private TextView _line2;
		private TextView _carouselItemBadge;
		private View _metadata;
        private View _tileView;
        private IMvxBindingContext BindindContext;

        public IMvxBindingContext BindingContext
        {
            get
            {
                return BindindContext;
            }
        }

        public SimpleCarouselItemViewHolder() : base(null)
		{
		}

		public SimpleCarouselItemViewHolder(View v) : base(v)
		{
            // hold the views
            _tileView = v;
			_line1 = v.FindViewById<TextView>(Resource.Id.carouselItemLine1);
			_line2 = v.FindViewById<TextView>(Resource.Id.carouselItemLine2);
			_imageView = v.FindViewById<MvxImageView>(Resource.Id.carouselItemImage);
			_metadata = v.FindViewById(Resource.Id.metadataTxtArea);
            BindindContext = new MvxBindingContext();
           
        }

		public void SetTile(DummyCarouselTileViewModel tile)
		{
            BindindContext.DataContext = tile;
            _imageView.ImageUrl = tile.ImageUrl;
        }
			
		public override void OnAttachedToWindow()
		{
		}

		public override void OnDetachedFromWindow()
		{
		}
	}
}

