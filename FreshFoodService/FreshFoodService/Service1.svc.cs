using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FreshFoodService;

namespace FreshFoodService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public bool register(User user)
        {
            var usera = (from u in db.Users
                         where u.Id.Equals(user.Id)
                         select u).FirstOrDefault();

            if(usera == null)
            {
                db.Users.InsertOnSubmit(user);
                try
                {
                    db.SubmitChanges();
                    return true;
                }catch(Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
                        
        }

        public List<Item> getItems()
        {
            dynamic aitems = (from i in db.Items
                              select i).DefaultIfEmpty();
            List<Item> list = new List<Item>();
            if (aitems != null)
            {
                foreach (Item newItem in aitems)
                {
                    var nitems = new Item
                    {
                        Item_name = newItem.Item_name,
                        Item_price = newItem.Item_price,
                        Item_Cat = newItem.Item_Cat,
                        item_qty = newItem.item_qty
                    };
                    list.Add(nitems);
                }
            }
            return list;
        }

        public bool addItem(Item item)
        {
            var test = (from i in db.Items
                        where i.Id.Equals(item.Id)
                        select i).FirstOrDefault();
            if(test == null)
            {
                db.Items.InsertOnSubmit(item);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
