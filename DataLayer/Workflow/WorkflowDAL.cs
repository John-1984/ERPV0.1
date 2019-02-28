using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.Entity;
using System.Data.Entity;

namespace DataLayer.Workflow
{
    public class WorkflowDAL
    {
        public WorkflowDAL()
        {
        }

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

            }

            return _steps;
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
                    var et = ex.Message;
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
                    var et = ex.Message;
                }
            }

            return _steps;
        }
    }
}
