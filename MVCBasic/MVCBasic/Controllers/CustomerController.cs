using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCBasic.Models;
using MVCBasic.Repository.Domain.Cutomers;
using MVCBasic.Repository.Repository.Customers;

namespace MVCBasic.Controllers
{
    public class CustomerController : Controller
    {
        #region ctor

        private readonly CustomerRepository _customerRepository;
        public CustomerController()
        {
            _customerRepository = CustomerRepository.Data;
        }

        #endregion

        #region Index

        [HttpGet]
        public ActionResult Index()
        {
            var entities = _customerRepository.GetAll();
            var model = new List<CustomerModel>();
            entities.ForEach(x =>
            {
                model.Add(ToModel(x));
            });
            return View(model);
        }

        #endregion

        #region Add

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Add()
        {
            return View("Add", new CustomerModel());
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Add(CustomerModel model)
        {
            var entity = ToEntity(model);
            _customerRepository.Add(entity);
            return RedirectToRoute("CustomerIndex");
        }

        #endregion

        #region Update

        [HttpGet]
        public ActionResult Update(int id)
        {
            var entity = _customerRepository.GetAll().FirstOrDefault(x => x.Id == id);
            return View(ToModel(entity));
        }

        [HttpPost]
        public ActionResult Update(CustomerModel model)
        {
            var entity = ToEntity(model);
            _customerRepository.Update(entity);
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

        #endregion

        #region Common
        [NonAction]
        public CustomerModel ToModel(Customer entity)
        {
            return new CustomerModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                EmailAddress = entity.EmailAddress,
                Phone = entity.Phone,
                State = entity.State,
                ZipCode = entity.ZipCode
            };
        }

        [NonAction]
        public Customer ToEntity(CustomerModel entity)
        {
            return new Customer
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                EmailAddress = entity.EmailAddress,
                Phone = entity.Phone,
                State = entity.State,
                ZipCode = entity.ZipCode
            };
        }
        #endregion
    }
}