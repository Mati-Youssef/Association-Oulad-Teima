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
using System.IO;
using System.Data.SqlClient;

namespace GestionAssociation
{
    public partial class frminkhirat : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();

        public void remplirC()
        {
            data = ad.readData("select *  from mission");
            comboBox4.DataSource = data;
            comboBox4.DisplayMember = "typeM";
            comboBox4.ValueMember = "idM";
 
        }
        public void remplirC2()
        {
            data = ad.readData("select *  from mission");
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "typeM";
            comboBox1.ValueMember = "idM";
        }
        public void remplirC3()
        {
            data = ad.readData("select *  from mission");
            comboBox6.DataSource = data;
            comboBox6.DisplayMember = "typeM";
            comboBox6.ValueMember = "idM";
        }
        public void remplirC4()
        {
            data = ad.readData("select *  from mission");
            comboBox7.DataSource = data;
            comboBox7.DisplayMember = "typeM";
            comboBox7.ValueMember = "idM";
        }
        public void tam()
        {
            data = ad.readData("select max(NumC) from condidtur ");
            try
            {
                int x = Int32.Parse(data.Rows[0][0].ToString());

                x = x + 1;
                textBox5.Text = x.ToString();
            }
            catch
            {

                textBox5.Text ="1";
            }
        }
        public frminkhirat()
        {
            InitializeComponent();
            cn.ConnectionString = "Data Source = .; Initial Catalog = association; Integrated Security = True";
        }
        ado ad = new ado();
        DataTable data = new DataTable();
        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            data = ad.readData("select * from condidtur where NumC = '" + textBox6.Text + "'");
            if (data.Rows.Count == 0) { MessageBox.Show("لا يوجد"); }
            else
            {
                dateTimePicker1.Text = data.Rows[0][1].ToString();
                comboBox6.Text = data.Rows[0][2].ToString();
                comboBox7.Text = data.Rows[0][3].ToString();
                textBox10.Text = data.Rows[0][4].ToString();
                textBox9.Text = data.Rows[0][5].ToString();
                textBox8.Text = data.Rows[0][6].ToString();
                comboBox2.Text = data.Rows[0][7].ToString();
                textBox7.Text = data.Rows[0][8].ToString();
            }
           
            
            
        }      
        private void frminkhirat_Load(object sender, EventArgs e)
        {
            remplirC4();
            remplirC3();
            remplirC2();
            remplirC();
            //string[] installs = new string[] { "محاربةالامية", "الخياطة", "الاعلاميات","دروس الدعم" };
            //comboBox4.Items.AddRange(installs);
            //comboBox1.Items.AddRange(installs);

            string[] Qart = new string[] { "حي الحديب", "حي اولاد فحل", "حي الكريداني" };
            comboBox9.Items.AddRange(Qart);
            comboBox2.Items.AddRange(Qart);
            tam();
            string[]  HH = new string[] { "رقم المنخرط", "اسم المنخرط", "عمر المنخرط" };
            comboBox3.Items.AddRange(HH);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
         
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
   
            try
            {
                if (radioButton2.Checked == false)
                {
                   
                    if (dateTimePicker2.Text != "" && comboBox4.Text != "" && comboBox9.Text != "" && comboBox1.Text != "" && textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                    {

                        try
                        {
                            bool flag;
                            flag = ad.IUDData("Insert into condidtur values ('" + textBox5.Text + "','" + dateTimePicker2.Value + "',N'" + comboBox4.Text + "',N'" + comboBox1.Text + "',N'" + textBox4.Text + "',N'" + textBox3.Text + "',N'" + textBox2.Text + "',N'" + comboBox9.Text + "',N'" + textBox1.Text + "')");
                            if (flag == true)
                            {
                                MessageBox.Show("تم الاضافة بنجاح", "مرحبا");
                                tam();
                                comboBox4.Text = "";
                                comboBox1.Text = "";
                                comboBox3.Text = "";
                                comboBox9.Text = "";
                                textBox4.Text = "";
                                textBox3.Text = "";
                                textBox1.Text = "";
                                textBox2.Text = "";
                            }
                            else
                                MessageBox.Show("فشلت العملية", "مرحبا");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("يجب ملئ جميع الخانات", "تنبيه");
                }
                else
                if( radioButton2.Checked == true)
                {
                   
                    
                        if (dateTimePicker2.Text != "" && comboBox4.Text != "" && textBox11.Text != "" && comboBox1.Text != "" && textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                        {

                            try
                            {
                                bool flag;
                                flag = ad.IUDData("Insert into condidtur values ('" + dateTimePicker2.Value + "',N'" + comboBox4.Text + "',N'" + comboBox1.Text + "',N'" + textBox4.Text + "',N'" + textBox3.Text + "',N'" + textBox2.Text + "',N'" + textBox11.Text + "',N'" + textBox1.Text + "')");
                                if (flag == true)
                                {
                                    MessageBox.Show("تم الاضافة بنجاح", "مرحبا");
                                    tam();
                                    comboBox4.Text = "";
                                    comboBox1.Text = "";
                                    comboBox3.Text = "";
                                    textBox11.Text = "";
                                    textBox4.Text = "";
                                    textBox3.Text = "";
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                }
                                else
                                    MessageBox.Show("فشلت العملية", "مرحبا");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                            MessageBox.Show("يجب ملئ جميع الخانات", "تنبيه");
                    
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void simpleButton9_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("تاكيد الحدف  ", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool flag;
                if (textBox6.Text != "")
                {
                    flag = ad.IUDData($"delete from condidtur where NumC  ={textBox6.Text}");
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
                if (textBox6.Text != "")
                {                
                    flag = ad.IUDData("UPDATE condidtur set dateC ='" + dateTimePicker1.Value + "', typeC1 =N'" + comboBox6.Text + "',typeC2 = N'" + comboBox7.Text + "',Nom =N'" + textBox10.Text + "', Cin ='" + textBox9.Text + "',age = '" + textBox8.Text + "', Qartie =N'" + comboBox2.Text + "',prix ='" + textBox7.Text + "' where NumC  = '" + textBox6.Text + "'");
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( comboBox3.SelectedIndex == 0)
            {
                DataTable d = new DataTable();
               d= ad.readData("select * from condidtur order by NumC");
                dataGridView1.DataSource = d;
            }
            if (comboBox3.SelectedIndex == 1)
            {
                DataTable d = new DataTable();
                d = ad.readData("select * from condidtur order by Nom");
                dataGridView1.DataSource = d;
            }
            if (comboBox3.SelectedIndex == 2)
            {
                DataTable d = new DataTable();
                d = ad.readData("select * from condidtur order by age");
                dataGridView1.DataSource = d;
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataTable d = new DataTable();
            d = ad.readData("select * from condidtur");
            dataGridView1.DataSource = d;
        }

       
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Text = "قم بادخال اسم الحي ";
            label2.Visible = true;
            textBox11.Visible = true;
            if (radioButton2.Checked == true)
            {
                comboBox9.Enabled = false;
            }
            else
                comboBox9.Enabled = true;

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            groupControl3.Visible = true;
        }
    }
}