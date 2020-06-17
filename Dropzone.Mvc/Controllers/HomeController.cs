using Dropzene.Model.Models;
using Dropzone.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dropzone.Mvc.Controllers
{
    public class HomeController : Controller
    {
        ProjectContext db = new ProjectContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }


        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product, IEnumerable<HttpPostedFileBase> file/*IEnumerable<HttpPostedFileBase> files*/)
        {
            //bool isSavedSuccessfully = false;
            //string fileName = "";
            string fName = "";
            var path = "";
            
            foreach (var fileName in file)
            {
               

                //fName = file.FileName;
                if (file != null && fileName.ContentLength > 0)
                {

                    var originalDirectory = new DirectoryInfo(string.Format("{0}Uploads", Server.MapPath(@"\")));

                    string pathString = System.IO.Path.Combine(originalDirectory.ToString());

                    
                     fName = Path.GetFileName(fileName.FileName);

                    bool isExists = System.IO.Directory.Exists(pathString);

                    if (!isExists)
                        System.IO.Directory.CreateDirectory(pathString);

                    path = string.Format("{0}\\{1}", pathString,fName);
                    //file.SaveAs(path);

                    fileName.SaveAs(path);


                    //isSavedSuccessfully = true;
                }

               

               

            }
            product.ImagePath = fName;

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}