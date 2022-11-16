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
    public partial class SurveyForm : Form
    {
        LoginForm loginForm;
        //Mail mail = new Mail("/*FromEmailAddress*/");
        private String employeeName;
        private String selectRestaurant;
        private int lunchYear = 2021;
        private int lunchMonth = 7;
        private int lunchDay = 28;
        private int cntEmail = 0;

        public SurveyForm()
        {
            InitializeComponent();
            lblPeriod.Text = "(" + lunchMonth.ToString() + "/" + lunchDay.ToString() + "/" + lunchYear.ToString() + ")";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            loginForm = new LoginForm();

            loginForm.loginEventHandler += getEmployeeName;
            DialogResult Result = loginForm.ShowDialog();

            if (Result != DialogResult.OK)
            {
                this.Close();
            }
        }

        private void getEmployeeName(String employeeName)
        {
            this.employeeName = employeeName;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.selectRestaurant = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.selectRestaurant = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.selectRestaurant = radioButton3.Text;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime lunchDate = new DateTime(lunchYear, lunchMonth, lunchDay, 12, 0, 0);
            DateTime submitDate = DateTime.Now;

            //check submit date is valid
            if (lunchDate <= submitDate)
            {
                MessageBox.Show("We already had team lunch on " + lunchDate.ToString("MM/dd/yyyy") + "!");
            }
            else
            {
                if (cntEmail > 0)
                {
                    MessageBox.Show("You already sent an email!");
                }
                else
                {
                    cntEmail++;

                    //Send email to summer
                    /*String toAddress = "ToEmailAddress";
                    String subject = "Team Lunch Survey";
                    String body = employeeName + " has selected " + selectRestaurant;

                    mail.setToAddress(toAddress);
                    MessageBox.Show(mail.sendMail(subject, body));*/
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
