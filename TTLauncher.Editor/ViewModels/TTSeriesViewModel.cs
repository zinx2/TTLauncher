using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Data;
using TTLauncher.Editor.Models;
using TTLauncher.Editor.Services;

namespace TTLauncher.Editor.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TTSeriesViewModel : BindableBase
    {
        private readonly ITTSeriesDataService seriesDataService;
        private readonly SynchronizationContext synchronizationContext;
        private readonly IRegionManager regionManager;
        private ObservableCollection<TTSeries> seriesCollection;

        private const string SeriesIdKey = "SeriesId";

        [ImportingConstructor]
        public TTSeriesViewModel(ITTSeriesDataService dataService, IRegionManager regionManager)
        {
            this.synchronizationContext = SynchronizationContext.Current ?? new SynchronizationContext();
            this.seriesCollection = new ObservableCollection<TTSeries>();
            this.Series = new ListCollectionView(this.seriesCollection);
            this.regionManager = regionManager;
            this.seriesDataService = dataService;

            this.seriesDataService.BeginGetDatas(
                r =>
                {
                    var series_collection = this.seriesDataService.EndGetDatas(r);

                    this.synchronizationContext.Post(
                        s =>
                        {
                            foreach (var series in series_collection)
                            {
                                this.seriesCollection.Add(series);
                            }
                        },
                        null);
                },
                null);
        }
        public ICollectionView Series { get; private set; }

    }
}
