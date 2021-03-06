using MachineApp.DataAccess.Data;
using MachineApp.Models;
using MachineApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
       

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _db.ApplicationUsers.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                
            }

            return Json(new { data = userList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Fel vid låsning / upplåsning" });
            }
            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked, we will unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "Operationen lyckades." });
        }

        //public async Task<IActionResult> InactiveDelete(string id)
        //{
        //    if (id == null || id.Trim().Length == 0)
        //    {
        //        return NotFound();
        //    }

        //    var userFromDb = await _db.ApplicationUsers.FindAsync(id);
        //    if (userFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userFromDb);
        //}

        ////Post Delete
        //[HttpPost, ActionName("InactiveDelete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult InActiveDeletePOST(string id)
        //{


        //    ApplicationUser userFromDb = _db.ApplicationUsers.Where(u => u.Id == id).FirstOrDefault();
        //    userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
        //    _db.Users.Remove(userFromDb);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion
    }
}
