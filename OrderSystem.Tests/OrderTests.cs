using NUnit.Framework;
using System;

namespace OrderSystem.Tests
{
    public class OrderTests
    {
        [Test]
        public void NewOrder_ShouldBePending()
        {
            var order = new Order(1, new[] { "Coffee" });
            Assert.AreEqual(OrderStatus.Pending, order.Status);
        }

        [Test]
        public void Complete_ShouldChangeStatusToCompleted()
        {
            var order = new Order(2, new[] { "Tea" });
            order.Complete();
            Assert.AreEqual(OrderStatus.Completed, order.Status);
        }

        [Test]
        public void Complete_WhenNotPending_ShouldThrow()
        {
            var order = new Order(3, new[] { "Bagel" });
            order.Complete();

            Assert.Throws<InvalidOperationException>(() => order.Complete());
        }
    }
}
