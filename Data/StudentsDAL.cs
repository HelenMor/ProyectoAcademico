using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StudentsDAL
    {
        // Insert, Update

        public bool SaveStudent (Alumno Al) 
        {
            bool Result = new bool();
            var StudentEntities = new UniversidadEntities();
            try
            {               
                StudentEntities.Alumno.Add(Al);
                StudentEntities.SaveChanges();
                Result = true;                       
            }
            catch (Exception ex)
            {
                throw;
            }

            return Result;
        }

        // Get
        public List<Alumno> ListStudents()
        {
            var EntitiesStudent= new UniversidadEntities();
            List<Alumno> ListStudent = new List<Alumno>();
            try
            {
                ListStudent = EntitiesStudent.Alumno.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListStudent;
        }

    }
}
