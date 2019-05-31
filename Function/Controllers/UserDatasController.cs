using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Function.EF;
using Function.Models;

namespace Function.Controllers
{
    public class UserDatasController : Controller
    {
        private UserContext db = new UserContext();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Block = "none";
            var user = db.UserDatas.Find(3);
            return View(user);
        }

        [HttpGet]
        public ActionResult ShowChart()
        {
            ViewBag.G = new SelectList(db.Charts, "Id", "Name");
            UserData data = new UserData
            {
                A = 0,
                B = 0,
                C = 0,
                RangeFrom = 0,
                RangeTo = 0,
                Step = 0
            };
            return View(data);
        }
        [HttpPost]
        public ActionResult ShowChart(int? G)
        {
            ViewBag.G = new SelectList(db.Charts, "Id", "Name");
            if (G == null)
            {
                UserData data = new UserData
                {
                    A = 0,
                    B = 0,
                    C = 0,
                    RangeFrom = 0,
                    RangeTo = 0,
                    Step = 0
                };
                return View(data);

            }
            UserData userData = null;
            try
            {
                var chart = db.Charts.Find(G);
                userData = db.UserDatas.Find(chart.UserData.Id);

            }
            catch (Exception p)
            {
                ViewBag.message = p.Message;
            }
            return View(userData);

        }
        [HttpPost]
        public ActionResult Save(Chart chart)
        {
            if(chart.Name == null)
            {
                ViewBag.Message = "Данные графика не введены. График не сохранен";
                UserData data = new UserData
                {
                    A = 0,
                    B = 0,
                    C = 0,
                    RangeFrom = 0,
                    RangeTo = 0,
                    Step = 0
                };
                return View("Index", data);
            }
            int id = (from m in db.UserDatas select m.Id).ToList().Last();
            chart.UserData = db.UserDatas.Find(id);
            db.Charts.Add(chart);
            db.SaveChanges();

            return View();
        }

        [HttpPost]
        public ActionResult Index(UserData data)
        {
            try
            {
                if (ModelState.IsValid)
                {//проверка всех данных_покрытие тестами_тестирование
                    if (data.A == 0)
                    {
                        ViewBag.Message = "Коэффициент 'a' не может быть равен нулю! " +
                            "Нарисован график по умолчанию в ознакомительных целях";
                        var user = db.UserDatas.Find(3);
                        return View(user);
                    }
                    else if (data.Step <= 0)
                    {
                        ViewBag.Message = "Коэффициент 'step' не может быть равен или меньше нуля! " +
                            "Нарисован график по умолчанию в ознакомительных целях";
                        var user = db.UserDatas.Find(3);
                        return View(user);
                    }
                    else if (data.RangeTo == 0)
                    {
                        ViewBag.Message = "Коэффициент 'rangeTo' не должен быть равен нулю! " +
                            "Нарисован график по умолчанию в ознакомительных целях";
                        var user = db.UserDatas.Find(3);
                        return View(user);
                    }
                    else if (data.RangeFrom == 0)
                    {
                        ViewBag.Message = "Коэффициент 'rangeFrom' не должен быть равен нулю! " +
                            "Нарисован график по умолчанию в ознакомительных целях";
                        var user = db.UserDatas.Find(3);
                        return View(user);
                    }
                    else
                    {
                        ViewBag.Block = "block";
                        db.UserDatas.Add(data);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception p)
            {
                ViewBag.Message = p.Message;
            }

            return View(data);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
