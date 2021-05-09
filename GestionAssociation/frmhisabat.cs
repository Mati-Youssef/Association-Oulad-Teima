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
    public partial class frmhisabat : DevExpress.XtraEditors.XtraForm
    {
        public string name;
        ado ad = new ado();
        DataTable data = new DataTable();
        public frmhisabat()
        {
            InitializeComponent();
        }
        public void tam()
        {
         data = ad.readData("select max(idC) from Compte ");
         
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
        string y;
        public string  check()
        {
            
            if (radioButton1.Checked == true)
            {
               y = "المصاريف";
            }
            if (radioButton2.Checked == true)
            {
                y = "المذاخيل";
            }
                     
            return y;
        }
        public bool testcheck()
        {
            bool x = false;
            if (radioButton1.Checked == true || radioButton2.Checked == true)
            {
                x = true;
            }
            else x = false;
            return x;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (testcheck() == true && textBox2.Text != "" && textBox3.Text != "" &&  comboBox1.Text != "" && comboBox3.Text != "")
            {
                string y = check();
                bool flag;
                flag = ad.IUDData("Insert into Compte values (N'" + textBox5.Text + "',N'" + y + "',N'" + comboBox3.Text + "',N'" + comboBox1.Text + "',N'" + textBox2.Text + "',N'" + name+ "','" + textBox3.Text + "')");
                if (flag == true)
                {
                    MessageBox.Show("تم الاضافة بنجاح", "مرحبا");
                    tam();
                    comboBox1.Text = "";
                    textBox2.Text = "";
                    comboBox4.Text = "";
                    textBox3.Text = "";
                    comboBox3.Text = "";
             
                }
                else
                    MessageBox.Show("فشلت العملية", "مرحبا");
            }
            else
                MessageBox.Show("يجب ملئ جميع الخانات", "تنبيه");
        }

        private void frmhisabat_Load(object sender, EventArgs e)
        {
            tam();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for ( int i = 2015; i<= DateTime.Now.Year; i++)
            {
                comboBox3.Items.Add(i);
                comboBox4.Items.Add(i);
            }
            string[] HH = new string[] { "يناير", " فبراير", " مارس", " ابريل", " ماي", " يونيو", " يوليو", " أغسطس", " سبتمبر", " أكتوبر", " نوفمبر", " ديسمبر" };
            comboBox1.Items.AddRange(HH);
            comboBox2.Items.AddRange(HH);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
           
                if (radioButton4.Checked == true)
                {
                    y = "المصاريف";
                }
                if (radioButton3.Checked == true)
                {
                    y = "المذاخيل";
                }

          
         
           data = ad.readData("select * from Compte where typeCompte  =N'" + y + "' and Anne = '" + comboBox4.Text+ "' and Mois =N'" +comboBox2.Text+ "' ");
           
            dataGridView1.DataSource = data;
            DataTable d = new DataTable();
            d = ad.readData("select sum(prix) from Compte where typeCompte  =N'" + y + "' and Anne = '" + comboBox4.Text + "' and Mois =N'" + comboBox2.Text + "' ");
            label2.Text = d.Rows[0][0].ToString() + " " + "DH";
            label2.Visible = true;
            if ( radioButton3.Checked == true)
            {
                label3.Text = "مجموع المذاخيل :";
            }
            if (radioButton4.Checked == true)
            {
                label3.Text = "مجموع المصريف :";
            }

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}