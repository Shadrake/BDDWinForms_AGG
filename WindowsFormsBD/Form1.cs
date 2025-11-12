using BDDWinForms_AGG.Models;
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
using WindowsFormsBD.DAL;
using static System.Net.Mime.MediaTypeNames;

namespace BDDWinForms_AGG
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Usar calse SqlConnection, dentro de try/catch
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                labMessage.Text = "¡Conexión establecida!";
                btnOpen.Enabled = false;
                btnClose.Enabled = true;
            }
            catch (Exception ex)
            {
                labMessage.Text = "¡Error de conexión!";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                labMessage.Text = "Conexión cerrada.";
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
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

            // Crear una instancia del DAL y llamar al método
            JobDAL dal = new JobDAL();

            if (!dal.InsertJob2(title, minSalary, maxSalary))
                MessageBox.Show("Error al insertar el puesto.");
            else
                MessageBox.Show("Puesto insertado correctamente.");
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

        // ** 4a parte **
        private void btnInsert3_Click(object sender, EventArgs e)
        {
            // Crear el objeto Job a partir de los TextBox
            Job j = LeerJob();

            if (j == null)
            {
                MessageBox.Show("Error al leer el puesto.");
                return;
            }

            // Crear instancia del DAL
            JobDAL dal = new JobDAL();

            // Llamar al método que inserta un objeto Job
            if (!dal.InsertJob3(j))
                MessageBox.Show("Error al insertar el puesto.");
            else
                MessageBox.Show("Puesto insertado correctamente.");
        }

        // ** 5a parte **
        private void btnInsert4_Click(object sender, EventArgs e)
        {
            // con parametros SQL
            Job j = LeerJob();
            if (j == null)
            {
                MessageBox.Show("Error al leer el puesto.");
                return;
            }

            JobDAL dal = new JobDAL();
            if (!dal.InsertJob4(j))
                MessageBox.Show("Error al insertar el puesto.");
            else
                MessageBox.Show("Puesto insertado correctamente.");
        }

        // ** 2a parte **
        // Añadir un metodo Insertar()
        private bool InsertJob1()
        {
            // usar  try/catch/finally
            try
            {
                // codigo SQL, INSERT INTO en tabla jobs
                string sql = @"
INSERT INTO jobs ([job_title], [min_salary] ,[max_salary])
VALUES ('Software Developer', 60000, 120000)";

                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                // usar SqlCommand, metodo ExecuteNonQuery
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
