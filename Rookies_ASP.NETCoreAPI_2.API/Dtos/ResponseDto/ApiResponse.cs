namespace Rookies_ASP.NETCoreAPI_2.API.Dtos.ResponseDto
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } = StatusCodes.Status200OK;

        public string Message { get; set; } = string.Empty;

        public object Data { get; set; } = new { };
    }
}
