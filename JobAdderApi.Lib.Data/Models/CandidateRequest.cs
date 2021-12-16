using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdderApi.Lib.Data.Models
{
    public class CandidateRequest
    {
        public int JobId { get; set; }
        public List<string> SkillTags { get; set; }
        public Dictionary<string, int> WeightedSkills { get; set; }
    }
}
