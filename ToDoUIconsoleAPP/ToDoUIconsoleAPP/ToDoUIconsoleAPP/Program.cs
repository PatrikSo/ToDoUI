/*
 * https://www.youtube.com/watch?v=FJ76vL_EwXA
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;



namespace ToDoUIconsoleAPP
{
    public partial class Program : Form
    {
        private Panel panel1;
        private RichTextBox richTextBox1;
        private Panel panel2;
        private Label label1;
        private Button button2;
        private Button button1;

        string path = @"C:\";
        string toDoText = "";
        DateTime date = DateTime.Now;
        string todaysFilePath = "";
        string dateFormatted = " ";

        public Program()
        {
            InitializeComponent();
            StartUp(label1, richTextBox1);
        }

        private void StartUp(System.Windows.Forms.Label label1, System.Windows.Forms.RichTextBox richTextBox1)
        {
            label1.Text = dateFormatted;

            dateFormatted = date.ToString("MM/dd/yyyy").Replace('/', '-');



            //Checking for TO DO directory in Desktop, if none we make one
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var dirName = $@"{docPath}\TO DO";
            path = dirName;

            DirectoryInfo di = Directory.CreateDirectory(dirName);

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Directory exists");
            }
            else
            {
                Console.WriteLine("Directory does not exist");
            }

            //Checking for .txt file with todays date, if none we make one (and use it)
            var filePath = $@"{docPath}\TO DO\{dateFormatted}.txt";
            todaysFilePath = filePath;

            if (File.Exists(filePath))
            {
                Console.WriteLine("Todays file exists");
                //checking if we can load an existing file into richtextBox (if we made it earlier today, for later edit)
                richTextBox1.Text = File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine("File does not exist");
                FileStream fi = File.Create(filePath);
                Console.WriteLine("File now exists");
                fi.Close();
            }
        }

        static void Main(string[] args)
        {
            Application.Run(new Program());
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 335);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 49);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "FILE OPEN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(182, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "FILE SAVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DATE";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 55);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(483, 280);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(481, 334);
            this.Controls.Add(this.panel1);
            this.Name = "Program";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        //FILE OPEN
        private void button1_Click(object sender, EventArgs e)
        {
            toDoText = File.ReadAllText(todaysFilePath);
            //richTextBox1.LoadFile(@"C:\Users\PatHQ\source\repos\ToDoUI\TO DO 10 3 2022.txt");
            richTextBox1.Text = toDoText;
        }

        //FILE CLOSE
        private void button2_Click(object sender, EventArgs e)
        {
            toDoText = richTextBox1.Text;
            File.WriteAllText(todaysFilePath, toDoText);
        }
    }
}
