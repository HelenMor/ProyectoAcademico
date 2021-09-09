using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        StudentBL ServicesStudent = new StudentBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    /*var ListStudent =  ServicesStudent.LstStudent().Where(s => s.Status == "ACT").ToList();
                    Session["HLstStudent"] = ListStudent;
                    if (ListStudent.Count()>0)
                    {
                        LlenarGridStudent();
                    }*/
                }
            }


            catch (Exception)
            {

                throw;
            }


        }

        protected void BtSeleccionar_Command(object sender, CommandEventArgs e)
        {
  


        }

        protected void SaveStudent_Click(object sender, EventArgs e)
        {
            Alumno Alum = new Alumno();
            ServicesStudent = new StudentBL();
            if ( txtStudenteName.Text!="" && txtLastName1.Text != "" && TxtLastName2.Text != "" && TxtIdentificationId.Text!="")
            {
                int IdStudente = Convert.ToInt32(Session["HIdStudent"]);
                Alum.Id = IdStudente > 0 ? IdStudente : 0;
                Alum.Nombres = txtStudenteName.Text;
                Alum.PrimerApellido = txtLastName1.Text;
                Alum.SegundoApellido = TxtLastName2.Text;
                Alum.Cedula = TxtIdentificationId.Text;
                ServicesStudent.SaveStudent(Alum);
            }
        }

        private void LlenarGridStudent()
        {
            try
            {
                DataTable Table = new DataTable();
                Table.Columns.Add("Id");
                Table.Columns.Add("ltName");
                Table.Columns.Add("ltLastaName1");
                Table.Columns.Add("ltLastaName2");
                Table.Columns.Add("LtAge");
                Table.Columns.Add("IDentificationId");

                var List = Session["HLstStudent"] as List<Alumno>;
                foreach(var ls in List)
                {
                    DataRow row = Table.NewRow();
                    row["Id"] = ls.Id;
                    row["ltName"] = ls.Nombres;
                    row["ltLastaName1"] = ls.PrimerApellido;
                    row["ltLastaName2"] = ls.SegundoApellido;
                    row["LtAge"] = 30;
                    row["IDentificationId"] = ls.Cedula;
                    Table.Rows.Add(row);
                }
                gvStudents.DataSource = Table;
                gvStudents.DataBind();
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}