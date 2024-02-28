using NewPlannerAPI.Domain.Models;

namespace NewPlannerAPI.Domain.Services
{
    public interface IPlannerCommand
    {
        public Response Create(PlannerHeader plannerHeaders);
        public Response Update(PlannerHeader plannerHeaders);
        public Response Delete(int id);
    }
}
