using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }
      
        // GET: Users
        public IActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users
        //        .SingleOrDefaultAsync(m => m.UserId == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        // GET: Users/Create
        public IActionResult Create()
        {


            List<Employees> countrylist = new List<Employees>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            countrylist = (from product in _context.Employees
                           select product).ToList();

            // ------- Inserting Select Item in List -------
            countrylist.Insert(0, new Employees { EmpId = 0, FullName = "Select" });

            // ------- Assigning countrylist to ViewBag.ListofCountry -------
            ViewBag.ListofCountry = countrylist;




            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(/*[Bind("UserId,Name,Email,PhoneNumber,Address,Purpose,Name_of_company,Whom_to_see,Company_name,Name_of_event,From_where,To_whom,Sign_in")]*/ BigView model)
        {

            if (!ModelState.IsValid)
            {
                return View();
              
            }
            var smtpClient = new SmtpClient
            {
                Host = "smtp.office365.com", // set your SMTP server name here
                Port = 25, // Port 
                EnableSsl = true,
                Credentials = new NetworkCredential("onyeamah@lotusbetaanalytics.com", "")
            };
            // ------- Getting Data from Database Using EntityFrameworkCore -------


            using (var message = new MailMessage("onyeamah@lotusbetaanalytics.com","onyeamah@lotusbetaanalytics.com")
            {
                Subject = model.User.Purpose,
                Body = " Hello" + model.User.Name + "is waiting"

            })
               smtpClient.SendMailAsync(message);

       
            _context.Add(model.User);
           
             _context.SaveChanges();
            return RedirectToAction("SuccessPage");

        }
        public IActionResult SuccessPage()
        {
            return View();
        }
        public IActionResult Main()
        {
            return View();
        }
        public IActionResult New()
        {
            return View();
        }
       

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        public JsonResult Search(string term)
        {
            var exist = (from s in _context.Users.Where(s => s.Name.StartsWith(term))
                         select new { value = s.Name, label = s.Name }).ToList();
            return Json(exist);
        }
      
        [HttpGet]
        public IActionResult Existing( int id)
        {
            User mde = new User();
            List<Employees> countrylist = new List<Employees>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            countrylist = (from data in _context.Employees
                           select data).ToList();
         
            // ------- Inserting Select Item in List -------
            countrylist.Insert(0, new Employees { EmpId = 0, FullName = "Select" });

            // ------- Assigning countrylist to ViewBag.ListofCountry -------
            ViewBag.ListofCountry = countrylist;

            return View();
        }
        //REFERENCE PURPOSE
        //private void PopulateDropdownList(object selectedEmployee = null)
        //{
        //    var Query = from d in _context.Employees
        //                orderby d.FullName
        //                select d;
        //    ViewBag.EmpId = new SelectList(Query, "EmpId", "FullName", selectedEmployee);
        //}
        [HttpPost]
        public async Task<IActionResult> Existing()
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            var user = from s in _context.Generals where s.UserId == s.User.UserId select s;
            foreach (var item in user)
            {
                _context.Add(item);
            }
            

            await _context.SaveChangesAsync();
            return RedirectToAction("Existing");
        
        }
      
    }
}
