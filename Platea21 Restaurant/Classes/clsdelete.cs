using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Cindy_Restaurant.Classes
{
    class clsdelete : clsInsert
    {

        public void deleteEmployee(string id)
        {
            try
            {
                string sql = "delete from tblEmployee where empID='" + id.Trim() + "'";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Empleado eliminado correctamente !", "Guardado - Platea21 Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //void payment
        public  void deleteDetailsSettlementByID(string kot) {
            try
            {
                string sql = "delete from detailsSettlement where KOT='" + kot.Trim() + "'";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pago evitado exitosamente !", "Guardado - Platea21 Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
    }
}
