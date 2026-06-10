using MangoFusion_API.Data;
using MangoFusion_API.Models;
using MangoFusion_API.Models.Dto;
using MangoFusion_API.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MangoFusion_API.Controllers
{
  
        [ApiController]
        [Route("api/[controller]")]

        public class OrderDetailsController : Controller
        {
            private readonly ApplicationDbContext _db;
            private readonly ApiResponse _response;
            public OrderDetailsController(ApplicationDbContext db, ApiResponse response)
            {
                _db = db;
                _response = new ApiResponse();
            }
        [HttpPut("{orderDetailsId:int}")]
        public ActionResult<ApiResponse> UpdateOrder(int orderDetailsId, [FromBody] OrderDetailsUpdateDTO orderDetailsDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(orderDetailsId != orderDetailsDTO.OrderDetailId)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.ErrorMessage.Add("order id mismatch");
                        return BadRequest(_response);
                    }
                    OrderDetail? orderDetailsFromDb = _db.OrderDetails.FirstOrDefault(u => u.OrderDetailId == orderDetailsId);
                    if (orderDetailsFromDb == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.ErrorMessage.Add("order not found");
                        return NotFound(_response);
                    }
                    
                     orderDetailsFromDb.Rating = orderDetailsDTO.Rating;   
                    _db.SaveChanges();
                    _response.StatusCode = HttpStatusCode.Created;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = ModelState.Values.SelectMany(u => u.Errors).
                        Select(u => u.ErrorMessage).ToList();
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessage.Add(ex.Message);
                return BadRequest(_response);
            }
        }
    }
}
