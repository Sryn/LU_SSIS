using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class CollectionInformationController
    {
        LogicUniversityEntities ctx;
        public CollectionInformationController()
        {
            ctx = new LogicUniversityEntities();
        }

        public List<Model.CollectionInformation> getListCollectionInformation()
        {
            List<Employee> representativeList = ctx.Employees.Where(x => x.Role == "Representative").ToList();
            List<Model.CollectionInformation> collectionInformationList = new List<Model.CollectionInformation>();


            foreach (Employee item in representativeList)
            {
                Model.CollectionInformation temporary = new Model.CollectionInformation();
                temporary.EmployeeID = item.EmployeeID;
                temporary.Email = item.Email;
                temporary.Name = item.Name;
                temporary.DepartmentID = item.DepartmentID;
                temporary.Role = item.Role;
                temporary.deptName = item.Department.DepartmentName;
                temporary.collectionPointName = item.Department.CollectionPoint.CollectionPointName;

                collectionInformationList.Add(temporary);
            }


            return collectionInformationList;

        }
    }

}