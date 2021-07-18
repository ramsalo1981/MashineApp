using Dapper;
using MachineApp.DataAccess.Repository.IRepository;
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
    public class ApplicationTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ApplicationType applicationType = new ApplicationType();
            if (id == null)
            {
                //this is for create
                return View(applicationType);
            }
            //this is for edit
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            applicationType = _unitOfWork.SP_Call.OneRecord<ApplicationType>(SD.Proc_ApplicationType_Get, parameter);
            if (applicationType == null)
            {
                return NotFound();
            }
            return View(applicationType);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Name", applicationType.Name);
                if (applicationType.Id == 0)
                {
                    _unitOfWork.SP_Call.Execute(SD.Proc_ApplicationType_Create, parameter);

                }
                else
                {
                    parameter.Add("@Id", applicationType.Id);
                    _unitOfWork.SP_Call.Execute(SD.Proc_ApplicationType_Update, parameter);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationType);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.SP_Call.List<ApplicationType>(SD.Proc_ApplicationType_GetAll, null);
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            var objFromDb = _unitOfWork.SP_Call.OneRecord<ApplicationType>(SD.Proc_ApplicationType_Get, parameter);
            if (objFromDb == null)
            {
                //TempData["Error"] = "Error deleting Category";
                return Json(new { success = false, message = "Fel vid radering" });
            }

            _unitOfWork.SP_Call.Execute(SD.Proc_ApplicationType_Delete, parameter);
            _unitOfWork.Save();

            //TempData["Success"] = "Category successfully deleted";
            return Json(new { success = true, message = "Radera lyckades" });

        }

        #endregion
    }
}
