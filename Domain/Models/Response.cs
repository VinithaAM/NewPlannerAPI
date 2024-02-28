namespace NewPlannerAPI.Domain.Models
{
    public class Response
    {
        public string? Status { get; set; }
        public string? StatusMessage { get; set; }
        public dynamic? Data { get; set; }
    }
}
