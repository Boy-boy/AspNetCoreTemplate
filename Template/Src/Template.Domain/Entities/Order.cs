using Core.Ddd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Template.Domain.Entities
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order : AggregateRoot<Guid>
    {
        public DateTime OrderDate { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        public OrderStatus Status { get; private set; }
        public decimal TotalAmount { get; private set; }

        protected Order() { }

        public Order(List<OrderItem> orderItems)
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.UtcNow;
            OrderItems = orderItems ?? new List<OrderItem>();
            Status = OrderStatus.Pending;
            TotalAmount = CalculateTotalAmount();
        }

        private decimal CalculateTotalAmount()
        {
            return OrderItems.Sum(item => item.TotalPrice);
        }

        public void Confirm()
        {
            if (Status == OrderStatus.Pending)
            {
                Status = OrderStatus.Confirmed;
            }
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Pending)
            {
                Status = OrderStatus.Cancelled;
            }
        }
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
}
