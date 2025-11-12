using BDDWinForms_AGG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        // Añadir un método InsertarJobV2()
        public bool InsertJob2(string title, decimal? minSalary, decimal? maxSalary)
        {
            // con parámetros NULLables
            try
            {
                string sql = @"
INSERT INTO jobs ([job_title], [min_salary] ,[max_salary])
VALUES (@job_title, @min_salary, @max_salary)";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Asignar parámetros, controlando valores nulos
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
        public bool InsertJob3(Job job)
        {
            // con objeto Job, y control de NULLs
            try
            {
                string sql = @"
INSERT INTO jobs ([job_title], [min_salary], [max_salary])
VALUES (@job_title, @min_salary, @max_salary)";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

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
        public bool InsertJob4(Job job)
        {
            // con parametros SQL y objeto Job, y control de NULLs
            try
            {
                string sql = @"
INSERT INTO jobs ([job_title], [min_salary], [max_salary])
VALUES (@job_title, @min_salary, @max_salary)";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

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
