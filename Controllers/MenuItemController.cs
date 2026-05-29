using MangoFusion_API.Data;
using MangoFusion_API.Models;
using MangoFusion_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MangoFusion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ApiResponse _response;
        private readonly IWebHostEnvironment _env;
        public MenuItemController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _response = new ApiResponse();
            _env = env;
        }
        [HttpGet]
        public IActionResult GetMenuItems()
        {
            _response.Result = _db.MenuItems.ToList();
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpGet("{id:int}", Name = "GetMenuItem")]
        public IActionResult GetMenuItems(int id)
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            MenuItem? menuItem = _db.MenuItems.FirstOrDefault(u => u.Id == id);
            _response.Result = menuItem;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse>> CreateMenuItem([FromForm] MenuItemCreateDTO menuItemCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (menuItemCreateDTO.File == null || menuItemCreateDTO.File.Length == 0)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.ErrorMessage = ["file is required."];
                        return BadRequest(_response);
                    }
                    var imagesPath = Path.Combine(_env.WebRootPath, "images");
                    if (!Directory.Exists(imagesPath))
                    {
                        Directory.CreateDirectory(imagesPath);
                    }
                    var filePath = Path.Combine(imagesPath, menuItemCreateDTO.File.FileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    //uploading the images
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await menuItemCreateDTO.File.CopyToAsync(stream);
                    }
                    MenuItem menuItem = new ()
                    {
                        Name = menuItemCreateDTO.Name,
                        Description = menuItemCreateDTO.Description,
                        Category = menuItemCreateDTO.Category,
                        SpecialTag = menuItemCreateDTO.SpecialTag,
                        Price = menuItemCreateDTO.Price,
                        Image = "images/" + menuItemCreateDTO.File.FileName
                    };
                    _db.MenuItems.Add(menuItem);
                    await _db.SaveChangesAsync();
                    _response.Result = menuItem;
                    _response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetMenuItem", new { id = menuItem.Id }, _response);
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = [ex.ToString()];
            }
            return BadRequest(_response);
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ApiResponse>> UpdateMenuItem(int id,[FromForm] MenuItemUpdateDTO menuItemUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (menuItemUpdateDTO.File == null || menuItemUpdateDTO.Id!=id)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                       // _response.ErrorMessage = ["file is required."];
                        return BadRequest(_response);
                    }
                    MenuItem? menuItemFromDb = _db.MenuItems.FirstOrDefault(u => u.Id == id);
                    if (menuItemFromDb == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        //_response.ErrorMessage = ["MenuItem not found."];
                        return BadRequest(_response);
                    }
                    menuItemFromDb.Name = menuItemUpdateDTO.Name;
                    menuItemFromDb.Description = menuItemUpdateDTO.Description;
                    menuItemFromDb.Category = menuItemUpdateDTO.Category;
                    menuItemFromDb.SpecialTag = menuItemUpdateDTO.SpecialTag;
                    menuItemFromDb.Price = menuItemUpdateDTO.Price;
                    if (menuItemUpdateDTO.File != null && menuItemUpdateDTO.File.Length > 0)
                    {

                        var imagesPath = Path.Combine(_env.WebRootPath, "images");
                        if (!Directory.Exists(imagesPath))
                        {
                            Directory.CreateDirectory(imagesPath);
                        }
                        var filePath = Path.Combine(imagesPath, menuItemUpdateDTO.File.FileName);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }

                        var filePath_OldFile = Path.Combine(_env.WebRootPath, menuItemFromDb.Image);
                        if (System.IO.File.Exists(filePath_OldFile))
                        {
                            System.IO.File.Delete(filePath_OldFile);
                        }

                        //uploading the images
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await menuItemUpdateDTO.File.CopyToAsync(stream);
                        }
                        menuItemFromDb.Image = "images/" + menuItemUpdateDTO.File.FileName;
                    }
                    
                   
                    _db.MenuItems.Update(menuItemFromDb);
                    await _db.SaveChangesAsync();
                   _response.StatusCode = HttpStatusCode.Created;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = [ex.ToString()];
            }
            return BadRequest(_response);
        }
    }
}

