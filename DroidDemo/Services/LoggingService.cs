using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SMDemoData.Interfaces;

namespace DroidDemo.Services
{
    class LoggingService : ILoggingService
    {
        public void Log(string message)
        {
            Android.Util.Log.Info(Application.Context.PackageName, message);
        }
    }
}