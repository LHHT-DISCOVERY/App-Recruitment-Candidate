using app_recruitment.controller;
using app_recruitment.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainController mainController = new MainController();
            mainController.controller();
            Console.ReadLine();
        }
    }
}
