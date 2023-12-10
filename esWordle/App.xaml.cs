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
        public static ServiceProvider ServiceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            #region View
            services.AddSingleton<GameView>();
            services.AddTransient<OptionsView>();
            #endregion

            #region ViewModel
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<GameViewModel>();
            services.AddTransient<OptionsViewModel>();
            services.AddSingleton<WordleGridViewModel>();
            services.AddTransient<WordInputViewModel>();
            services.AddSingleton<GameSessionViewModel>();
            #endregion ViewModel

            services.AddTransient<WordAccessor>();
            services.AddTransient<RuleEnforcer>();    
            services.AddSingleton<MainNavigationService>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
