using DataAccessLayer.ProjectContext;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst_Otel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Context c = new Context();

        private void btnlistele_Click(object sender, EventArgs e)
        {
            var values = c.Customers.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerName = txtad.Text;
            customer.CustomerSurname = txtsad.Text;
            customer.CustomerPhone = txttel.Text;
            customer.CustomerGender = cmbcinsiyet.Text;
            c.Customers.Add(customer);
            c.SaveChanges();
            MessageBox.Show("Müşteri eklendi!");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtid.Text);
            var values = c.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            c.Customers.Remove(values);
            c.SaveChanges();
            MessageBox.Show("Müşteri silindi!");
        }

     
    }
}
