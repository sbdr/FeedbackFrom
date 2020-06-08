using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FeedbackFrom.Models
{
    public class FeedbackModels
    {
        public int? FeedbackId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string FeedbackName { get; set; }
        [Display(Name = "Start Date")]
        
        public string StartDate { get; set; }
        [Display(Name = "End Date")]
        
        public string EndDate { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be atleast {2} characters long and maximum {1} characters", MinimumLength = 10)]
        public string FeedbackDescription { get; set; }
        public List<Department> Departments { get; set; }
        [Display(Name = "Department")]
        public int Departmentid { get; set; }
        public int Range { get; set; }

        [Display(Name = "No Of Checkboxes")]
        public int CheckBoxNo { get; set; }
        public List<Question> Questions { get; set; }
        [Display(Name = "Questions")]
        public int[] QuestionIds { get; set; }

        public FeedbackModels()
        {
            Departments = new List<Department>();
            Questions = new List<Question>();
        }
    }

    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleText { get; set; }
    }
}