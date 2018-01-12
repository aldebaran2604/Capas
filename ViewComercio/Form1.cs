using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwitchDataBaseWebService;

namespace ViewComercio
{
    public partial class Form1 : Form
    {
        private Switch switchControl = new Switch();
        public Form1()
        {
            InitializeComponent();
            tabControlArticles.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Article> articles = switchControl.ShowArticles();
            if (articles.Count>0)
            {
                BindingList<Article> BindingArticles = new BindingList<Article>(articles);
                dataGridView1.DataSource = BindingArticles;
            }
        }

        private void buttonAddArticle_Click(object sender, EventArgs e)
        {
            int id = switchControl.AddArticle(
                textBoxDescription.Text,
                Double.Parse(textBoxPrice.Text),
                Int32.Parse(textBoxStock.Text)
            );
            if (id>0)
            {
                MessageBox.Show("Save Articles");
            }
        }

        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            if (current.Name.Equals("tabPage1"))
            {
                List<Article> articles = switchControl.ShowArticles();
                if (articles.Count > 0)
                {
                    BindingList<Article> BindingArticles = new BindingList<Article>(articles);
                    dataGridView1.DataSource = BindingArticles;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow gridrow = dataGridView1.Rows[e.RowIndex];
            Article article = (Article)gridrow.DataBoundItem;
            
            switchControl.EditArticle(
               article.Id,
               article.Description,
               Decimal.ToDouble(article.Price.GetValueOrDefault(0)),
               Decimal.ToInt32(article.Stock.GetValueOrDefault(0))
            );

            List<Article> articles = switchControl.ShowArticles();
            if (articles.Count > 0)
            {
                BindingList<Article> BindingArticles = new BindingList<Article>(articles);
                dataGridView1.DataSource = BindingArticles;
            }
        }
    }
}
