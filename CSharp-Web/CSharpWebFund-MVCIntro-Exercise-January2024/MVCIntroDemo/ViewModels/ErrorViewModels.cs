namespace MVCIntroDemo.ViewModels
{
    public class ErrorViewModels
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
