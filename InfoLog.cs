using System.Collections.Generic;

namespace Shop_Wpf_App_Entity_Framework
{
    internal class InfoLog
    {
        public List<string> log = new();
        public void AddToLog(string msg) => log.Add(msg);
    }
}
