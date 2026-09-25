namespace SunamoEditorConfig._public;

/// <summary>
/// Represents a result that can contain either a successful result value or an exception message
/// </summary>
/// <typeparam name="T">The type of the result value</typeparam>
public class ResultWithExceptionEditorConfig<T>
{
    /// <summary>
    /// Gets or sets the successful result value (null if an exception occurred)
    /// </summary>
    public T? Result { get; set; }

    /// <summary>
    /// Initializes a new instance with a successful result
    /// </summary>
    /// <param name="result">The successful result value</param>
    public ResultWithExceptionEditorConfig(T? result)
    {
        Result = result;
    }

    /// <summary>
    /// Gets or sets the exception message (null if the operation succeeded)
    /// </summary>
    public string? Exception { get; set; }

    /// <summary>
    /// Initializes a new instance with an exception message
    /// </summary>
    /// <param name="exception">The exception message describing the error</param>
    public ResultWithExceptionEditorConfig(string? exception)
    {
        Exception = exception;
    }
}