using HemNet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemNet.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateContact(Contact contact)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            } else
            {
                return View("SuccessAddContact",contact);
            }

        }
    }

    
}
