using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elden_Ring_Tool {
    partial class AboutBox1 : Form {
        public AboutBox1() {
            InitializeComponent();
        }

        
        private void okButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
