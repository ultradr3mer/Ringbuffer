using System;

namespace Ringbuffer
{
  public class Ringbuffer<T> : IRingbuffer<T>
  {
    #region Fields

    private readonly T[] data;
    private readonly int size;
    private int count = 0;
    private int reader = -1;
    private int writer = -1;

    #endregion Fields

    #region Constructors

    public Ringbuffer(int size)
    {
      this.size = size;
      this.data = new T[size];
    }

    #endregion Constructors

    #region Methods

    public void Add(T value)
    {
      this.writer = this.Next(this.writer);
      this.data[this.writer] = value;

      if (reader == -1)
      {
        reader = 0;
        count += 1;
      }
      else if (this.reader == this.writer)
      {
        this.reader = this.Next(this.reader);
      }
      else
      {
        count += 1;
      }
    }

    public int Count()
    {
      return this.count;
    }

    public int Size()
    {
      return this.size;
    }

    public T Take()
    {
      if (this.Count() == 0)
      {
        throw new Exception("Buffer empty");
      }

      var result = this.data[this.reader];
      this.reader = this.Next(this.reader);
      this.count -= 1;
      return result;
    }

    private int Next(int pos)
    {
      int next = pos + 1;
      return next < this.size ? next : 0;
    }

    #endregion Methods
  }
}