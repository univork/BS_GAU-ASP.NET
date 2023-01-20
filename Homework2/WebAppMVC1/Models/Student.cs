using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework2.Models
{
    public class Student
    {
        //validations
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Enter First Name"),MaxLength(30)]
        [Display(Name ="Student name ")]
        public String FirstName { get; set; }

        [DataType(DataType.Text)]
        public String LastName{ get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "email not valid")]
        [DataType(DataType.Text)]
        public String Email{ get; set; }

        [DataType(DataType.Text)]
        public String Password { get; set; }

        [Compare("Password",ErrorMessage ="enter confirm password")]
    
        public String RepeatPassword { get; set; }


    }
}