using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForManageVisitors.Models;

namespace WebApiForManageVisitors.Controllers
{
    public class EmployeeDepartmentController : Controller
    {
        ManageVisitorsEntities _DbManageVisitorsEntities = new ManageVisitorsEntities();
        // GET: EmployeeDepartment

        public void CheckViewBagData()
        {
            @ViewBag.EmployeeDepartment = true;
            @ViewBag.EmployeeRegistration = false;
            @ViewBag.VisitorRegistration = false;
            @ViewBag.Account = false;
            @ViewBag.EmployeeDesignation = false;
            @ViewBag.ContractorMaster = false;
            @ViewBag.RequestDetails = false;
        }

        public ActionResult Index()
        {
            CheckViewBagData();
            List<DepartmentMasterModel> _objDepartmentModel = new List<DepartmentMasterModel>();
            var Department = _DbManageVisitorsEntities.tbl_DepartmentMaster.ToList();
            foreach (var item in Department)
            {
                DepartmentMasterModel _objDepartmentMasterModel = new DepartmentMasterModel();
                var Departmentitem = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentID == item.DepartmentID).FirstOrDefault();
                _objDepartmentMasterModel.DepartmentID = Departmentitem.DepartmentID;
                _objDepartmentMasterModel.DepartmentName = Departmentitem.DepartmentName;
                _objDepartmentMasterModel.DepartmentCreateDate = Departmentitem.DepartmentCreateDate;
                _objDepartmentModel.Add(_objDepartmentMasterModel);
            }
            return View(_objDepartmentModel.ToList());

        }

        // GET: EmployeeDepartment/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(a => a.DepartmentID == id).FirstOrDefault();
            DepartmentMasterModel _objDepartmentModel = new DepartmentMasterModel();
            _objDepartmentModel.DepartmentID = model.DepartmentID;
            _objDepartmentModel.DepartmentName = model.DepartmentName;
            _objDepartmentModel.DepartmentCreateDate = model.DepartmentCreateDate;
            return View(_objDepartmentModel);
        }

        [HttpPost]
        public JsonResult DepartmentExists(string DepartmentName, int? DepartmentID)
        {
            if (DepartmentID != null)
            {
                if (_DbManageVisitorsEntities.tbl_DepartmentMaster.Any(x => x.DepartmentName == DepartmentName))
                {
                    tbl_DepartmentMaster existingDepartment = _DbManageVisitorsEntities.tbl_DepartmentMaster.Single(x => x.DepartmentName == DepartmentName);
                    if (existingDepartment.DepartmentID != DepartmentID)
                    {
                        return Json(false);
                    }
                    else
                    {
                        return Json(true);
                    }
                }
                else
                {
                    return Json(true);
                }
            }
            else
            {
                return Json(!_DbManageVisitorsEntities.tbl_DepartmentMaster.Any(x => x.DepartmentName == DepartmentName));
            }
        }

        // GET: EmployeeDepartment/Create
        public ActionResult Create()
        {
            CheckViewBagData();
            return View();
        }

        // POST: EmployeeDepartment/Create
        [HttpPost]
        public ActionResult Create(DepartmentMasterModel collection)
        {
            CheckViewBagData();
            if (ModelState.IsValid)
            {
               var data = new tbl_DepartmentMaster()
                {
                    DepartmentName = collection.DepartmentName,
                    DepartmentCreateDate = DateTime.Now
                };
               if (!_DbManageVisitorsEntities.tbl_DepartmentMaster.Any(p=>p.DepartmentName==collection.DepartmentName))
                {
                    try
                    {
                        _DbManageVisitorsEntities.tbl_DepartmentMaster.Add(data);
                        _DbManageVisitorsEntities.SaveChanges();


                        List<string> Desig = new List<string> { "Activity Owner", "Area Owner", "Safety" };
                        foreach (var item in Desig)
                        {
                            var DesignationData = new tbl_DesignationMaster()
                            {
                                DepartmentID = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(p => p.DepartmentName == collection.DepartmentName).Select(p => p.DepartmentID).FirstOrDefault(),
                                DesignationName = item,
                                DesignationCreateDate= DateTime.Now
                            };
                            _DbManageVisitorsEntities.tbl_DesignationMaster.Add(DesignationData);
                            _DbManageVisitorsEntities.SaveChanges();
                        }
                        return RedirectToAction("Index");
                    }
                    catch(Exception ex)
                    {
                        return View();
                    }

                }
                else
                {
                   ViewBag.Errormessage = "Fail";
                }

            }
            return View();
        }

        // GET: EmployeeDepartment/Edit/5
        public ActionResult Edit(int id)
        {
            CheckViewBagData();
            DepartmentMasterModel _objDepartmentModel = new DepartmentMasterModel();
            var model = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(a => a.DepartmentID == id).FirstOrDefault();
            {
                _objDepartmentModel.DepartmentID = model.DepartmentID;
                _objDepartmentModel.DepartmentName = model.DepartmentName;
                _objDepartmentModel.DepartmentCreateDate = model.DepartmentCreateDate;
            }
            return View(_objDepartmentModel);

        }

        // POST: EmployeeDepartment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DepartmentMasterModel collection)
        {
            // TODO: Add update logic here
            //DepartmentMasterModel _objDepartment = new DepartmentMasterModel();
            try
            {
                CheckViewBagData();
                if (ModelState.IsValid)
                {
                    var data = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(b => b.DepartmentID == id).FirstOrDefault();
                    {
                        //data.DepartmentID = collection.DepartmentID;
                        data.DepartmentName = collection.DepartmentName;
                        _DbManageVisitorsEntities.Entry(data).State = EntityState.Modified;
                        _DbManageVisitorsEntities.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
         

                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeDepartment/Delete/5
        public ActionResult Delete(int id)
        {
            CheckViewBagData();
            var model = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(a => a.DepartmentID == id).FirstOrDefault();
            DepartmentMasterModel _objModel = new DepartmentMasterModel();
            _objModel.DepartmentCreateDate = model.DepartmentCreateDate;
            _objModel.DepartmentID = model.DepartmentID;
            _objModel.DepartmentName = model.DepartmentName;
             return View(_objModel);
        }

        // POST: EmployeeDepartment/Delete/5
  
        public ActionResult DeleteNow(int id)
        {
            try
            {
                CheckViewBagData();
                // TODO: Add delete logic here
                var model = _DbManageVisitorsEntities.tbl_DepartmentMaster.Where(a => a.DepartmentID == id).FirstOrDefault();
                _DbManageVisitorsEntities.tbl_DepartmentMaster.Remove(model);
                _DbManageVisitorsEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
