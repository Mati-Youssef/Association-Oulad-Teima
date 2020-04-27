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
    public partial class addmission : DevExpress.XtraEditors.XtraForm
    {
        ado ado = new ado();
        DataTable data = new DataTable();
        public void tam()
        {
            data = ado.readData("select max(idM) from mission ");
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
        public addmission()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           bool flag  = ado.IUDData("Insert into mission values ('" + textBox1.Text + "',N'" + textBox2.Text + "')");
            if (flag == true)
            {
                MessageBox.Show("تم الاضافة بنجاح", "مرحبا");
                tam();
                textBox2.Text = "";
            }
            else
                MessageBox.Show("فشلت العملية", "مرحبا");
        }

        private void addmission_Load(object sender, EventArgs e)
        {
            tam();
        }
     
    }
}