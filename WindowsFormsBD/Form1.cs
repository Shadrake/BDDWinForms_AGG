using BDDWinForms_AGG.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsBD.DAL;

namespace BDDWinForms_AGG
{
    /*
    En algun lugar en un futuro cuando haga algo de modificar o actualizar, deberé meter esto:
    
    EmployeesDataContext dc = new EmployeesDataContest();
    
    - Recuperar varios
    IQueryable<jobs> jobsLinq = from job in dc.jobs
                                where job.job_id == 15
                                select job;
    
     - Para recuperar solo los nombres de los jobs
    var jobsTitles = from job in dc.jobs
                     where job.job_id == 15
                     select job.job_title;

    - Para recuperar solo el primero o 1 de la lista.
    jobs j = (from job in dc.jobs
                where job.job_id == 15
                select job).FirstOrDefault();

    - Devuelve lista
    - Pone var porque sino le da error al rener más IQuerable<jobs> (creo)
    var jobsLinq2 = dc.jobs.Where(j2 => j1.job_id == 15);
    
    var miJob = dc.jobs.Where(j2 => j2.job_id = 15).FirstOrDefaul();
    
    jobs j = (from j3 in dc.jobs
                where j3.job_id == 15
                select j3).FirstOrDefault();

    List<string> jobsTitles = (from j4 in dc.jobs
                                where j4.job_id == 15
                                select j4.job_title).ToList();

    // Si vas insertando cosas, hacer SubmitChanges.
    // Si al empezar laapp lees el objeto, haces cosas, lo cambias y más tarde haces Submit, no funcionará
    // Habrá que buscarlo por su ID y cambiar los valores para poder actualizarlo.
    j.job_title = "Nuevo titulo desde LINQ to SQL";
    dc.SubmitChanges();

    - Si quiero crear un nuevo registro, crear nuevo job con sus valores y cosas
    jobs jNew = new jobs();
    jNew.job.title = "Insertado";
    dc.jobs.InsertOnSubmit(jNew);
    dc.SubmitChanges();

    */

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
            // insertar valores concretos (hard coded)
            JobDAL dal = new JobDAL();
            if (!dal.InsertJob1())
                MessageBox.Show("Error al insertar el puesto.");
            else
                MessageBox.Show("Puesto insertado correctamente.");
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
    }
}
