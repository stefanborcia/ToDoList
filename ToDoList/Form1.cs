using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
            SqlCommand selectCmd =
                new SqlCommand(
                    "Select id As Number,day As Day,time As Time,todo As ToDo,requirements As Requirements from Table1",
                    con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = selectCmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand saveBtn =
                new SqlCommand(
                    "Insert into Table1(id,day,time,todo,requirements) Values(@id,@day,@time,@todo,@requirements)",
                    con);
            saveBtn.Parameters.AddWithValue("id", textBox1.Text);
            saveBtn.Parameters.AddWithValue("day", textBox2.Text);
            saveBtn.Parameters.AddWithValue("time", textBox3.Text);
            saveBtn.Parameters.AddWithValue("todo", textBox4.Text);
            saveBtn.Parameters.AddWithValue("requirements", textBox5.Text);

            con.Open();
            saveBtn.ExecuteNonQuery();
            con.Close();
            bind_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand editBtn = new SqlCommand(
                "Update Table1 Set day=@day,time=@time,todo=@todo,requirements=@requirements where id=@id",
                con);
            editBtn.Parameters.AddWithValue("day", textBox2.Text);
            ;
            editBtn.Parameters.AddWithValue("time", textBox3.Text);
            editBtn.Parameters.AddWithValue("todo", textBox4.Text);
            editBtn.Parameters.AddWithValue("requirements", textBox5.Text);
            editBtn.Parameters.AddWithValue("id", textBox1.Text);

            con.Open();
            editBtn.ExecuteNonQuery();
            con.Close();
            bind_Data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox1.Text = selectedrow.Cells[0].Value.ToString();
            textBox2.Text = selectedrow.Cells[1].Value.ToString();
            textBox3.Text = selectedrow.Cells[2].Value.ToString();
            textBox4.Text = selectedrow.Cells[3].Value.ToString();
            textBox5.Text = selectedrow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand deleteBtn = new SqlCommand("Delete from Table1 where id=@id", con);
            deleteBtn.Parameters.AddWithValue("id", textBox1.Text);

            con.Open();
            deleteBtn.ExecuteNonQuery();
            con.Close();
            bind_Data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand selectCmd =
                new SqlCommand(
                    "Select id As Number,day As Day,time As Time,todo As ToDo,requirements As Requirements from Table1" +
                    " where todo Like @todo+'%'", con);
            selectCmd.Parameters.AddWithValue("todo", textBox6.Text);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = selectCmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };
            func(Controls);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Add a ToDo Task")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Add a ToDo Task";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "HH:MM:SS")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "HH:MM:SS";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "MM/DD/YYYY")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "MM/DD/YYYY";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Add requirements for the task")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Add requirements for the task";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Represent how important the task is")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Represent how important the task is";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Search a specific todo task")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
             if (textBox6.Text == "")
            {
                textBox6.Text = "Search a specific todo task";
                textBox6.ForeColor = Color.Black;
            }
        }
    }
}
