using CRUDusingADO.NETinMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDusingADO.NETinMVC.Models
{
    public class SqlB1DbHelper
    {
        private string connectionString;
        private string destinationConnectionString;
        private SqlConnection con;
        private SqlConnection destinationCon;

        public SqlB1DbHelper()
        {
            connectionString = "data source = DESKTOP-V8FP4B1; database = B1DB; integrated security = true;";
            //destinationConnectionString = "data source = DESKTOP-V8FP4B1; database = B1DBBackup; integrated security = true;";
            con = new SqlConnection(connectionString);
            //destinationCon = new SqlConnection(destinationConnectionString);
        }

        public List<Student> GetStudents()   //GetStudents mtd return student
        {
            List<Student> students = new List<Student>();

            #region Using SqlDataReader
            //Steps for fetching data from database 
            //1) Establish Connection
            // string ConnectionString = "data source = DESKTOP-V8FP4B1; database = B1DB; integrated security = true;";

            // SqlConnection con = new SqlConnection(ConnectionString);  //SqlConnection--it is class in ADO.Net

            //2)Prepare Command
            SqlCommand cmd = new SqlCommand("select * from student", con);  //Sql Command is a class in ADO.Net
            con.Open();                                               //Open()  --it is method/event in SqlConnection class
                                                                      //con should always open before executing command

            //3) Execute Command
            SqlDataReader reader = cmd.ExecuteReader();  //It's one of way(class) of executing command

            while (reader.Read())
            {
                Student s = new Student();

                s.RollNo = reader["RollNo"] != DBNull.Value ? (int?)reader["RollNo"] : null;
                s.Name = reader["Name"].ToString();
                s.Age = reader["Age"] != DBNull.Value ? (int?)reader["Age"] : null;
                s.Email = reader["email"].ToString();
                s.DoB = reader["DoB"] != DBNull.Value ? (DateTime?)reader["DoB"] : null;
                s.City = reader["City"].ToString();
                s.TrainerId = reader["TrainerId"] != DBNull.Value ? (int?)reader["TrainerId"] : null;

                students.Add(s);
            }
            con.Close();

            return students;
            #endregion

            #region Using SqlDataAdapter
            //try
            //{
            //    SqlDataAdapter adapter = new SqlDataAdapter("select * from student", con);

            //    DataSet ds = new DataSet();
            //    adapter.Fill(ds);

            //    if (ds != null && ds.Tables != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            DataRow row = ds.Tables[0].Rows[i];
            //            Student s = new Student();

            //            s.RollNo = (int)row["RollNo"];
            //            s.Name = row["Name"].ToString();
            //            s.Age = (int)row["Age"];
            //            s.Email = row["email"].ToString();
            //            s.DoB = (DateTime)row["DoB"];

            //            students.Add(s);
            //        }
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    return null;
            //}
            //return students;
            #endregion
        }

        public Student GetStudent(int rollnumber)     //Not calling this method through student controller as not created 
        {
            Student s = null;
            try
            {
                string cmdtxt = "usp_GetStudentbyRollNo";
                SqlCommand cmd = new SqlCommand(cmdtxt, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RollNo", rollnumber);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        s = new Student();

                        s.RollNo = reader["RollNo"] != DBNull.Value ? (int?)reader["RollNo"] : null;
                        s.Name = reader["Name"].ToString();
                        s.Age = reader["Age"] != DBNull.Value ? (int?)reader["Age"] : null;
                        s.Email = reader["email"].ToString();
                        s.DoB = reader["DoB"] != DBNull.Value ? (DateTime?)reader["DoB"] : null;
                        s.City = reader["City"].ToString();
                        s.TrainerId = reader["TrainerId"] != DBNull.Value ? (int?)reader["TrainerId"] : null;

                    }
                }
                return s;
            }
            catch(Exception Ex)
            {
                return null;
            }

        }

        public bool InsertStudent(Student student, out int studentrollnumber)
        {
            try
            {
                List<Student> students = new List<Student>();

                con.Open();

                SqlCommand cmd = new SqlCommand("usp_InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@email", student.Email);
                cmd.Parameters.AddWithValue("@DoB", student.DoB);
                cmd.Parameters.AddWithValue("@City", student.City);
                cmd.Parameters.AddWithValue("@TrainerId", student.TrainerId);
               

                SqlParameter rollnumber = new SqlParameter();
                rollnumber.ParameterName = "@RollNo";
                rollnumber.SqlDbType = SqlDbType.Int;
                rollnumber.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(rollnumber);

                cmd.ExecuteNonQuery();
                con.Close();

                studentrollnumber = (int)rollnumber.Value;
                return true;
            }
            catch (Exception e)
            {
                studentrollnumber = 0;
                return false;
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                List<Student> students = new List<Student>();

                con.Open();

                SqlCommand cmd = new SqlCommand("usp_UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RollNo", student.RollNo);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@email", student.Email);
                cmd.Parameters.AddWithValue("@DoB", student.DoB);
                cmd.Parameters.AddWithValue("@City", student.City);
                cmd.Parameters.AddWithValue("@TrainerId", student.TrainerId);

                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteStudent(int rollnumber)
        {
            try
            {
                List<Student> students = new List<Student>();

                con.Open();

                SqlCommand cmd = new SqlCommand("usp_DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RollNo", rollnumber);

                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool BackupStudent()
        {
            try
            {
                string readStudntCommand = "select * from student where AddedDate = @AddedDate and" + "IsBackedup = 0";
                SqlCommand cmd = new SqlCommand(readStudntCommand, con);
                cmd.Parameters.AddWithValue("AddedDate", DateTime.Now.ToString("yyyy-MM-dd"));
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();// we will get all student from B1DB

                destinationCon.Open();
                SqlBulkCopy copy = new SqlBulkCopy(destinationCon);
                copy.DestinationTableName = "dbo.student";
                copy.WriteToServer(reader);  //copy all student from reader object to student table

                return true;
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
                if (destinationCon != null)
                    destinationCon.Dispose();
            }
        }
    }
}