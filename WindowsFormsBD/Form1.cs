using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsBD
{
    public partial class Form1 : Form
    {
        // ** 1a parte **
        SqlConnection connection = null;

        // Definir cadena de conexión, parametros de acceso
        string ConStr = "Server=46.183.118.102,54321;" +
            "Database=AbrilEmpleados;" +
            "User Id=sa;" +
            "Password=Sql#123456789;" +
            "TrustServerCertificate=true";
        public Form1()
        {
            connection = new SqlConnection(ConStr);

            InitializeComponent();
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            // Usar calse SqlConnection, dentro de try/catch
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                labMessage.Text = "¡Conexión establecida!";
                butOpen.Enabled = false;
                butClose.Enabled = true;
            }
            catch (Exception ex)
            {
                labMessage.Text = "¡Error de conexión!";
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                labMessage.Text = "Conexión cerrada.";
                butOpen.Enabled = true;
                butClose.Enabled = false;
            }
            catch (Exception ex)
            {
                labMessage.Text = "¡Fallo al cerrar!";
            }
        }

        // ** 2a parte **
        private void btnInsert1_Click(object sender, EventArgs e)
        {
            //   insertar valores concretos (hard coded)
            InsertJob1();
        }

        // ** 3a parte **
        private void btnInsert2_Click(object sender, EventArgs e)
        {
            // insertar Job basado en txtBox
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Introduzca el título del puesto.");
                return;
            }

            decimal valorLeido;
            decimal? minSalary = null;
            decimal? maxSalary = null;

            if (!String.IsNullOrWhiteSpace(txtMin.Text))
            {
                if (decimal.TryParse(txtMin.Text, out valorLeido))
                    minSalary = valorLeido;
            }

            if (!String.IsNullOrWhiteSpace(txtMax.Text))
            {
                if (decimal.TryParse(txtMax.Text, out valorLeido))
                    maxSalary = valorLeido;
            }

            if(!InsertarJobV2(title, minSalary, maxSalary))
                MessageBox.Show("Error al insertar el puesto.");
        }

        private Job LeerJob()
        {             
            // txtJobTitle, txtMinSalary, txtMaxSalary
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Introduzca el título del puesto.");
                return null;
            }

            decimal valorLeido;
            decimal? minSalary = null;
            decimal? maxSalary = null;

            if (!String.IsNullOrWhiteSpace(txtMin.Text))
            {
                if (decimal.TryParse(txtMin.Text, out valorLeido))
                    minSalary = valorLeido;
                else
                    return null;
            }

            if (!String.IsNullOrWhiteSpace(txtMax.Text))
            {
                if (decimal.TryParse(txtMax.Text, out valorLeido))
                    maxSalary = valorLeido;
                else
                    return null;
            }

            Job job = new Job()
            {
                job_title = title,
                min_salary = minSalary,
                max_salary = maxSalary
            };
            return job;
        }
        private void btnInsert3_Click(object sender, EventArgs e)
        {
            // con objeto Job
            Job j = LeerJob();

            if (j == null || !InsertarJobV3(j))
                MessageBox.Show("Error al insertar el puesto.");
        }

        private void btnInsert4_Click(object sender, EventArgs e)
        {
            // con parametros SQL
            Job j = LeerJob();
            if (j == null || !InsertarJobV4(j))
                MessageBox.Show("Error al insertar el puesto.");
        }

        // ** 2a parte **
        // Añadir un metodo Insertar()
        private bool InsertJob1()
        {
            // insert fijo
            try
            {
                string sql = @"
INSERT INTO jobs ([job_title], [min_salary] ,[max_salary])
VALUES ('Software Developer', 60000, 120000)";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                int num = sqlCommand.ExecuteNonQuery();
                //MessageBox.Show($"{num} filas insertadas!");
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        private bool InsertarJobV2(string title, decimal? minSalary, decimal? maxSalary)
        {
            // con parámetros NULLables
            try
            {
                string sql = $@"
INSERT INTO jobs ([job_title], [min_salary] ,[max_salary])
VALUES ('{title}', {minSalary}, {maxSalary})";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                int num = sqlCommand.ExecuteNonQuery();
                //MessageBox.Show($"{num} filas insertadas!");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        private bool InsertarJobV3(Job job)
        {
            // con objeto Job, y control de NULLs
            try
            {
                string sql = $@"
INSERT INTO jobs ([job_title], [min_salary] ,[max_salary])
VALUES ('{job.job_title}', 
        {(job.min_salary == null ? "NULL" : job.min_salary.ToString())}, 
        {(job.max_salary == null ? "NULL" : job.max_salary.ToString())})";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                int num = sqlCommand.ExecuteNonQuery();
                //MessageBox.Show($"{num} filas insertadas!");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        private bool InsertarJobV4(Job job)
        {
            // con parametros SQL y objeto Job, y control de NULLs
            try
            {
                string sql = $@"
INSERT INTO jobs ([job_title], [min_salary] ,[max_salary])
VALUES ( @job_title, @min_salary, @max_salary)";

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
