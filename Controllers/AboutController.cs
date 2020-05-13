using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpowerHealthyStudents.Data;
using EmpowerHealthyStudents.Models;
using EmpowerHealthyStudents.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices.ComTypes;
using System.IO;


namespace EmpowerHealthyStudents.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public IActionResult Index()
        {
            return View();
        }

       
    }
}