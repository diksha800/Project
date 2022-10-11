using HomeCare.Infrastructure;
using HomeCare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeCare.ViewModel
{
    public class AppointmentViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Specialist { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        [CurrentDate
        (ErrorMessage = "Appointment Date must be greater than or equal to Today's Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDate { get; set; }
    }
}