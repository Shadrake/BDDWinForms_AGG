using BDDWinForms_AGG.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsBD.DAL;

namespace BDDWinForms_AGG
{
    public partial class Form1 : Form
    {
        // ** 1a parte **
        SqlConnection connection = null;

        // Definir cadena de conexión, parametros de acceso
        string ConStr = "Server=serverName;" +
            "Database=AbrilEmpleados;" +
            "User Id=user;" +
            "Password=serverPass;" +
            "TrustServerCertificate=true";

        public Form1()
        {
            connection = new SqlConnection(ConStr);
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
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
                if (connection.State != System.Data.ConnectionState.Closed)
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
            JobDAL dal = new JobDAL();
            if (!dal.InsertJob1())
                MessageBox.Show("Error al insertar el job.");
            else
                MessageBox.Show("Job insertado correctamente.");
        }

        // ** 3a parte **
        private void btnInsert2_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Introduzca el título del job.");
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

            JobDAL dal = new JobDAL();
            if (!dal.InsertJob2(title, minSalary, maxSalary))
                MessageBox.Show("Error al insertar el job.");
            else
                MessageBox.Show("Job insertado correctamente.");
        }

        private Job LeerJob()
        {
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Introduzca el título del job.");
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
            Job j = LeerJob();
            if (j == null)
            {
                MessageBox.Show("Error al leer el job.");
                return;
            }

            JobDAL dal = new JobDAL();
            if (!dal.InsertJob3(j))
                MessageBox.Show("Error al insertar el job.");
            else
                MessageBox.Show("Job insertado correctamente.");
        }

        // ** 5a parte **
        private void btnInsert4_Click(object sender, EventArgs e)
        {
            Job j = LeerJob();
            if (j == null)
            {
                MessageBox.Show("Error al leer el job.");
                return;
            }

            JobDAL dal = new JobDAL();
            if (!dal.InsertJob4(j))
                MessageBox.Show("Error al insertar el job.");
            else
                MessageBox.Show("Job insertado correctamente.");
        }

        // Cargar lista de jobs
        private void btnLoadJobs_Click(object sender, EventArgs e)
        {
            JobDAL dal = new JobDAL();
            var jobList = dal.GetAll();

            listBoxJobs.DataSource = jobList;
            listBoxJobs.DisplayMember = "job_title";
            listBoxJobs.ValueMember = "job_id";
        }

        // Actualizar job seleccionado
        private void btnUpdateJob_Click(object sender, EventArgs e)
        {
            if (listBoxJobs.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un job de la lista.");
                return;
            }

            Job selectedJob = (Job)listBoxJobs.SelectedItem;

            Job updatedJob = LeerJob();
            if (updatedJob == null)
            {
                MessageBox.Show("Error al leer los datos del job.");
                return;
            }

            updatedJob.job_id = selectedJob.job_id;

            JobDAL dal = new JobDAL();
            if (!dal.UpdateJob(updatedJob))
                MessageBox.Show("Error al actualizar el job.");
            else
                MessageBox.Show("Job actualizado correctamente.");
        }
    }
}
