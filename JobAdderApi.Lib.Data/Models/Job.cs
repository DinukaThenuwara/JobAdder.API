using JobAdderApi.Lib.Data.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace JobAdder.Data.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Skills { get; set; }
        public Dictionary<string, int> WeightedSkills
        {
            get
            {
                var tags = this.Skills.Split(',').Select(a => a.Trim()).ToList();
                var weightedSkillTags = new Dictionary<string, int>();
                var maxWeight = Constants.MAX_WEIGHT;

                for (var i = 1; i <= tags.Count; i++)
                {
                    if (weightedSkillTags.ContainsKey(tags[i - 1])) continue;

                    weightedSkillTags.Add(tags[i - 1], (maxWeight / i) + (maxWeight / 2));
                }

                return weightedSkillTags;
            }
        }
        public List<string> SkillTags { get { return this.Skills.Split(',').Select(a => a.Trim()).ToList(); } }
    }
}
