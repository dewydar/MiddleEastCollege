using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiddleEastCollege.Models
{
    [MetadataType(typeof(ComplaintMetaData))]
    public partial class Complaint
    {
    }
    public class ComplaintMetaData
    {
        [Display(Name = "StudentName", ResourceType = typeof(Resource))]
        [MaxLength(200)]
        public string StudentName { get; set; }
        [Display(Name = "StudentID", ResourceType = typeof(Resource))]
        public long StudentID { get; set; }
        [Display(Name = "ComplaintType", ResourceType = typeof(Resource))]
        [Required]
        public long ComplaintType { get; set; }
        [Display(Name = "Subject", ResourceType = typeof(Resource))]
        [Required]
        [MaxLength(4000)]
        public string Subject { get; set; }
    }
}