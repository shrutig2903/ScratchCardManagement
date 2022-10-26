namespace ScratchCardManagement.ViewModels
{
    public class BaseResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object Data { get; set; }
    }
}
