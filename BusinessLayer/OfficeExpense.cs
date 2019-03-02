using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class OfficeExpense
    {
        private static List<BusinessModels.OfficeExpense> OfficeExpenses = new List<BusinessModels.OfficeExpense>();
        private DataLayer.OfficeExpenseDAL _dataLayer = null;
        private DataLayer.ExpenseTypeDAL _expdataLayer = null;
       
        public OfficeExpense()
        {
            _dataLayer = new DataLayer.OfficeExpenseDAL();
            _expdataLayer = new DataLayer.ExpenseTypeDAL();
           
        }

        public BusinessModels.OfficeExpense GetOfficeExpense(Int32 identity){
            return _dataLayer.GetOfficeExpense(identity);
        }

        public IEnumerable<BusinessModels.OfficeExpense> GetAll() { 
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.OfficeExpense> GetAll(int locID)
        {
            return _dataLayer.GetAll(locID);
        }

        public IEnumerable<BusinessModels.ExpenseType> GetAllExpenseTpe()
        {
            return _expdataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.OfficeExpense> GetAll(int locID, int empID)
        {
            return _dataLayer.GetAll(locID,empID);
        }

        public IEnumerable<BusinessModels.OfficeExpense> GetMatchingOfficeExpenses(string prefix)
        {
            return _dataLayer.GetMatchingOfficeExpenses(prefix);
        }

        public Boolean Delete(Int32 identity){
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.OfficeExpense OfficeExpense){
            return _dataLayer.Update(OfficeExpense);
        }

        public bool Insert(BusinessModels.OfficeExpense OfficeExpense)
        {
           return _dataLayer.Insert(OfficeExpense);           
        }        

    }


}
