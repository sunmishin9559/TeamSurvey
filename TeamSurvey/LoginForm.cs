using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamSurvey
{

    public partial class LoginForm : Form
    {
        public delegate void EventHandler(String employeeName);
        public event EventHandler loginEventHandler;
        private DataMap participants = new DataMap();
        private String employeeName;
        private String employeeID;
        public LoginForm()
        {
            InitializeComponent();

            participants.put("41601972", "Chris Nolen");
            participants.put("40005874", "Irvin Lamas");
            participants.put("41600415", "Jacob Hicks");
            participants.put("41602661", "Jeonghoon Kim");
            participants.put("21601548", "Junmo Kang");
            participants.put("41602822", "Summer Shin");
            participants.put("41603438", "Kyle Robertson");
            participants.put("41603437", "Ali Rashad");
            participants.put("qkqhajdcjddl", "Seoungyun Han");

            cbEmployeeName.Items.AddRange(participants.getValues());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            employeeName = cbEmployeeName.Text;
            employeeID = txtEmployeeID.Text.Replace(" ", String.Empty);

            if (employeeName == "")
            {
                lblLoginError.Text = "Please select your name";
                return;
            }

            if (employeeID == "")
            {
                lblLoginError.Text = "Plese enter your employee ID";
                txtEmployeeID.Text = "";
                return;
            }
            else

            if (employeeID != participants.getKey(employeeName))
            {
                lblLoginError.Text = "Your employee ID is not correct";
                txtEmployeeID.Text = "";
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.loginEventHandler(employeeName);
            this.Close();
        }
    }
}
