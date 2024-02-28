using NewPlannerAPI.Domain.Models;
using NewPlannerAPI.Domain.Services;

namespace NewPlannerAPI.Infrastructure.Repositories
{
    public class PlannerQuery : IPlannerQuery
    {
        private readonly AppDbContext _appDbContext;
        public PlannerQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Response GetAll()
        {
            Response response = new ();
            try
            {

                List<PlannerHeader> result = (from ph in _appDbContext.TrtPlannerHeader
                              select new PlannerHeader
                              {
                                Id=ph.Id,
                                PlannerName=ph.PlannerName,
                                CreatedBy=ph.CreatedBy,
                                CreatedDatetime=ph.CreatedDatetime,
                                ModifiedBy=ph.ModifiedBy,
                                ModifiedDatetime=ph.ModifiedDatetime,
                                DeletedBy=ph.DeletedBy,
                                DeletedDatetime=ph.DeletedDatetime,

                              }).ToList();
                result.ForEach(x =>
                {
                    var planDetails = _appDbContext.TrtPlannerDetail.Where(f => f.HeaderId == x.Id).ToList();
                    if (planDetails.Count > 0 && planDetails != null)
                    {
                        x.PlannerDetail = planDetails;
                    }
                });

                response.Status = "Success";
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                response.StatusMessage = ex.Message;
                return response;
            }
        }

        public Response GetById(int id)
        {
            Response response = new ();
            try
            {
                PlannerHeader plannerHeader=new ();
                var resultData= _appDbContext.TrtPlannerHeader.Where(x=>x.Id == id).FirstOrDefault();
                var detailResult=_appDbContext.TrtPlannerDetail.Where(x=>x.HeaderId == id).ToList();
                plannerHeader.Id = resultData.Id;
                plannerHeader.PlannerName = resultData.PlannerName;
                plannerHeader.CreatedBy = resultData.CreatedBy;
                plannerHeader.CreatedDatetime = resultData.CreatedDatetime;
                plannerHeader.ModifiedBy = resultData.ModifiedBy;
                plannerHeader.ModifiedDatetime = resultData.ModifiedDatetime;
                plannerHeader.DeletedBy = resultData.DeletedBy;
                plannerHeader.DeletedDatetime = resultData.DeletedDatetime;
                plannerHeader.PlannerDetail = detailResult;

                response.Status = "Success";
                response.Data = plannerHeader;
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
