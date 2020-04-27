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
    public partial class frmprof : DevExpress.XtraEditors.XtraForm
    {
        ado ad = new ado();
        DataTable data = new DataTable();
        public void tam()
        {
            data = ad.readData("select max(NumP) from prof ");
            try
            {
                int x = Int32.Parse(data.Rows[0][0].ToString());

                x = x + 1;
                textBox5.Text = x.ToString();
            }
            catch (Exception)
            {

                textBox5.Text = "1";
            }
        }
        public frmprof()
        {
            InitializeComponent();
        }

        private void frmprof_Load(object sender, EventArgs e)
        {
            string[] HH = new string[] { "رقم الاستاد(ة)", "اسم الاستاد (ة)", "أجرة الاستاذ(ة) " };
            comboBox1.Items.AddRange(HH);
            string[] installs = new string[] { "محاربةالامية", "الخياطة", "الاعلاميات", "دروس الدعم" };
            comboBox4.Items.AddRange(installs);
            tam();
            string[] Qart = new string[] { "حي الحديب", "حي اولاد فحل", "حي الكريداني" };
            comboBox9.Items.AddRange(Qart);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateEdit1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox4.Text != "" && textBox6.Text != "" &&comboBox9.Text != "")
            {
                bool flag;
              
                flag = ad.IUDData("Insert into prof values ('" + textBox5.Text + "','" + dateEdit1.EditValue+ "',N'" + comboBox4.Text + "',N'" + textBox6.Text + "',N'" + textBox4.Text + "',N'"+textBox3.Text+ "',N'" + textBox2.Text + "',N'" + comboBox9.Text + "')");
                if (flag == true)
                {
                    MessageBox.Show("تم الاضافة بنجاح", "مرحبا");
                    tam();
                    comboBox4.Text = "";
                    comboBox9.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                }
                else
                    MessageBox.Show("فشلت العملية", "مرحبا");
            }
            else
                MessageBox.Show("يجب ملئ جميع الخانات", "تنبيه");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
          data =  ad.readData("select * from prof where NumP = '"+textBox1.Text+"' ");
            if (data.Rows.Count == 0) { MessageBox.Show("لا يوجد"); }
            else
            {
                dateEdit2.Text = data.Rows[0][1].ToString();
                comboBox2.Text = data.Rows[0][2].ToString();
                textBox7.Text = data.Rows[0][3].ToString();
                textBox8.Text = data.Rows[0][4].ToString();
                textBox10.Text = data.Rows[0][5].ToString();         
                textBox9.Text = data.Rows[0][6].ToString();
                comboBox3.Text = data.Rows[0][7].ToString();
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("تاكيد الحدف  ", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool flag;
                if (textBox6.Text != "")
                {
                    flag = ad.IUDData($"delete from prof where NumP  ={textBox1.Text}");
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

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("تاكيد التعديل  ", "تحدير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool flag;
                if (textBox1.Text != "")
                {
                    flag = ad.IUDData("UPDATE prof set datedebut ='" + dateEdit2.Text + "', mission =N'" + comboBox2.Text + "',salire = '" + textBox7.Text + "',Nom =N'" + textBox8.Text + "', Cin ='" + textBox10.Text + "',tele = '" + textBox9.Text + "', Qartie =N'" + comboBox3.Text + "' where NumP  = '" + textBox1.Text + "'");
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
           data = ad.readData("select * from prof");
            dataGridView1.DataSource = data;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DataTable d = new DataTable();
                d = ad.readData("select * from prof order by NumP");
                dataGridView1.DataSource = d;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                DataTable d = new DataTable();
                d = ad.readData("select * from prof order by Nom");
                dataGridView1.DataSource = d;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                DataTable d = new DataTable();
                d = ad.readData("select * from prof order by salire");
                dataGridView1.DataSource = d;
            }
        }
    }
}