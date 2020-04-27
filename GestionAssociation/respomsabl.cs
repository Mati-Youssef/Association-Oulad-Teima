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
    public partial class respomsabl : DevExpress.XtraEditors.XtraForm
    {
        ado ad = new ado();
        DataTable data = new DataTable();
        string imge = "";
        public respomsabl()
        {
            InitializeComponent();
            cn.ConnectionString = "Data Source = .; Initial Catalog = association; Integrated Security = True";
        }
        public void tam()
        {
            data = ad.readData("select max(NumR) from resp ");
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
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private void simpleButton1_Click(object sender, EventArgs e)
        {         
                   

              
              

                    
            if (dateEdit2.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox4.Text != "" && textBox6.Text != "" && comboBox9.Text != "")
            {
                try
                {
                    byte[] img = null;
                    FileStream stream = new FileStream(imge, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);
                    img = brs.ReadBytes((int)stream.Length);
                    string Query = "Insert into resp values ('" + textBox5.Text + "',@img,'" + dateEdit2.Text + "',N'" + comboBox4.Text + "',N'" + textBox6.Text + "',N'" + textBox4.Text + "',N'" + textBox3.Text + "',N'" + textBox2.Text + "',N'" + comboBox9.Text + "')";
                    cmd.CommandText = Query;
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.Parameters.Add(new SqlParameter("@img", img));
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    pictureBox1.Image = null;

                    MessageBox.Show("تم الاضافة بنجاح", "مرحبا");
                    tam();
                    comboBox4.Text = "";
                    comboBox9.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }

               
                
                
            }
            else
                MessageBox.Show("يجب ملئ جميع الخانات", "تنبيه");
        }

        private void respomsabl_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string[] HH = new string[] { "رقم المنخرط", "اسم المنخرط", " حي المنخرط" };
            comboBox3.Items.AddRange(HH);
            tam();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Close();
                cn.Open();
                cmd.CommandText = "select * from resp where NumR = '" + textBox1.Text + "'";
                cmd.Connection = cn;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {

                    byte[] images = ((byte[])reader[1]);
                    dateEdit1.Text = reader[2].ToString();
                    comboBox2.Text = reader[3].ToString();
                    textBox8.Text = reader[4].ToString();
                    textBox7.Text = reader[5].ToString();
                    textBox10.Text = reader[6].ToString();
                    textBox9.Text = reader[7].ToString();
                    comboBox1.Text = reader[8].ToString();

                    if (images == null)
                    {
                        pictureBox2.Image = null;
                    }
                    else
                    {
                        MemoryStream stream = new MemoryStream(images);
                        pictureBox2.Image = Image.FromStream(stream);
                    }

                }
                else
                {
                    MessageBox.Show("لا يوجد");
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
            
            
            //data = ad.readData("Select * from resp where NumR ='"+textBox1.Text+"'");
            //if (data.Rows.Count == 0) { MessageBox.Show("لا يوجد"); }
            //else
            //{
              
            //    dateEdit1.Text = data.Rows[0][1].ToString();
            //    textBox10.Text = data.Rows[0][2].ToString();
            //    textBox9.Text = data.Rows[0][3].ToString();
            //    textBox8.Text = data.Rows[0][4].ToString();
            //    comboBox2.Text = data.Rows[0][5].ToString();
            //    textBox7.Text = data.Rows[0][6].ToString();
            //    comboBox1.Text = data.Rows[0][7].ToString();
            //}
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            data = ad.readData("Select * from resp ");
            dataGridView1.DataSource = data;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                DataTable d = new DataTable();
                d = ad.readData("select * from resp order by NumR");
                dataGridView1.DataSource = d;
            }
            if (comboBox3.SelectedIndex == 1)
            {
                DataTable d = new DataTable();
                d = ad.readData("select * from resp order by Nom");
                dataGridView1.DataSource = d;
            }
            if (comboBox3.SelectedIndex == 2)
            {
                DataTable d = new DataTable();
                d = ad.readData("select * from resp order by salire");
                dataGridView1.DataSource = d;
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("تاكيد الحدف  ", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool flag;
                if (textBox1.Text != "")
                {
                    flag = ad.IUDData($"delete from resp where NumR  ={textBox1.Text}");
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
                    flag = ad.IUDData("UPDATE resp set datedebut ='" + dateEdit1.EditValue + "', Nom =N'" + textBox7.Text + "', mission ='" + comboBox2.Text + "',salire = '" + textBox8.Text + "', Cin =N'" + textBox10.Text + "',tele ='" + textBox9.Text + "',Qartie ='" + comboBox1.Text + "' where NumR  = '" + textBox1.Text + "'");
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

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png Files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imge = dialog.FileName.ToString();

                pictureBox1.ImageLocation = imge;
            }
            pictureBox1.Image = null;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}