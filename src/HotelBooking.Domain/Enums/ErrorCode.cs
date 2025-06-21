namespace HotelBooking.Domain.Enums
{
    public enum ErrorCode
    {
        NoError = 0,
        SomethingWentWrong = 500,


        InvalidRoomID = 100,
        RoomNotFound = 101,
        RoomAlreadyExist= 102,


    }
} 