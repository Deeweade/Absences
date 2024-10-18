namespace Absence.Domain.Models.Exceptions;

public class ContextualException : Exception
{
    public new Exception InnerException { get; set; }
    public string MethodName { get; private set; }
    public string ClassName { get; private set; }
    public int LineNumber { get; private set; }
    public new string Message { get; set; } = string.Empty;

    public ContextualException(Exception innerException, string methodName = "", 
        string className = "", int lineNumber = 0, string message = null)
    {
        InnerException = innerException;
        MethodName = methodName;
        ClassName = className;
        LineNumber = lineNumber;
        Message = message;
    }

    public override string ToString()
    {
        return $"Exception occurred in method {MethodName} of class {ClassName} at line {LineNumber}. " +
               $"Message: {Message}. InnerException: {InnerException?.Message}";
    }
}