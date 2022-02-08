using BlazorChat.Server.Models;
using BlazorChat.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly BlazingChatContext _context;

        public UserController(ILogger<UserController> logger, BlazingChatContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public List<Contact> Get()
        {
            //Convert users to contacts
            List<User> users = _context.Users.ToList();
            List<Contact> contacts = new List<Contact>();

            foreach (var user in users)
            {
                contacts.Add(new Contact(user.FirstName, user.LastName));
            }
            return contacts;
        }
    }
}
