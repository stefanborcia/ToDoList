using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=.; initial catalog=ToDoListDB;integrated security=true");
        private void Form1_Load(object sender, EventArgs e)
        {
            bind_Data();
        }

        private void bind_Data()
        {
            SqlCommand cmd1 =
                new SqlCommand(
                    "Select id As Number,day As Day,time As Time,todo As ToDo,requirements As Requirements from Table1", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 =
                new SqlCommand(
                    "Insert into Table1(id,day,time,todo,requirements) Values(@id,@day,@time,@todo,@requirements)",
                    con);
            cmd2.Parameters.AddWithValue("id",textBox1.Text);
            cmd2.Parameters.AddWithValue("day", DateTime.Parse(textBox2.Text));
            cmd2.Parameters.AddWithValue("time", DateTime.Parse(textBox3.Text));
            cmd2.Parameters.AddWithValue("todo",textBox4.Text);
            cmd2.Parameters.AddWithValue("requirements",textBox5.Text);

            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
            bind_Data();
        }
    }
}
