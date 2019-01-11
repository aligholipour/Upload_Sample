using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload_Sample.Models.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Manager { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectCreated { get; set; }
        public string ImagePath { get; set; }
    }
}
