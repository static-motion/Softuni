using System.Collections.Generic;
using System.Text;

namespace SoftUniStore.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<HomeGameViewModel> Games { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            int rowCount = 0;
            int gameCount = 0;
            foreach (HomeGameViewModel game in this.Games)
            {
                if (rowCount % 3 == 0)
                {
                    builder.Append("<div class=\"card-group\">");
                    rowCount = 1;
                }
                builder.Append(game);
                gameCount++;
                if (gameCount % 3 == 0)
                {
                    builder.Append("</div>");
                    rowCount = 3;
                }
            }
            return builder.ToString();
        }
    }
}
