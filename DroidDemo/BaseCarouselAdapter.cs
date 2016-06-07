using System;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Content;
using System.Windows.Input;

namespace DroidDemo
{
	/*
	 * A Base carousel adapter to be used by both vertical lists of carousels
	 * or horizontal lists of carousel items
	 */
	public abstract class BaseCarouselAdapter<T> : RecyclerView.Adapter, ICarouselDataAdapter<T>
	{
		protected Context Ctx { get; private set; }

		private List<T> _items;
		protected List<T> Items
		{
			get
			{
				return _items;
			}
		}

		public BaseCarouselAdapter(Context ctx)
		{
			Ctx = ctx;
			_items = new List<T>();
		}

		public override int ItemCount
		{
			get
			{
				if(_items != null)
					return _items.Count;
				return 0;
			}
		}

		public void Clear()
		{
			if(_items != null)
				_items.Clear();
		}

		public virtual void Add(ICollection<T> items)
		{
			_items.AddRange(items);
		}

		public T GetItemAt(int position)
		{
			return _items[position];
		}

	}
}

