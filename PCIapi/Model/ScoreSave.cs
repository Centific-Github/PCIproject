using System;

namespace PCIapi.Model
{
    public class ScoreSave
    {
        public int PcicmpID { get; set; }

        public int ProjectID { get; set; }
        public int ActivityId { get; set; }
        public int[] ScoreCrdID { get; set; }
        public DateTime Date { get; set; }
        public int SaveType { get; set; }

    }
}
