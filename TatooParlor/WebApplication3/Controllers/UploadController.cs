using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.DataAccessPostgreSqlProvider;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using TatooParlor;

namespace WebApplication3.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoUpload(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var xs = new XmlSerializer(typeof(TatooSalon));
                var ship = (TatooSalon)xs.Deserialize(stream);


                using (var db = new TatooParlorDbContext())
                {
                    var dbs = new DbTatooParlor();
                    foreach (var s in ship.Journal)
                    {
                        dbs.Journal = new Collection<DbFlight>();
                        foreach (var flight in ship.Journal)
                        {
                            dbs.Journal.Add(new DbFlight()
                            {
                                VisitorName = flight.VisitorName,
                                Age = flight.Age,
                                Gender = flight.Gender,
                                BodyPart = flight.BodyPart,
                                Contacts = flight.Contacts,
                                DateToVisit = flight.DateToVisit,
                                Master = flight.Master,
                                TatooStyles = flight.TatooStyles,
                            });
                        }
                    }

                    db.SpaceShips.Add(dbs);
                    db.SaveChanges();
                }


                return View(ship);
            }
        }

        //public ActionResult Image(int id)
        //{
        //    using (var db = new SpaceFleetDbContext())
        //    {
        //        return base.File(db.SpaceShips.Find(id).Photo, "image/jpeg");
        //    }
        //}

        public ActionResult List()
        {
            List<DbTatooParlor> list;
            using (var db = new TatooParlorDbContext())
            {
                list = db.SpaceShips.Include(s => s.Journal).ToList();
            }

            return View(list);
        }
    }
}