using MiddleEastCollege.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MiddleEastCollege.BLL
{
    public class CommonBLL
    {
        MiddleEastCollegeEntities db = new MiddleEastCollegeEntities();
        public bool SaveData(object model,out string message,out string messageTitle)
        {
            message=string.Empty;
            messageTitle = string.Empty;
            try
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
                if (db.SaveChanges() != 0)
                {
                    messageTitle = Resource.Success;
                    message = Resource.SavedSuccess;
                    return true;
                }
                else
                {
                    messageTitle = Resource.Error;
                    message = Resource.ErrorInSave;
                    return false;
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    messageTitle = "Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State
                        + " has the following validation errors:";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        message = message + "- Property: "+ ve.PropertyName + ", Error: "+ ve.ErrorMessage;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                messageTitle = Resource.Error;
                message = ex.InnerException.Message;
                return false;
            }
        }
       public List<Tuple<long,string>> Types(string TupleListName)
        {
            string lang = HttpContext.Current.Request.Cookies["_culture"].Value.ToLower();

            return db.MenuItems.Where(z => z.MainMenu.MainMenuName == TupleListName).Select(z => new
            {
                z.MenuItemID,
               Name=(lang.Contains("en"))? z.MenuNameENG:z.MenuNameAR
            }).ToList().Select(x => new Tuple<long, string>(x.MenuItemID, x.Name)).ToList();
        }
    }
}