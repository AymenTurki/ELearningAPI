using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearningAPI.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize(Roles = "Learner")]
    public class FrontController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}