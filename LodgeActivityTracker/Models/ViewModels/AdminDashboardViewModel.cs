using System.Collections.Generic;
using LodgeActivityTracker.Models;

public class AdminDashboardViewModel
{
    public int TotalActivities { get; set; }
    public int ActivitiesToday { get; set; }
    public List<Activity> RecentActivities { get; set; }
}
