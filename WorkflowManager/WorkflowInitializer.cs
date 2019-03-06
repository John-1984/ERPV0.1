using System;
namespace WorkflowManager
{
    /// <summary>
    /// Workflow initializer.
    /// Separating the initializer from Engine, just in case Rules engine has to be incorporated in later stage.
    /// </summary>
    public class WorkflowInitializer
    {
        private readonly DataLayer.Workflow.WorkflowDAL _dataLayer = null;

        public WorkflowInitializer()
        {
            _dataLayer = new DataLayer.Workflow.WorkflowDAL();
        }

        /// <summary>
        /// Workflows the selector. This function will decide the workflow based on Pre Defined Conditions
        /// </summary>
        /// <returns>The selector.</returns>
        /// <param name="InitiatorRole">Initiator role.</param>
        /// <param name="InitiatorBranch">Initiator branch.</param>
        /// <param name="InitiatorID">Initiator identifier.</param>
        public int WorkflowSelector(string InitiatorRole, string InitiatorBranch , string InitiatorID) {
            var _workflowID = -1;
            if(InitiatorRole.Equals("Agent") && InitiatorBranch.Equals("Mumbai - Targeo"))
            {
                _workflowID = 1;
            }
            else
            {
                _workflowID = 2;
            }
            return _workflowID;
        }

        public Boolean InitializeWorkflow(int WorkflowID, int userID, int workItemID, string workItemType, string WorkflowName = "")
        {
            return ActivateWorkflow(WorkflowID, userID, workItemID, workItemType);
        }

        public Boolean InitializeWorkflow(string InitiatorRole, string InitiatorBranch, string InitiatorID, int userID, int workItemID, string workItemType)
        {
            var _workflowID = WorkflowSelector(InitiatorRole, InitiatorBranch, InitiatorID);
            return InitializeWorkflow(_workflowID, userID, workItemID, workItemType);
        }

        /// <summary>
        /// Base method which actually Activates the workflow.
        /// </summary>
        /// <returns><c>true</c>, if workflow was activated, <c>false</c> otherwise.</returns>
        /// <param name="WorkflowID">Workflow identifier.</param>
        private Boolean ActivateWorkflow(int WorkflowID, int userID, int workItemID, string workItemType)
        {
            return _dataLayer.ActivateWorkflow(WorkflowID, userID, workItemID, workItemType);
        }

        /// <summary>
        /// This method gets workflow id for locaction and itemtype.
        /// </summary>        
        public BusinessModels.Workflow.Workflow GetWorkFLowIDForLocationAndItemType(int? locID, int typeID)
        {
            return _dataLayer.GetWorkFLowIDForLocationAndItemType(locID,typeID);
        }
    }
}
