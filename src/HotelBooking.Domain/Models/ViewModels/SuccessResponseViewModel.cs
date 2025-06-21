namespace HotelBooking.Domain.Models.ViewModels
{
    public class SuccessResponseViewModel<T> : ResponseViewModel<T>
    {
        public SuccessResponseViewModel(T Data, string message = "")
        {
            this.Data = Data;
            Message = message;
            IsSuccess = true;
            ErrorCode = HotelBooking.Domain.Enums.ErrorCode.NoError;
        }
    }
}
