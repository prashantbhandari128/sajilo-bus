using WebService.Business.Result.Template.Process;

namespace WebService.Business.Result.Template.Query
{
    public class QueryResultList<T> : ProcessResult where T : class
    {
        public int Count { get; set; } = 0;
        public List<T>? Data { get; set; }
        public QueryResultList() { }
        public QueryResultList(bool status, string message, List<T>? data) 
        {
            Status = status;
            Message = message;
            if (data != null)
            {
                Count = data.Count;
            }
            Data = data;
        }
        public QueryResultList<T> SetResult(bool status, string message, List<T>? data)
        {
            Status = status;
            Message = message;
            if (data != null)
            {
                Count = data.Count;
            }
            Data = data;
            return this;
        }
    }
}
