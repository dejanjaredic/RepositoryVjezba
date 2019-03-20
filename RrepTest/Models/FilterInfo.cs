using System.Collections.Generic;

namespace RrepTest.Models
{
    public class FilterInfo
    {
        public string Condition { get; set; }
        public List<RuleInfo> Rules{ get; set; } = new List<RuleInfo>();
    }
}