﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this method executes BEFORE any event method on
            //     EACH processing of this web page

            OutputArea.ForeColor = System.Drawing.Color.Black;
            OutputArea.Font.Size = 20;
            OutputArea.Text = "";
        }

        protected void PressMe_Click(object sender, EventArgs e)
        {
            //this method stub for the button was generated by
            //   double clicking the button control on your web form
            //   while in Design view.

            //when the PressMe button is pressed, this code will
            //     be executed
            //this is called event-driven logic
            //the event was the pressing of the buttone
            //see the OnClick property of your control on the
            //    web page

            //the ID name of a control acts as the variable name
            //    in your code
            //since, each control is a class instance, access to
            //    the contents of a class is by the class properties
            //JUST like Razor, 95% of all data content is returned
            //   as a string

            if (string.IsNullOrEmpty(NameArg.Text))
            {
                OutputArea.Text = "Enter your name, please";
               
            }
            else
            {
                OutputArea.Text = "Hello " + NameArg.Text;
                OutputArea.ForeColor = System.Drawing.Color.Red;
                OutputArea.Font.Size = 100;
            }
        }

      
    }
}