using ECocktails.Domain.Base;
using ECocktails.Domain.DomainModels;
using ECocktails.Repository.Interface;
using ECocktails.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetDetailsForOder(BaseEntity model)
        {
            return _orderRepository.GetOrderDetails(model);
        }
    }
}
