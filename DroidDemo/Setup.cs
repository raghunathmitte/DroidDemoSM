using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using SMDemoData.Interfaces;
using DroidDemo.Services;
using SMDemoData;
using System.Reflection;
using System.Collections.Generic;

namespace DroidDemo
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
			return new SMDemoData.App();
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly
        };

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.LazyConstructAndRegisterSingleton<ILoggingService, LoggingService>();
            Mvx.LazyConstructAndRegisterSingleton<IDownloadService, DownloadService>();
        }
    }
}
