using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZHDotNetTrainingInPersonBatch1.ConsoleApp
{


    [Table("Tbl_Student")]
    public class StudentDto
    {
        [Key]
       // [Column("in db name")] we can use any name in under line
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MobileNo { get; set; }
        public string DeleteFlag { get; set; }
    }
}
