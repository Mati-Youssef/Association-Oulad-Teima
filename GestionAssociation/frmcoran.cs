using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GestionAssociation
{
    public partial class frmcoran : DevExpress.XtraEditors.XtraForm
    {
        ado ado = new ado();
        DataTable data = new DataTable();
        public frmcoran()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
          data =   ado.readData($"Select * from eleve where NumE = {textBox6.Text}");
            if (data.Rows.Count == 0) { MessageBox.Show("لا يوجد"); }
            else
            {
                dateTimePicker1.Text = data.Rows[0][1].ToString();
                textBox10.Text = data.Rows[0][2].ToString();
                textBox9.Text = data.Rows[0][3].ToString();
                textBox8.Text = data.Rows[0][4].ToString();
                comboBox2.Text = data.Rows[0][5].ToString();
                textBox7.Text = data.Rows[0][6].ToString();
            }
        }
        public void tam()
        {
            data = ado.readData("select max(NumE) from eleve ");
            try
            {
                int x = Int32.Parse(data.Rows[0][0].ToString());

                x = x + 1;
                textBox1.Text = x.ToString();
            }
            catch (Exception)
            {

                textBox1.Text = "1";
            }
        }
        private void frmcoran_Load(object sender, EventArgs e)
        {
            string[] Qart = new string[] { "حي الحديب", "حي اولاد فحل", "حي الكريداني" };
            comboBox1.Items.AddRange(Qart);
            tam();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string[] HH = new string[] { "رقم المنخرط", "اسم المنخرط", "حي المنخرط" };
            comboBox3.Items.AddRange(HH);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if ( dateTimePicker2.Text!=""&&textBox2.Text !=""&&textBox3.Text!=""&&textBox4.Text!=""&&comboBox1.Text != "" && textBox5.Text != "")
            {
                bool flag;
                flag = ado.IUDData("Insert into eleve values ('" + textBox1.Text + "','" + dateTimePicker2.Value + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + textBox4.Text + "',N'" + comboBox1.Text + "',N'" + textBox5.Text + "')");
                if (flag == true)
                {
                    MessageBox.Show("تم الاضافة بنجاح", "مرحبا");
                    tam();
                    comboBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                }
                else
                    MessageBox.Show("فشلت العملية", "مرحبا");
            }
            else
                MessageBox.Show("يجب ملئ جميع الخانات", "تنبيه");

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("تاكيد الحدف  ", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool flag;
                if (textBox6.Text != "")
                {
                    flag = ado.IUDData($"delete from eleve where NumE  ={textBox6.Text}");
                    if (flag == true)
                    {
                        MessageBox.Show("تم الحذف بنجاح");
                    }
                    else
                        MessageBox.Show("فشلت العملية");
                }
                else
                    MessageBox.Show("قم بكتابة رقم الشخص المطلوب ");
            }
            else
                MessageBox.Show("تم الغاء العملية ");
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("تاكيد التعديل  ", "تحدير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool flag;
                if (textBox6.Text != "")
                {      
                    flag = ado.IUDData("UPDATE eleve set dateC ='" + dateTimePicker1.Value + "', Nom =N'" + textBox10.Text + "', IdE ='" + textBox9.Text + "',age = '" + textBox8.Text + "', Qartie =N'" + comboBox2.Text + "',prix ='" + textBox7.Text + "' where NumE  = '" + textBox6.Text + "'");
                    if (flag == true)
                    {
                        MessageBox.Show("تم التعديل بنجاح");
                    }
                    else
                        MessageBox.Show("فشلت العملية");
                }
                else
                    MessageBox.Show("قم بالبحت عن الشخص المطلوب");
            }
            else
                MessageBox.Show("تم الغاء العملية");
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            data = ado.readData("select * from eleve");
            dataGridView1.DataSource = data;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                DataTable d = new DataTable();
                d = ado.readData("select * from eleve order by NumE");
                dataGridView1.DataSource = d;
            }
            if (comboBox3.SelectedIndex == 1)
            {
                DataTable d = new DataTable();
                d = ado.readData("select * from eleve order by Nom");
                dataGridView1.DataSource = d;
            }
            if (comboBox3.SelectedIndex == 2)
            {
                DataTable d = new DataTable();
                d = ado.readData("select * from eleve order by Qartie");
                dataGridView1.DataSource = d;
            }
        }
    }
}