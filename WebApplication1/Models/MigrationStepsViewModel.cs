using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("MigrationSteps")]
    public class MigrationStepsViewModel
    {
        [Key]
        public int StepNumber { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public TaskStatusEnum TaskStatus { get; set; }
    }
}