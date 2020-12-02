using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParserFromInternet
{
    internal class Danger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string SourceOfThrear { get; set; }
        public string SubjectOfThreat { get; set; }
        public bool ConfidenceProblem { get; set; }
        public  bool FullnesProblem { get; set; }

        public List<Danger> dangersList = new List<Danger>();

        HashSet<Danger> dangersHash = new HashSet<Danger>();
    }
}
