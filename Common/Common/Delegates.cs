using Common.Args;

namespace Common.Common
{
    public delegate void StreamStarted(object sender, StreamStartedArgs e);

    public delegate void StreamEnded(object sender, StreamEndedArgs e);

    public delegate void LogMessageAdded(object sender, LogMessageArgs e);

    public delegate void StreamListLoaded(object sender, StreamListLoadedArgs e);

    public delegate void StreamListUpdated(object sender, StreamListUpdatedArgs e);

    public delegate void ProcessExited(object sender, ProcessExitedArgs args);
}