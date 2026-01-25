using System;
using System.ComponentModel.DataAnnotations;

namespace LodgeActivityTracker.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Activity Name is required")]
        public string ActivityName { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // default to Pending
    }
}
