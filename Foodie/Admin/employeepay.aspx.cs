using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Foodie.Admin
{
    public partial class employeepay : System.Web.UI.Page
    {
        protected  TableCell basicSalaryCell; 
        protected TableCell allowancesCell;
        protected TableCell deductionsCell;
        protected TableCell totalSalaryCell;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        //protected void btnCalculate_Click(object sender, EventArgs e)
        //{
        //    int empID = Convert.ToInt32(txtEmpID.Text);
        //    string empName = txtEmpName.Text;
        //    double basicSalary = Convert.ToDouble(txtBasicSalary.Text);
        //    double da = Convert.ToDouble(txtDA.Text);
        //    double hra = Convert.ToDouble(txtHRA.Text);

        //    double grossSalary = basicSalary + da + hra;
        //    double netSalary = grossSalary - (grossSalary * 0.1); // Assuming 10% deduction

        //    List<EmployeeSalary> salaryDetails = new List<EmployeeSalary>();
        //    salaryDetails.Add(new EmployeeSalary { EmployeeID = empID, EmployeeName = empName, BasicSalary = (decimal)basicSalary, GrossSalary = (decimal)grossSalary, NetSalary = (decimal)netSalary });

        //    //lvSalaryDetails.DataSource = salaryDetails;
        //    //lvSalaryDetails.DataBind();

        //    gvSalaryDetails.DataSource = salaryDetails;
        //    gvSalaryDetails.DataBind();
        //}

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            // Check if ViewState["SalaryDetails"] exists
            if (ViewState["SalaryDetails"] == null)
            {
                // If it doesn't exist, create a new List<EmployeeSalary> and store it in ViewState
                ViewState["SalaryDetails"] = new List<EmployeeSalary>();
            }

            // Retrieve the existing list from ViewState

            List<EmployeeSalary> salaryDetails = (List<EmployeeSalary>)ViewState["SalaryDetails"];

            // Parse input values
            int empID = Convert.ToInt32(txtEmpID.Text);
            string empName = txtEmpName.Text;
            double basicSalary = Convert.ToDouble(txtBasicSalary.Text);
            double da = Convert.ToDouble(txtDA.Text);
            double hra = Convert.ToDouble(txtHRA.Text);

            // Calculate grossSalary and netSalary
            double grossSalary = basicSalary + da + hra;
            double netSalary = grossSalary - (grossSalary * 0.1); // Assuming 10% deduction

            // Create a new EmployeeSalary object for the current employee
            EmployeeSalary newEmployee = new EmployeeSalary
            {
                EmployeeID = empID,
                EmployeeName = empName,
                BasicSalary = (decimal)basicSalary,
                GrossSalary = (decimal)grossSalary,
                NetSalary = (decimal)netSalary
            };

            // Add the new employee to the list
            salaryDetails.Add(newEmployee);

            // Store the updated list back in ViewState
            ViewState["SalaryDetails"] = salaryDetails;

            // Bind the updated list to the GridView
            gvSalaryDetails.DataSource = salaryDetails;
            gvSalaryDetails.DataBind();

            // Clear the input fields
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            txtEmpID.Text = string.Empty;
            txtEmpName.Text = string.Empty;
            txtBasicSalary.Text = string.Empty;
            txtDA.Text = string.Empty;
            txtHRA.Text = string.Empty;
        }


    }
    [Serializable]
    public  class EmployeeSalary
    {
       
            public int EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public decimal BasicSalary { get; set; }
            public decimal GrossSalary { get; set; }
            public decimal NetSalary { get; set; }
        }
    }

    

    


