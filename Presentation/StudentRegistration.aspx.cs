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
                    var ListStudent =  ServicesStudent.LstStudent().Where(s => s.Status == "ACT").ToList();
                    Session["HLstStudent"] = ListStudent;
                    if (ListStudent.Count()>0)
                    {
                        LlenarGridStudent();
                    }
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
                int Year = Convert.ToInt32( txtbirthday.Text.Substring(6, 4));
                int Month = Convert.ToInt32(txtbirthday.Text.Substring(3, 2));
                int Day = Convert.ToInt32(txtbirthday.Text.Substring(0, 2));               
                DateTime nacimiento = new DateTime( Year, Month, Day);
                TxtAge.Text = Convert.ToString(DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1);

                Alum.Id = IdStudente > 0 ? IdStudente : 0;
                Alum.Nombres = txtStudenteName.Text;
                Alum.PrimerApellido = txtLastName1.Text;
                Alum.SegundoApellido = TxtLastName2.Text;
                Alum.Cedula = TxtIdentificationId.Text;
                Alum.Status = ddlStatus.SelectedValue;
                Alum.Sexo = ddlGender.SelectedValue;
                ServicesStudent.SaveStudent(Alum);
            }
        }

        private void LlenarGridStudent()
        {
            try
            {
                DataTable Table = new DataTable();
                Table.Columns.Add("Id");
                Table.Columns.Add("Name");
                Table.Columns.Add("LastName1");
                Table.Columns.Add("LastName2");
                Table.Columns.Add("Age");
                Table.Columns.Add("IdentificationId");

                var List = Session["HLstStudent"] as List<Alumno>;
                foreach(var ls in List)
                {
                    DataRow row = Table.NewRow();
                    row["Id"] = ls.Id;
                    row["Name"] = ls.Nombres;
                    row["LastName1"] = ls.PrimerApellido;
                    row["LastName2"] = ls.SegundoApellido;
                    row["Age"] = "30";
                    row["IdentificationId"] = ls.Cedula;
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