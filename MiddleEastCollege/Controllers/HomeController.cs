using MiddleEastCollege.BLL;
using MiddleEastCollege.Common;
using MiddleEastCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MiddleEastCollege.Common.CommonEnum;

namespace MiddleEastCollege.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AppointmentForm()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AppointmentForm(Appointment model)
        {
            if (Request["submit"] != null)
            {
                ModelState.Remove("AppointmentID");
                if (ModelState.IsValid)
                {
                    string message = string.Empty;
                    string messageTitle = string.Empty;
                    CommonBLL _bll = new CommonBLL();
                    var result = _bll.SaveData(model, out message, out messageTitle);
                    if (result)
                    {
                        TempData["Message"] = General.BuildToastMessage(messageTitle, message, ToastType.success);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Message"] = General.BuildToastMessage(messageTitle, message, ToastType.error);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    return View(model);
                }
            }
            else if (Request["cancel"] != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public ActionResult EnquiryForm()
        {
            CommonBLL _bll = new CommonBLL();
            ViewBag.Types = _bll.Types("EnquiryType");
            return View();
        }
        [HttpPost]
        public ActionResult EnquiryForm(Enquiry model)
        {
            if (Request["submit"] != null)
            {
                CommonBLL _bll = new CommonBLL();

                ModelState.Remove("EnquiryID");
                if (ModelState.IsValid)
                {
                    string message = string.Empty;
                    string messageTitle = string.Empty;
                    var result = _bll.SaveData(model, out message, out messageTitle);
                    if (result)
                    {
                        TempData["Message"] = General.BuildToastMessage(messageTitle, message, ToastType.success);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Message"] = General.BuildToastMessage(messageTitle, message, ToastType.error);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {

                    ViewBag.Types = _bll.Types("EnquiryType");

                    return View(model);
                }
            }
            else if (Request["cancel"] != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public ActionResult ComplaintForm()
        {
            CommonBLL _bll = new CommonBLL();
            ViewBag.Types = _bll.Types("ComplaintType");
            return View();
        }
        [HttpPost]
        public ActionResult ComplaintForm(Complaint model)
        {
            if (Request["submit"] != null)
            {
                ModelState.Remove("ComplaintID");
                CommonBLL _bll = new CommonBLL();
                if (ModelState.IsValid)
                {
                    string message = string.Empty;
                    string messageTitle = string.Empty;
                    var result = _bll.SaveData(model, out message, out messageTitle);
                    if (result)
                    {
                        TempData["Message"] = General.BuildToastMessage(messageTitle, message, ToastType.success);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Message"] = General.BuildToastMessage(messageTitle, message, ToastType.error);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    ViewBag.Types = _bll.Types("ComplaintType");
                    return View(model);
                }
            }
            else if (Request["cancel"] != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult SetCulture(string _culture)
        {
            SetCulturelang(_culture);
            return RedirectToAction("Index");
        }
        public void SetCulturelang(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                string[] myCookies = Request.Cookies.AllKeys;
                Response.Cookies["_culture"].Expires = DateTime.Now.AddDays(-1);
                cookie.Value = culture;   // update cookie value
            }
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
            }
            if (culture.Contains("en"))
            {
                General.CurrentLang = (int)CommonEnum.CurrentLang.FirstLang;
            }
            else
            {
                General.CurrentLang = (int)CommonEnum.CurrentLang.ScoundLang;

            }
            cookie.Expires = DateTime.Now.AddYears(1);

            Response.Cookies.Add(cookie);
        }
    }
}