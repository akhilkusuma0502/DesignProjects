using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_BusinessLogicLayer
{
    using ElibManagementSystem_DataAccessLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
  public  class DisciplinesBLL
    {
        DisciplinesOperations DisciplinesDALObj;
        public DisciplinesBLL()
        {
            DisciplinesDALObj = new DisciplinesOperations();
        }
        public List<Disciplines> GetAll()
        {
            var DisciplinesList = new List<Disciplines>();
            try
            {
                var ObjDAL = new DisciplinesOperations();
                DisciplinesList = ObjDAL.GetDisciplines();
                if (DisciplinesList == null || DisciplinesList.Count == 0)
                    throw new ELibException("Disciplines not found");
            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }
            return DisciplinesList;
        }



        public bool InsertDisciplines(string discipline)
        {
            var IsInserted = false;
            if (discipline != null)
            {
                IsInserted = DisciplinesDALObj.InsertDisciplines(discipline);
            }
            else
                throw new ELibException("Discipline Name should be valid");
            return IsInserted;
        }

        public bool DeleteDiscipline(int id)
        {
            var IsDeleted = false;
            if (id > 0)
            {
                IsDeleted = DisciplinesDALObj.DeleteDiscipline(id);
            }
            else
                throw new ELibException("Discipline Id should be valid");
            return IsDeleted;
        }

        public bool UpdateDiscipline(int id, string disciplinename)
        {
            var IsUpdated = false;
            if (id > 0 && disciplinename != null)
            {
                IsUpdated = DisciplinesDALObj.UpdateDiscipline(id, disciplinename);
            }
            else
                throw new ELibException("Updation progress Failed..! Try again with proper id and name");
            return IsUpdated;
        }


        public Disciplines FindDisciplineById(int id)
        {
            Disciplines DisciplineObj = null;
            if (id > 0)
            {
                DisciplineObj = DisciplinesDALObj.FindDisciplineById(id);
            }
            else
                throw new ELibException("Unable to find discipline! Try again with proper id");
            return DisciplineObj;
        }

    }
}
