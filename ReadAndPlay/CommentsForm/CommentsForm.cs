using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.Comments
{
    public partial class CommentsForm : Form
    {
        bool commentsDone;
        string selectedPath;

        public CommentsForm(string selectedPath)
        {
            InitializeComponent();
            labelVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
            this.selectedPath = selectedPath;
            commentsDone = false;
            openCommentsFile(selectedPath);
        }

        private void openCommentsFile(string selectedPath)
        {
            string file = @"\comments.txt";

            if (File.Exists(selectedPath + file))
            {
                textBoxComments.Text = File.ReadAllText(selectedPath + file);
                textBoxComments.SelectionStart = 0;
                commentsDone = false;
            }
        }

        private void CommentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (commentsDone)
            {
                DialogResult dialogResult = MessageBox.Show("Save changes?", "Comments done", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                    saveComments();
            }
        }

        private void saveComments()
        {
            File.WriteAllText(selectedPath + @"\comments.txt", textBoxComments.Text);            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            commentsDone = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveComments();
            commentsDone = false;
            this.Close();
        }

        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            commentsDone = false;
            this.Close();
        }
    }
}
