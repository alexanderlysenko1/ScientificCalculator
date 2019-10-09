using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }
        public string Evaluate(float first,float second,string oper)
        {
            double result = 0;
            Expression expression = new Expression();
           
            switch (oper)
            {
                case "+":
                    result = first + second;
                    expression.Operation = first.ToString() + oper.ToString() + second.ToString();
                    break;
                case "-":
                    result = first - second;
                    expression.Operation = first.ToString() + oper.ToString() + second.ToString();
                    break;
                case "÷":
                    result = first / second;
                    expression.Operation = first.ToString() + oper.ToString() + second.ToString();
                    break;
                case "×":
                    result = first * second;
                    expression.Operation = first.ToString() + oper.ToString() + second.ToString();
                    break;
                case "√":
                    result = Math.Sqrt(second);
                    expression.Operation = oper.ToString() + second.ToString();
                    break;
                case "%":
                    result = second / 100;
                    expression.Operation = oper.ToString() + second.ToString();
                    break;
                case "х²":
                    result = second * second;
                    expression.Operation = oper.ToString() + second.ToString();
                    break;
                case "lx":
                    result = 1 / second;
                    expression.Operation = oper.ToString() + second.ToString();
                    break;
                case "±":
                    result = -1 * second;
                    expression.Operation = oper.ToString() + second.ToString();
                    break;

            }
            expression.Result = result.ToString();
            db.Expressions.Add(expression);
            db.SaveChanges();
            return expression.Result;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Expressions()
        {
            var db = new ApplicationDbContext();
            return Json(db.Expressions, JsonRequestBehavior.AllowGet);
        }

    }
}