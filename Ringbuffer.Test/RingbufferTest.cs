using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ringbuffer.Test
{
  [TestClass]
  public class RingbufferTest
  {
    #region Methods

    [TestMethod]
    public void Add15Test()
    {
      // Arrange
      IRingbuffer<int> buffer = new Ringbuffer<int>(10);

      // Act
      buffer.Add(0);
      buffer.Add(1);
      buffer.Add(2);
      buffer.Add(3);
      buffer.Add(4);
      buffer.Add(5);
      buffer.Add(6);
      buffer.Add(7);
      buffer.Add(8);
      buffer.Add(9);
      buffer.Add(10);
      buffer.Add(11);
      buffer.Add(12);
      buffer.Add(13);
      buffer.Add(14);

      // Assert
      Assert.AreEqual(10, buffer.Size());
      Assert.AreEqual(10, buffer.Count());
      Assert.AreEqual(5, buffer.Take());
      Assert.AreEqual(6, buffer.Take());
      Assert.AreEqual(7, buffer.Take());
      Assert.AreEqual(7, buffer.Count());
    }

    [TestMethod]
    public void Add5Test()
    {
      // Arrange
      IRingbuffer<int> buffer = new Ringbuffer<int>(10);

      // Act
      buffer.Add(0);
      buffer.Add(1);
      buffer.Add(2);
      buffer.Add(3);
      buffer.Add(4);

      // Assert
      Assert.AreEqual(10, buffer.Size());
      Assert.AreEqual(5, buffer.Count());
      Assert.AreEqual(0, buffer.Take());
      Assert.AreEqual(1, buffer.Take());
      Assert.AreEqual(2, buffer.Take());
      Assert.AreEqual(2, buffer.Count());
    }

    [TestMethod]
    public void TakeAllTest()
    {
      // Arrange
      IRingbuffer<int> buffer = new Ringbuffer<int>(10);

      // Act
      buffer.Add(0);
      buffer.Add(1);
      buffer.Add(2);
      buffer.Add(3);
      buffer.Add(4);

      // Assert
      Assert.AreEqual(10, buffer.Size());
      Assert.AreEqual(5, buffer.Count());
      Assert.AreEqual(0, buffer.Take());
      Assert.AreEqual(1, buffer.Take());
      Assert.AreEqual(2, buffer.Take());
      Assert.AreEqual(3, buffer.Take());
      Assert.AreEqual(4, buffer.Take());
      Assert.AreEqual(0, buffer.Count());
    }

    [TestMethod]
    public void TakeOneToManyTest()
    {
      // Arrange
      IRingbuffer<int> buffer = new Ringbuffer<int>(10);

      // Act
      buffer.Add(0);
      buffer.Add(1);
      buffer.Add(2);
      buffer.Add(3);
      buffer.Add(4);

      // Assert
      Assert.AreEqual(10, buffer.Size());
      Assert.AreEqual(5, buffer.Count());
      Assert.AreEqual(0, buffer.Take());
      Assert.AreEqual(1, buffer.Take());
      Assert.AreEqual(2, buffer.Take());
      Assert.AreEqual(3, buffer.Take());
      Assert.AreEqual(4, buffer.Take());

      Assert.ThrowsException<Exception>(() => buffer.Take());
    }

    #endregion Methods
  }
}