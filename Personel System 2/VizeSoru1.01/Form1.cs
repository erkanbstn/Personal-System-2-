﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VizeSoru1._01
{
    public partial class Form1 : Form
    {

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4PML7KK; Initial Catalog=Northwind; Integrated Security=TRUE");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Silver; 
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
                textBox2.PasswordChar = '*';
            }
        }

        char? none = null;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar =Convert.ToChar(none);
            }
        }

        bool isThere;
        public static string infoUnvan = "";

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pass = textBox2.Text;
           
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Personeller", connection);
            SqlDataReader reader = command.ExecuteReader();
        
            while (reader.Read())
            {
                if (username == reader["Adi"].ToString().TrimEnd() && pass == reader["Extension"].ToString().TrimEnd())
                {
                    Form2 frm2 = new Form2();
                    frm2.ShowDialog();
                    infoUnvan = reader["Unvan"].ToString().TrimEnd();
                    isThere = true;
                    break;
                }

                else
                {
                    isThere = false;

                }
            }//while döngüsü

            if (isThere)
            {
                MessageBox.Show("Başarıyla giriş yaptınız !", "Program");

            }

            else
            {
                MessageBox.Show("Giriş yapamadınız !", "Program");
            }
        }//private void  button2_Click
    }
}
