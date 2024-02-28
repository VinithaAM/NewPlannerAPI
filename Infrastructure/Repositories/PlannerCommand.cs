using NewPlannerAPI.Domain.Models;
using NewPlannerAPI.Domain.Services;
using System.Reflection.PortableExecutable;

namespace NewPlannerAPI.Infrastructure.Repositories
{
    public class PlannerCommand : IPlannerCommand
    {
        private readonly AppDbContext _appDbContext;
        public PlannerCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Response Create(PlannerHeader plannerHeaders)
        {
            Response response = new();
            try
            {
                plannerHeaders.CreatedDatetime = DateTime.Now;
                foreach (var item in plannerHeaders.PlannerDetail)
                {
                    item.CreatedDatetime = DateTime.Now;
                }
                _appDbContext.AddRange(plannerHeaders);
                _appDbContext.SaveChanges();
                response.Status = "Success";
                response.StatusMessage = "Saved Successfully";
                response.Data= plannerHeaders;
                return response;
            }
            catch(Exception ex)
            {
                response.Status = "Failed";
                response.StatusMessage = ex.Message;
                return response;
            }
        }

        public Response Delete(int id)
        {
            Response response = new();
            try
            {
                var deleteDetail = _appDbContext.TrtPlannerHeader.Where(x => x.Id == id).FirstOrDefault();
                if(deleteDetail != null)
                {
                    _appDbContext.Remove(deleteDetail);
                    _appDbContext.SaveChanges();
                    response.Status = "Success";
                    response.StatusMessage = "Deleted Successfully";
                    
                }
                else
                {
                    response.Status = "Failed";
                    response.StatusMessage = "Record not Fount";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                response.StatusMessage = ex.Message;
                return response;
            }
        }

        public Response Update(PlannerHeader plannerHeaders)
        {
            Response response = new ();
            try
            {
               
                    plannerHeaders.ModifiedDatetime = DateTime.Now;
                    foreach (var item in plannerHeaders.PlannerDetail)
                    {
                        item.ModifiedDatetime = DateTime.Now;
                    }
                _appDbContext.UpdateRange(plannerHeaders);
                _appDbContext.SaveChanges();
                response.Status = "Success";
                response.StatusMessage = "Updated SuccessFully";
                response.Data = plannerHeaders;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                response.StatusMessage = ex.Message;
                return response;
            }
        }
    }
}
