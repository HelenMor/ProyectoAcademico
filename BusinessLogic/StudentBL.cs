using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class StudentBL
    {
        StudentsDAL Datos = new StudentsDAL();

        public bool SaveStudent(Alumno Al) 
        {
            bool Result = new bool();

            try
            {               
                Result = Datos.SaveStudent(Al);             
          
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Result;        
        }

        public Alumno GetStudent (int IdStudent)
        {
            Alumno Student = new Alumno();

            try
            {
                Student = (from Stud in Datos.ListStudents()
                           where Stud.Id == IdStudent
                           select Stud).LastOrDefault();

            }
            catch (Exception ex)
            {

                throw;
            }

            return Student;
        }

        public List<Alumno> LstStudent()
        {
            List<Alumno> Lst = new List<Alumno>();

            try
            {
                Lst = Datos.ListStudents();

            }
            catch (Exception)
            {

                throw;
            }

            return Lst;
        }


    }
}
