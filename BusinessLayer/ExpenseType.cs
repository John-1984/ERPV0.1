using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class ExpenseType
    {
        private List<BusinessModels.ExpenseType> ExpenseTypes = new List<BusinessModels.ExpenseType>();
        private DataLayer.ExpenseTypeDAL _dataLayer = null;

        public ExpenseType()
        {
            _dataLayer = new DataLayer.ExpenseTypeDAL();
        }

        public BusinessModels.ExpenseType GetExpenseType(Int32 identity)
        {
            return _dataLayer.GetExpenseType(identity);
        }

        public IEnumerable<BusinessModels.ExpenseType> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.ExpenseType ExpenseType)
        {
            return _dataLayer.Update(ExpenseType);
        }

        public Boolean Insert(BusinessModels.ExpenseType ExpenseType)
        {
            return _dataLayer.Insert(ExpenseType);
        }

      

    }


}
