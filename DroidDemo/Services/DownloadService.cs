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
using SMDemoData;
using Java.Net;
using Java.IO;
using System.Threading.Tasks;
using SMDemoData.Interfaces;

namespace DroidDemo.Services
{
    public class DownloadService : IDownloadService
    {
        private readonly ILoggingService _loggingSrevice;
        public DownloadService(ILoggingService loggingSrevice)
        {
            _loggingSrevice = loggingSrevice;
        }

        public object DownLoadVideo(string fileUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetData(string fileUrl)
        {
          return await Task.Run<string> (()=>{
                HttpURLConnection connection = null;
                string result = null;
                try
                {
                    URL url = new URL(fileUrl);
                    connection = (HttpURLConnection)url.OpenConnection();
                    connection.ReadTimeout = 60000;
                    connection.DoInput = true;
                    connection.Connect();
                  _loggingSrevice.Log(string.Format("Response Code {0} ", connection.ResponseCode));
                    result = ReadString(connection.InputStream, 1024);
                  _loggingSrevice.Log(string.Format("[DownloadService] - Response String =  {0} ", result));
                }
                catch (Exception e)
                {
                  _loggingSrevice.Log(string.Format("[DownloadService] Exception {0} ", e.Message));
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Disconnect();
                    }
                }
                return result;
            });
        }

        private String ReadString(System.IO.Stream stream, int len) 
        {
            StringBuilder responseString = new StringBuilder();
            BufferedReader bufferedReader = null;
            try
            {
                Java.IO.Reader reader = null;
                reader = new Java.IO.InputStreamReader(stream, "UTF-8");
                bufferedReader = new BufferedReader(reader);
                string line;
                while ((line = bufferedReader.ReadLine()) != null)
                {
                    responseString.Append(line);
                }
            }
            catch (Exception e)
            {
                _loggingSrevice.Log(string.Format("[DownlaodService] Exception while reading response  {0}", e.Message));
            }
            finally
            {
                if (bufferedReader != null)
                {
                    bufferedReader.Close();
                }
            }
            return (responseString.ToString().Length == 0)? null : responseString.ToString();
        }

}
}