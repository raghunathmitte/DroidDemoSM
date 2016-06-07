using System;
using System.Windows.Input;
using Android.Views;
using Android.Support.V7.Widget;

namespace DroidDemo
{
	/*
	 * Simple carousel item base class
	 */
	public abstract class BaseCarouselItemViewHolder : RecyclerView.ViewHolder
	{
		public BaseCarouselItemViewHolder(View v) : base(v)
		{
		}

		public virtual void OnAttachedToWindow()
		{
		}

		public virtual void OnDetachedFromWindow()
		{
		}
	}
}

