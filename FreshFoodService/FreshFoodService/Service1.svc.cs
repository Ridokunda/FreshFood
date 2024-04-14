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

        public User Login(string email, string password)
        {
            var loguser = (from u in db.Users
                           where u.email.Equals(email) && u.password.Equals(password)
                           select u).FirstOrDefault();
            if(loguser != null)
            {
                var newuser = new User
                {
                    Id = loguser.Id,
                    email = loguser.email,
                    password = loguser.password,

                };
                return newuser;
            }
            else
            {
                return null;
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
                        Item_ID = newItem.Item_ID,
                        Item_name = newItem.Item_name,
                        Item_price = newItem.Item_price,
                        Item_Cat = newItem.Item_Cat,
                        item_qty = newItem.item_qty,
                        Item_img = newItem.Item_img,
                    };
                    list.Add(nitems);
                }
            }
            return list;
        }

        public bool addItem(Item item)
        {
            var test = (from i in db.Items
                        where i.Item_ID.Equals(item.Item_ID)
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

        public Item getItem(int id)
        {
            var item = (from i in db.Items
                        where i.Item_ID.Equals(id)
                        select i).FirstOrDefault();
            if(item != null)
            {
                var return_item = new Item
                {
                    Item_ID = item.Item_ID,
                    Item_name = item.Item_name,
                    Item_price = item.Item_price,
                    Item_Cat = item.Item_Cat,
                    item_qty = item.item_qty
                };
                return return_item;
            }
            else
            {
                return null;
            }
            
        }

        public int getItemId(Item item)
        {
            return item.Item_ID;
        }

        public bool addItemonCart(int C_ID, int I_ID,int qty)
        {
            var item = (from i in db.Items
                        where i.Item_ID.Equals(I_ID)
                        select i).FirstOrDefault();
            var cus = (from c in db.Users
                       where c.Id.Equals(C_ID)
                       select c).FirstOrDefault();
            if (item != null && cus != null)
            {
                var add = new onCart
                {
                    CustomerID = cus.Id,
                    Item_ID = item.Item_ID,
                    OnCart_qty = qty
                };
                db.onCarts.InsertOnSubmit(add);
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
            return false;
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
