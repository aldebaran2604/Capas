using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SwitchDataBaseWebService.ServiceReference1;

namespace SwitchDataBaseWebService
{
    public class Switch
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Switch));
        private DBComercio comercio = new DBComercio();
        private Service1Client clienteArticles = new Service1Client();
        public int AddArticle(string description, double Price, int Stock)
        {
            /*decimal? DbId = null;
            int id = 0;
            try
            {
                DbId = comercio.AddArticle1(description, (decimal)Price, Stock).First();
            } catch(Exception ex)
            {

            }
            if (DbId!=null)
            {
                id = Decimal.ToInt32((decimal)DbId);
            }*/
            int id = clienteArticles.AddWSArticle(description, Price, Stock);
            return id;
        }

        public void EditArticle(int Id,string Description, double? Price, int? Stock)
        {
            try
            {
                comercio.EditArticle(Id, Description, (Decimal)Price, Stock);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        ///  Regresa la lista de articulos
        /// </summary>
        /// <returns>List<Article></returns>
        public List<Article> ShowArticles()
        {
            List<Article> articles = null;
            try
            {
                articles = comercio.ShowAll1().ToList();
            }
            catch (Exception ex)
            {
                log.Error("Error: "+ex.Message);
            }
            return articles;
        }
        /*static void Main(string[] args)
        {
            Switch switchControl = new Switch();
            try {
                List<Article> result = switchControl.ShowArticles();
                foreach (Article article in result)
                {
                    Console.WriteLine(article.Description);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            Console.ReadLine();
        }*/
    }
}
