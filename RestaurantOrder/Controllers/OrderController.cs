using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Contracts;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMapper _mapper;



        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateOrder(int tablenumber, string notes)
        {
            var order = new Order { TableNumber = tablenumber, Notes = notes};
            orderService.CreateOrder(order); 

            var model = _mapper.Map<OrderDto>(order);

            return RedirectToAction("Index", "Home");
            
           
          
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {

            return View();
        }
    }
}
