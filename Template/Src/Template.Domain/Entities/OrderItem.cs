using Core.Ddd.Domain.Entities;
using System;

namespace Template.Domain.Entities
{
    /// <summary>
    /// 订单项
    /// </summary>
    public class OrderItem : Entity<Guid>
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }

        protected OrderItem() { }
        public OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = unitPrice * quantity;
        }
    }
}
