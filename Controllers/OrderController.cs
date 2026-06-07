using MangoFusion_API.Data;
using MangoFusion_API.Models;
using MangoFusion_API.Models.Dto;
using MangoFusion_API.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MangoFusion_API.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ApiResponse _response;
        public OrderController(ApplicationDbContext db, ApiResponse response)
        {
            _db = db;
            _response = response;
        }
        [HttpGet]
        public ActionResult<ApiResponse> GetOrders( string userId="")
        {
           IEnumerable<OrderHeader> orderHeaderList = _db.OrderHeaders.Include(u => u.OrderDetails)
                .ThenInclude(u => u.MenuItem).OrderByDescending(u => u.OrderHeaderId);
            if (!string.IsNullOrEmpty(userId))
            {
                orderHeaderList = orderHeaderList.Where(u => u.ApplicationUserId == userId);
            }
            _response.Result = orderHeaderList;
            _response.StatusCode = HttpStatusCode.OK;
            return  Ok(_response);
        }

        [HttpGet("{orderId:int}")]
        public ActionResult<ApiResponse> GetOrders(int orderId)
        {
            if(orderId ==0)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Invalid order id");
                return BadRequest(_response);
            }



            OrderHeader? orderHeader = _db.OrderHeaders.Include(u => u.OrderDetails)
                 .ThenInclude(u => u.MenuItem).FirstOrDefault(u => u.OrderHeaderId ==orderId);
            if (orderHeader == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("order not found");
                return NotFound(_response);
            }
            _response.Result = orderHeader;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpPost]
        public ActionResult<ApiResponse> CreateOrder([FromBody] OrderHeaderCreateDTO orderHeaderDTO)
        {
            try
            {
                if (ModelState.IsValid) { 
                OrderHeader orderHeader = new()
                {
                    PickUpName = orderHeaderDTO.PickUpName,
                    PickUpPhoneNumber = orderHeaderDTO.PickUpPhoneNumber,
                    PickUpEmail = orderHeaderDTO.PickUpEmail,
                    OrderDate = DateTime.Now,
                    ApplicationUserId = orderHeaderDTO.ApplicationUserId,
                    OrderTotal = orderHeaderDTO.OrderTotal,
                    Status = SD.status_confirmed,
                    TotalItem = orderHeaderDTO.TotalItem

                };
                    _db.OrderHeaders.Add(orderHeader);
                    _db.SaveChanges();
                    foreach (var orderDetailDto in orderHeaderDTO   .OrderDetails)
                    {
                        OrderDetail orderDetail = new()
                        {
                            OrderHeaderId = orderHeader.OrderHeaderId,
                            MenuItemId = orderDetailDto.MenuItemId,
                           Quantity = orderDetailDto.Quantity,
                            ItemName = orderDetailDto.ItemName,
                            Price = orderDetailDto.Price
                        };
                        _db.OrderDetails.Add(orderDetail);
                        
                    }
                    _db.SaveChanges();
                    _response.Result = orderHeader;
                    orderHeader.OrderDetails = [];
                    _response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtAction(nameof(GetOrders), new { orderId = orderHeader.OrderHeaderId }, _response);
                }
                else
                {
                        _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage=ModelState.Values.SelectMany(u=>u.Errors).
                        Select(u => u.ErrorMessage).ToList();
                    return BadRequest(_response);
                }
            }
            catch(Exception ex)
            {
                 _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessage.Add(ex.Message);
                return BadRequest(_response);
            }
        }
    }
}
