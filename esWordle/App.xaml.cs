using DataAccess;
using DataAccess.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace esWordle
{
    public partial class App : Application
    {
        public App()
        {
            var test = new WordAccessor().GetWords(); // TODO: change this with DependencyInjection available
        }
    }
}
