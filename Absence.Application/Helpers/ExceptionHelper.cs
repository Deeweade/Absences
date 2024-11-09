using Absence.Domain.Models.Exceptions;
using System.Runtime.CompilerServices;
using Absence.Domain.Models.Constants;
using Absence.Domain.Models.Enums;

namespace Absence.Application.Helpers;

public static class ExceptionHelper
{
    // Универсальный метод для стандартных исключений
    public static void Throw<TException>(ExceptionalEvents @event) where TException : Exception
    {
        var message = ExceptionMessages.GetMessage(@event);

        throw (TException)Activator.CreateInstance(typeof(TException), message)!;
    }

    // Универсальный метод для выбрасывания кастомного исключения с контекстом
    public static void ThrowContextualException<TException>(ExceptionalEvents @event,
        [CallerMemberName] string methodName = "", 
        [CallerFilePath] string className = "", 
        [CallerLineNumber] int lineNumber = 0) where TException : Exception
    {
        var message = ExceptionMessages.GetMessage(@event);

        var innerException = Activator.CreateInstance(typeof(TException), message);

        throw new ContextualException((TException)innerException, methodName, className, lineNumber);
    }

    // Универсальный метод для выбрасывания кастомного исключения с контекстом
    public static void ThrowContextualException<TException>(string message,
        [CallerMemberName] string methodName = "", 
        [CallerFilePath] string className = "", 
        [CallerLineNumber] int lineNumber = 0) where TException : Exception
    {
        var innerException = Activator.CreateInstance(typeof(TException), message);

        throw new ContextualException((TException)innerException, methodName, className, lineNumber);
    }
}