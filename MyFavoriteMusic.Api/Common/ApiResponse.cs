namespace MyFavoriteMusic.Api.Common
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string? message = null)
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message,
                Errors = null
            };
        }

        public static ApiResponse<T> FailureResponse(string? message = null, List<string>? erros = null) 
        {
            return new ApiResponse<T> {
                IsSuccess = false,
                Data = default,
                Message = message,
                Errors = erros 
            };
        }

    }
}
