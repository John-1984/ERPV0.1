using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace ERP.Controllers
{
    [ERP.CustomeFilters.LoggingFilter]
    [ERP.CustomeFilters.ExceptionFilter]
    public class WorkflowDashboardController : Controller
    {
        private readonly WorkflowManager.WorkflowEngine _workflowEngine = new WorkflowManager.WorkflowEngine();
        public ActionResult Inbox()
        {
            return View ("Inbox", GetActiveWorkflows("", 1, "", ""));
        }

        public ActionResult WorkflowAction(int purchaseID, int activeStepID, int activeWorkflowID)
        {
            TempData["PurchaseID"] = ViewBag.PurchaseID = purchaseID;
            TempData["ActiveStepID"] = ViewBag.ActiveStepID = activeStepID;
            TempData["ActiveWorkflowID"] = ViewBag.ActiveWorkflowID = activeWorkflowID;

            return View();
        }

        [HttpPost]
        public ActionResult WorkflowActionHandler(FormCollection formCollection)
        {
            var action = formCollection["Action"];
            var comments = formCollection["Comments"];
            var purchaseID = formCollection["PurchaseID"];
            var activeStepID = formCollection["ActiveStepID"];
            var activeWorkflowID = formCollection["ActiveWorkflowID"];

            _workflowEngine.WorkflowActionHandler(Convert.ToInt32(activeStepID), action, comments, Convert.ToInt32(activeWorkflowID), Convert.ToInt32(purchaseID));
            return View("Inbox", GetActiveWorkflows("", 1, "", ""));
        }

        public ActionResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return View("Inbox", GetActiveWorkflows(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Workflow.ActiveStep> GetActiveWorkflows(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {
            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "WorkflowName" : "";

            var _activeSteps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.ActiveStep>>(_workflowEngine.GetActiveWorkflows("hardware@PurchaseManager.com"));
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                _activeSteps = _activeSteps.FindAll(p => p.ActiveWorkflow.Workflow.Name.ToLower().Contains(searchString.ToLower()) && (Convert.ToDateTime(p.ActiveWorkflow.CreatedDate)).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate));
            else if (!string.IsNullOrEmpty(searchString))
                _activeSteps = _activeSteps.FindAll(p => p.ActiveWorkflow.Workflow.Name.ToLower().Contains(searchString.ToLower()));
            else if (!string.IsNullOrEmpty(createdDate))
                _activeSteps = _activeSteps.FindAll(p => (Convert.ToDateTime(p.ActiveWorkflow.CreatedDate)).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate));

            switch (sortOrder)
            {
                case "WorkflowName":
                    _activeSteps = _activeSteps.OrderByDescending(st => st.ActiveWorkflow.Workflow.Name).ToList();
                    break;
                case "DateAsc":
                    _activeSteps = _activeSteps.OrderBy(st => st.ActiveWorkflow.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    _activeSteps = _activeSteps.OrderByDescending(st => st.ActiveWorkflow.CreatedDate).ToList();
                    break;
                default:
                    _activeSteps = _activeSteps.OrderBy(st => st.ActiveWorkflow.Workflow.Name).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return _activeSteps.ToPagedList(No_Of_Page, Size_Of_Page);
        }
    }
}
