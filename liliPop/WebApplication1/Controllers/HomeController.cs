using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly bool _isBuy = true;

        private readonly bool _isFree = false;

        private readonly AppUserManger _userManager;


        public ActionResult Index() => View();


        public ActionResult Check(Guid key)
        {
            var token = Guid.NewGuid().ToString("N");


            if (_isFree)
            {
                return File("~/Content/bootstrap.css", "application/css");
            }

            if (_isBuy)
            {
                DownloadProvider.Tokens.Add(new DownloadToken(key, token));
            }

           return RedirectToAction("Download", new {token});
        }


        public ActionResult Download(string token)
        {
            if (!IsVerifyied(token)) return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

            var user = Request.GetDownloadManagerUser();

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }


            var isSuccess = _userManager.SignIn(user.Password, user.UserName);


            if (isSuccess)
            {
                return File("~/Content/bootstrap.css", "application/css");
            }

            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }

        private bool IsVerifyied(string token)
        {
            return DownloadProvider.Tokens.Any(x => x.Token == token);
        }
    }

    internal class AppUserManger
    {
        public bool SignIn(string password, string userName)
        {
            return true;
        }
    }
}