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
        private List<ChildrenShowDetailsResponse> _childrenShowDetails = new List<ChildrenShowDetailsResponse>();
        public List<ChildrenShowDetailsResponse> ChildrenShowDetails { get { return _childrenShowDetails; } set { _childrenShowDetails = value; } }

        public decimal TotalScore { get; set; }



    }
    public class ChildrenShowDetailsResponse
    {
        //private List<string> _activityDesc = new List<string>();
        //private List<string> _compValue = new List<string>();
        //private List<decimal> _scoreValue = new List<decimal>();
        //public List<string> ActivityDesc { get { return _activityDesc; } set { _activityDesc = value; } }

        //public List<string> CompValue { get { return _compValue; } set { _compValue = value; } }

        //public List<decimal> ScoreValue { get { return _scoreValue; } set { _scoreValue = value; } }
        public string ActivityDesc { get; set; }
        public string CompValue { get; set; }
        public decimal ScoreValue { get; set; }
    }
}
