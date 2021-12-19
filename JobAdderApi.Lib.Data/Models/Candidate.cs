using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobAdder.Data.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string SkillTags { get; set; }
        public Dictionary<string, int> WeightedSkills 
        { 
            get 
            {
                var tags = this.SkillTags.Split(',').Select(a => a.Trim()).ToList();
                var weightedSkillTags = new Dictionary<string, int>();
                var maxWeight = 100;

                for (var i = 1; i <= tags.Count; i++)
                {
                    if (weightedSkillTags.ContainsKey(tags[i - 1])) continue;

                    weightedSkillTags.Add(tags[i - 1], (maxWeight / i) + (maxWeight/2));
                }

                return weightedSkillTags; 
            } 
        }

        public List<string> Skills { get { return this.SkillTags.Split(',').Select(a => a.Trim()).ToList(); } }
    }
}
