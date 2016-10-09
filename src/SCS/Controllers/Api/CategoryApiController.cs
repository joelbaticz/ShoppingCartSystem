using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860


using SCS.Models;
using SCS.Services;

using System.Net;

using SCS.ViewModels;


namespace SCS.Controllers.Api
{
    
    public class CategoryApiController : Controller
    {

        private ICategoryRepository _catRepo;

        public CategoryApiController(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
        }

        [HttpGet("api/categories")]
        public JsonResult GetCategories()
        {
            //return Json(new { name = "Welcome" });
            try
            {
                var result = _catRepo.GetAll();
                return Json(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = ex.Message });
            }
        }


        [HttpPost("api/categories")]
        //FromBody is telling .NET that be careful you are receiving Json in Html Body

        //No longer passing Category, but CategoryViewModel for validation
        //public JsonResult PostCategory([FromBody] Category aCat)
        public JsonResult PostCategory([FromBody] CategoryViewModel vm)
        {
            /*
            try
            { 
                return Json(true);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                //return Json(new { message = "error" });
                return Json(new { message =  ex.Message });
            }
            */
            try
            {
                if (ModelState.IsValid)
                {
                    //map to model
                    Category cat = new Category
                    {
                        Name = vm.Name,
                        Description = vm.Description
                    };

                    //save to database
                    _catRepo.Create(cat);

                    return Json(cat);
                }
                //invalid
                //we are throwing back the ModelState object in a json form
                //The server is still happy, but the request is bad
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = "failed", ModelState = ModelState });
                
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //return Json(new { message = "error" });
                return Json(new { message = ex.Message });
            }

        }

    }
}
