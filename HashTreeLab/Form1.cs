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
            createBinaryTree(subs);
        }

        BinaryTree bt = new BinaryTree();

        void createBinaryTree(string[] subs)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Random rnd = new Random();
            for (int i = 0; i < Convert.ToInt32(comboBox1.SelectedItem); i++)
            {
                try
                {
                    string text = subs[i];
                    bt.Add(rnd.Next(1,200000), subs[i]);
                }
                catch (Exception) { continue; }
            }

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            label4.Text = "Потребовалось времени на создание бинарного дерева поиска (ч,мин,сек,мсек): " + elapsedTime;
            bt.TraverseInOrder(bt.Root, listBox1);
        }

        HashTable hashTable = new HashTable();

        void createHashTable(string[] subs)
        { 
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
        string selected = null;
        string selectedWord = null;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] s = listBox1.SelectedItem.ToString().Split(' ');
            selected = s[0];
            selectedWord = s[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(selected != null)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                hashTable.Search(selectedWord);
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                label5.Text = "Времени для поиска в хеш таблице: " + elapsedTime;

                Stopwatch stopWatch1 = new Stopwatch();
                stopWatch1.Start();
                bt.Find(Convert.ToInt32(selected));
                stopWatch1.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts1 = stopWatch1.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts1.Hours, ts1.Minutes, ts1.Seconds,
                    ts1.Milliseconds / 10);
                label6.Text = "Времени для поиска в бинарном дереве: " + elapsedTime1;
            }
            else { MessageBox.Show("Нужно выбрать словечко для поиска"); }

        }
    }
}
