using BDDWinForms_AGG.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsBD.DAL
{
    internal class JobDAL
    {
        // LINQ to SQL DataContext
        private EmpleadosDataContext dc;

        public JobDAL()
        {
            dc = new EmpleadosDataContext();
        }

        // Insertar valores concretos
        public bool InsertJob1()
        {
            try
            {
                job j = new job()
                {
                    job_title = "Software Developer",
                    min_salary = 60000,
                    max_salary = 120000
                };

                dc.jobs.InsertOnSubmit(j);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool InsertJob2(string title, decimal? minSalary, decimal? maxSalary)
        {
            try
            {
                job j = new job()
                {
                    job_title = title,
                    min_salary = minSalary,
                    max_salary = maxSalary
                };

                dc.jobs.InsertOnSubmit(j);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool InsertJob3(Job jobModel)
        {
            try
            {
                job j = new job()
                {
                    job_title = jobModel.job_title,
                    min_salary = jobModel.min_salary,
                    max_salary = jobModel.max_salary
                };

                dc.jobs.InsertOnSubmit(j);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool InsertJob4(Job jobModel)
        {
            try
            {
                job j = new job()
                {
                    job_title = jobModel.job_title,
                    min_salary = jobModel.min_salary,
                    max_salary = jobModel.max_salary
                };

                dc.jobs.InsertOnSubmit(j);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // Devolver todos los jobs
        public List<Job> GetAll()
        {
            try
            {
                var query = from j in dc.jobs
                            select new Job
                            {
                                job_id = j.job_id,
                                job_title = j.job_title,
                                min_salary = j.min_salary,
                                max_salary = j.max_salary
                            };

                return query.ToList();
            }
            catch (Exception ex)
            {
                return new List<Job>();
            }
        }

        // Actualizar job existente
        public bool UpdateJob(Job jobModel)
        {
            try
            {
                var j = dc.jobs.FirstOrDefault(x => x.job_id == jobModel.job_id);
                if (j != null)
                {
                    j.job_title = jobModel.job_title;
                    j.min_salary = jobModel.min_salary;
                    j.max_salary = jobModel.max_salary;
                    dc.SubmitChanges();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
