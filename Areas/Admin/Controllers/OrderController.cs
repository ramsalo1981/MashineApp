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
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        //[BindProperty]
        //public OrderDetailsVM OrderVM { get; set; }

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index()
        {
            return View();
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetOrderList(string status)
        {
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            IEnumerable<OrderHeader> orderHeaderList;

            orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");

            //if (User.IsInRole(SD.Role_Admin))
            //{
            //    orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            //}
            //else
            //{
            //    orderHeaderList = _unitOfWork.OrderHeader.GetAll(
            //                            u => u.ApplicationUserId == claim.Value,
            //                            includeProperties: "ApplicationUser");
            //}

            //switch (status)
            //{
            //    case "pending":
            //        orderHeaderList = orderHeaderList.Where(o => o.PaymentStatus == SD.PaymentStatusDelayedPayment);
            //        break;
            //    case "inprocess":
            //        orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == SD.StatusApproved ||
            //                                                o.OrderStatus == SD.StatusInProcess ||
            //                                                o.OrderStatus == SD.StatusPending);
            //        break;
            //    case "completed":
            //        orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == SD.StatusShipped);
            //        break;
            //    case "rejected":
            //        orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == SD.StatusCancelled ||
            //                                                o.OrderStatus == SD.StatusRefunded ||
            //                                                o.OrderStatus == SD.PaymentStatusRejected);
            //        break;
            //    default:
            //        break;
            //}

            return Json(new { data = orderHeaderList });
        }
        #endregion
    }
}
