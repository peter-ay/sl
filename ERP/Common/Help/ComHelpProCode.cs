using System.Collections.ObjectModel;
using System.Windows.Controls;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpProCode
    {
        private static ObservableCollection<V_U_ProcessClass> _UHV_B_Material_ProcessClass = new ObservableCollection<V_U_ProcessClass>();
        public static ObservableCollection<V_U_ProcessClass> UHV_B_Material_ProcessClass
        {
            get
            {
                return _UHV_B_Material_ProcessClass;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UHV_B_Material_Process = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UHV_B_Material_Process
        {
            get
            {
                return _UHV_B_Material_Process;
            }
        }

        public static void Load()
        {
            Load1();
            Load2();
        }

        private static void Load2()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Man, "GetV_U_ProcessClassAllListQuery", ddsProClass_LoadedData);
            dds.Load();
        }

        static void ddsProClass_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_ProcessClass.Clear();
            foreach (V_U_ProcessClass t in e.Entities)
            {
                _UHV_B_Material_ProcessClass.Add(t);
            }
        }

        private static void Load1()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_ProcessHelpListQuery", dds_LoadedData, true);
            dds.Load();
        }

        static void dds_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_Process.Clear();
            foreach (V_B_Material_Process t in e.Entities)
            {
                _UHV_B_Material_Process.Add(t);
            }
            ResetProCode();
        }


        private static void ResetProCode()
        {
            ReSetMianWan();
            ReSetChaSe();
            ReSetJuSe();
            ReSetZuanKong();
            ReSetCheBian();
            ReSetPiHua();
            ReSetKaiKeng();
            ReSetOtherProcess();
            ReSetRanSe();
            ReSetRanseName();
            ReSetShuiYin();
            ReSetPaoGuang();
            ReSetJingJia();
            ReSetCaiBian();
        }

        private static void ReSetCaiBian()
        {
            _UV_B_ProcessCaiBian.Clear();
            _UV_B_ProcessCaiBian_CF.Clear();
            _UV_B_ProcessCaiBian_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.CaiBian)
                {
                    _UV_B_ProcessCaiBian.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessCaiBian_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessCaiBian_CF.Add(item);
                }
            }
        }

        private static void ReSetJingJia()
        {
            _UV_B_ProcessJingJia.Clear();
            _UV_B_ProcessJingJia_CF.Clear();
            _UV_B_ProcessJingJia_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.JingJia)
                {
                    _UV_B_ProcessJingJia.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessJingJia_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessJingJia_CF.Add(item);
                }
            }
        }

        private static void ReSetPaoGuang()
        {
            _UV_B_ProcessPaoGuang.Clear();
            _UV_B_ProcessPaoGuang_CF.Clear();
            _UV_B_ProcessPaoGuang_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.PaoGuang)
                {
                    _UV_B_ProcessPaoGuang.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessPaoGuang_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessPaoGuang_CF.Add(item);
                }
            }
        }

        private static void ReSetShuiYin()
        {
            _UV_B_ProcessShuiYin.Clear();
            _UV_B_ProcessShuiYin_CF.Clear();
            _UV_B_ProcessShuiYin_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.ShuiYin)
                {
                    _UV_B_ProcessShuiYin.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessShuiYin_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessShuiYin_CF.Add(item);
                }
            }
        }

        private static void ReSetRanseName()
        {
            _UV_B_ProcessRanSeName.Clear();
            _UV_B_ProcessRanSeName_CF.Clear();
            _UV_B_ProcessRanSeName_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.RanSeName)
                {
                    _UV_B_ProcessRanSeName.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessRanSeName_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessRanSeName_CF.Add(item);
                }
            }
        }

        private static void ReSetRanSe()
        {
            _UV_B_ProcessRanSe.Clear();
            _UV_B_ProcessRanSe_CF.Clear();
            _UV_B_ProcessRanSe_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.RanSe)
                {
                    _UV_B_ProcessRanSe.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessRanSe_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessRanSe_CF.Add(item);
                }
            }
        }

        private static void ReSetOtherProcess()
        {
            _UV_B_ProcessOtherProcess.Clear();
            _UV_B_ProcessOtherProcess_CF.Clear();
            _UV_B_ProcessOtherProcess_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.OtherProcess)
                {
                    _UV_B_ProcessOtherProcess.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessOtherProcess_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessOtherProcess_CF.Add(item);
                }
            }
        }

        private static void ReSetKaiKeng()
        {
            _UV_B_ProcessKaiKeng.Clear();
            _UV_B_ProcessKaiKeng_CF.Clear();
            _UV_B_ProcessKaiKeng_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.KaiKeng)
                {
                    _UV_B_ProcessKaiKeng.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessKaiKeng_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessKaiKeng_CF.Add(item);
                }
            }
        }

        private static void ReSetPiHua()
        {
            _UV_B_ProcessPiHua.Clear();
            _UV_B_ProcessPiHua_CF.Clear();
            _UV_B_ProcessPiHua_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.PiHua)
                {
                    _UV_B_ProcessPiHua.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessPiHua_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessPiHua_CF.Add(item);
                }
            }
        }

        private static void ReSetCheBian()
        {
            _UV_B_ProcessCheBian.Clear();
            _UV_B_ProcessCheBian_CF.Clear();
            _UV_B_ProcessCheBian_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.CheBian)
                {
                    _UV_B_ProcessCheBian.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessCheBian_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessCheBian_CF.Add(item);
                }
            }
        }

        private static void ReSetZuanKong()
        {
            _UV_B_ProcessZuanKong.Clear();
            _UV_B_ProcessZuanKong_CF.Clear();
            _UV_B_ProcessZuanKong_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.ZuanKong)
                {
                    _UV_B_ProcessZuanKong.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessZuanKong_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessZuanKong_CF.Add(item);
                }
            }
        }

        private static void ReSetJuSe()
        {
            _UV_B_ProcessJuSe.Clear();
            _UV_B_ProcessJuSe_CF.Clear();
            _UV_B_ProcessJuSe_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.JuSe)
                {
                    _UV_B_ProcessJuSe.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessJuSe_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessJuSe_CF.Add(item);
                }
            }
        }

        private static void ReSetChaSe()
        {
            _UV_B_ProcessChaSe.Clear();
            _UV_B_ProcessChaSe_CF.Clear();
            _UV_B_ProcessChaSe_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.ChaSe)
                {
                    _UV_B_ProcessChaSe.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessChaSe_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessChaSe_CF.Add(item);
                }
            }
        }

        private static void ReSetMianWan()
        {
            _UV_B_ProcessMianWan.Clear();
            _UV_B_ProcessMianWan_CF.Clear();
            _UV_B_ProcessMianWan_KF.Clear();
            foreach (var item in UHV_B_Material_Process)
            {
                if (item.ProClass.ToUpper().Trim() == ComProCodeKey.MianWan)
                {
                    _UV_B_ProcessMianWan.Add(item);
                    if (item.F_ST == true)
                        _UV_B_ProcessMianWan_KF.Add(item);
                    if (item.F_RX == true)
                        _UV_B_ProcessMianWan_CF.Add(item);
                }
            }
        }

        #region MianWan
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessMianWan = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessMianWan
        {
            get
            {
                return _UV_B_ProcessMianWan;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessMianWan_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessMianWan_CF
        {
            get
            {
                return _UV_B_ProcessMianWan_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessMianWan_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessMianWan_KF
        {
            get
            {
                return _UV_B_ProcessMianWan_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region ChaSe
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessChaSe = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessChaSe
        {
            get
            {
                return _UV_B_ProcessChaSe;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessChaSe_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessChaSe_CF
        {
            get
            {
                return _UV_B_ProcessChaSe_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessChaSe_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessChaSe_KF
        {
            get
            {
                return _UV_B_ProcessChaSe_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region JuSe
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessJuSe = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessJuSe
        {
            get
            {
                return _UV_B_ProcessJuSe;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessJuSe_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessJuSe_CF
        {
            get
            {
                return _UV_B_ProcessJuSe_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessJuSe_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessJuSe_KF
        {
            get
            {
                return _UV_B_ProcessJuSe_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region ZuanKong
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessZuanKong = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessZuanKong
        {
            get
            {
                return _UV_B_ProcessZuanKong;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessZuanKong_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessZuanKong_CF
        {
            get
            {
                return _UV_B_ProcessZuanKong_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessZuanKong_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessZuanKong_KF
        {
            get
            {
                return _UV_B_ProcessZuanKong_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region CheBian
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessCheBian = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessCheBian
        {
            get
            {
                return _UV_B_ProcessCheBian;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessCheBian_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessCheBian_CF
        {
            get
            {
                return _UV_B_ProcessCheBian_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessCheBian_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessCheBian_KF
        {
            get
            {
                return _UV_B_ProcessCheBian_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region PiHua
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessPiHua = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessPiHua
        {
            get
            {
                return _UV_B_ProcessPiHua;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessPiHua_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessPiHua_CF
        {
            get
            {
                return _UV_B_ProcessPiHua_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessPiHua_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessPiHua_KF
        {
            get
            {
                return _UV_B_ProcessPiHua_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region KaiKeng
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessKaiKeng = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessKaiKeng
        {
            get
            {
                return _UV_B_ProcessKaiKeng;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessKaiKeng_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessKaiKeng_CF
        {
            get
            {
                return _UV_B_ProcessKaiKeng_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessKaiKeng_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessKaiKeng_KF
        {
            get
            {
                return _UV_B_ProcessKaiKeng_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region OtherProcess
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessOtherProcess = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessOtherProcess
        {
            get
            {
                return _UV_B_ProcessOtherProcess;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessOtherProcess_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessOtherProcess_CF
        {
            get
            {
                return _UV_B_ProcessOtherProcess_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessOtherProcess_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessOtherProcess_KF
        {
            get
            {
                return _UV_B_ProcessOtherProcess_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region RanSe
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessRanSe = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessRanSe
        {
            get
            {
                return _UV_B_ProcessRanSe;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessRanSe_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessRanSe_CF
        {
            get
            {
                return _UV_B_ProcessRanSe_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessRanSe_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessRanSe_KF
        {
            get
            {
                return _UV_B_ProcessRanSe_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region RanSeName
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessRanSeName = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessRanSeName
        {
            get
            {
                return _UV_B_ProcessRanSeName;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessRanSeName_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessRanSeName_CF
        {
            get
            {
                return _UV_B_ProcessRanSeName_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessRanSeName_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessRanSeName_KF
        {
            get
            {
                return _UV_B_ProcessRanSeName_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region ShuiYin
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessShuiYin = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessShuiYin
        {
            get
            {
                return _UV_B_ProcessShuiYin;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessShuiYin_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessShuiYin_CF
        {
            get
            {
                return _UV_B_ProcessShuiYin_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessShuiYin_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessShuiYin_KF
        {
            get
            {
                return _UV_B_ProcessShuiYin_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region PaoGuang
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessPaoGuang = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessPaoGuang
        {
            get
            {
                return _UV_B_ProcessPaoGuang;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessPaoGuang_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessPaoGuang_CF
        {
            get
            {
                return _UV_B_ProcessPaoGuang_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessPaoGuang_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessPaoGuang_KF
        {
            get
            {
                return _UV_B_ProcessPaoGuang_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region JingJia
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessJingJia = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessJingJia
        {
            get
            {
                return _UV_B_ProcessJingJia;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessJingJia_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessJingJia_CF
        {
            get
            {
                return _UV_B_ProcessJingJia_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessJingJia_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessJingJia_KF
        {
            get
            {
                return _UV_B_ProcessJingJia_KF;
            }
        }
        #endregion
        /////////////////////////////////
        #region CaiBian
        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessCaiBian = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessCaiBian
        {
            get
            {
                return _UV_B_ProcessCaiBian;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessCaiBian_CF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessCaiBian_CF
        {
            get
            {
                return _UV_B_ProcessCaiBian_CF;
            }
        }

        private static ObservableCollection<V_B_Material_Process> _UV_B_ProcessCaiBian_KF = new ObservableCollection<V_B_Material_Process>();
        public static ObservableCollection<V_B_Material_Process> UV_B_ProcessCaiBian_KF
        {
            get
            {
                return _UV_B_ProcessCaiBian_KF;
            }
        }
        #endregion
    }
}
