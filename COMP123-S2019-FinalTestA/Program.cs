using COMP123_S2019_FinalTestA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMP123_S2019_FinalTestA.Objects;

namespace COMP123_S2019_FinalTestA
{
   public static class Program
    {
        public static string FirstName { get; set; }
        public static string LastName { get; set; }


        public static HeroGenerator heroGenerator;
        public static SplashScreen splashScreen;
        public static AboutForm aboutForm;
        public static Hero chracter;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            aboutForm=new AboutForm();
            chracter=new Hero();
            heroGenerator = new HeroGenerator();
            splashScreen= new SplashScreen();
            Application.Run(splashScreen);
        }
    }
}
