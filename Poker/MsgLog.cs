using System;
using System.Diagnostics;

namespace Poker
{
    public class MsgLog
    {
        public MsgLog(string errMsg)
        {
            DateTime dt = DateTime.Now;
            errMsg = $"dt : errMsg";
            EventLog log = new EventLog("Application", ".", "Poker");
            log.WriteEntry(errMsg, EventLogEntryType.Error);
        }
    }
}
