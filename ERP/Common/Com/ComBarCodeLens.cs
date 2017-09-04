using ERP.Utility;
using ERP.View;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace ERP.Common
{
    public class ComBarCodeLens
    {
        public static ComBarCodeLensInfo GetLensInfoFromBarCode(string lensCodeInfo)
        {
            ComBarCodeLensInfo _Rs = new ComBarCodeLensInfo();
            string _LensCodeInfo = lensCodeInfo;
            if (string.IsNullOrEmpty(_LensCodeInfo))
                return null;
            string _LensCode = "";
            int s1 = _LensCodeInfo.IndexOf('+');
            int s2 = _LensCodeInfo.IndexOf('-');
            int _SPH = 0; int _CYL = 0; int _X_ADD = 0;
            try
            {
                if (s1 == -1)//-100-100
                {
                    _LensCode = _LensCodeInfo.Substring(0, s2).Trim();
                    _LensCodeInfo = _LensCodeInfo.Substring(s2 + 1);
                    _SPH = -1 * Convert.ToInt32(_LensCodeInfo.Substring(0, _LensCodeInfo.IndexOf('-')));
                    _LensCodeInfo = _LensCodeInfo.Substring(_LensCodeInfo.IndexOf('-') + 1);
                    _CYL = -1 * Convert.ToInt32(_LensCodeInfo);
                    _X_ADD = 0;
                    goto Branch;
                }
                if (s2 == -1)//+100+100
                {
                    _LensCode = _LensCodeInfo.Substring(0, s1).Trim();
                    _LensCodeInfo = _LensCodeInfo.Substring(s1 + 1);
                    _SPH = Convert.ToInt32(_LensCodeInfo.Substring(0, _LensCodeInfo.IndexOf('+')));
                    _LensCodeInfo = _LensCodeInfo.Substring(_LensCodeInfo.IndexOf('+') + 1);
                    _CYL = 0;
                    _X_ADD = Convert.ToInt32(_LensCodeInfo);
                    goto Branch;
                }
                if (s1 < s2)//+100-100
                {
                    _LensCode = _LensCodeInfo.Substring(0, s1).Trim();
                    _LensCodeInfo = _LensCodeInfo.Substring(s1 + 1);
                    _SPH = Convert.ToInt32(_LensCodeInfo.Substring(0, _LensCodeInfo.IndexOf('-')));
                    _LensCodeInfo = _LensCodeInfo.Substring(_LensCodeInfo.IndexOf('-') + 1);
                    _CYL = -1 * Convert.ToInt32(_LensCodeInfo);
                    _X_ADD = 0;
                    goto Branch;
                }
                if (s1 > s2)//-100+100
                {
                    _LensCode = _LensCodeInfo.Substring(0, s2).Trim();
                    _LensCodeInfo = _LensCodeInfo.Substring(s2 + 1);
                    _SPH = -1 * Convert.ToInt32(_LensCodeInfo.Substring(0, _LensCodeInfo.IndexOf('+')));
                    _LensCodeInfo = _LensCodeInfo.Substring(_LensCodeInfo.IndexOf('+') + 1);
                    _CYL = 0;
                    _X_ADD = Convert.ToInt32(_LensCodeInfo);
                    goto Branch;
                }
            }
            catch
            {
                MessageErp.ErrorMessage(ErpUIText.Get("ERP_ErrComBarCodeLens_Invalid"));
                return null;
            }

        Branch:
            _Rs.LensCode = _LensCode;
            _Rs.SPH = _SPH;
            _Rs.CYL = _CYL;
            _Rs.X_ADD = _X_ADD;
            _Rs.F_LR = "";
            return _Rs;
        }
    }

    public class ComBarCodeLensInfo
    {
        public string LensCode
        {
            get;
            set;
        }

        public int SPH
        {
            get;
            set;
        }

        public int CYL
        {
            get;
            set;
        }

        public int X_ADD
        {
            get;
            set;
        }

        public string F_LR
        {
            get;
            set;
        }
    }
}
