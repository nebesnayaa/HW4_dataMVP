using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW4_dataMVP
{
    
    public partial class View : Form, IView
    {
        #region IView Implementation

        public string name
        {
            get { return textBox1.Text.Trim(); }
            set { textBox1.Text = value; }
        }

        public string age
        {
            get { return textBox2.Text.Trim(); }
            set { textBox2.Text = value; }
        }

        public string keyWord
        {
            get { return textBox3.Text.Trim(); }
            set { textBox3.Text = value; }
        }

        public event EventHandler<EventArgs> SaveDataEvent;

        #endregion  IView Implementation

        public View()
        {
            InitializeComponent();
            button_save.Enabled = false;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveDataEvent?.Invoke(this, EventArgs.Empty);

            File.AppendAllText("data.txt", $"Name: {name} \tAge: {age}\n");
            dataList.Items.Add($"Name: {name} \tAge: {age}\n");
            
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button_save.Enabled = name.Length > 0 && age.Length > 0;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                dataList.Items.RemoveAt(dataList.SelectedIndex);
            }
            catch
            {
                dataList.Items.Clear();
            }
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            dataList.Items.Clear();

            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            string dataFromFile = sr.ReadToEnd();
            string copyText = dataFromFile;
            string text = null;

            for (int i = 0; i < copyText.Length; i++)
            {
                text += copyText[i];
                if (copyText[i] == '\n')
                {
                    dataList.Items.Add(text);
                    text = null;
                }
            }
            fs.Close();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            dataList.Items.Clear();

            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            string dataFromFile = sr.ReadToEnd();
            var copyData = dataFromFile.Split('\n').ToList();

            for (int i = 0; i < copyData.Count; i++)
            {
                if (copyData[i].Contains(keyWord))
                {
                    dataList.Items.Add(copyData[i]);
                }
            }

            fs.Close();
            textBox3.Clear();
        }
    }
}
