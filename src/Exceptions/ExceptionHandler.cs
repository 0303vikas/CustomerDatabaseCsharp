namespace src.Exceptions;

public class FileException : Exception
{
    private string _errorMessage;
    private int _errorCode;

    public FileException(string errorMessage, int errorCode)
    {
        _errorMessage = errorMessage;
        _errorCode = errorCode;
    }

    public static FileException FetchException(string? message)
    {
        return new FileException(message ?? "Error Fetching Data: Cann't retrive data from database", 500);
    }

    public static FileException AddingNewException(string? message)
    {
        return new FileException(message ?? "Error Adding Data: Cann't add data from database", 500);
    }

    public static FileException ModifyDataException(string? message)
    {
        return new FileException(message ?? "Error Updating Data: Cann't update data in database", 500);
    }
}