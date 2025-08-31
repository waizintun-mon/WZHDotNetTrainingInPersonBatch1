using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZHDotNetTrainingInPersonBatch1.ConsoleApp
{
    public class AdoDotNetService
    {
        //string connection = "Data Source"
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
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
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
            

                DataRow row = dt.Rows[i];

                Console.WriteLine("student id=>" + row["StudentId"]);
                Console.WriteLine("Student code =>" + row["StudentCode"]);
                Console.WriteLine("StudentName =>" + row["StudentName"]);
                Console.WriteLine("FatherName =>" + row["FatherName"]);
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
                               ('S002'
                               ,'Ma Ma'
                               ,'U Ba'
                               ,'0967676'
                               ,0)";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
          int result =  cmd.ExecuteNonQuery();
            Console.WriteLine(result>0? "insert successful": "failed");
            
            connection.Close();

        }
        public void Update()
        {

           
            string query = @"UPDATE [dbo].[Tbl_Student]
               SET 
                  [StudentName] = 'Ko Hla'
                  ,[FatherName] = 'U Hla'
                 WHERE StudentId = 2";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
           int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? "update successful" : "failed");

            connection.Close();

        }
        public void Delete()
        {
            string query = @"UPDATE [dbo].[Tbl_Student]
               SET DeleteFlag = 1
                 WHERE StudentId = 2";
            SqlConnection connection = new SqlConnection( _sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? "Delete successful" : "failed");

            connection.Close();


        }
    }
}
