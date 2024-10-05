using WebService.Business.Result.Template.Process;

namespace WebService.Business.Result.Template.Query
{
    public class QueryResult<T> : ProcessResult where T : class
    {
        public T? Data { get; set; }
        public QueryResult() { }
        public QueryResult(bool status, string message, T? data) 
        {
            Status = status;
            Message = message;
            Data = data;
        }
        public QueryResult<T> SetResult(bool status, string message, T? data)
        {
            Status = status;
            Message = message;
            Data = data;
            return this;
        }
    }
}
