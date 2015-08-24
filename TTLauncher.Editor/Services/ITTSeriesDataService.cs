using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTLauncher.Editor.Models;

namespace TTLauncher.Editor.Services
{
    public interface ITTSeriesDataService
    {
        //TTSeriesCollection GetSeriesCollection();
        IAsyncResult BeginGetDatas(AsyncCallback callback, object userState);
        IEnumerable<TTSeries> EndGetDatas(IAsyncResult result);
        TTSeries GetSeries(Guid id);
    }
}
