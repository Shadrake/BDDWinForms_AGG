using BDDWinForms_AGG.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsBD.DAL
{
    internal class JobDAL
    {
        // ** 1a parte **
        SqlConnection connection = null;

        // Definir cadena de conexión, parámetros de acceso
        string ConStr = "Server=46.183.118.102,54321;" +
            "Database=AbrilEmpleados;" +
            "User Id=sa;" +
            "Password=Sql#123456789;" +
            "TrustServerCertificate=true";

        public JobDAL()
        {
            connection = new SqlConnection(ConStr);
        }

        // ** 2a parte **
        // Insertar valores concretos (hard coded)
        public bool InsertJob1()
        {
            try
            {
                string sql = @"
INSERT INTO jobs ([job_title], [min_salary] ,[max_salary])
VALUES ('Software Developer', 60000, 120000)";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                int num = sqlCommand.ExecuteNonQuery();
                //MessageBox.Show($"{num} filas insertadas!");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // ** 3a parte **
        // Insertar Job con parámetros NULLables
        public bool InsertJob2(string title, decimal? minSalary, decimal? maxSalary)
        {
            try
            {
                string sql = @"
INSERT INTO jobs ([job_title], [min_salary], [max_salary])
VALUES (@job_title, @min_salary, @max_salary)";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                sqlCommand.Parameters.AddWithValue("@job_title", title);
                sqlCommand.Parameters.AddWithValue("@min_salary", (object)minSalary ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@max_salary", (object)maxSalary ?? DBNull.Value);

                int num = sqlCommand.ExecuteNonQuery();
                //MessageBox.Show($"{num} filas insertadas!");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // ** 4a parte **
        // Insertar Job con objeto Job y control de NULLs
        public bool InsertJob3(Job job)
        {
            try
            {
                string sql = @"
INSERT INTO jobs ([job_title], [min_salary], [max_salary])
VALUES (@job_title, @min_salary, @max_salary)";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                sqlCommand.Parameters.AddWithValue("@job_title", job.job_title);
                sqlCommand.Parameters.AddWithValue("@min_salary", (object)job.min_salary ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@max_salary", (object)job.max_salary ?? DBNull.Value);

                int num = sqlCommand.ExecuteNonQuery();
                //MessageBox.Show($"{num} filas insertadas!");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // ** 5a parte **
        // Insertar Job con parámetros SQL y objeto Job
        public bool InsertJob4(Job job)
        {
            try
            {
                string sql = @"
INSERT INTO jobs ([job_title], [min_salary], [max_salary])
VALUES (@job_title, @min_salary, @max_salary)";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                sqlCommand.Parameters.AddWithValue("@job_title", job.job_title);
                sqlCommand.Parameters.AddWithValue("@min_salary", (object)job.min_salary ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@max_salary", (object)job.max_salary ?? DBNull.Value);

                int num = sqlCommand.ExecuteNonQuery();
                //MessageBox.Show($"{num} filas insertadas!");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}