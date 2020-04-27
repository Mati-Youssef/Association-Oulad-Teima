using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAssociation
{
    class ado
    {
  
            // Declaration Objet SqlClient
            private SqlConnection cn = new SqlConnection();
            private SqlCommand cmd = new SqlCommand();
            private SqlDataAdapter da = new SqlDataAdapter();

            // Constructeur
            public ado()
            {
                cn.ConnectionString = "Data Source = .; Initial Catalog = association; Integrated Security = True";
            }

            // Pour Ouvrir la connection
            private void cnOpen()
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }

            // Pour fermer la connection
            private void cnClose()
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            // Pour Select Data dans la BD
            public DataTable readData(string query)
            {
                DataTable dt = new DataTable();
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = cn;

                    cnOpen();
                    da.SelectCommand = cmd;
                    cnClose();

                    da.Fill(dt);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                return dt;
            }

            // Pour Insert, Update et Delete Data dans la BD
            public bool IUDData(string query)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = cn;
                try
                {
                    cnOpen();
                    cmd.ExecuteNonQuery();
                    cnClose();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }


        
    }

}

