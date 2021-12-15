using System;
using System.Collections.Generic;
using System.Text;

namespace JobAdder.Data.Models
{
    public class Candidate
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SkillTags { get; set; }
        public string[] Skills { get { return this.SkillTags.Split(','); } }
    }
}
