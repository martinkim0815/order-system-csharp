using System;
using System.Collections.Generic;

namespace OrderSystem
{
    public enum OrderStatus { Pending, Completed, Cancelled }

    public class Order
    {
        public int Id { get; }
        public List<string> Items { get; }
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;

        public Order(int id, IEnumerable<string> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            Id = id;
            Items = new List<string>(items);
        }

        public void Complete()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException("Order cannot be completed.");
            Status = OrderStatus.Completed;
        }

        public override string ToString()
        {
            return $"Order #{Id} - {string.Join(", ", Items)} - {Status}";
        }
    }
}
