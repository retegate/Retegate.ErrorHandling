namespace Retegate.ErrorHandling;

public static class Helper
{
    public static string InstanceMessage(string logTraceId)
    {
        return $"For more information, search the log trace id '{logTraceId}' in the logs.";
    }
}