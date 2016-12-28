using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusHostel.Web.Models
{
    public class BookingModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(20, MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a message.")]
        [StringLength(1024, MinimumLength = 1)]
        public string Message { get; set; }
    }
}