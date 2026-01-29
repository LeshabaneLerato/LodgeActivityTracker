using LodgeActivityTracker.Models;

namespace LodgeActivityTracker.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public List<Activity> RecentActivities { get; set; } = new();
        public int TotalActivities { get; set; }
        public int PendingCount { get; set; }
        public int ApprovedCount { get; set; }
        public int RejectedCount { get; set; }
    }
}
