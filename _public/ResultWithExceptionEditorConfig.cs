namespace SunamoEditorConfig._public;

public class ResultWithExceptionEditorConfig<T>
{


    public T? Result { get; set; }

    public ResultWithExceptionEditorConfig(T? result)
    {
        Result = result;
    }

    public string? Exception { get; set; }

    public ResultWithExceptionEditorConfig(string? exception)
    {
        Exception = exception;
    }
}