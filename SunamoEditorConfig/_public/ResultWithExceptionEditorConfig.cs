namespace SunamoEditorConfig._public;

/// <summary>
/// Represents the result with exception editor config t type.
/// </summary>
public class ResultWithExceptionEditorConfig<T>
{
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    public T? Result { get; set; }

    /// <summary>
    /// Result with exception editor config.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns>The result with exception editor config result.</returns>
    public ResultWithExceptionEditorConfig(T? result)
    {
        Result = result;
    }

    /// <summary>
    /// Gets or sets the exception.
    /// </summary>
    public string? Exception { get; set; }

    /// <summary>
    /// Result with exception editor config.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>The result with exception editor config result.</returns>
    public ResultWithExceptionEditorConfig(string? exception)
    {
        Exception = exception;
    }
}
