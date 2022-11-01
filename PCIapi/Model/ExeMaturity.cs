using System.Collections.Generic;

namespace PCIapi.Model
{
    public class ExeMaturity
    {

        public int ExcKeyActivityID { get; set; }       
        public string ExcKeyActivityDesc { get; set; }       
         
    }
    public class Showdetails
    {
        public string AreasDesc { get; set; }
        public string ActivityDesc { get; set; }
        public string CompValue { get; set; }
        public decimal ScoreValue { get; set; }
    }
    public class ShowDetailsResponse
    {
        public string AreasDesc { get; set; }
        public List<string> ActivityDesc { get; set; }
        public List<string> CompValue { get; set; }
        public List<decimal> ScoreValue { get; set; }
        public decimal TotalScore   { get; set; }
    }
}
