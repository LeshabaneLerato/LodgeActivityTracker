using System;
using System.ComponentModel.DataAnnotations;

namespace LodgeActivityTracker.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        public string ActivityName { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime ActivityDate { get; set; }

        public string Status { get; set; }  // Pending / Completed
    }
}
