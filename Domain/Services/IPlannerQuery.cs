using NewPlannerAPI.Domain.Models;

namespace NewPlannerAPI.Domain.Services
{
    public interface IPlannerQuery
    {
        public Response GetById(int id);
        public Response GetAll();
    }
}
