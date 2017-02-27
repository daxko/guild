using System;
using System.Web.Mvc;

namespace StaticVariables.Controllers
{
    public class CalcController : Controller
    {
        static int _a;
        static int _b;

        public ActionResult index()
        {
            return View();
        }

        public ActionResult add(int a, int b)
        {
            _a = a;
            _b = b;

            do_some_other_work();
            
            var total = _a + _b;
            return Content(total.ToString());
        }

        // Simulate doing work that takes a little bit of time.
        void do_some_other_work()
        {
            System.Threading.Thread.Sleep(new Random().Next(0, 500));
        }
    }
}