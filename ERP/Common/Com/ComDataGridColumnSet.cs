using ERP.Utility;
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows.Controls;
using System.Xml.Linq;

namespace ERP.Common
{
    public class ComDataGridColumnSet
    {
        public static void WriteDataGridColumnInfo(string dgName, DataGrid dg, string ShowPreviewType = "")
        {
            string userConfigPath = System.IO.Path.Combine("ERP20_DataGrid", USysInfo.DBCode + USysInfo.UserCode + dgName + ComLanguageResourceManage.CurrentCulture.Name + "DataGridInfo.xml");
            try
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (store.FileExists(userConfigPath))
                    {
                        store.DeleteFile(userConfigPath);
                    }
                }

                try
                {
                    using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (!isoStore.FileExists(userConfigPath))
                        {
                            if (!isoStore.DirectoryExists("ERP20_DataGrid"))
                            {
                                isoStore.CreateDirectory("ERP20_DataGrid");
                            }
                            XElement dataGridsElement = new XElement("dataGrids");
                            XElement dataGridElement = new XElement("dataGrid");

                            dataGridElement.Add(new XAttribute("ShowPreviewType", ShowPreviewType));
                            foreach (var g in dg.Columns)
                            {
                                try
                                {
                                    dataGridElement.Add(new XAttribute(g.Header.ToString().Trim().Replace("(", "").Replace(")", ""), g.DisplayIndex.ToString()));
                                }
                                catch { }
                            }
                            dataGridsElement.Add(dataGridElement);
                            XDocument doc = new XDocument(dataGridsElement);
                            using (IsolatedStorageFileStream isoStream =
                                new IsolatedStorageFileStream(userConfigPath, FileMode.OpenOrCreate,
                                                                FileAccess.Write,
                                                                isoStore))
                            {
                                doc.Save(isoStream);
                                isoStream.Flush();
                            }
                        }
                    }
                }

                catch { }

            }
            catch { }
        }

        public static void ReadDataGridColumnInfo(string dgName, DataGrid dg, out string spt)
        {
            string userConfigPath = System.IO.Path.Combine("ERP20_DataGrid", USysInfo.DBCode + USysInfo.UserCode + dgName + ComLanguageResourceManage.CurrentCulture.Name + "DataGridInfo.xml");
            XDocument xDoc;
            spt = "3";
            try
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (!isoStore.FileExists(userConfigPath))
                    {
                        return;
                    }

                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(userConfigPath, FileMode.OpenOrCreate, FileAccess.Read, isoStore))
                    {
                        xDoc = XDocument.Load(isoStream);
                    }
                    var ShowPreviewType = (from c in xDoc.Descendants("dataGrid")
                                           select c.Attribute("ShowPreviewType").Value).FirstOrDefault();
                    if (ShowPreviewType != null)
                    {
                        spt = ShowPreviewType;
                    }

                    foreach (var g in dg.Columns)
                    {
                        if (g.Header == null)
                            continue;
                        var dgTemp = from c in xDoc.Descendants("dataGrid")
                                     select c.Attribute(g.Header.ToString().Trim().Replace("(", "").Replace(")", "")).Value;
                        g.DisplayIndex = Convert.ToInt32(dgTemp.First());
                    }
                }
            }

            catch
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (store.FileExists(userConfigPath))
                    {
                        store.DeleteFile(userConfigPath);
                    }
                }
            }
        }
    }
}
