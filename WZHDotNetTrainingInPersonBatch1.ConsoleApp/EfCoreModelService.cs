using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZHDotNetTrainingInPersonBatch1.ConsoleApp
{
    public class EfCoreModelService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
      var lst= db.Students.ToList();
            foreach(var student in lst)
            {
                Console.WriteLine(student.StudentCode);
                Console.WriteLine(student.StudentName);
                Console.WriteLine(student.FatherName);
                Console.WriteLine( student.MobileNo);
            }
        }
        public void Create()
        {
            StudentDto student = new StudentDto()
            {
                StudentCode ="S007",
                StudentName = "Ko Aung",
                FatherName = "U Mya",
                MobileNo ="098787878"
            };
            AppDbContext db = new AppDbContext();
            db.Students.Add(student);
           int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Saving successful" : "failed");

        }
        public void Update()
        {
            AppDbContext db = new AppDbContext();
           var edit = db.Students.FirstOrDefault(x=>x.StudentId == 1);
            if(edit == null)
            {
                return;
            }
            edit.FatherName = "Ko Maung";
            db.SaveChanges();

        }
        public void Delete()
        {
            AppDbContext db = new AppDbContext();
            var delete = db.Students.FirstOrDefault(x => x.StudentId == 7);
                if(delete is null)
            {
                return;
            }
                db.Students.Remove(delete);
               int result = db.SaveChanges();
        }
    }
}
