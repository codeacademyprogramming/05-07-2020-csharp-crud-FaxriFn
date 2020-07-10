using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        private readonly DataAccessLayer _dataAccess;

        public PersonController()
        {
            _dataAccess = new DataAccessLayer();
        }
        // GET: Person
        public ActionResult Index()
        {
            var data = _dataAccess.People.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Person person = _dataAccess.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
        [HttpPost]
        public ActionResult Edit(int Id, string name, string surname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                Person persons = new Person { Id = Id, Name = name, Surname = surname };
                return View(persons);
            }
            Person person = _dataAccess.People.Find(Id);
            if (person == null)
            {
                return HttpNotFound();
            }
            person.Name = name;
            person.Surname = surname;
            _dataAccess.SaveChanges();
            return RedirectToAction("index");
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = _dataAccess.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            _dataAccess.People.Remove(person);
            _dataAccess.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name,string surname)
        {
            if (string.IsNullOrEmpty(name))
            {
                return View();
            }
            Person person = new Person()
            {
                Name = name,
                Surname=surname
            };
            _dataAccess.People.Add(person);
            _dataAccess.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}