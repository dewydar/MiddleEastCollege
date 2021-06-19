using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiddleEastCollege.Models
{
    [MetadataType(typeof(AppointmentMetaData))]
    public partial class Appointment
    {
    }
    public class AppointmentMetaData
    {
        [Display(Name = "StudentData", ResourceType = typeof(Resource))]
        [Required]
        [MaxLength(200)]
        public string StudentData { get; set; }
        [Display(Name = "StudentID", ResourceType = typeof(Resource))]
        [Required]
        public long StudentID { get; set; }
        [Display(Name = "Section", ResourceType = typeof(Resource))]
        [Required]
        [MaxLength(200)]
        public string Section { get; set; }
        [Display(Name = "TeacherName", ResourceType = typeof(Resource))]
        [Required]
        [MaxLength(200)]
        public string TeacherName { get; set; }
        [Display(Name = "Subject", ResourceType = typeof(Resource))]
        [Required]
        [MaxLength(200)]
        public string Subject { get; set; }
        [Display(Name = "Date", ResourceType = typeof(Resource))]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}