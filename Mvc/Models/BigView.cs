using Microsoft.AspNetCore.Mvc;

namespace Mvc.Models
{
    public class BigView
    {
       [BindProperty]
        public User User { get; set; }
        public Employees Employees { get;  set; }
        [BindProperty]
        public General General { get; set; }
        

    }
}
