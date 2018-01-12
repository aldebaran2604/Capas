using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSComercio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public int AddWSArticle(string Description, double Price, int Stock)
        {
            DBComercioEntities comercio = new DBComercioEntities();
            decimal? DbId = null;
            int id = 0;
            try
            {
                DbId = comercio.AddArticle(Description, (decimal)Price, Stock).First();
            }
            catch (Exception ex)
            {

            }
            if (DbId != null)
            {
                id = Decimal.ToInt32((decimal)DbId);
            }
            return id;
        }

        public void EditaWSArticle(int Id, string Description, double Price, int Stock)
        {
            throw new NotImplementedException();
        }

        public List<Articles> ShowWSArticles()
        {
            throw new NotImplementedException();
        }
    }
}
