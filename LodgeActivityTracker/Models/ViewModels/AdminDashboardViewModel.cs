using LodgeActivityTracker.Models;
using System.Collections.Generic;

namespace LodgeActivityTracker.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalActivities { get; set; }
        public List<Activity> RecentActivities { get; set; } = new();
    }
}
