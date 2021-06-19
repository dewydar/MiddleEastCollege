using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiddleEastCollege.Models
{
    [MetadataType(typeof(EnquiryMetaData))]
    public partial class Enquiry
    {
    }
    public class EnquiryMetaData
    {
        [Display(Name = "StudentName", ResourceType = typeof(Resource))]
        [Required]
        [MaxLength(200)]
        public string StudentName { get; set; }
        [Display(Name = "StudentID", ResourceType = typeof(Resource))]
        [Required]
        public long StudentID { get; set; }
        [Required]
        public long EnquiryType { get; set; }
        [Display(Name = "Section", ResourceType = typeof(Resource))]
        [Required]
        [MaxLength(200)]
        public string Section { get; set; }
        [Display(Name = "Subject", ResourceType = typeof(Resource))]
        [Required]
        [MaxLength(4000)]
        public string Subject { get; set; }
    }
}