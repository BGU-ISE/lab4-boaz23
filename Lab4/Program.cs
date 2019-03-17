using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using log4net;

namespace Lab4
{

    class Program
    {
        //Declare an instance for log4net
        private static readonly ILog Log =
              LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            Login();
            ImplementLoggingFuntion();
        }

        private static bool Login()
        {
            var loginController = new LoginController();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Userid: ");
                string userid = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                switch (loginController.Login(userid, password))
                {
                    case LoginResponse.Succeeded:
                        Console.WriteLine("Login succeeded");
                        return true;
                    case LoginResponse.Failed:
                        Console.WriteLine("Login faild, try again.\n");
                        break;
                    case LoginResponse.TooManyAttempts:
                        Console.WriteLine("Too many attempts were made, you may not enter.");
                        return false;
                    default:
                        throw new Exception("Code should not reach here.");
                }
            }

            return false;
        }

        private static void ImplementLoggingFuntion()
        {
            /* We have 5 levels of log message. Let's test all.
             *  FATAL
                ERROR
                WARN
                INFO
                DEBUG
             */
            var secs = 3;
            Log.Fatal("Start log FATAL...");
            Console.WriteLine("Start log FATAL...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Error("Start log ERROR...");
            Console.WriteLine("Start log ERROR...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Warn("Start log WARN...");
            Console.WriteLine("Start log WARN...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Info("Start log INFO...");
            Console.WriteLine("Start log INFO...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Debug("Start log DEBUG...");
            Console.WriteLine("Start log DEBUG...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }
}
