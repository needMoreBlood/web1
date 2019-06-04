using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.EntityFrameworkCore;
//using TatooParlor.Web.Models.DataAccessPostgreSqlProvider;
using TatooParlor.Web.Models;

namespace TatooParlor.Web.Controllers
{
    public class uploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoUpload(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var xs = new XmlSerializer(typeof(TatooParlor.TatooSalon));
                var tatoo = (TatooParlor.TatooSalon)xs.Deserialize(stream);


                using (var db = new TatooParlorDbContext())
                {
                    var dbs = new DbTatooSalon()
                    {
                        VisitorName = tatoo.VisitorName,
                        Photo = tatoo.Photo,
                        Age = tatoo.Age,


                    };
                    dbs.Journal = new Collection<DbRegistration>();
                    foreach (var person in tatoo.Journal)
                    {
                        dbs.Journal.Add(new DbRegistration()
                        {
                            Contacts = person.Contacts,
                            Gender = person.Gender,
                            DateToVisit = person.DateToVisit,
                            TatooStyles = person.TatooStyles,
                            BodyPart = person.BodyPart,
                            Master = person.Master
                        });
                    }

                    db.TatooSalons.Add(dbs);
                db.SaveChanges();
            }


            return View(tatoo);
        }
    }

    public ActionResult Image(int id)
    {
        using (var db = new TatooParlorDbContext())
        {
            return base.File(db.TatooSalons.Find(id).Photo, "image/jpeg");
        }
    }

    public ActionResult List()
    {
        List<DbTatooSalon> list;
        using (var db = new TatooParlorDbContext())
        {
            list = db.TatooSalons.Include(s => s.Journal).ToList();
        }

        return View(list);
    }
}
}