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
                if (Al.Id==0)
                { 
                   StudentEntities.Alumno.Add(Al);
                   StudentEntities.SaveChanges();
                   Result = true; 

                }

                else if(Al.Id>0)
                {
                 
                   
                    var ObjStudent = (from Es in StudentEntities.Alumno.ToList()
                                         where Es.Id == Al.Id
                                         select Es).LastOrDefault();


                    if (ObjStudent != null)
                    {
                        ObjStudent.Nombres = Al.Nombres;
                        ObjStudent.PrimerApellido = Al.PrimerApellido;
                        ObjStudent.SegundoApellido = Al.SegundoApellido;
                        ObjStudent.Cedula =Al.Cedula;
                        ObjStudent.BirthDay = Al.BirthDay;
                        ObjStudent.Sexo = Al.Sexo;
                        ObjStudent.Direccion = Al.Direccion;
                        ObjStudent.Telefono = Al.Telefono;
                        ObjStudent.Status = Al.Status;
                        StudentEntities.SaveChanges();
                        Result = true;
                    }


                }
                
                
                
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
