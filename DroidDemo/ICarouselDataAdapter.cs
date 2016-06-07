using System;
using System.Collections.Generic;

namespace DroidDemo
{
	public interface ICarouselDataAdapter<T>
	{
		T GetItemAt(int position);
		void Add(ICollection<T> items);
		void Clear();
		int ItemCount { get; }
		void NotifyItemChanged(int position);
	}
}

