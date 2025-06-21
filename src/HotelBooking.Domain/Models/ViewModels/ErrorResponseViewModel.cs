using HotelBooking.Domain.Enums;

namespace HotelBooking.Domain.Models.ViewModels
{
    public class ErrorResponseViewModel : ResponseViewModel<object>
    {
        public ErrorResponseViewModel(string message = "", ErrorCode errorCode = ErrorCode.SomethingWentWrong)
        {
            Data = null;
            Message = message;
            IsSuccess = false;
            ErrorCode = errorCode;
        }
    }
}
