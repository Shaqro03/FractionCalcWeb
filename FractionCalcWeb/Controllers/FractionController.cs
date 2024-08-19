using Microsoft.AspNetCore.Mvc;
using FractionCalcWeb.Controllers;
using FractionCalcWeb.Models;
using System.Reflection;
using System;


namespace FractionCalcWeb.Controllers;

public class FractionController : Controller
{
    public IActionResult FractionCalculator()
    {
        return View(new Fraction());
    }

    [HttpPost]

       public IActionResult FractionCalculator(Fraction f, string calculate)
        {
        if(f.hayt1 == 0 || f.hayt2 == 0)
            {
            ModelState.AddModelError("", "Denominator cannot be zero.");
            return View(f);
        }
        switch (calculate)
            {
                case "add":
                    f.amb3 = Convert.ToInt32((f.hayt2 * (f.hayt1 * f.amb1 + f.ham1) + f.hayt1 * (f.hayt2 * f.amb2 + f.ham2))/(f.hayt1*f.hayt2));
                    f.hayt3 = f.hayt1 * f.hayt2;
                    f.ham3 = (f.hayt2 * (f.hayt1 * f.amb1 + f.ham1) + f.hayt1 * (f.hayt2 * f.amb2 + f.ham2))-(f.amb3 * f.hayt3);
                    break;
                case "min":
                    f.amb3= Convert.ToInt32((f.hayt2 * (f.hayt1 * f.amb1 + f.ham1) - f.hayt1 * (f.hayt2 * f.amb2 + f.ham2)) / (f.hayt1 * f.hayt2));
                    f.hayt3 = f.hayt1 * f.hayt2;
                    f.ham3 = (f.hayt2 * (f.hayt1 * f.amb1 + f.ham1) - f.hayt1 * (f.hayt2 * f.amb2 + f.ham2)) - (f.amb3 * f.hayt3);
                break;
                case "sub":
                f.amb3 = Convert.ToInt32(((f.hayt1 * f.amb1 + f.ham1) * (f.hayt2 * f.amb2 + f.ham2)) / (f.hayt1 * f.hayt2));
                f.hayt3 = f.hayt1 * f.hayt2;
                f.ham3 = ((f.hayt1 * f.amb1 + f.ham1) * (f.hayt2 * f.amb2 + f.ham2)) - (f.amb3 * f.hayt3);
                break;
                case "div":
                if((f.hayt2 * f.amb2 + f.ham2)!=0)
                {
                    f.amb3 = Convert.ToInt32(((f.hayt1 * f.amb1 + f.ham1)*f.hayt2)/(f.hayt1 * (f.hayt2 * f.amb2 + f.ham2)));
                    f.hayt3 = f.hayt1 * (f.hayt2 * f.amb2 + f.ham2);
                    f.ham3= ((f.hayt1 * f.amb1 + f.ham1) * f.hayt2)-(f.amb3 * f.hayt3);
                }
                break;
            default:
              
                break;
            }
        return View(f);
        }
}
