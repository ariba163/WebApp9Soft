using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp9Soft.Models.ViewModels
{
    public class contact
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = " Name *")]
        [Required]
        public string Name { get; set; }

        [Display(Name = " Email *")]
        [Required]
        public string Email { get; set; }

        [Display(Name = " Subject *")]
        [Required]
        public string Subject { get; set; }

        [Display(Name = " Contact No *")]
        [Required]
        public string ContactNo { get; set; }

        [Display(Name = " Please describe what you need.")]
        [Required]
        public string Message { get; set; }
        public string RequestNumber { get; set; }


    }
}