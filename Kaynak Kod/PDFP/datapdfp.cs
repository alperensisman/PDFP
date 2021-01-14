using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programlamadillerifinal
{
    class datapdfp
    {
        public static string _LASTDATAJSON;
        public static ArrayList _LASTDATAOBJECT = new ArrayList();

        public static void DataKontrolVeYaOlustur(bool getir=true)
        {
            var dataFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Pdfp\data.pdfp");
            var dataOnlyFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pdfp");
            if(Directory.Exists(dataOnlyFolder))
            {
                if (File.Exists(dataFile))
                {
                    if(getir)
                    {
                        _LASTDATAJSON =SolveCyripto(File.ReadAllText(dataFile));
                        JsonToAllTez();
                    }
                }
                else
                {
                    FileStream fs = new FileStream(dataFile, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Close();
                }
            }
            else
            {
                Directory.CreateDirectory(dataOnlyFolder);
                FileStream fs = new FileStream(dataFile, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Close();
            }
        }
        public static string TezToJson(Tez GelenTez)
        {
            return JsonConvert.SerializeObject(GelenTez);
        }
        public static Tez JsonToTez(string GelenTezJson)
        {
            Tez tezMap = JsonConvert.DeserializeObject<Tez>(GelenTezJson);
            return tezMap;
        }
        public static void AllTezToJson()
        {
            Tez[] AllObject= new Tez[_LASTDATAOBJECT.Count];
            for (int i = 0; i < _LASTDATAOBJECT.Count; i++)
            {
                AllObject[i] = (Tez)_LASTDATAOBJECT[i];
            }
            _LASTDATAJSON=JsonConvert.SerializeObject(AllObject);
            UpdateFile();
        }
        public static void JsonToAllTez()
        {
            ArrayList Kontrol = JsonConvert.DeserializeObject<ArrayList>(_LASTDATAJSON);
            if (Kontrol == null)
                return;
            _LASTDATAOBJECT = new ArrayList();
            for (int i = 0; i < Kontrol.Count; i++)
            {
                _LASTDATAOBJECT.Add(JsonToTez(Kontrol[i].ToString()));
            }
        }
        public static void UpdateFile()
        {
            DataKontrolVeYaOlustur(false);
            var dataFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Pdfp\data.pdfp");
            File.Delete(dataFile);
            FileStream fs = new FileStream(dataFile, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(Cyripto(_LASTDATAJSON));
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static void cloudProjects(string folderPath)
        {
            string filePath = folderPath + @"\projects.pdfp";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            if (File.Exists(filePath))
                File.Delete(filePath);
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(Cyripto(_LASTDATAJSON));
            sw.Flush();
            sw.Close();
            fs.Close();
        }



        public static void CozumProjectsAdd(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json=File.ReadAllText(filePath);
                ArrayList Kontrol = JsonConvert.DeserializeObject<ArrayList>(SolveCyripto(json));
                if (Kontrol == null)
                    return;
                ArrayList _DATAOBJECT = new ArrayList();
                for (int i = 0; i < Kontrol.Count; i++)
                {
                    _DATAOBJECT.Add(JsonToTez(Kontrol[i].ToString()));
                }
                if(_LASTDATAOBJECT==null)
                {
                    _LASTDATAOBJECT = _DATAOBJECT;
                    AllTezToJson();
                    return;
                }
                else
                {
                    int oldCount = _LASTDATAOBJECT.Count;
                    for (int i = 0; i < _DATAOBJECT.Count; i++)
                    {
                        Tez tz0 = (Tez)_DATAOBJECT[i];
                        bool ekle = true;
                        for (int j = 0; j < _LASTDATAOBJECT.Count; j++)
                        {
                            Tez tz1 = (Tez)_LASTDATAOBJECT[j];
                            if ((tz0.projeTezIcerik == tz1.projeTezIcerik) && (tz0.projeAdi == tz1.projeAdi) && (tz0.tezSahibi == tz1.tezSahibi))
                            {
                                ekle = false;
                                break;
                            }
                        }
                        if (ekle)
                        {
                            _LASTDATAOBJECT.Add(tz0);
                        }
                    }
                    if (oldCount != _LASTDATAOBJECT.Count)
                    {
                        AllTezToJson();
                    }
                }
            }
        }

        internal static void RaporKaydet(string folderPath, Tez thisTez)
        {
            string filePath = folderPath + "\\"+ thisTez.projeAdi.Replace(" ","") +"_"+ thisTez.tezSahibi.Replace(" ", "") + ".txt";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            if (File.Exists(filePath))
                File.Delete(filePath);
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Flush();
            string[] raporParcala = thisTez.projeRaporlar.Split(new string[] { "&&" },StringSplitOptions.RemoveEmptyEntries);
            string[] istaParcala = thisTez.IstatistikselBilgiler.Split(new string[] { "&&" }, StringSplitOptions.RemoveEmptyEntries);
            sw.WriteLine("Raporlar");
            sw.WriteLine("");
            for (int i = 0; i < raporParcala.Length; i++)
            {
                sw.WriteLine(raporParcala[i]);
            }
            sw.WriteLine("");
            sw.WriteLine("-------------------------------");
            sw.WriteLine("");
            sw.WriteLine("İstatistiksel Bilgiler");
            sw.WriteLine("");
            for (int i = 0; i < istaParcala.Length; i++)
            {
                sw.WriteLine(istaParcala[i]);
            }
            sw.Close();
            fs.Close();
        }


        public static string Cyripto(string text)
        {
            int sifreXOR = 0;
            string sifreTxt = "Sayın Doç. Dr. Fatih ÖZKAYNAK a ithafen. Bu Şifreleme Zayıf Ama Güzel bir Şifreleme Yöntemi. Ayrıca Güçlü bir Stratejidir.";
            foreach (char c in sifreTxt.ToCharArray()) sifreXOR += (int)c;
            StringBuilder cyripto = new StringBuilder();
            foreach (char c in text.ToCharArray()) cyripto.Append((char)((int)c ^ sifreXOR));
            return cyripto.ToString();
        }
        public static string SolveCyripto(string cyriptoText)
        {
            int sifreXOR = 0;
            string sifreTxt = "Sayın Doç. Dr. Fatih ÖZKAYNAK a ithafen. Bu Şifreleme Zayıf Ama Güzel bir Şifreleme Yöntemi. Ayrıca Güçlü bir Stratejidir.";
            foreach (char c in sifreTxt.ToCharArray()) sifreXOR += (int)c;
            StringBuilder Solved = new StringBuilder();
            foreach (char c in cyriptoText.ToCharArray()) Solved.Append((char)((int)c ^ sifreXOR));
            return Solved.ToString();
        }




    }
}
