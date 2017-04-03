using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForManageVisitors.Models;

namespace WebApiForManageVisitors.Controllers
{
    public class ContractorMasterController : Controller
    {
        ManageVisitorsEntities _DbManageVisitorsEntities = new ManageVisitorsEntities();
        public void CheckViewBagData()
        {
            @ViewBag.EmployeeRegistration = false;
            @ViewBag.VisitorRegistration = false;
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = false;
            @ViewBag.ContractorMaster = true;
            @ViewBag.RequestDetails = false;
        }

        // GET: ContractorMaster
        public ActionResult Index()
        {
             CheckViewBagData();

            List<ContractorMasterModel> _objListContractorMasterModel = new List<ContractorMasterModel>();
            var _objAllContractorMasterModel = _DbManageVisitorsEntities.tbl_ContractorMaster.ToList();

            foreach (var item in _objAllContractorMasterModel)
            {
                ContractorMasterModel _class = new ContractorMasterModel();

                _class.ContractorSrNo = item.ContractorSrNo;
                _class.CompanyName = item.CompanyName;
                _class.ContractorName = item.ContractorName;
                _class.ContractorContactNo = (item.ContractorContactNo);
                _class.ContractorCreateDate = (item.ContractorCreateDate);
                _objListContractorMasterModel.Add(_class);
            }

            return View(_objListContractorMasterModel.ToList());
        }

        // GET: ContractorMaster/Details/5
        public ActionResult Details(int id)
        {
            CheckViewBagData();

            ContractorMasterModel _objContractorMasterModel = new ContractorMasterModel();
            var model = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(a => a.ContractorSrNo == id).FirstOrDefault();
            {
                _objContractorMasterModel.ContractorSrNo = model.ContractorSrNo;
                _objContractorMasterModel.CompanyName = model.CompanyName;
                _objContractorMasterModel.ContractorName = model.ContractorName;
                _objContractorMasterModel.ContractorContactNo = model.ContractorContactNo;
                _objContractorMasterModel.ContractorCreateDate = model.ContractorCreateDate;
            };
            return View(_objContractorMasterModel);
        }

        // GET: ContractorMaster/Create
        public ActionResult Create()
        {
            CheckViewBagData();
            return View();
        }

        // POST: ContractorMaster/Create
        [HttpPost]
        public ActionResult Create(ContractorMasterModel collection)
        {
            try
            {
                CheckViewBagData();
                if (ModelState.IsValid)
                {
                    var data = new tbl_ContractorMaster
                    {
                        CompanyName = collection.CompanyName,
                        ContractorName = collection.ContractorName,
                        ContractorContactNo = collection.ContractorContactNo,
                       // ContractorCreateDate = DateTime.Now
                    };

                    _DbManageVisitorsEntities.tbl_ContractorMaster.Add(data);
                    _DbManageVisitorsEntities.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ContractorMaster/Edit/5
        public ActionResult Edit(int id)
        {
            CheckViewBagData();
            ContractorMasterModel _objContractorMasterModel = new ContractorMasterModel();
            var model = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(a => a.ContractorSrNo == id).FirstOrDefault();
            {
                _objContractorMasterModel.ContractorSrNo = model.ContractorSrNo;
                _objContractorMasterModel.CompanyName = model.CompanyName;
                _objContractorMasterModel.ContractorName = model.ContractorName;
                _objContractorMasterModel.ContractorContactNo = (model.ContractorContactNo);
                _objContractorMasterModel.ContractorCreateDate = (model.ContractorCreateDate);

            };

            return View(_objContractorMasterModel);
        }

        // POST: ContractorMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContractorMasterModel collection)
        {
            try
            {
                CheckViewBagData();
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    ContractorMasterModel _objContractorMasterModel = new ContractorMasterModel();
                    var model = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(a => a.ContractorSrNo == id).FirstOrDefault();
                    {
                        //_objContractorMasterModel.ContractorSrNo = model.ContractorSrNo;
                        //_objContractorMasterModel.CompanyName = collection.CompanyName;
                        //_objContractorMasterModel.ContractorName = collection.ContractorName;
                        //_objContractorMasterModel.ContractorContactNo = (collection.ContractorContactNo);
                        ////_objContractorMasterModel.ContractorCreateDate = (model.ContractorCreateDate);
                        model.ContractorSrNo = collection.ContractorSrNo;
                        model.CompanyName = collection.CompanyName;
                        model.ContractorName = collection.ContractorName;
                        model.ContractorContactNo = (collection.ContractorContactNo);
                        model.ContractorCreateDate = collection.ContractorCreateDate;
                    };

                    _DbManageVisitorsEntities.Entry(model).State = EntityState.Modified;
                    _DbManageVisitorsEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ContractorMaster/Delete/5
        public ActionResult Delete(int id)
        {
            CheckViewBagData();
            ContractorMasterModel _objContractorMasterModel = new ContractorMasterModel();
            var model = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(a => a.ContractorSrNo == id).FirstOrDefault();
         
            _objContractorMasterModel.ContractorSrNo = model.ContractorSrNo;
            _objContractorMasterModel.CompanyName = model.CompanyName;
            _objContractorMasterModel.ContractorName = model.ContractorName;
            _objContractorMasterModel.ContractorContactNo = (model.ContractorContactNo);
            _objContractorMasterModel.ContractorCreateDate = (model.ContractorCreateDate);

            return View(_objContractorMasterModel);
        }

        // POST: ContractorMaster/Delete/5
      
        public ActionResult DeleteNow(int id, FormCollection collection)
        {
            try
            {
                CheckViewBagData();
                // TODO: Add delete logic here
                var model = _DbManageVisitorsEntities.tbl_ContractorMaster.Where(a => a.ContractorSrNo == id).FirstOrDefault();
                _DbManageVisitorsEntities.tbl_ContractorMaster.Remove(model);
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
