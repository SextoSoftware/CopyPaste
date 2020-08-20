using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cindy_Restaurant.Classes;
using Cindy_Restaurant.Forms;
using Cindy_Restaurant.Form_View;
using Cindy_Restaurant.Folder_Updates;
namespace Cindy_Restaurant
{
    public partial class frmParent : Form
    {
        public frmParent()
        {
            InitializeComponent();
        }

        public int getLogNum;
        DateTime dayTime = new DateTime();
        clsSelect selectClass = new clsSelect();
        clsUpdate updateClass = new clsUpdate();
        public string emPloID;
        public string getIDNumber;

        ComboBox lblCur = new ComboBox();// pull the default currency;
        private void frmParent_Load(object sender, EventArgs e)
        {
            selectClass.getEmployeeByID(statGetUser.Text.ToString());
            emPloID = selectClass.getEmployeeID;
            timer1.Start();
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            frmDeveloper vDeveloper = new frmDeveloper();
            vDeveloper.ShowDialog();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           dayTime = DateTime.Now;
            statGetDate.Text = dayTime.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult reason = MessageBox.Show("¿ESTA SEGURO DE SALIR?", "CERRAR APLICACION - PLATEA21", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (reason.Equals(DialogResult.OK)) {
                getCashierReportText();
                DateTimePicker endDay = new DateTimePicker();

                updateClass.updateLogHistory(getLogNum, statGetUser.Text, endDay, endDay);
                this.Close();
        }
    }

        private void button5_Click(object sender, EventArgs e)
        {
            frmRegEmp regEmeployee = new frmRegEmp();
            regEmeployee.ShowDialog();
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            frmAddUsers addUsers = new frmAddUsers();
            addUsers.ShowDialog();
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            btnCancel recallForm = new btnCancel();
            selectClass.getEmployeeByID(this.statGetUser.Text);
            recallForm.lblGetId.Text = selectClass.getEmployeeID;
            recallForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTheTables tableorder = new frmTheTables();
            tableorder.empID = this.statGetUser.Text;
            tableorder.receiptType = btnDineIn.Text;
           
            tableorder.ShowDialog();
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            orderInfo infoOrder = new orderInfo();
            
            infoOrder.txtWaiterName.Text = this.statGetUser.Text;
            infoOrder.txtTableNo.Text = "0";
            //infoOrder.txtAdultNo.Text = "1";
            //infoOrder.txtChild.Text = "0";
            infoOrder.txtReceiptType.Text = btnTakeAway.Text;
            infoOrder.orderType = btnTakeAway.Text;
            infoOrder.ShowDialog();
        }

        private void btnNocharge_Click(object sender, EventArgs e)
        {
            frmTheTables tableorder = new frmTheTables();
            tableorder.receiptType = btnNocharge.Text;
            
            tableorder.empID = this.statGetUser.Text;
            tableorder.ShowDialog();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
           frmChangePass  passChange = new frmChangePass();
            passChange.getEmpName = this.statGetUser.Text;
            passChange.ShowDialog();
        }

        private void btnBakup_Click(object sender, EventArgs e)
        {
            updateClass.BackUp();
        }

        private void btnCuurency_Click(object sender, EventArgs e)
        {
            frmCurrency curr = new frmCurrency();
            curr.ShowDialog();
        }

        private void btnAddPOSCurrency_Click(object sender, EventArgs e)
        {
            frmAddElectronicCurrency elecAdd = new frmAddElectronicCurrency();
            elecAdd.ShowDialog();
        }

        private void btnAddMenus_Click(object sender, EventArgs e)
        {
            frmProductReg prodAdd = new frmProductReg();
            prodAdd.ShowDialog();
        }

        private void btnAddMenuGroup_Click(object sender, EventArgs e)
        {
            frmProdType prodType = new frmProdType();
            prodType.ShowDialog();
        }

        private void btnVCurrency_Click(object sender, EventArgs e)
        {
            frmViewCurrency vCurr = new frmViewCurrency();
            vCurr.ShowDialog();
        }

        private void btnVPOS_Click(object sender, EventArgs e)
        {
            frmViewElectronicCurrency vPOS = new frmViewElectronicCurrency();
            vPOS.ShowDialog();
        }

        private void btnVEmployee_Click(object sender, EventArgs e)
        {
            frmViewEmployees vEmployee = new frmViewEmployees();
            vEmployee.ShowDialog();
        }

        private void btnVUsers_Click(object sender, EventArgs e)
        {
            frmViewUsers vUsers = new frmViewUsers();
            vUsers.ShowDialog();
        }

        private void btnVLogins_Click(object sender, EventArgs e)
        {
            frmViewLogHistory vLogs = new frmViewLogHistory();
            vLogs.ShowDialog();
        }

        private void btnVorder_Click(object sender, EventArgs e)
        {
            frmViewOrderInfo vOrder = new frmViewOrderInfo();
            vOrder.ShowDialog();
        }

        private void btnVProducts_Click(object sender, EventArgs e)
        {
            frmViewProducts vProd = new frmViewProducts();
            vProd.ShowDialog();
        }

        private void btnVProdTypes_Click(object sender, EventArgs e)
        {
            frmViewProductTypes vProdType = new frmViewProductTypes();
            vProdType.ShowDialog();
        }

        private void btnVtaxes_Click(object sender, EventArgs e)
        {
            frmViewTax vTax = new frmViewTax();
            vTax.ShowDialog();
        }

        //cashier information

        private void getCashierReportText()
        {
            selectClass.selectShiftNumberAndTimeFromLoginHistory(this.statGetUser.Text);
            string cashierID = selectClass.getEmployeeByID(this.statGetUser.Text);

          selectClass.sumAllCash(cashierID,Convert.ToDateTime(selectClass.logDates), dayTime.Date);
          selectClass.sumAllPOS(cashierID, DateTime.Parse(selectClass.logDates), dayTime.Date);
         
            //cashier report goes here
            frmVCashierReport repCashier = new frmVCashierReport();
            repCashier.textBox1.AppendText("\t\tREPORTE DE CAJERO" + Environment.NewLine);
            repCashier.textBox1.AppendText("*******************************************" + Environment.NewLine);
            repCashier.textBox1.AppendText("Nro. Movimiento : "+ selectClass.shifts + Environment.NewLine);
            repCashier.textBox1.AppendText(Environment.NewLine+"Usuario : " + this.statGetUser.Text + Environment.NewLine);
            repCashier.textBox1.AppendText(Environment.NewLine +"Hora de entrada : "+ selectClass.logDates + " " + selectClass.tymer + Environment.NewLine);
            repCashier.textBox1.AppendText( Environment.NewLine+"Hora de salida : " + statGetDate.Text + Environment.NewLine);
            repCashier.textBox1.AppendText(Environment.NewLine + "*******************************************" + Environment.NewLine);
            repCashier.textBox1.AppendText("\tTOTAL PAGOS RECIBIDOS" + Environment.NewLine);
            repCashier.textBox1.AppendText("*******************************************" + Environment.NewLine);
            repCashier.textBox1.AppendText(Environment.NewLine + "EFECTIVO : " + selectClass.selectCurrencyUsedToComboBox(repCashier.textBox1.Text.ToString()) + selectClass.cashValue + Environment.NewLine);
            repCashier.textBox1.AppendText(Environment.NewLine + "POS : " + selectClass.selectCurrencyUsedToComboBox(repCashier.textBox1.Text.ToString()) + selectClass.POSvalue + Environment.NewLine);
            repCashier.textBox1.AppendText(Environment.NewLine + "*******************************************" + Environment.NewLine);
            repCashier.textBox1.AppendText("\tAGREGAR DINERO EN EFECTIVO Y POS " + Environment.NewLine);
            repCashier.textBox1.AppendText("*******************************************" + Environment.NewLine);

            repCashier.textBox1.AppendText(Environment.NewLine + "TOTAL : " + selectClass.selectCurrencyUsedToComboBox(repCashier.textBox1.Text.ToString())  + (selectClass.POSvalue + selectClass.cashValue) + Environment.NewLine);
            repCashier.textBox1.AppendText(Environment.NewLine + "CERRANDO VENTA DEL DIA A :  " + selectClass.selectCurrencyUsedToComboBox(repCashier.textBox1.Text.ToString()) + (selectClass.POSvalue + selectClass.cashValue) + Environment.NewLine);
            repCashier.textBox1.AppendText(Environment.NewLine + "*******************************************" + Environment.NewLine);
            repCashier.textBox1.AppendText(Environment.NewLine + "Gracias por su estupendo trabajo");
           
            repCashier.ShowDialog();

        
        
        }

        private void btnVsalesRports_Click(object sender, EventArgs e)
        {
            getCashierReportText();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmVDetailsSettlement vDetails = new frmVDetailsSettlement();
            vDetails.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmVFreezeItems vFreeze = new frmVFreezeItems();
            vFreeze.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmVNetSales netSales = new frmVNetSales();
            netSales.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmVTaxSales vTaxSales = new frmVTaxSales();
            vTaxSales.ShowDialog();
        }



        }
}
