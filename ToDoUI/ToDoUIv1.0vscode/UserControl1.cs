using System;
using System.Windows.Forms;
using System.IO;

namespace ToDoUIv1._0
{
    public partial class UserControl1: UserControl
    {
        string path = @"C:\";
        string toDoText = "";
        DateTime date = DateTime.Now;
        string todaysFilePath = "";
        string dateFormatted = "";

        string openingPath = "";

        public UserControl1()
        {
            InitializeComponent();

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
            }

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("TO DO UPDATED");
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //Potential on enter save

            /*
            if(e.KeyCode == Keys.Enter)
            {
                path = textBox1.Text;
            }
            */
        }
    }
}
