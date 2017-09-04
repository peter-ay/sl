using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;
using ERP.Utility;

namespace ERP.Common
{
    public class ComDDsInfo
    {

        DomainContext domaincontext;

        public DomainContext Domaincontext
        {
            get { return domaincontext; }
            set { domaincontext = value; }
        }

        int pageSize = 1;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        string queryName;

        public string QueryName
        {
            get { return queryName; }
            set { queryName = value; }
        }

        private string _defaultsortkey;

        public string DefaultSortKey
        {
            get { return _defaultsortkey; }
            set { _defaultsortkey = value; }
        }

        private string _DefaultIDCode;

        public string DefaultIDCode
        {
            get { return _DefaultIDCode; }
            set { _DefaultIDCode = value; }
        }

        private string _DefaultKeyCode;

        public string DefaultKeyCode
        {
            get { return _DefaultKeyCode; }
            set { _DefaultKeyCode = value; }
        }

        private string _DefaultKeyName;

        public string DefaultKeyName
        {
            get { return _DefaultKeyName; }
            set { _DefaultKeyName = value; }
        }

        private List<ComFilters> filters = new List<ComFilters>();

        public List<ComFilters> Filters
        {
            get { return filters; }
            set { filters = value; }
        }

        private List<ComSorts> sorts = new List<ComSorts>();

        public List<ComSorts> Sorts
        {
            get { return sorts; }
            set { sorts = value; }
        }

        private List<ComGroups> _Groups = new List<ComGroups>();

        public List<ComGroups> Groups
        {
            get { return _Groups; }
            set { _Groups = value; }
        }

        private List<ComParameters> parameters = new List<ComParameters>();

        public List<ComParameters> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        private bool isAutoLoad = false;

        public bool IsAutoLoad
        {
            get { return isAutoLoad; }
            set { isAutoLoad = value; }
        }

        public ComDDsInfo()
        {

        }

        public void AddDefaultFilters(string idCode, string sidCode)
        {
            this.Filters.Add(new ComFilters() { PropertyPath = idCode, FilterOperator = FilterOperator.IsEqualTo, Value = sidCode, IgnoredValue = "999" });
        }

        public void AddDefaultFiltersNext(string idCode, string sidCode)
        {
            this.Filters.Add(new ComFilters() { PropertyPath = idCode, FilterOperator = FilterOperator.IsGreaterThan, Value = sidCode, IgnoredValue = "999" });
        }

        public void AddDefaultFiltersPrevious(string idCode, string sidCode)
        {
            this.Filters.Add(new ComFilters() { PropertyPath = idCode, FilterOperator = FilterOperator.IsLessThan, Value = sidCode, IgnoredValue = "999" });
        }

        public void AddDefaultParameters(string keyCode, string skeyCode)
        {
            if (!string.IsNullOrEmpty(keyCode))
                this.Parameters.Add(new ComParameters() { ParameterName = keyCode, Value = skeyCode.MyStr() });
        }

        public void AddDefaultParameters(string keyCode, string skeyCode, string _keyname, string _skeyname)
        {
            string sWhere = "";
            //if (!string.IsNullOrEmpty(keyCode))
            //    this.Parameters.Add(new ComParameters() { ParameterName = keyCode, Value = skeyCode.MyStr() });
            //if (!string.IsNullOrEmpty(_keyname))
            //    this.Parameters.Add(new ComParameters() { ParameterName = _keyname, Value = _skeyname.MyStr() });
            this.Parameters.Add(new ComParameters() { ParameterName = "sWhere", Value = sWhere });
        }

        public void AddDefaultSorts(string skeyCode, bool isDsc = false)
        {
            if (isDsc)
                this.Sorts.Add(new ComSorts() { PropertyPath = skeyCode, SortDirection = ListSortDirection.Descending });
            else
                this.Sorts.Add(new ComSorts() { PropertyPath = skeyCode, SortDirection = ListSortDirection.Ascending });
        }

        public void AddGroups(string sKeyCode)
        {
            this.Groups.Add(new ComGroups() { PropertyPath = sKeyCode });
        }

        public void ClearDefault()
        {
            this.Filters.Clear();
            this.Sorts.Clear();
            this.Groups.Clear();
            this.Parameters.Clear();
        }

    }

    public class ComFilters
    {
        public string PropertyPath
        {
            get;
            set;
        }
        public FilterOperator FilterOperator
        {
            get;
            set;
        }
        public Object Value
        {
            get;
            set;
        }

        public string IgnoredValue
        {
            get;
            set;
        }
    }

    public class ComSorts
    {
        public string PropertyPath
        {
            get;
            set;
        }
        public ListSortDirection SortDirection
        {
            get;
            set;
        }
    }

    public class ComParameters
    {
        public string ParameterName
        {
            get;
            set;
        }
        public Object Value
        {
            get;
            set;
        }
    }

    public class ComGroups
    {
        public string PropertyPath
        {
            get;
            set;
        }
    }

}
