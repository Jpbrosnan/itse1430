/*
 * ITSE 1430
 * Product Database Project
 * Name: Jonathan Brosnan
 * Lab 4 Final
 * Last Updated: 12/06/23
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows
{
    partial class AboutBox1 : Form
    {
        public AboutBox1 ()
        {
            InitializeComponent();
            Text = String.Format("About {0}", "Assignment: Lab 4");
            labelProductName.Text = "Jonathan Brosnan";
            labelVersion.Text = "FALL 2023";
            labelCopyright.Text = "ITSE 1430";
            labelCompanyName.Text = "Lab 4";
        }

     

       



    }
}
