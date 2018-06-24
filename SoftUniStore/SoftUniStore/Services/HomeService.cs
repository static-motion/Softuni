using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SimpleHttpServer.Models;
using SoftUniStore.Models;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Services
{
    public class HomeService : Service
    {
        public HomeViewModel GetHomeViewModel()
        {
            HomeViewModel model = new HomeViewModel();
            IEnumerable<HomeGameViewModel> games = this.Context.Games.Select(game => new HomeGameViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ImageThumbnail = game.ImageThumbnail,
                Size = game.Size,
                Price = game.Price
            });
            model.Games = games;
            return model;
        }

        public GameInfoViewModel GetGameInfo(int gameId)
        {
            Game game = this.Context.Games.FirstOrDefault(g => g.Id == gameId);
            return new GameInfoViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate,
                Size = game.Size,
                Trailer = game.Trailer,
                Price = game.Price
            };
        }

        public int GetGameIdFromRequest(HttpRequest request)
        {
            return int.Parse(Regex.Match(request.Url, @"\d").Value);
        }

        public void BuyGame(int gameId, HttpSession session)
        {
            User user = this.Context.Logins.FirstOrDefault(u => u.SessionId == session.Id).User;
            user.GamesList.Add(this.Context.Games.FirstOrDefault(game => game.Id == gameId));
        }

        public void GetOwnedGames(HttpSession session)
        {
            User currentUser = this.Context.Logins.FirstOrDefault(login => login.SessionId == session.Id).User;
            HomeViewModel model = new HomeViewModel();
            //todo
        }
    }
}
