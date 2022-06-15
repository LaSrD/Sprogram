using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace 进制转换
{
    public partial class 进制转换 : Form
    {
        byte begin = 2;
        byte end = 2;
        bool isdigit = true;
        public 进制转换()
        {
            InitializeComponent();
            comboBox1.Items.Add("2进制");
            comboBox1.Items.Add("8进制");
            comboBox1.Items.Add("10进制");
            comboBox1.Items.Add("16进制");
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.Items.Add("2进制");
            comboBox2.Items.Add("8进制");
            comboBox2.Items.Add("10进制");
            comboBox2.Items.Add("16进制");
            comboBox2.SelectedItem = comboBox1.Items[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            change();
        }

        private void button2_b_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == comboBox1.Items[0].ToString())
            {
                button2_b.BackColor = Color.Orange;
                button8_b.BackColor = Color.White;
                button10_b.BackColor = Color.White;
                button16_b.BackColor = Color.White;
                begin = 2;
            }
            if (comboBox1.Text == comboBox1.Items[1].ToString())
            {
                button8_b.BackColor = Color.Orange;
                button2_b.BackColor = Color.White;
                button10_b.BackColor = Color.White;
                button16_b.BackColor = Color.White;
                begin = 8;
            }
            if (comboBox1.Text == comboBox1.Items[2].ToString())
            {
                button10_b.BackColor = Color.Orange;
                button8_b.BackColor = Color.White;
                button2_b.BackColor = Color.White;
                button16_b.BackColor = Color.White;
                begin = 10;
            }
            if (comboBox1.Text == comboBox1.Items[3].ToString())
            {
                button16_b.BackColor = Color.Orange;
                button8_b.BackColor = Color.White;
                button10_b.BackColor = Color.White;
                button2_b.BackColor = Color.White;
                begin = 16;
            }
            change();
        }

        private void button8_b_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = comboBox1.Items[1];
        }

        private void button10_b_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = comboBox1.Items[2];
        }

        private void button16_b_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = comboBox1.Items[3];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == comboBox2.Items[0].ToString())
            {
                button2_e.BackColor = Color.Orange;
                button8_e.BackColor = Color.White;
                button10_e.BackColor = Color.White;
                button16_e.BackColor = Color.White;
               end = 2;
            }
            if (comboBox2.Text == comboBox2.Items[1].ToString())
            {
                button8_e.BackColor = Color.Orange;
                button2_e.BackColor = Color.White;
                button10_e.BackColor = Color.White;
                button16_e.BackColor = Color.White;
               end = 8;
            }
            if (comboBox2.Text == comboBox2.Items[2].ToString())
            {
                button10_e.BackColor = Color.Orange;
                button8_e.BackColor = Color.White;
                button2_e.BackColor = Color.White;
                button16_e.BackColor = Color.White;
               end = 10;
            }
            if (comboBox2.Text == comboBox2.Items[3].ToString())
            {
                button16_e.BackColor = Color.Orange;
                button8_e.BackColor = Color.White;
                button10_e.BackColor = Color.White;
                button2_e.BackColor = Color.White;
               end = 16;
            }
            change();
        }

        private void button2_e_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = comboBox2.Items[0];
        }

        private void button8_e_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = comboBox2.Items[1];
        }

        private void button10_e_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = comboBox2.Items[2];
        }

        private void button16_e_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = comboBox2.Items[3];
        }

        private void btnchangle_Click(object sender, EventArgs e)
        {
            isdigit = !isdigit;
            if (isdigit)
                btnchangle.Text = "整数";
            else
                btnchangle.Text = "实数";
            change();

        }
        private void change()
        {
            if (isdigit)
            {
                switch (begin)
                {
                    case 2:
                        textBox2.Text = base_Conversion.base_binaryToother(textBox1.Text, end);
                        break;
                    case 8:
                        textBox2.Text = base_Conversion.base_OctToOther(textBox1.Text, end);
                        break;
                    case 10:
                        textBox2.Text = base_Conversion.base_DecToOther(textBox1.Text, end);
                        break;
                    case 16:
                        textBox2.Text = base_Conversion.base_HexToOther(textBox1.Text, end);
                        break;
                }
            }
            else
            {
                switch (begin)
                {
                    case 2:
                        textBox2.Text = base_Conversion.doublebinaryToOther(textBox1.Text, end);
                        break;
                    case 8:
                        textBox2.Text = base_Conversion.doubleOctToOther(textBox1.Text, end);
                        break;
                    case 10:
                        textBox2.Text = base_Conversion.doubleDecToOther(textBox1.Text, end);
                        break;
                    case 16:
                        textBox2.Text = base_Conversion.doubleHexToOther(textBox1.Text, end);
                        break;
                }
            }

        }
    }
}
