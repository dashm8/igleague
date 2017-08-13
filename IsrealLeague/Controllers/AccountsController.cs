using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsrealLeague.Data;
using IsrealLeague.Models;

namespace IsrealLeague.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountContext _context;

        public AccountsController(AccountContext context)
        {
            _context = context;    
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {

            return View(await _context.users
                .OrderBy(usr => usr.score)
                .Reverse()
                .ToListAsync());
        }

        public async Task<IActionResult> Index(string usr)
        {
            return View(await _context.users.Where(Model => Model.username == usr).ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Profile(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.users
                .SingleOrDefaultAsync(m => m.ID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("username,password,email")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(account);
        }


    }
}
