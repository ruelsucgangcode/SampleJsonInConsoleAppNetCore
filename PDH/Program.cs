using Microsoft.Extensions.DependencyInjection;
using PDH.Repository;
using PDH.Repository.Common;
using PDH.Repository.Infastructure;
using PDH.Services.Infastructures;
using System;

namespace PDH
{
    public class Program 
    {
        static void Main(string[] args)
        {
            var _serviceProvider = ServiceContainer.ConfigurePizza();

            // display the header and user options
            TextLabels.PrintHeader(Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.SubHeaderText1)));
            TextLabels.MainMenu();

            // user input
            string val;
            Console.Write(TextLabels.SelectMenu());
            val = Console.ReadLine();
            int mnu = Convert.ToInt32(val);

            // execute the service that will identify which option to process
            var serviceObj = _serviceProvider.GetService<iAppService>();
            serviceObj.GetOption(mnu);

            Console.ReadLine();
        }
    }       
}
