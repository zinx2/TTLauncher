using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TTLauncher.Editor.Models;
using TTLauncher.Infrastructure;

namespace TTLauncher.Editor.Services
{
    [Export(typeof(ITTSeriesDataService))]
    public class TTSeriesDataService : ITTSeriesDataService
    {
        private readonly List<TTSeries> seriesCollection;
        public TTSeriesDataService()
        {
            this.seriesCollection = new List<TTSeries>();
            for (int i = 0; i < 9; i++)
            {
                seriesCollection.Add(new TTSeries()
                {
                    Name = "시리즈0" + (i + 1).ToString(),
                    ThumbnailPath = "/TTLauncher.Editor;component/Resources/0" + (i + 1).ToString() + ".jpg",
                    IsSecret = i < 7 ? false : true,
                    //Child = new ObservableCollection<TTEpisodes>()
                });
            }
        }
        public IAsyncResult BeginGetDatas(AsyncCallback callback, object userState)
        {
            var asyncResult = new AsyncResult<IEnumerable<TTSeries>>(callback, userState);
            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    asyncResult.SetComplete(new ReadOnlyCollection<TTSeries>(this.seriesCollection), false);
                });

            return asyncResult;
        }

        public IEnumerable<TTSeries> EndGetDatas(IAsyncResult asyncResult)
        {
            var localAsyncResult = AsyncResult<IEnumerable<TTSeries>>.End(asyncResult);

            return localAsyncResult.Result;
        }

        public TTSeries GetSeries(Guid id)
        {
            return this.seriesCollection.FirstOrDefault(e => e.Id == id);
        }
    }
}
