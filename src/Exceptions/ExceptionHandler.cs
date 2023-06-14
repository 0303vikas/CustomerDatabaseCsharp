using System;
namespace src.Exceptions;

public class HandlerExceptions : Exception
{
    private string _errorMessage;
    private int _errorCode;

    public HandlerExceptions(string errorMessage, int errorCode)
    {
        _errorMessage = errorMessage;
        _errorCode = errorCode;
    }

    public static HandlerExceptions FetchException(string? message)
    {
        return new HandlerExceptions(message ?? "Error Fetching Data: Cann't retrive data from database", 500);
    }

    public static HandlerExceptions AddingNewException(string? message)
    {
        return new HandlerExceptions(message ?? "Error Adding Data: Cann't add data from database", 500);
    }

    public static HandlerExceptions ModifyDataException(string? message)
    {
        return new HandlerExceptions(message ?? "Error Updating Data: Cann't update data in database", 500);
    }

    public static HandlerExceptions UniqueIdAndEmailException(string message)
    {
        return new HandlerExceptions(message, 500);
    }

    public static HandlerExceptions CustomerExistanceException(string message)
    {
        return new HandlerExceptions(message, 500);
    }

    public static HandlerExceptions MissingParameterException(string message)
    {
        return new HandlerExceptions(message, 500);
    }
}