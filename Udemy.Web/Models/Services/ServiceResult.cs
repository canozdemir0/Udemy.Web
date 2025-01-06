namespace Udemy.Web.Models.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public string? SuccessMessage { get; set; }

        public bool IsFail => Errors is not null && Errors.Count > 0;

        public bool IsSuccess => !IsFail;

        public static ServiceResult<T> Success(T data, string? successMessage = null)
        {
            return new ServiceResult<T>
            {
                Data = data,
                SuccessMessage = successMessage
            };
        }

        public static ServiceResult<T> Error(string error)
        {
            return new ServiceResult<T>
            {
                Errors = [error]
            };
        }

        public static ServiceResult<T> Error(List<string> errors)
        {
            return new ServiceResult<T>
            {
                Errors = errors
            };
        }
    }

    public class ServiceResult
    {
        public List<string>? Errors { get; set; }
        public bool IsFail => Errors is not null && Errors.Count > 0;
        public bool IsSuccess => !IsFail;
        public string? SuccessMessage { get; set; }

        public static ServiceResult Success(string? successMessage = null)
        {
            return new ServiceResult()
            {
                SuccessMessage = successMessage
            };
        }

        public static ServiceResult Error(string error)
        {
            return new ServiceResult
            {
                Errors = [error]
            };
        }

        public static ServiceResult Error(List<string> errors)
        {
            return new ServiceResult
            {
                Errors = errors
            };
        }
    }
}
