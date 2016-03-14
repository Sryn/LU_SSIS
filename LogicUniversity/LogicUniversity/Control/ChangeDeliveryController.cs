using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;
using LogicUniversity.Control;

namespace LogicUniversity.Control
{
    public class ChangeDeliveryController
    {
        Model.LogicUniversityEntities ctx;
        public ChangeDeliveryController()
        {
            ctx = new LogicUniversityEntities();
        }
        public CollectionPoint getCollectionPoint()
        {
            return ctx.CollectionPoints.FirstOrDefault();
        }
        public string saveCollectionDate(string firstCollectionDate,string secondCollectionDate,string sEmpID)
        {
            List<CollectionPoint> cpList = ctx.CollectionPoints.ToList();
            foreach(CollectionPoint cp in cpList)
            {
                cp.FirstCollectionDate = firstCollectionDate;
                cp.SecondCollectionDate = secondCollectionDate;
            }
            ctx.SaveChanges();
            EmailControl eCrt = new EmailControl();
            eCrt.sendEmailForChangeDeliveryDate(sEmpID);
            return "success";
        }
    }
}