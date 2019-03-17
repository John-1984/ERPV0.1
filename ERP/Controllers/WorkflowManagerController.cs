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
    public class WorkflowManagerController : Controller
    {
        private readonly WorkflowManager.WorkflowSetup _workflowSetup = new WorkflowManager.WorkflowSetup();
        private BusinessLayer.Menu _menu = new BusinessLayer.Menu();
        private BusinessLayer.Location _location = new BusinessLayer.Location();
        private BusinessLayer.Employee _employee = new BusinessLayer.Employee();
        public ActionResult ManageWorkflows()
        {
            Models.Workflow.Workflow mdWorkFlow = new Models.Workflow.Workflow();
            mdWorkFlow.MenuList = null;
            mdWorkFlow.MenuList = new SelectList(_menu.GetAllApprovalNeededItems(), "Identity", "Name");
            mdWorkFlow.LocationList = null;
            mdWorkFlow.LocationList = new SelectList(_location.GetAll(), "Identity", "LocationName");
            return View(mdWorkFlow);
        }

        public ActionResult ManageSteps()
        {
            Models.Workflow.Step mdStep = new Models.Workflow.Step();
            mdStep.LocationList = null;
            mdStep.LocationList= new SelectList(_location.GetAll(), "Identity", "LocationName");

            mdStep.EmployeeList = null;
            mdStep.EmployeeList = new SelectList(_employee.GetAll(), "Identity", "EmployeeName");
            return View(mdStep);
        }

        public ActionResult AssociateWorkflowAndSteps()
        {
            return View();
        }

        public PartialViewResult _WorkflowsAll()
        { 
            return PartialView(GetWorkflows("", 1, "", ""));
        }

        public PartialViewResult _StepsAll()
        {
            return PartialView(GetSteps("", 1, "", ""));
        }

        public PartialViewResult _WorkflowSteps(int workflowID)
        {
            return PartialView(GetWorkflowSteps(workflowID, "", 1, "", ""));
        }

        public PartialViewResult _StepAddViewEdit()
        {
            Models.Workflow.Step mdStep = new Models.Workflow.Step();
            mdStep.LocationList = null;
            mdStep.LocationList = new SelectList(_location.GetAll(), "Identity", "LocationName");
            mdStep.EmployeeList = null;
            mdStep.EmployeeList= new SelectList(_employee.GetAll(), "Identity", "EmployeeName");
            return PartialView("_StepAddViewEdit", mdStep);
        }

        public ActionResult _StepViewEdit(int identity)
        {
            return PartialView("_StepAddViewEdit", AutoMapperConfig.Mapper().Map<Models.Workflow.Step>(_workflowSetup.GetStep(identity)));
        }
        [HttpPost]
        public JsonResult Employee(string identity)
        {

            return Json(new SelectList(_employee.GetAllEmployeesOnLocationByManager(int.Parse(identity)), "Identity", "EmployeeName"));
        }
        [HttpPost]
        public ActionResult AddWorkflow(Models.Workflow.Workflow workflow, FormCollection frmFields)
        {
            var value = frmFields["hdnWorkFlowItemType"];

            if (!String.IsNullOrEmpty(value))
                workflow.ItemType = int.Parse(value);

            var locvalue = frmFields["hdnWorkFlowLocation"];
            if (!String.IsNullOrEmpty(locvalue))
                workflow.LocationID = Convert.ToInt32(locvalue);

            workflow.CreatedBy = Convert.ToInt32(Session["EmployeeID"].ToString());
            workflow.CreatedDate = DateTime.Now.ToString();

            _workflowSetup.AddWorkflow(AutoMapperConfig.Mapper().Map<BusinessModels.Workflow.Workflow>(workflow));

            return RedirectToAction("_WorkflowsAll");
        }

        [HttpPost]
        public ActionResult AddEditStep(Models.Workflow.Step step, FormCollection frmFields)
        {
            var empvalue = frmFields["hdnWorkFlowStepEmployee"];
            if (!String.IsNullOrEmpty(empvalue))
                step.StepOwner = empvalue;

            if (step.Identity == -1)
            {
                

                step.CreatedBy = Session["EmployeeID"].ToString();
                step.CreatedDate = DateTime.Now.ToString();
                _workflowSetup.AddStep(AutoMapperConfig.Mapper().Map<BusinessModels.Workflow.Step>(step));
            }
            else
            {
                _workflowSetup.UpdateStep(AutoMapperConfig.Mapper().Map<BusinessModels.Workflow.Step>(step));
            }

            return RedirectToAction("_StepsAll");
        }

        [HttpPost]
        public ActionResult AssociateWorkflowStep(Models.Workflow.WorkflowStepMapping workflowStepMapping)
        {
            _workflowSetup.AssociateWorkflowStep(AutoMapperConfig.Mapper().Map<BusinessModels.Workflow.WorkflowStepMapping>(workflowStepMapping));
            return RedirectToAction("_WorkflowSteps", new { workflowID = workflowStepMapping.WorkflowID });
        }

        [HttpPost]
        public ActionResult DeleteWorkflow(int identity)
        {
            _workflowSetup.DeleteWorkflow(identity);
            return RedirectToAction("_WorkflowsAll");
        }

        [HttpPost]
        public ActionResult DeleteStep(int identity)
        {
            _workflowSetup.DeleteStep(identity);
            return RedirectToAction("_StepsAll");
        }

        [HttpPost]
        public ActionResult DeleteWorkflowStep(int stepID, int workflowID)
        {
            _workflowSetup.DeleteWorkflowStep(stepID, workflowID);
            return RedirectToAction("_WorkflowSteps", new { workflowID });
        }

        public PartialViewResult WorkflowPaging(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_WorkflowsAll", GetWorkflows(sortOrder, page, createdDate, searchString));
        }

        public PartialViewResult StepsPaging(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_StepsAll", GetSteps(sortOrder, page, createdDate, searchString));
        }

        public PartialViewResult WorkflowStepsPaging(int? page, int workflowID, string sortOrder = "", string createdDate = "", string searchString = "" )
        {
            return PartialView("_WorkflowSteps", GetWorkflowSteps(workflowID, sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Workflow.Workflow> GetWorkflows(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "WorkflowName" : "";

            var workflows = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Workflow>>(_workflowSetup.GetAllWorkflows());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                workflows = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Workflow>>(_workflowSetup.GetAllWorkflows().ToList().FindAll(p => p.Name.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                workflows = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Workflow>>(_workflowSetup.GetAllWorkflows().ToList().FindAll(p => p.Name.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                workflows = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Workflow>>(_workflowSetup.GetAllWorkflows().ToList().FindAll(p => p.CreatedDate.Equals(createdDate)));

            switch (sortOrder)
            {
                case "WorkflowName":
                    workflows = workflows.OrderByDescending(wf => wf.Name).ToList();
                    break;
                case "DateAsc":
                    workflows = workflows.OrderBy(wf => wf.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    workflows = workflows.OrderByDescending(wf => wf.CreatedDate).ToList();
                    break;
                default:
                    workflows = workflows.OrderBy(wf => wf.Name).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return workflows.ToPagedList(No_Of_Page, Size_Of_Page);
        }

        private IPagedList<Models.Workflow.Step> GetSteps(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "StepName" : "";

            var steps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Step>>(_workflowSetup.GetAllSteps());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                steps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Step>>(_workflowSetup.GetAllSteps().ToList().FindAll(p => p.Name.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                steps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Step>>(_workflowSetup.GetAllSteps().ToList().FindAll(p => p.Name.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                steps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Step>>(_workflowSetup.GetAllSteps().ToList().FindAll(p => p.CreatedDate.Equals(createdDate)));

            switch (sortOrder)
            {
                case "WorkflowName":
                    steps = steps.OrderByDescending(wf => wf.Name).ToList();
                    break;
                case "DateAsc":
                    steps = steps.OrderBy(wf => wf.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    steps = steps.OrderByDescending(wf => wf.CreatedDate).ToList();
                    break;
                default:
                    steps = steps.OrderBy(wf => wf.Name).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return steps.ToPagedList(No_Of_Page, Size_Of_Page);
        }

        private IPagedList<Models.Workflow.Step> GetWorkflowSteps(int workflowID, string sortOrder, int? page, string createdDate = "", string searchString = "")
        {
            if(workflowID == -1)
            {
                return new List<Models.Workflow.Step>().ToPagedList(1, 8);
            }

            ViewBag.WorkflowID = workflowID;
            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "StepName" : "";

            var steps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Step>>(_workflowSetup.GetWorkflowSteps(workflowID));
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                steps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Step>>(_workflowSetup.GetWorkflowSteps(workflowID).ToList().FindAll(p => p.Name.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                steps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Step>>(_workflowSetup.GetWorkflowSteps(workflowID).ToList().FindAll(p => p.Name.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                steps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.Step>>(_workflowSetup.GetWorkflowSteps(workflowID).ToList().FindAll(p => p.CreatedDate.Equals(createdDate)));

            switch (sortOrder)
            {
                case "WorkflowName":
                    steps = steps.OrderByDescending(wf => wf.Name).ToList();
                    break;
                case "DateAsc":
                    steps = steps.OrderBy(wf => wf.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    steps = steps.OrderByDescending(wf => wf.CreatedDate).ToList();
                    break;
                default:
                    steps = steps.OrderBy(wf => wf.Name).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return steps.ToPagedList(No_Of_Page, Size_Of_Page);
        }

        [HttpPost]
        public JsonResult WorkflowAutoComplete(string prefix)
        {
            var workflows = _workflowSetup.GetMatchingWorkflows(prefix);

            return Json(workflows);
        }

        [HttpPost]
        public JsonResult StepAutoComplete(string prefix)
        {
            var steps = _workflowSetup.GetMatchingSteps(prefix);

            return Json(steps);
        }

        public ActionResult InitiateWorkflow()
        {
            var _workflowInitializer = new WorkflowManager.WorkflowInitializer();
            _workflowInitializer.InitializeWorkflow(3, 1, 1, "Sales");
            return new EmptyResult();
        }
    }
}
