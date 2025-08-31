using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WZHDotNetTrainingInPersonBatch1.ConsoleApp
{
    public class DapperService
    {
     private readonly   SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@@123",
            TrustServerCertificate = true,
        };
        public void Read()
        {
            string query = @"SELECT [StudentId]
      ,[StudentCode]
      ,[StudentName]
      ,[FatherName]
      ,[MobileNo]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Student]";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            List<Student> lst = db.Query<Student>(query).ToList();
            int no = 0;
            foreach ( var student in lst )
            {
                Console.WriteLine($"{no+1} =>{student.StudentCode}-{ student.StudentName} - {student.FatherName}  -{student.MobileNo}");
                no++;
            }
        }
        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Student]
                               ([StudentCode]
                               ,[StudentName]
                               ,[FatherName]
                               ,[MobileNo]
                               ,[DeleteFlag])
                         VALUES
                               ('S003'
                               ,'Mg Ma'
                               ,'U Ba'
                               ,'0967676'
                               ,0)";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var result = db.Execute(query);
            Console.WriteLine(result > 0 ? "saving successful" : "failed");
        }
        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Student]
               SET 
                  [StudentName] = 'Ko Hla'
                  ,[FatherName] = 'U Hla'
                 WHERE StudentId = 2";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var result = db.Execute(query);
            Console.WriteLine(result > 0 ? "updating successful" : "failed");
        }
        
    }
}
