using System.Linq;
using System.Runtime.CompilerServices;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using static SoftUniStore.Data.Data;
using SoftUniStore.Models;

namespace SoftUniStore.Utilities
{
    public class AuthenticationManager
    {
        public static void Logout(HttpResponse response, string sessionId)
        {
            Login currentLogin = Context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
            currentLogin.IsActive = false;
            Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }

        public static bool AuthenticateUser(HttpSession session)
        {
            if (Context.Logins.Any(login => login.SessionId == session.Id && login.IsActive))
            {
                return false;
            }
            return true;
        }
    }
}
