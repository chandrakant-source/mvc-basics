using System.Linq;
using System.Web.Mvc;
using MVCBasic.Models;

namespace MVCBasic.Controllers
{
    //[RouteArea("Master")]
    //[RoutePrefix("Customers")]
    //[Route("{action}")]
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
            return View(_customerRepository.GetAll());
        }

        #endregion

        #region Add
        [Route("EditCustomer/{id:int}")]
        [Route("Customer/Edit/{id:int}")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            var entity = _customerRepository.GetAll().FirstOrDefault(x => x.Id == id);
            return View(entity);
        }
        #endregion
    }
}