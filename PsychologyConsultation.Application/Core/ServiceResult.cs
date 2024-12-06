namespace PsychologyConsultation.Application.Core
{
    public class ServiceResult<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public ServiceResult(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
    }
}
