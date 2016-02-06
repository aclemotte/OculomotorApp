using LookAndPlayForm.DataBase;
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
        string date;
        string user_id;

        public CommentsForm(string date, string user_id)
        {
            InitializeComponent();

            this.date = date;
            this.user_id = user_id;
            commentsDone = false;
            loadCommentsFromDB(date, user_id);
            //openCommentsFile(selectedPath);
        }

        /*
        private void openCommentsFile(string selectedPath)
        {
            string file = @"\comments.txt";

            if (File.Exists(selectedPath + file))
            {
                textBoxComments.Text = File.ReadAllText(selectedPath + file);
                textBoxComments.SelectionStart = 0;
                commentsDone = false;
            }
        }*/

        private void CommentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (commentsDone)
            {
                DialogResult dialogResult = MessageBox.Show("Save changes?", "Comments done", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                    //saveComments();
                    saveCommentsInDB(date, user_id);
            }
        }

        private void loadCommentsFromDB(string date, string user_id)
        {
            textBoxComments.Text = DataBaseWorker.LoadComments(date, user_id);
            textBoxComments.SelectionStart = 0;
            commentsDone = false;
        }

        private void saveCommentsInDB(string date, string user_id)
        {
            DataBaseWorker.SaveComments(textBoxComments.Text, date, user_id);
        }

        /*
        private void saveComments()
        {
            File.WriteAllText(selectedPath + @"\comments.txt", textBoxComments.Text);            
        }*/

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            commentsDone = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveCommentsInDB(date, user_id);
            //saveComments();
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
