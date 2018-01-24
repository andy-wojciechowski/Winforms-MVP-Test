using CommandLine;
using System;
using System.Windows.Forms;
using CardCollectorMVPTest.Forms;
using CardCollectorMVPTest.DependencyResolution;
using CardCollectorStandard.Domain.Facades;
using CardCollectorStandard.Domain.Dtos;

namespace CardCollectorMVPTest
{
    class Options
    {
        [Option('u', "NewUser", Default = false)]
        public bool NewUser { get; set; }
    }

    static class Program
    {
        public static bool WasNewUserCreated;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var parserResult = Parser.Default.ParseArguments(args, typeof(Options));
            parserResult.WithParsed(ParsedArgs);
            if(!WasNewUserCreated)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AutoMapperConfig.Configure();
                Application.Run(new SetSelectionList());
            }
        }

        public static void ParsedArgs(object options)
        {
            var o = (Options)options;
            if(o.NewUser)
            {
                var username = Environment.UserName;
                Console.WriteLine("Please enter your password");
                var password = Console.ReadLine();
                using (var container = ObjectFactory.GetContainer())
                {
                    var userFacade = container.GetInstance<IUserFacade>();
                    userFacade.CreateUser(new UserRequestDto
                    {
                        Username = username,
                        Password = password
                    });
                }
                WasNewUserCreated = true;
            }
        }
    }
}
