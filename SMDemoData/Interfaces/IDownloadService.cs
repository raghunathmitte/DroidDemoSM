using System;
using System.Threading.Tasks;

namespace SMDemoData
{
	public interface IDownloadService
	{
		object DownLoadVideo(string fileUrl);
        Task<string> GetData(string fileUrl);
	}
}

