using AspNetCore.Reporting;
using GMS.Data;
using GMS.Helpers.AutentifikacijaAutorizacija;
using GMS.Reporting.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GMS.Reporting.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Report1Controller : ControllerBase
    {
        private ApplicationDbContext _db;

        public Report1Controller(ApplicationDbContext db)
        {
            _db = db;
        }

        public static List<Report1Model> GetKorisnici(ApplicationDbContext db)
        {
            List<Report1Model> podaci = db.Korisnik
                .Include("Grad")
                .Include("Spol")
                .Include("Teretana")
                .Select(s => new Report1Model
            {
                Ime = s.Ime,
                Prezime = s.Prezime,
                Username = s.Username,
                NazivGrad = s.Grad.Naziv,
                NazivSpol = s.Spol.Naziv,
                NazivTeretana = s.Teretana.Naziv

            }).ToList();

            return podaci;
        }

        [HttpGet]
        [Route("PDFReport")]
        public IActionResult Index()
        {

            LocalReport _localReport = new LocalReport("Reporting/RDLC/Report1.rdlc");
            List<Report1Model> podaci = GetKorisnici(_db);
            DataSet ds = new DataSet();
            _localReport.AddDataSource("dsKorisnici", podaci);

            //Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("nalog", HttpContext.GetLoginInfo().korisnickiNalog.Username);

            // EXCEL FORMAT

            //ReportResult result = _localReport.Execute(RenderType.ExcelOpenXml);
            //return File(result.MainStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            // PDF FORMAT

            ReportResult result = _localReport.Execute(RenderType.Pdf);
            return File(result.MainStream, "application/pdf");

        }


        [HttpGet]
        [Route("ExcelReport")]
        public IActionResult Index2()
        {

            LocalReport _localReport = new LocalReport("Reporting/RDLC/Report1.rdlc");
            List<Report1Model> podaci = GetKorisnici(_db);
            DataSet ds = new DataSet();
            _localReport.AddDataSource("dsKorisnici", podaci);

            //Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("nalog", HttpContext.GetLoginInfo().korisnickiNalog.Username);

            // EXCEL FORMAT

            ReportResult result = _localReport.Execute(RenderType.ExcelOpenXml);
            return File(result.MainStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            // PDF FORMAT

            //ReportResult result = _localReport.Execute(RenderType.Pdf);
            //return File(result.MainStream, "application/pdf");

        }
    }
}
