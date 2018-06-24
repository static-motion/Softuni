using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Services;
using SoftUniStore.Utilities;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Controllers
{
    class HomeController : Controller
    {
        private HomeService service;
        public HomeController()
        {
            this.service = new HomeService();
        }
        [HttpGet]
        public IActionResult<HomeViewModel> Index()
        {
            HomeViewModel AllGamesView = this.service.GetHomeViewModel();
            return this.View(AllGamesView);
        }

        [HttpPost]
        public IActionResult Index(HttpResponse response, HttpRequest request, HttpSession session)
        {
            return null;
        }


        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.Logout(response, session.Id);
            this.Redirect(response, "/users/login");
        }

        [HttpGet]
        public IActionResult<GameInfoViewModel> Info(HttpRequest request)
        {
            int gameId = this.service.GetGameIdFromRequest(request);
            GameInfoViewModel gameInfoView = this.service.GetGameInfo(gameId);
            return this.View(gameInfoView);
        }

        [HttpPost]
        public IActionResult Info(HttpSession session, HttpRequest request, HttpResponse response)
        {
            int gameId = this.service.GetGameIdFromRequest(request);
            this.service.BuyGame(gameId, session);
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Owned(HttpSession session)
        {
            this.service.GetOwnedGames(session);
            return null;
        }
    }
}
