namespace BLL
{
    public class BaseResponse
    {
        public int _responseCode { get; set; }
        public string _message { get; set; }

        public BaseResponse(int responseCode, string message)
        {
            _responseCode = responseCode;
            _message = message;
        }
    }
}