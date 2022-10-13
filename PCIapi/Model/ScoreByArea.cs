using System.Collections.Generic;

namespace PCIapi.Model
{
    public class ScoreByArea
    {
        public int ScoreCrdID { get; set; }
        public string ExcKeyActivityDesc { get; set; }
        public  List<string> CompValue{ get; set; }
        public string ScoreDesc { get; set; }
        public List<decimal> ScoreValue { get; set; }

    }
}
