// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
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