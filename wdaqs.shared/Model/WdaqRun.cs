using System.Collections.Generic;

namespace wdaqs.shared.Model
{
    public class WdaqRun
    {
        public List<WdaqReading> Readings { get; set; }

        public WdaqRun()
        {
            Readings = new List<WdaqReading>();
        }
    }
}