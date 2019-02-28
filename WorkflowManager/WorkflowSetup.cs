using System;
using System.Collections.Generic;
using BusinessModels.Workflow;

namespace WorkflowManager
{
    public class WorkflowSetup
    {
        private DataLayer.Workflow.WorkflowDAL _dataLayer = null;

        public WorkflowSetup()
        {
            _dataLayer = new DataLayer.Workflow.WorkflowDAL();
        }

        public List<Workflow> GetAllWorkflows()
        {
            return _dataLayer.GetAllWorkflows();
        }

        public List<Step> GetAllSteps() {
            return _dataLayer.GetAllSteps();
        }

        public List<Step> GetWorkflowSteps(int workflowID)
        {
            return _dataLayer.GetWorkflowSteps(workflowID);
        }

        public Boolean AddWorkflow(Workflow workflow)
        {
            return _dataLayer.AddWorkflow(workflow);
        }

        public Boolean DeleteWorkflow(int identity)
        {
            return _dataLayer.DeleteWorkflow(identity);
        }

        public Step GetStep(int identity)
        {
            return _dataLayer.GetStep(identity);
        }

        public Boolean AddStep(Step step)
        {
            return _dataLayer.AddStep(step);
        }

        public Boolean AssociateWorkflowStep(WorkflowStepMapping workflowStepMapping)
        {
            return _dataLayer.AssociateWorkflowStep(workflowStepMapping);
        }

        public Boolean UpdateStep(Step step)
        {
            return _dataLayer.UpdateStep(step);
        }

        public Boolean DeleteStep(int identity)
        {
            return _dataLayer.DeleteStep(identity);
        }

        public Boolean DeleteWorkflowStep(int stepID, int workflowID)
        {
            return _dataLayer.DeleteWorkflowStep(stepID, workflowID);
        }

        public IEnumerable<Workflow> GetMatchingWorkflows(string prefix)
        {
            return _dataLayer.GetMatchingWorkflows(prefix);
        }

        public IEnumerable<Step> GetMatchingSteps(string prefix)
        {
            return _dataLayer.GetMatchingSteps(prefix);
        }
    }
}
