using System;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;
using ERP.Utility;

namespace ERP.Common
{
    public class ComDDSFactory
    {
        public static DomainDataSource Get(DomainContext domainContext, string queryName, Action<object, LoadedDataEventArgs> loaded, bool isAddDbCode = false)
        {
            DomainDataSource dds = new DomainDataSource();
            dds.AutoLoad = false;
            dds.DomainContext = domainContext;
            dds.QueryName = queryName;
            dds.PageSize = 0;
            dds.RefreshInterval = new System.TimeSpan(1, 0, 0, 0, 0);
            dds.LoadDelay = new System.TimeSpan(1, 0, 0, 0, 0);
            dds.LoadInterval = new System.TimeSpan(1, 0, 0, 0, 0);
            dds.LoadingData += (s, e) => { e.LoadBehavior = LoadBehavior.RefreshCurrent; };
            dds.LoadedData += new EventHandler<LoadedDataEventArgs>(loaded);
            if (isAddDbCode)
                dds.QueryParameters.Add(new Parameter() { ParameterName = "dbCode", Value = USysInfo.DBCode });
            return dds;
        }

        public static DomainDataSource Get(ComDDsInfo dds, Action<object, LoadingDataEventArgs> loading, Action<object, LoadedDataEventArgs> loaded)
        {
            DomainDataSource _dds = new DomainDataSource();
            _dds.AutoLoad = dds.IsAutoLoad;
            _dds.DomainContext = dds.Domaincontext;
            _dds.QueryName = dds.QueryName;
            _dds.PageSize = dds.PageSize;

            dds.Parameters.ForEach(item =>
            {
                _dds.QueryParameters.Add
                    (new Parameter() { ParameterName = item.ParameterName, Value = item.Value });
            });

            dds.Filters.ForEach(item =>
                {
                    _dds.FilterDescriptors.Add
                        (
                             new FilterDescriptor() { PropertyPath = item.PropertyPath, Operator = item.FilterOperator, Value = item.Value, IgnoredValue = item.IgnoredValue }
                        );
                });

            dds.Sorts.ForEach(item => { _dds.SortDescriptors.Add(new SortDescriptor(item.PropertyPath, item.SortDirection)); });

            dds.Groups.ForEach(item => { _dds.GroupDescriptors.Add(new GroupDescriptor(item.PropertyPath)); });

            if (loading == null)
            {
                _dds.LoadingData += (s, e) => { e.LoadBehavior = LoadBehavior.RefreshCurrent; };
            }
            else
                _dds.LoadingData += new EventHandler<LoadingDataEventArgs>(loading);

            _dds.LoadedData += new EventHandler<LoadedDataEventArgs>(loaded);
            _dds.RefreshInterval = new System.TimeSpan(1, 0, 0, 0, 0);
            _dds.LoadDelay = new System.TimeSpan(1, 0, 0, 0, 0);
            _dds.LoadInterval = new System.TimeSpan(1, 0, 0, 0, 0);
            return _dds;
        }
    }
}
