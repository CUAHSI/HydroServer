using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HydroServer.Proxy;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Interface i = new Interface())
            {                
                foreach (var item in i.ODMDatabases()) 
                { 
                    listBox1.Items.Add(item.Title); 
                }                
                foreach (var item in i.ODMDatabaseQuery1()) 
                { 
                    listBox2.Items.Add(item.Title); 
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
