using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBD
{
    public class Job
    {
        public int job_id { get; set; }
        public string job_title { get; set; }
        public decimal? min_salary { get; set; }
        public decimal? max_salary { get; set; }
    }
}
