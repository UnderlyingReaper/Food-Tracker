using Food_Tracker_Backend.DTOs;

namespace Food_Tracker_Backend.Interfaces
{
    public interface IBudgetService
    {
        public Task<BudgetDashboardDTO> GetDashboardAsync();
    }
}
