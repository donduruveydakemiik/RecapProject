using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ListOfProduct();  
            ListCategories();
            ListProductsByProductName(txtSearch.Text);
        }

        private void ListOfProduct()
        {
            using (NorthWindContext context = new NorthWindContext())
            {

                dgwProduct.DataSource = context.Products.ToList();
            }
        }

        private void ListCategories()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
               cbxCategories.DataSource = context.Categories.ToList();
                cbxCategories.DisplayMember= "CategoryName";
                cbxCategories.ValueMember= "CategoryId";

            }
        }

        public void ListProductsByCategories(int categoryId)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                dgwProduct.DataSource = context.Products.Where(P => P.CategoryId==categoryId).ToList();
            }
        }

        public void ListProductsByProductName(string key)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                dgwProduct.DataSource = context.Products.Where(P => P.ProductName.Contains(key)).ToList();
            }
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListProductsByCategories(cbxCategories.SelectedIndex);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            ListProductsByProductName(txtSearch.Text);
        }
    }
}
