using System;
using Core.Ddd.Domain.Entities;

namespace Template.Domain.Entities
{
    /// <summary>
    /// 支付
    /// </summary>
    public class Payment : AggregateRoot<Guid>
    {
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentMethod Method { get; private set; }
        public PaymentStatus Status { get; private set; }

        protected Payment() { }
        public Payment(Guid orderId, decimal amount, PaymentMethod method)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            Method = method;
            Status = PaymentStatus.Pending;
        }

        public void Process()
        {
            if (Status == PaymentStatus.Pending)
            {
                Status = PaymentStatus.Processed;
            }
        }

        public void Fail()
        {
            if (Status == PaymentStatus.Pending)
            {
                Status = PaymentStatus.Failed;
            }
        }
    }

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer
    }

    public enum PaymentStatus
    {
        Pending,
        Processed,
        Failed
    }
}
