using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.Entity;
using System.Data.Entity;

namespace DataLayer.Workflow
{
    public class WorkflowDAL
    {
        private const string messageFormatShort = "WorkflowDAL:: Method: {0} - DateTime: {1} - Exception: {2}";
        private readonly LoggingModule.Logging _logger;
        public WorkflowDAL()
        {
            _logger = new LoggingModule.Logging();
        }

        #region "Workflow Management"
        public List<BusinessModels.Workflow.Workflow> GetAllWorkflows()
        {
            var _workflows = new List<BusinessModels.Workflow.Workflow>();
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _workflows = dbContext.Workflow
                            .ToList();
            }

            return _workflows;
        }

        public List<BusinessModels.Workflow.Step> GetAllSteps()
        {
            var _steps = new List<BusinessModels.Workflow.Step>();
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _steps = dbContext.Step
                            .ToList();
            }
            return _steps;
        }

        public List<BusinessModels.Workflow.Step> GetWorkflowSteps(int workflowID)
        {
            var _steps = new List<BusinessModels.Workflow.Step>();
            try
            {
                using (var dbContext = new WorkflowDbContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;

                    var distinctStepID = dbContext.WorkflowStepMapping
                        .Where(p => p.WorkflowID.Equals(workflowID))
                        .Select(p => p.StepID).Distinct().ToArray();

                    _steps = (from step in dbContext.Step
                              where distinctStepID.Contains(step.Identity)
                              select step).ToList();

                }
            }
            catch (Exception ex)
            {
                var message = "OnException:: ";
                message = message + string.Format(messageFormatShort, "GetWorkflowSteps", DateTime.Now.ToString(), ex.Message);
            }

            return _steps;
        }

        public List<BusinessModels.Workflow.ActiveStep> GetActiveWorkflowSteps(int activeWorkflowID)
        {
            var _activeSteps = new List<BusinessModels.Workflow.ActiveStep>();
            try
            {
                using (var dbContext = new WorkflowDbContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;

                    var _activeWorkflow = dbContext.ActiveWorkflow
                        .Where(p => p.ActiveID.Equals(activeWorkflowID))
                        .Include(k => k.ActiveStep).FirstOrDefault();

                    _activeSteps = _activeWorkflow.ActiveStep.ToList();
                }
            }
            catch (Exception ex)
            {
                var message = "OnException:: ";
                message = message + string.Format(messageFormatShort, "GetWorkflowSteps", DateTime.Now.ToString(), ex.Message);
            }

            return _activeSteps;
        }

        public Boolean AddWorkflow(BusinessModels.Workflow.Workflow workflow)
        {
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Entry(workflow).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean DeleteWorkflow(int identity)
        {
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Entry(new BusinessModels.Workflow.Workflow() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.Workflow.Step GetStep(int identity)
        {
            var _step = new BusinessModels.Workflow.Step();
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _step = dbContext.Step
                            .Where(p => p.Identity.Equals(identity))
                            .FirstOrDefault();
            }

            return _step;
        }

        public BusinessModels.Workflow.Workflow GetWorkFLowIDForLocationAndItemType(int? locid, int itemid)
        {
            var _workflow = new BusinessModels.Workflow.Workflow();
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _workflow = dbContext.Workflow
                            .Where(p => p.LocationID==locid && p.ItemType==itemid)
                            .FirstOrDefault();
            }

            return _workflow;
        }

        public Boolean AddStep(BusinessModels.Workflow.Step step)
        {
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Entry(step).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean UpdateStep(BusinessModels.Workflow.Step step)
        {
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Entry(step).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean DeleteStep(int identity)
        {
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Entry(new BusinessModels.Workflow.Step() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean DeleteWorkflowStep(int stepID, int workflowID)
        {
            try
            {
                using (var dbContext = new WorkflowDbContext())
                {
                    var identity = dbContext.WorkflowStepMapping.Where(p => p.StepID.Equals(stepID) && p.WorkflowID.Equals(workflowID)).Select(q => q.Identity).FirstOrDefault();

                    dbContext.Entry(new BusinessModels.Workflow.WorkflowStepMapping() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var message = "OnException:: ";
                message = message + string.Format(messageFormatShort, "DeleteWorkflowStep", DateTime.Now.ToString(), ex.Message);
            }

            return true;
        }

        public Boolean AssociateWorkflowStep(BusinessModels.Workflow.WorkflowStepMapping workflowStepMapping)
        {
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Entry(workflowStepMapping).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

        public IEnumerable<BusinessModels.Workflow.Workflow> GetMatchingWorkflows(string prefix)
        {
            var _workflows = new List<BusinessModels.Workflow.Workflow>();
            using (var dbContext = new WorkflowDbContext())
            {
                try
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    _workflows = dbContext.Workflow
                                .ToList()
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(prefix.ToLower())))
                                .ToList();
                }
                catch (Exception ex)
                {
                    var message = "OnException:: ";
                    message = message + string.Format(messageFormatShort, "GetMatchingWorkflows", DateTime.Now.ToString(), ex.Message);
                }
            }

            return _workflows;
        }

        public IEnumerable<BusinessModels.Workflow.Step> GetMatchingSteps(string prefix)
        {
            var _steps = new List<BusinessModels.Workflow.Step>();
            using (var dbContext = new WorkflowDbContext())
            {
                try
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    _steps = dbContext.Step
                                .ToList()
                                .Where(p => (p != null && !string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(prefix.ToLower())))
                                .ToList();
                }
                catch (Exception ex)
                {
                    var message = "OnException:: ";
                    message = message + string.Format(messageFormatShort, "GetMatchingSteps", DateTime.Now.ToString(), ex.Message);
                }
            }

            return _steps;
        }
        #endregion

        #region "Workflow Initialization"
        /// <summary>
        /// Activates the workflow.
        /// </summary>
        /// <returns><c>true</c>, if workflow was activated, <c>false</c> otherwise.</returns>
        /// <param name="WorkflowID">Workflow identifier.</param>
        /// <param name="userID">User identifier.</param>
        /// <param name="workItemID">Work item identifier.</param>
        /// <param name="workItemType">Work item type.</param>
        public Boolean ActivateWorkflow(int WorkflowID, int userID, int workItemID, string workItemType)
        {
            //Get all Workflow Steps
            var _workflowSteps = GetWorkflowSteps(WorkflowID);
            var _activeSteps = new List<BusinessModels.Workflow.ActiveStep>();

            //Generate the Active Steps
            _workflowSteps.ForEach(p => {
                _activeSteps.Add(new BusinessModels.Workflow.ActiveStep()
                {
                    Comments = string.Empty,
                    HasNotificationSend = "No",
                    Status = _workflowSteps.IndexOf(p) == 0 ? "Active" : string.Empty, //Set first item as Active
                    StepID = p.Identity,
                    UpdatedDate = DateTime.Now.ToString()
                });
            });

            //Generate the complete Active Workflow and Active Steps Model for insertion
            var _activeWorkflows = new BusinessModels.Workflow.ActiveWorkflow()
            {
                WorkflowID = WorkflowID,
                Status = "InProgress",
                PurchaseID = workItemID,
                CreatedBy = userID.ToString(),
                CreatedDate = DateTime.Now.ToString(),
                CurrentStepID = _workflowSteps.First().Identity,
                PreviousStepID = _workflowSteps.First().Identity,
                ActiveStep = _activeSteps
            };

            using (var dbContext = new WorkflowDbContext())
            {
                try
                {
                    dbContext.Entry(_activeWorkflows).State = EntityState.Added;
                    dbContext.SaveChanges();

                    //Test if ID is returned back.
                    var test = _activeWorkflows.ActiveID;
                }
                catch (Exception ex)
                {
                    var message = "OnException:: ";
                    message = message + string.Format(messageFormatShort, "ActivateWorkflow", DateTime.Now.ToString(), ex.Message);
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region "Workflow Engine"

        public List<BusinessModels.Workflow.ActiveStep> GetActiveWorkflows(string User)
        {
            var _activeSteps = new List<BusinessModels.Workflow.ActiveStep>();
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                try
                {
                    _activeSteps = dbContext.ActiveStep
                                     .Where(p => p.Step.StepOwner.Equals(User) && p.Status.Equals("Active"))
                                     .Include(k => k.ActiveWorkflow)
                                     .Include(l => l.Step)
                                     .Include(s => s.ActiveWorkflow.Workflow)
                                     .Include(s => s.ActiveWorkflow.Workflow.Menu)
                                     .Include(s => s.ActiveWorkflow.Workflow.Employee)
                                     .ToList();
                }
                catch (Exception ex)
                {
                    var message = "OnException:: ";
                    message = message + string.Format(messageFormatShort, "ActivateWorkflow", DateTime.Now.ToString(), ex.Message);
                }
            }
            return _activeSteps;
        }

        public BusinessModels.Workflow.ActiveWorkflow GetActiveWorkflowsDetails(int workflowid)
        {
            var _activeSteps = new BusinessModels.Workflow.ActiveWorkflow();
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                try
                {
                    _activeSteps = dbContext.ActiveWorkflow
                                     .FirstOrDefault(p => p.ActiveID.Equals(workflowid)); ;
                }
                catch (Exception ex)
                {
                    var message = "OnException:: ";
                    message = message + string.Format(messageFormatShort, "WorkflowDetails", DateTime.Now.ToString(), ex.Message);
                }
            }
            return _activeSteps;
        }

        public BusinessModels.Workflow.Workflow GetWorkflowsDetails(int workflowid)
        {
            var _activeSteps = new BusinessModels.Workflow.Workflow();
            using (var dbContext = new WorkflowDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                try
                {
                    _activeSteps = dbContext.Workflow
                        .Include(o=>o.Menu)
                                     .FirstOrDefault(p => p.Identity.Equals(workflowid)); ;
                }
                catch (Exception ex)
                {
                    var message = "OnException:: ";
                    message = message + string.Format(messageFormatShort, "WorkflowDetails", DateTime.Now.ToString(), ex.Message);
                }
            }
            return _activeSteps;
        }



        public List<BusinessModels.Workflow.ActiveWorkflow> GetAllActiveWorkflows()
        {
            return new List<BusinessModels.Workflow.ActiveWorkflow>();
        }

        public Boolean WorkflowActionHandler(int activeStepID, string action, string comments, int activeWorkflowID, int purchaseID, int itemid, string itemname, int locid, int compType, int compid)
        {
            var _activeWorkflowSteps = GetActiveWorkflowSteps(activeWorkflowID);
            var _activeStepIndex = _activeWorkflowSteps.IndexOf(_activeWorkflowSteps.Find(p => p.ActiveStepID == activeStepID));
            var _isFinalStep = (_activeStepIndex == (_activeWorkflowSteps.Count() - 1)) ? true : false;

            if (!_isFinalStep)
            {
                using (var dbContext = new WorkflowDbContext())
                {
                    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                    {
                        dbContext.Configuration.LazyLoadingEnabled = false;
                        try
                        {
                            #region "Update Active Step"
                            var _activeStep = _activeWorkflowSteps.Find(p => p.ActiveStepID == activeStepID);
                            _activeStep.Comments = comments;
                            _activeStep.Status = string.Empty;
                            _activeStep.Action = action;
                            _activeStep.UpdatedDate = DateTime.Now.ToString();
                            dbContext.Entry(_activeStep).State = EntityState.Modified;

                            dbContext.SaveChanges();
                            #endregion

                            #region "Activate Next Step"
                            var _nextActiveStep = _activeWorkflowSteps[_activeStepIndex + 1];
                            _nextActiveStep.Status = "Active";
                            dbContext.Entry(_nextActiveStep).State = EntityState.Modified;

                            dbContext.SaveChanges();
                            #endregion

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            var message = "OnException:: ";
                            message = message + string.Format(messageFormatShort, "WorkflowActionHandler", DateTime.Now.ToString(), ex.Message);
                        }
                    }
                }
            }
            else
            {
                using (var dbContext = new WorkflowDbContext())
                {
                    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                    {
                        dbContext.Configuration.LazyLoadingEnabled = false;
                        try
                        {
                            #region "Update Active Step"
                            var _activeStep = _activeWorkflowSteps.Find(p => p.ActiveStepID == activeStepID);
                            _activeStep.Comments = comments;
                            _activeStep.Status = string.Empty;
                            _activeStep.Action = action;
                            _activeStep.UpdatedDate = DateTime.Now.ToString();
                            dbContext.Entry(_activeStep).State = EntityState.Modified;

                            dbContext.SaveChanges();
                            #endregion

                            #region "Mark ActiveWorkflow as Completed"
                            var _activeWorkflow = dbContext.ActiveWorkflow.Find(activeWorkflowID);
                            _activeWorkflow.Status = "Completed";
                            _activeWorkflow.CompletedDate = DateTime.Now.ToString();
                            dbContext.Entry(_activeWorkflow).State = EntityState.Modified;

                            //coded 
                            //Update status of quotation and product enquiry if completed
                            if(itemname.Equals("Sales Quotation"))
                            {
                                DataLayer.EmployeeDAL _empLayer = new EmployeeDAL();
                                DataLayer.SalesQuotationDAL _sales = new SalesQuotationDAL();
                                DataLayer.ProductEnquiryDAL _prdEnq= new ProductEnquiryDAL();
                                BusinessModels.Employee empDet = _empLayer.GetFinanceManagerOnCompanyType(locid, compid, compType);
                                BusinessModels.SalesQuotation mdsales= _sales.UpdateSalesQuotationAssignedandStatus(empDet.Identity, 4, purchaseID);

                                _prdEnq.UpdateProductEnquiryStatus(4, mdsales.ProductEnquiryID);
                            }

                            dbContext.SaveChanges();
                            #endregion

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            var message = "OnException:: ";
                            message = message + string.Format(messageFormatShort, "WorkflowActionHandler", DateTime.Now.ToString(), ex.Message);
                        }
                    }
                }
            }
            return true;
        }

        #endregion

        private void RollBack(DbContext dbContext)
        {
            var changedEntries = dbContext.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}