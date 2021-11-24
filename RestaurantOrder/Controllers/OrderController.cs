using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Models;
using RestaurantOrder.Services.Contracts;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMapper _mapper;
        private readonly IDishService _dishService;
        private readonly INeededDishService _neededDishService;



        public OrderController(IOrderService orderService, IMapper mapper, IDishService dishService, INeededDishService neededDishService)
        {
            this.orderService = orderService;
            _mapper = mapper;
            _dishService = dishService;
            _neededDishService = neededDishService;
        }

        [HttpPost]
        public IActionResult CreateOrder(int tableNumber, string notes)
        {
            var order = new Order { TableNumber = tableNumber, Notes = notes};
            var createdOrder = orderService.CreateOrder(order); 

            var model = _mapper.Map<OrderDto>(order);
            

            return RedirectToAction("GetAll", "Dish", new{id= createdOrder.OrderId});
        }



        [HttpGet]
        public ActionResult<Order> GetAll()
        {
            //ViewBag.OrderId = id;
            ViewModel viewModel = new ViewModel{Orders = orderService.GetAll(), NeededDishes = _neededDishService.GetAll()
            
        };
        return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {

            return View();
        }

            [HttpGet]
            public ActionResult<Dish> Menu(int id)
            {
                ViewBag.OrderId = id;

                return View(_dishService.GetAll());
            }
        

        [HttpGet]
        public IActionResult DeleteOrder()
        {

            return View();
        }
        [HttpPost]
        public ActionResult<Order> DeleteOrder(int id)
        {
            orderService.DeleteOrder(id);
            return RedirectToAction("DeleteOrder", "Order");
        }
    }
}
