using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkRequests.Models;

namespace WorkRequests.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WorkRequestViewModel model = new WorkRequestViewModel();
            DAL.WorkRequests wr = new DAL.WorkRequests();
            model.GetAllWorkRequests = wr.GetWorkRequests();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UploadTest()
        {
            return View();
        }

        public ActionResult GetReceipt()
        {
            Receipt model = new Receipt();
            DAL.WorkRequests wr = new DAL.WorkRequests();
            model.GetReceipts = wr.GetReceipts();

            return View(model);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, Receipt model)
        {
            var path = String.Empty;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                file.SaveAs(path);
            }

            if (ModelState.IsValid)
            {                
                Guid receiptName = new Guid();
                model.ReceiptImageName = receiptName.ToString();

                //model.ReceiptImage = GetPhoto(@"C:\Users\dallan\Documents\bare-my-soul.jpg"); //System.IO.File.ReadAllBytes(path);

                DAL.WorkRequests wr = new DAL.WorkRequests();
                string result = wr.AddReceipt(model);

                if (result == "-1")
                {
                    TempData["Message"] = "Work request successfully created!";
                }

                ModelState.Clear();

                return RedirectToAction("UploadTest");
            }



            return RedirectToAction("UploadTest");
        }

        public static byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }
    }
}