using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ringbuffer
{
	public interface IRingbuffer<T>
	{
		void Add(T value);
		T Take();
		int Count();
		int Size();
	}
}
