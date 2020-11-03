using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg += "Name: " + FullName.Text;
            msg += " Email: " + EmailAddress.Text;
            msg += " Phone: " + Phone.Text;
            msg += " Time: " + (FullOrPartTime.SelectedValue == "1" ? " Full time" :
                                FullOrPartTime.SelectedValue == "2" ? " Part time" : " Either");

            //handle the CheckBoxList
            //traverse the checkbox list, review one item
            //  at a time and add those items selected to the message
            //if no items were choosen, then add an appropriate message
            //  stating that no items were choosen

            msg += " Jobs: ";

            //set my found flag to "nothing found" (false)
            bool found = false;

            //loop processing, if something is found then
            //    set the found flag to true
            foreach (ListItem jobrow in Jobs.Items)
            {
                //for each item in the collection
                if (jobrow.Selected)
                {
                    msg += jobrow.Text + " ";
                    found = true;
                }
            }

            //check if nothing was found
            if (!found)
            {
                msg += "You did not select a job. Application rejected.";
            }

            MessageLabel.Text = msg;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FullName.Text = "";
            EmailAddress.Text = "";
            Phone.Text = "";
            //for Lists there are a couple of ways to reset
            //a) manually reset the control SelectIndex to -1
            FullOrPartTime.SelectedIndex = -1;
            //b) use a control method to reset (I prefer)
            Jobs.ClearSelection();
        }
    }
}