using System;
using System.Collections.Generic;

namespace WorkflowManager
{
    public class WorkflowEngine
    {
        private readonly DataLayer.Workflow.WorkflowDAL _dataLayer = null;

        public WorkflowEngine()
        {
            _dataLayer = new DataLayer.Workflow.WorkflowDAL();
        }

        public List<BusinessModels.Workflow.ActiveStep> GetActiveWorkflows(string User)
        {
            return _dataLayer.GetActiveWorkflows(User);
        }

        public List<BusinessModels.Workflow.ActiveWorkflow> GetAllActiveWorkflows()
        {
            return new List<BusinessModels.Workflow.ActiveWorkflow>();
        }

        public Boolean WorkflowActionHandler(int activeStepID, string action, string comments, int activeWorkflowID, int purchaseID,int itemid, string itemname, int locid, int compType, int compid)
        {
            return _dataLayer.WorkflowActionHandler(activeStepID, action, comments, activeWorkflowID, purchaseID, itemid,itemname,locid,compType, compid);
        }

        public BusinessModels.Workflow.ActiveWorkflow GetActiveWorkflowsDetails(int workflowid)
        {
            return _dataLayer.GetActiveWorkflowsDetails(workflowid);
        }

        public BusinessModels.Workflow.Workflow GetWorkflowsDetails(int workflowid)
        {
            return _dataLayer.GetWorkflowsDetails(workflowid);
        }

    }
}