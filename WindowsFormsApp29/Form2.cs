using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp29
{
    public partial class Form2 : Form
    {
        private static string connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = example.accdb";
        private OleDbConnection connection = new OleDbConnection(connect);
        private OleDbDataAdapter adapter = null;
        private DataSet dataSet = null;
        private DataTable table = null;
        int id = 1;
        public Form2()
        {
            InitializeComponent();
            connection.Open();
        }
        private void dataup()
        {
            dataSet.Tables["операции"].Clear();
            adapter.Fill(dataSet, "операции");
        }
        private void Initialization()
        {
            try
            {
               
                
             //   textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                //  textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                MessageBox.Show("Данного элемента нет!");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            adapter = new OleDbDataAdapter("SELECT * FROM операции", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "операции");
            table = dataSet.Tables["операции"];
            dataGridView1.DataSource = table;
            Initialization();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Initialization();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(textBox1.Text);
                int year = int.Parse(textBox2.Text);
                string place = textBox3.Text.ToString();
               //  string field = textBox3.Text.ToString();
            //    string name = textBox5.Text.ToString();
                OleDbCommand update = connection.CreateCommand();
                update.CommandText = $"UPDATE [операции] SET ID = '{id}', [Дата]='{year}' ,[Выполнил]='{place}'"; //' WHERE [ФИО]='{name}'
                update.ExecuteNonQuery();
                dataup();
            }
            catch
            {
                MessageBox.Show("Неверный формат данных!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(textBox6.Text);
               // int year = int.Parse(textBox2.Text);
               // string place = textBox3.Text.ToString();
                //string field = textBox3.Text.ToString();
              //  string name = textBox5.Text.ToString(); 
                OleDbCommand delete = connection.CreateCommand();
               delete.CommandText = $"DELETE FROM [операции] WHERE [ID] = {ID}";
                delete.ExecuteNonQuery();
                dataup();
            }
            catch
            {
                MessageBox.Show("Неверный формат данных!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // int ID = dataGridView1.Rows.Count;
                int ID = int.Parse(textBox7.Text);
                //int year = int.Parse(textBox8.Text);
                string year = textBox8.Text.ToString();
                string place = textBox9.Text.ToString();
               // string field = textBox9.Text.ToString();
               // string name = textBox10.Text.ToString();
                OleDbCommand Insert = connection.CreateCommand();
                Insert.CommandText = $"INSERT INTO [операции] ([ID],[Дата],[Выполнил]) VALUES('{ID}','{year}','{place}')";
                Insert.ExecuteNonQuery();
                dataup();
              textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
               // textBox9.Text = "";
            }
            catch
            {
                MessageBox.Show("Неверный формат данных!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
