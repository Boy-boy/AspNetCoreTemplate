using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Uow;
using Template.Domain.Entities;
using Template.Domain.Repositories;
using Template.Infrastructure.Dtos;

namespace Template.Application
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            return (await _orderRepository.FindAllAsync(p => true))
                .Select(order => new OrderDto
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    OrderItems = order.OrderItems.Select(item => new OrderItemDto
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        TotalPrice = item.TotalPrice
                    }).ToList(),
                    Status = order.Status,
                    TotalAmount = order.TotalAmount
                })
                .ToList();
        }

        public async Task CreateOrder(List<CreateOrderItemDto> orderItems)
        {
            var orderItemsDomain = orderItems.Select(item =>
            {
                var product = _productRepository.FindAsync(item.ProductId).GetAwaiter().GetResult();
                return new OrderItem(item.ProductId, item.Quantity, product.Price);
            }).ToList();

            var order = new Order(orderItemsDomain);
            _orderRepository.Add(order);
            await _unitOfWork.CommitAsync();
        }

        public async Task ConfirmOrder(Guid orderId)
        {
            var order = await _orderRepository.FindAsync(orderId);
            order.Confirm();
            _orderRepository.Update(order);
            await _unitOfWork.CommitAsync();
        }

        public async Task CancelOrder(Guid orderId)
        {
            var order = await _orderRepository.FindAsync(orderId);
            order.Cancel();
            _orderRepository.Update(order);
            await _unitOfWork.CommitAsync();
        }
    }
}
