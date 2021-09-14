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
                    LoadData();
                }
            }


            catch (Exception)
            {

                throw;
            }


        }

        private void LoadData()
        {
            var ListStudent = ServicesStudent.LstStudent().Where(s => s.Status == "ACT").ToList();
            Session["HLstStudent"] = ListStudent;
            if (ListStudent.Count() > 0)
            {
                LlenarGridStudent();
            }
        }

        protected void BtSeleccionar_Command(object sender, CommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            var listStudent = Session["HLstStudent"] as List<Alumno>;
            Session["HIdStudent"] = Id;
            Alumno Data = listStudent.Where(s => s.Id == Id).FirstOrDefault();
            if (Data!= null)
            {
                txtStudenteName.Text = Data.Nombres;
                txtLastName1.Text = Data.PrimerApellido;
                TxtLastName2.Text = Data.SegundoApellido;
                TxtIdentificationId.Text = Data.Cedula;
                txtbirthday.Text = Convert.ToString(Data.BirthDay.Value.ToShortDateString());
                CalculateAge();
                ddlGender.SelectedValue = Data.Sexo;
                ddlStatus.SelectedValue = Data.Status;
                txtAdress.Text = Data.Direccion;
                txtPhone.Text = Convert.ToString(Data.Telefono);
            }
        }

        protected void SaveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno Alum = new Alumno();
                ServicesStudent = new StudentBL();
                if (txtStudenteName.Text != "" && txtLastName1.Text != "" && TxtLastName2.Text != "" && TxtIdentificationId.Text != "")
                {
                    int IdStudente = Convert.ToInt32(Session["HIdStudent"]);

                    Alum.Id = IdStudente > 0 ? IdStudente : 0;
                    Alum.Nombres = txtStudenteName.Text;
                    Alum.PrimerApellido = txtLastName1.Text;
                    Alum.SegundoApellido = TxtLastName2.Text;
                    Alum.Sexo = ddlGender.SelectedValue;
                    Alum.Cedula = TxtIdentificationId.Text;
                    Alum.Direccion = txtAdress.Text;
                    Alum.Telefono = int.Parse(txtPhone.Text);
                    Alum.Status = ddlStatus.SelectedValue;
                    Alum.BirthDay = Convert.ToDateTime(txtbirthday.Text);

                    ServicesStudent.SaveStudent(Alum);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Data has been saved successfully!')", true);
                    LoadData();
                    CleanField();

                }

            }
            catch (Exception ex)
            {
                /*string script = @"<script type='text/javascript'>alert('{0}'); </script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);*/


                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"alert('An internal error has occurred'{ex.Message})", true);
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
                Table.Columns.Add("IdentificationId");
                Table.Columns.Add("Age");
                Table.Columns.Add("Adress");
                Table.Columns.Add("Gender");
                Table.Columns.Add("Phone");
                Table.Columns.Add("Status");


                var List = Session["HLstStudent"] as List<Alumno>;
                foreach(var ls in List)
                {
                    DataRow row = Table.NewRow();
                    row["Id"] = ls.Id;
                    row["Name"] = ls.Nombres;
                    row["LastName1"] = ls.PrimerApellido;
                    row["LastName2"] = ls.SegundoApellido;
                    row["IdentificationId"] = ls.Cedula;
                    row["Age"] = "30";
                    row["Adress"] = ls.Direccion;
                    row["Gender"] = ls.Sexo;
                    row["Phone"] = ls.Telefono;
                    row["Status"] = ls.Status;
                    Table.Rows.Add(row);
                }
                gvStudents.DataSource = Table;
                gvStudents.DataBind();
                

            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}'); </script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            }
        }

        protected void txtbirthday_TextChanged(object sender, EventArgs e)
        {
            CalculateAge();
            
        }

        private void CalculateAge()
        {
            int Year = Convert.ToInt32(txtbirthday.Text.Substring(6, 4));
            int Month = Convert.ToInt32(txtbirthday.Text.Substring(3, 2));
            int Day = Convert.ToInt32(txtbirthday.Text.Substring(0, 2));
            DateTime nacimiento = new DateTime(Year, Month, Day);
            TxtAge.Text = Convert.ToString(DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1);
        }

        private void CleanField()
        {
            txtStudenteName.Text="";
            txtLastName1.Text = "";
            TxtLastName2.Text = "";
            txtbirthday.Text = "";
            TxtIdentificationId.Text = "";
            TxtAge.Text = "";
            ddlGender.SelectedIndex = 0;
            ddlStatus.SelectedIndex=0;     
            txtAdress.Text = "";
            txtPhone.Text = "";
          

        }
    }
}