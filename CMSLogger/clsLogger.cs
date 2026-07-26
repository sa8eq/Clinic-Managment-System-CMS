using System;
using System.Diagnostics;

public static class clsLogger
{
    private const string SourceName = "CMS Clinic Management System";
    private const string LogName = "Application";

    public static void LogDatabaseError(Exception ex, string customMessage = "Database Connection Error")
    {
        try
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, LogName);
            }

            string logMessage = $"Error Time: {DateTime.Now}\n" +
                                $"Message: {customMessage}\n" +
                                $"Exception Details: {ex.Message}\n" +
                                $"Stack Trace:\n{ex.StackTrace}";

            EventLog.WriteEntry(SourceName, logMessage, EventLogEntryType.Error);
        }
        catch (Exception logEx)
        {
            throw new Exception(logEx.Message);
        }
    }
}