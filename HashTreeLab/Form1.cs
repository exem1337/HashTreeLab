using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HashTreeLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = File.ReadAllText("Text.txt");
            string[] subs = s.Split(' ');
            createHashTable(subs);
            //createBinaryTree(subs);
        }

        void createBinaryTree(string[] subs)
        {
            var bt = new BinaryTree();
            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Random rnd = new Random();
            for (int i = 0; i < Convert.ToInt32(comboBox1.SelectedItem); i++)
            {
                try
                {
                    bt.Insert(rnd.Next(1,200000), subs[i]);
                }
                catch (ArgumentException) { continue; }
            }

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            label4.Text = "Потребовалось времени на создание бинарного дерева поиска (ч,мин,сек,мсек): " + elapsedTime;

        }

        void createHashTable(string[] subs)
        {
            var hashTable = new HashTable(chart1);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Code

            for (int i = 0; i < Convert.ToInt32(comboBox1.SelectedItem); i++)
            {
                try
                {
                    hashTable.Insert(subs[i], i.ToString());
                }
                catch (ArgumentException) { continue; }
            }

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            label3.Text = "Потребовалось времени на создание хеш-таблицы (ч,мин,сек,мсек): " + elapsedTime;

            //string text = hashTable.Search(textBox1.Text.ToString());
            //textBox1.Text = text;

           

        }
    }
}
