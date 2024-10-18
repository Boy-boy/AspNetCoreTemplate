using System;
using System.Threading.Tasks;
using Core.Uow;
using Template.Domain.Entities;
using Template.Domain.Repositories;

namespace Template.Application
{
    public class PaymentService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IOrderRepository orderRepository,
            IPaymentRepository paymentRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessPayment(Guid orderId, PaymentMethod method)
        {
            var order = await _orderRepository.FindAsync(orderId);
            var payment = new Payment(order.Id, order.TotalAmount, method);
            payment.Process();
            _paymentRepository.Add(payment);
            await _unitOfWork.CommitAsync();
        }
    }
}
