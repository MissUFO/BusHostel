using BusHostel.BusinessService;
using BusHostel.Repository.BusinessObjects;
using BusHostel.Web.Models;
using BusHostel.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BusHostel.Web.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Home Page Booking
        public ActionResult HomePageBooking()
        {
            BookingModel booking = new BookingModel();
            if (TempData.ContainsKey("BookingModel"))
                booking = TempData["BookingModel"] as BookingModel;

            if (TempData.ContainsKey("IsBookingSuccess")==false)
                TempData["IsBookingSuccess"] = false;

            return PartialView(booking);
        }

        [HttpPost]
        public ActionResult HomePageBooking(BookingModel booking)
        {
            if (ModelState.IsValid == false)
            {
                TempData["BookingModel"] = booking;
                return RedirectToAction("Index", "Home");
            }
                
            try
            {
                //send email
                SmtpClient smtpClient = new SmtpClient();
                EmailArg emailArg = new EmailArg
                {

                    From = Settings.Default.EmailFrom,
                    Tos = Settings.Default.EmailTo,
                    Body = string.Format(Settings.Default.EmailBody, booking.Name, booking.Email, booking.Phone, booking.Message),
                    Subject = Settings.Default.EmailSubject,
                    Host = smtpClient.Host,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Port = smtpClient.Port
                };
                NotificationService srv = new NotificationService();
                srv.SendEmail(emailArg);

                TempData["IsBookingSuccess"] = true;
            }
            catch (Exception ex)
            {
                TempData["IsBookingSuccess"] = false;
                TempData["BookingModel"] = booking;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}