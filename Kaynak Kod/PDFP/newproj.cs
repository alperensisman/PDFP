using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace programlamadillerifinal
{
    class newproj
    {
        Tez thisTez;
        ArrayList istatistikselBilgiler = new ArrayList();
        ArrayList Raporlar = new ArrayList();
        ArrayList Kaynaklar = new ArrayList();
        ArrayList Sekiller = new ArrayList();
        ArrayList Icindekiler = new ArrayList();
        ArrayList Tablolar = new ArrayList();
        ArrayList paragrafListesi = new ArrayList();
        ArrayList duzenliIcerikSayfalari = new ArrayList();
        ArrayList sayfalardaKaynakAtiflari = new ArrayList();
        Regex denklem1 = new Regex(@"\([1-9]\.[0-9]\)");
        Regex denklem2 = new Regex(@"\([1-9][0-9]\.[0-9]\)");
        Regex denklem3 = new Regex(@"\([1-9]\.[1-9][0-9]\)");
        Regex denklem4 = new Regex(@"\([1-9][0-9]\.[1-9][0-9]\)");
        string[] romanRakam = new string[] { "i", "ii", "iii", "iv", "v", "vi", "vii", "viii", "ix", "x", "xi", "xii", "xiii", "xiv", "xv", "xvi", "xvii", "xviii", "xix", "xx" };
        string[] sayfalar;
        string[] BasliklarListesi;
        string[] aylar = { "ocak", "şubat", "mart", "nisan", "mayıs", "haziran", "temmuz", "ağustos", "eylül", "ekim", "kasım", "aralık" };
        int IcerikStartIndex = -1;
        int IcerikEndIndex = -1;
        int satirBaslariBosluk = 0;
        int normalBosluk = 0;
        bool firstMove = true;

        public void RunIt(ref Tez tez,ref int progressPercent,ref string progressText)
        {
            thisTez = tez;
            BolumSayfalar(ref progressPercent, ref progressText);
            if (firstMove)
            {
                BolumKaynaklar(ref progressPercent, ref progressText);
                BolumSekiller(ref progressPercent, ref progressText);
                BolumTablolar(ref progressPercent, ref progressText);
                //
                progressText = "Çift Tırnak Arasındaki Kelime Adetleri Kontrol Ediliyor...";
                ÇiftTirnakKelimeAdedi();
                progressPercent += 10;
                IcerikBasliklari();
                progressText = "Paragraflardaki Satir Sayıları Adetleri Kontrol Ediliyor...";
                IkiSatirdanAzParagraf();
                progressPercent += 10;
                progressText = "Anahtar Kelimeler Kontrol Ediliyor...";
                EnFazla5AnahtarKelimeKurali();
                progressPercent += 10;
                progressText = "Önsöz Bölümü Kontrol Ediliyor...";
                OnsozKontrolu();
                progressPercent += 10;
                progressText = "İçindekiler Bölümü Kontrol Ediliyor...";
                IcindekilerKontrolu();
                progressPercent += 10;
                progressText = "Denklem Numaraları Kontrol Ediliyor...";
                DenklemNumaralari();
                progressPercent += 10;
            }
            progressText = "Sonuçlar Listeleniyor...";
            RaporlariInjectEt();
            IstatistikInjectEt();
            progressPercent += 10;
        }


        void RaporlariInjectEt()
        {
            string[] InjectedRapor = new string[Raporlar.Count];
            for (int i = 0; i < Raporlar.Count; i++)
            {
                InjectedRapor[i] = Raporlar[i].ToString();
            }
            thisTez.projeRaporlar = string.Join("&&", InjectedRapor);
        }
        void IstatistikInjectEt()
        {
            string[] InjectedIstatistik = new string[istatistikselBilgiler.Count];
            for (int i = 0; i < istatistikselBilgiler.Count; i++)
            {
                InjectedIstatistik[i] = istatistikselBilgiler[i].ToString();
            }
            thisTez.IstatistikselBilgiler = string.Join("&&", InjectedIstatistik);
        }
        void DenklemNumaralari()
        {
            int denklemSay = 0;
            for (int i = 0; i < duzenliIcerikSayfalari.Count; i++)
            {
                string sayfa = duzenliIcerikSayfalari[i].ToString();
                if (sayfa.Trim() == "") continue;
                if (!DenklemRegexle(sayfa))
                {
                    string[] sayfaSatirlar = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < sayfaSatirlar.Length; j++)
                    {
                        string satir = string.Join(" ", sayfaSatirlar[j].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                        for (int k = 0; k < satir.Length; k++)
                        {
                            int baslangic = satir.Substring(k).IndexOf("(");
                            if (baslangic > -1)
                            {
                                baslangic = k + baslangic;
                                int son = satir.Substring(baslangic).IndexOf(")");
                                if (son > -1)
                                {
                                    string aralik = satir.Substring(baslangic, son + 1);
                                    if (aralik.Length > 7) continue;
                                    if (!DenklemRegexle(aralik))
                                    {
                                        k = satir.Length;
                                        string bolumNumarasi = bolumNumarasiBul(i, j);
                                        string denklemNumara = aralik.Substring(1, 1);
                                        if (bolumNumarasi != denklemNumara)
                                        {
                                            Raporlar.Add((i + 1) + " Numaralı Sayfada; " + aralik + " Numaralı Denklem Bölüm Başlıkları İle Uyuşmuyor.");
                                        }
                                        denklemSay++;
                                    }
                                }
                                k = baslangic;
                            }
                        }
                    }
                }
            }
            if(denklemSay>0)
            {
                istatistikselBilgiler.Add("Toplamda " + denklemSay + " Adet Denklem Bulundu.");
            }
        }
        string bolumNumarasiBul(int ii, int jj)
        {
           
            string bolumNumarasi = "";
            for (int i = ii; i >= 0; i--)
            {
                string sayfa = duzenliIcerikSayfalari[i].ToString();
                if (sayfa.Trim() == "") continue;
                string[] sayfaSatirlar = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (i != ii) jj = 0;
                for (int j = jj; j >= 0; j--)
                {
                    string satir = string.Join(" ", sayfaSatirlar[j].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    if (Array.IndexOf(BasliklarListesi, satir) > -1)
                    {
                        bolumNumarasi = satir;
                    }
                }
                if (bolumNumarasi != "") break;
            }
            if (bolumNumarasi != "")
            {
                bolumNumarasi = bolumNumarasi.Trim().Substring(0, 1);
            }
            else
            {
                bolumNumarasi = "-1";
            }
            return bolumNumarasi;
        }
        void IcindekilerKontrolu()
        {
            bool icindekilerBolumu = false;
            string icindekilerText = "";
            for (int i = 0; i < sayfalar.Length; i++)
            {
                if (sayfalar[i].Trim() == "") continue;
                string[] sayfaBasligiBul = sayfalar[i].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string baslik = sayfaBasligiBul[0].Trim().ToLower();
                if (icindekilerBolumu)
                {
                    if (baslik == "özet" || baslik == "abstract")
                    {
                        break;
                    }
                    else
                    {
                        icindekilerText += " " + sayfalar[i];
                    }
                }
                else
                {
                    if (baslik == "içindekiler")
                    {
                        icindekilerBolumu = true;
                        icindekilerText += " " + sayfalar[i];
                    }
                }
            }
            if (icindekilerText.Trim() == "")
            {
                Raporlar.Add("İçindekiler Bölümü Bulunamadı");
                return;
            }


            string[] icindekilerSatirlari = icindekilerText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 2; i < icindekilerSatirlari.Length - 1; i++)
            {
                string satir = icindekilerSatirlari[i].Trim().ToLower();
                if (Array.IndexOf(romanRakam, satir) > -1 || IsNumeric(satir)) continue; 
                string[] parcala = satir.Split(new string[] { "..." }, StringSplitOptions.RemoveEmptyEntries);
                string duzenliIfade = "";
                for (int j = 0; j < parcala.Length; j++)
                {
                    if (j == parcala.Length - 1)
                    {
                        duzenliIfade += parcala[j].Replace(".", "").Trim();
                    }
                    else
                    {
                        duzenliIfade += string.Join(" ", parcala[j].Replace("\r\n", "").Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)) + "|";
                    }
                }
                Icindekiler.Add(duzenliIfade);
            }

            for (int i = 0; i < Icindekiler.Count; i++)
            {
                string satir = Icindekiler[i].ToString();
                if (satir == "özgeçmiş")
                {
                    if (sayfalar[sayfalar.Length - 1].IndexOf("özgeçmiş") == -1)
                    {
                        Raporlar.Add("İçindekiler Tablosunda Yer Alan Özgeçmiş Bölümü Son Sayfada Değildir.");
                    }
                }
                else
                {
                    string bolum = satir.Split('|')[0].Trim();
                    string numara = satir.Split('|')[1].Trim();
                    bool bulunamadi = true;
                    for (int j = 2; j < sayfalar.Length; j++)
                    {
                        if (sayfalar[j].Trim() == "") continue;
                        string[] satirlar = sayfalar[j].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        string sayfaNumara = satirlar[satirlar.Length - 1].Trim();
                        if (sayfaNumara == numara)
                        {
                            bulunamadi = false;
                            string duzenliSayfa = string.Join(" ", sayfalar[j].Replace("\r\n", "").Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                            if (duzenliSayfa.IndexOf(bolum) == -1)
                            {
                                Raporlar.Add("İçindekiler Listesindeki " + bolum + " Bölümü " + numara + " Numaralı Sayfada Bulunamadı.");
                            }
                            break;
                        }
                    }
                    if (bulunamadi)
                    {
                        Raporlar.Add("İçindekiler Listesindeki " + bolum + " Bölümü " + numara + " Numaralı Sayfada Bulunamadı.");
                    }
                }
            }

        }
        void OnsozKontrolu()
        {
            string onSozBolumuTxt = "";
            for (int i = 0; i < sayfalar.Length; i++)
            {
                string sayfa = sayfalar[i].Trim().ToLower();
                if (sayfa.Trim() == "") continue;
                string[] sayfaSatirlar = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (sayfaSatirlar[0].Trim() == "önsöz")
                {
                    onSozBolumuTxt = sayfalar[i];
                    break;
                }
            }
            if (onSozBolumuTxt == "")
            {
                Raporlar.Add("Önsöz Bölümü Eksik. Lütfen Önsöz Sayfası Ekleyin");
                return;
            }
            string[] satirlar = onSozBolumuTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string paragraf = "";
            for (int j = 1; j < satirlar.Length - 1; j++)
            {
                string satir = satirlar[j];
                if (satir.Trim() == "") continue;
                if (paragraf == "")
                {
                    if (BoslukSay(satir) == satirBaslariBosluk)
                    {
                        paragraf += satir + "\r\n";
                    }
                }
                else
                {
                    if (BoslukSay(satir) == normalBosluk)
                    {
                        paragraf += satir + "\r\n";
                    }
                    else
                    {
                        break;
                    }
                }
            }
            paragraf = string.Join("", paragraf.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            if ((paragraf.IndexOf("teşekkür ederim") > -1) || (paragraf.IndexOf("şükranlarımı sunarım") > -1))
            {
                Raporlar.Add("Önsöz Bölümünün İlk Paragrafında Teşekkür ve ya Şükran İbaresi Yer Alamaz.");
            }
        }
        void EnFazla5AnahtarKelimeKurali()
        {
            bool ozetBolumundenSonra = false;
            string anahtarKelimeler = "";
            for (int i = 0; i < sayfalar.Length; i++)
            {
                string sayfa = sayfalar[i].Trim().ToLower();
                string[] satirlar = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (sayfa.Trim() == "") continue;
                if (ozetBolumundenSonra)
                {
                    if (satirlar[0].Trim() == "abstract") break;
                    for (int j = 1; j < satirlar.Length - 1; j++)
                    {
                        string satir = satirlar[j].Trim();
                        satir = string.Join(" ", satir.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                        if (satir.IndexOf("anahtar kelimeler") > -1)
                        {
                            anahtarKelimeler = satir;
                        }
                        else if (anahtarKelimeler != "")
                        {
                            anahtarKelimeler += " " + satir;
                        }
                    }
                }
                else
                {
                    if (satirlar[0].Trim() == "özet")
                    {
                        ozetBolumundenSonra = true;
                        i--;
                    }
                }
            }

            if (anahtarKelimeler.Trim() == "")
            {
                Raporlar.Add("Anahtar Kelimeler Bölümü Bulunamadı");
                return;
            }

            anahtarKelimeler = anahtarKelimeler.Replace("anahtar kelimeler", "").Replace(":", "").Trim();
            string[] terimler = anahtarKelimeler.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (terimler.Length > 5)
            {
                Raporlar.Add("Anahtar Kelimeler Bölümünde En Fazla 5 Adet Terim Olabilir.");
            }
        }
        void IcerikBasliklari()
        {
            bool IcindekilerStart = false;
            string IcindekilerText = "";
            for (int i = 0; i < sayfalar.Length; i++)
            {
                string sayfa = sayfalar[i].ToString().ToLower();
                if (sayfa.Trim() != "")
                {
                    string[] satirlar = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (!IcindekilerStart)
                    {
                        if (satirlar[0].Trim().ToLower() == "içindekiler")
                        {
                            IcindekilerStart = true;
                            IcindekilerText = IcindekilerText + " " + sayfa;
                        }
                    }
                    else
                    {
                        if (satirlar[0].Trim().ToLower() == "özet") break;
                        IcindekilerText = IcindekilerText + " " + sayfa;
                    }
                }
            }

            if(IcindekilerText.Trim()=="")
            {
                Raporlar.Add("İçindekiler Bölümü Bulunamadı");
                return;
            }

            string basliklarIcın = "";
            string[] textParcala = IcindekilerText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < textParcala.Length; i++)
            {
                string satir = textParcala[i].Trim().ToLower();
                if (IsNumeric(satir.Substring(0, 1)))
                {
                    int endIndex = satir.IndexOf("..");
                    string baslik = satir.Substring(0, endIndex);
                    baslik = string.Join(" ", baslik.Trim().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    basliklarIcın += baslik.Trim().ToLower() + "|";

                }
            }
            basliklarIcın = basliklarIcın.TrimEnd('|');
            BasliklarListesi = basliklarIcın.Split('|');
        }
        void IkiSatirdanAzParagraf()
        {

            SatirBasiBosluk();
            string paragraf = "";

            for (int i = 0; i < duzenliIcerikSayfalari.Count; i++)
            {
                string sayfa = duzenliIcerikSayfalari[i].ToString().ToLower();
                string[] satirlar = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int knt = 0;
                string ilksatir = string.Join(" ", satirlar[0].Trim().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                if (Array.IndexOf(BasliklarListesi, ilksatir) > -1) knt = 1;
                for (int j = knt; j < satirlar.Length - 1; j++)
                {
                    string satir = satirlar[j];
                    if (satir.Trim() == "") continue;
                    string[] parcaliSatir = satir.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string sonParca = parcaliSatir[parcaliSatir.Length - 1];
                    if (parcaliSatir[0].Trim() == "tablo") break;
                    if (paragraf == "")
                    {
                        if ((DenklemRegexle(sonParca.Trim())) && satir.IndexOf("=") == -1)
                        {
                            if (BoslukSay(satir) == satirBaslariBosluk)
                            {
                                paragraf += satir + "\r\n";
                            }
                        }
                        else
                        {
                            string satir2 = satirlar[j + 1];
                            if ((satir2.IndexOf("[") > -1) || (satir2.IndexOf("(") > -1) || (satir2.IndexOf("=") > -1))
                            {
                                j++;
                            }
                        }
                    }
                    else
                    {
                        if ((DenklemRegexle(sonParca.Trim())) && satir.IndexOf("=") == -1)
                        {
                            if (BoslukSay(satir) == normalBosluk)
                            {
                                paragraf += satir + "\r\n";
                            }
                            else
                            {
                                paragraf = paragraf.Trim() + "\r\n" + (i + 1).ToString();
                                paragrafListesi.Add(paragraf.Trim());
                                paragraf = "";
                                j--;
                            }
                        }
                        else
                        {
                            string satir2 = satirlar[j + 1];
                            if ((satir2.IndexOf("[") > -1) || (satir2.IndexOf("(") > -1) || (satir2.IndexOf("=") > -1))
                            {
                                j++;
                            }
                        }

                    }
                }
            }
            string sonSayfa = "";
            for (int i = 0; i < paragrafListesi.Count; i++)
            {
                string[] satirlar = paragrafListesi[i].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int satirSayisi = satirlar.Length - 1;
                if (satirlar[satirlar.Length - 1]==sonSayfa) continue;
                if (satirSayisi < 3)
                {
                    sonSayfa = satirlar[satirlar.Length - 1];
                    Raporlar.Add(satirlar[satirlar.Length - 1] + " Numaralı Sayfada;2 ve daha az satırdan oluşan paragraflar geçerli değildir. Lütfen Bir önceki paragrafla birleştiriniz.");
                }
            }
        }
        bool DenklemRegexle(string denklem)
        {
            bool returnIT = true;
            if (denklem1.IsMatch(denklem) || denklem2.IsMatch(denklem) || denklem3.IsMatch(denklem) || denklem4.IsMatch(denklem))
                returnIT = false;
            return returnIT;
        }
        void SatirBasiBosluk()
        {
            string sayfa = duzenliIcerikSayfalari[0].ToString();
            string[] sayfaParca = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            satirBaslariBosluk = BoslukSay(sayfaParca[1].ToLower());
            normalBosluk = BoslukSay(sayfaParca[0].ToLower());
        }
        void ÇiftTirnakKelimeAdedi()
        {

            for (int i = 0; i < sayfalar.Length; i++)
            {
                string sayfa = sayfalar[i].Replace('“', '"').Replace('”', '"').Replace("\r\n", "");
                if (sayfa.IndexOf('"') > -1)
                {
                    for (int j = 0; j < sayfa.Length; j++)
                    {
                        int startIndex = sayfa.Substring(j).IndexOf('"');
                        if (startIndex != -1)
                        {
                            startIndex += j + 1;
                            int endIndex = sayfa.Substring(startIndex + 1).IndexOf('"') + 1;
                            string tirnakArasi = sayfa.Substring(startIndex, endIndex);
                            string[] kelimeAdedi = tirnakArasi.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (kelimeAdedi.Length > 50)
                            {
                                string sayfaNumarasi = SayfaNumarasiDondur(i);
                                if (sayfaNumarasi != "-1")
                                    Raporlar.Add(sayfaNumarasi + " Numaralı sayfada; Çift Tırnak arasında 50 adetden fazla kelime bulunmuştur. Çift Tırnak arasında 50 adetden fazla kelime bulunamaz.");
                            }
                            j = startIndex + endIndex + 2;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

        }
        string SayfaNumarasiDondur(int index)
        {
            string sayfaNumarasi = "-1";
            string sayfa = sayfalar[index].Trim();
            string[] satirlar = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string NumaraKontrol = satirlar[satirlar.Length - 1].Trim().ToLower();
            if (Array.IndexOf(romanRakam, NumaraKontrol) > -1 || IsNumeric(NumaraKontrol))
            {
                sayfaNumarasi = NumaraKontrol;
            }
            return sayfaNumarasi;
        }
        void BolumTablolar(ref int progressPercent, ref string progressText)
        {
            progressText = "Tablolar Bulunuyor...";
            TablolariBul();
            progressPercent += 10;
            //---------------------
            progressText = "Tabloların Adedi Sayılıyor...";
            bool devamKnt=TabloSayisi();
            progressPercent += 10;
            if(devamKnt)
            {
                progressText = "Tablo Standartları Kontrol Ediliyor...";
                TabloStandartlari();
                progressPercent += 10;
                progressText = "Tablolara Yapılan Atıflar Kontrol Ediliyor...";
                TabloAtiflari();
                progressPercent += 10;
                TabloBlokAtiflari();
                progressText = "Tablolara Yapılan Blok Atıflar Kontrol Ediliyor...";
                progressPercent += 10;
            }
        }
        void TablolariBul()
        {
            bool tablolarBolumu = false;
            string tablolarText = "";
            for (int i = 0; i < sayfalar.Length; i++)
            {
                if (sayfalar[i].Trim() == "") continue;
                string[] sayfaBasligiBul = sayfalar[i].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string baslik = sayfaBasligiBul[0].Trim().ToLower();
                if (tablolarBolumu)
                {
                    if (baslik == "ekler listesi" || baslik == "simgeler ve kısaltmalar" || baslik == "1. giriş")
                    {
                        break;
                    }
                    else
                    {
                        tablolarText += " " + sayfalar[i];
                    }
                }
                else
                {
                    if (baslik == "tablolar listesi")
                    {
                        tablolarBolumu = true;
                        tablolarText += " " + sayfalar[i];
                    }
                }
            }
            if (tablolarText.Trim() == "")
            {
                Raporlar.Add("Tablolar Bölümü Bulunamadı.");
                return;
            }
            string[] tabloSatirlari = tablolarText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int oldSatirBosluk = 0;
            ArrayList TablolarDuzen = new ArrayList();
            for (int i = 1; i < tabloSatirlari.Length; i++)
            {
                string satir = tabloSatirlari[i].Trim().ToLower();
                if (!IsNumeric(satir) && satir != "" && satir.Length > 5)
                {
                    if (((satir.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0]).IndexOf("tablo")) > -1)
                    {
                        oldSatirBosluk = BoslukSay(tabloSatirlari[i].ToLower());
                        TablolarDuzen.Add(satir);
                    }
                    else
                    {
                        int nowSatirBosluk = BoslukSay(tabloSatirlari[i].ToLower());
                        if (!(oldSatirBosluk == nowSatirBosluk) || (oldSatirBosluk < nowSatirBosluk))
                        {
                            TablolarDuzen[TablolarDuzen.Count - 1] = TablolarDuzen[TablolarDuzen.Count - 1] + " " + satir;
                        }
                    }
                }
            }
            for (int i = 0; i < TablolarDuzen.Count; i++)
            {
                string tabloSatir = TablolarDuzen[i].ToString();
                string tabloDuzenlitxt = "";
                string[] parcaParcala = tabloSatir.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                tabloDuzenlitxt = parcaParcala[0].Trim() + " " + parcaParcala[1].Trim() + "|";
                tabloDuzenlitxt += parcaParcala[parcaParcala.Length - 1].Trim() + "|";
                string duzenliBaslik = "";
                for (int j = 2; j < parcaParcala.Length - 2; j++)
                {
                    duzenliBaslik += parcaParcala[j] + " ";
                }
                string sonKelime = parcaParcala[parcaParcala.Length - 2].ToString().Replace(".", "").Trim();
                if (sonKelime != "") duzenliBaslik += sonKelime;
                tabloDuzenlitxt += duzenliBaslik;
                Tablolar.Add(tabloDuzenlitxt);
            }
        }
        bool TabloSayisi()
        {
            bool returnIt = true;
            if (Tablolar.Count == 0)
            {
                returnIt = false;
            }
            else
            {
                istatistikselBilgiler.Add("Toplam Tablo Sayısı: " + (Tablolar.Count).ToString());
            }
            return returnIt;
            
        }
        void TabloStandartlari()
        {
            for (int i = 0; i < Tablolar.Count; i++)
            {
                string[] tabloObject = Tablolar[i].ToString().Split('|');
                string tablo = tabloObject[0];
                string sayfaNumarasi = tabloObject[1];
                string baslik = tabloObject[2].ToLower().Trim();
                int duzenliSayfaNumarasi = Convert.ToInt32(sayfaNumarasi) - 1;
                if ((duzenliSayfaNumarasi > duzenliIcerikSayfalari.Count - 1) || duzenliSayfaNumarasi < 0)
                {
                    Tablolar.RemoveAt(i);
                    Raporlar.Add("Tablolar Listesindeki " + tablo + " tablosu için verilen " + sayfaNumarasi + " numaralı sayfa yoktur ve ya sayfa numarası yanlış girilmiştir.");
                }
                else
                {
                    string sayfa = duzenliIcerikSayfalari[duzenliSayfaNumarasi].ToString().ToLower();
                    string[] sayfaSatirlar = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    bool bulunamadi = true;
                    for (int j = 0; j < sayfaSatirlar.Length; j++)
                    {
                        string satir = sayfaSatirlar[j].ToLower().Trim();
                        if (satir != "")
                        {
                            string[] satirParcala = satir.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (satirParcala.Length > 1)
                            {
                                string satirKontrol = satirParcala[0] + " " + satirParcala[1];
                                if (satirKontrol == tablo)
                                {
                                    bulunamadi = false;
                                }
                            }
                        }
                    }

                    if (bulunamadi)
                    {
                        Raporlar.Add(tablo + " Tablosu " + sayfaNumarasi + " Numaralı Sayfada Bulunamadı. Lütfen Tablolar Listesinden " + tablo + " Şeklini Kaldırın veya " + sayfaNumarasi + " Numaralı Sayfaya Tabloyu Ekleyin");
                    }
                }
            }
        }
        void TabloAtiflari()
        {
            for (int i = 0; i < Tablolar.Count; i++)
            {
                string[] tabloObject = Tablolar[i].ToString().Split('|');
                string tablo = tabloObject[0].TrimEnd('.');
                string sayfaNumarasi = tabloObject[1];
                int duzenliSayfaNumarasi = Convert.ToInt32(sayfaNumarasi) - 1;
                string atiflar = "";
                for (int j = duzenliSayfaNumarasi; j >= 0; j--)
                {
                    string sayfa = duzenliIcerikSayfalari[j].ToString().Replace("\r\n", "");
                    string[] sayfaDuzen = sayfa.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    sayfa = "";
                    for (int z = 0; z < sayfaDuzen.Length; z++)
                    {
                        string DuzenliTerimler = sayfaDuzen[z].Trim().ToLower();
                        sayfa += DuzenliTerimler + " ";
                    }

                    for (int k = 0; k < sayfa.Length; k++)
                    {
                        int ilkIndex = sayfa.Substring(k).IndexOf(tablo);
                        if (ilkIndex != -1)
                        {
                            ilkIndex = k + ilkIndex;
                            int sonIndex = tablo.Length + 1;
                            string tabloFarket = sayfa.Substring(ilkIndex, sonIndex);
                            string sonKarakter = tabloFarket.Substring(tabloFarket.Length - 1, 1);
                            if (sonKarakter != ".")
                            {
                                atiflar += (duzenliSayfaNumarasi + 1) + ",";
                            }
                            k = ilkIndex + sonIndex;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                atiflar = atiflar.TrimEnd(',');
                if (atiflar.Trim() != "")
                {
                    string[] atifsayi = atiflar.Split(',');
                    string bahset = "Sayfalarda";
                    if (atifsayi.Length < 2) bahset = "Sayfada";
                    istatistikselBilgiler.Add(tablo + " Tablosuna " + atiflar + " Numaralı " + bahset + " Atıf Yapılmıştır.");
                }
                else
                {
                    Raporlar.Add(tablo + " Tablosuna Atıf Yapılmamış. Lütfen Tablonun olduğu sayfada ve ya daha önceki sayfalarda atıf yapın.");
                }
            }
        }
        void TabloBlokAtiflari()
        {
            for (int i = 0; i < duzenliIcerikSayfalari.Count; i++)
            {
                string sayfa = duzenliIcerikSayfalari[i].ToString();
                for (int j = 0; j < sayfa.Length; j++)
                {
                    int baslangic = sayfa.Substring(j).IndexOf("(");
                    if (baslangic != -1)
                    {
                        baslangic = j + baslangic;
                        int son = sayfa.Substring(baslangic).IndexOf(")") + 1;
                        if (son != -1)
                        {
                            string parantezIci = sayfa.Substring(baslangic, son);
                            BlokTabloAra((i + 1).ToString(), parantezIci);
                        }
                        j = baslangic + son;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        void BlokTabloAra(string numara, string parantezIci)
        {
            if (parantezIci.IndexOf("tablo") == -1) return;
            parantezIci = parantezIci.Replace("\r\n", "").Replace("(", "").Replace(")", "").Trim();
            string[] boslukDuzen = parantezIci.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] forSearchIT;
            int Index = 0;
            if (boslukDuzen.Length > 1)
            {
                forSearchIT = new string[boslukDuzen.Length - 1];
                for (int i = 0; i < boslukDuzen.Length - 1; i++)
                {
                    forSearchIT[Index] = boslukDuzen[i] + " " + boslukDuzen[i + 1];
                }
            }
            else
            {
                forSearchIT = new string[1];
                forSearchIT[0] = boslukDuzen[0];
            }

            for (int i = 0; i < Tablolar.Count; i++)
            {
                string[] tabloObject = Tablolar[i].ToString().Split('|');
                string tablo = tabloObject[0].TrimEnd('.').Trim();
                if (Array.IndexOf(forSearchIT, tablo) > -1)
                {
                    Raporlar.Add(numara + " Numaralı Sayfada; " + tablo + " Tablosuna Blok Atıf Yapılmıştır. Şekillere ve Tablolara Blok Atıf Yapılamaz.");
                }
            }
        }
        void BolumSekiller(ref int progressPercent, ref string progressText)
        {
            progressText = "Şekiller Bulunuyor...";
            SekilleriBul();
            progressPercent += 10;
            //---------------------
            progressText = "Şekillerin Adedi Sayılıyor...";
            bool devamKnt=SekillerSayisi();
            progressPercent += 10;
            if(devamKnt)
            {
                progressText = "Şekil Standartları Kontrol Ediliyor...";
                SekillerStandartlari();
                progressPercent += 10;
                progressText = "Şekillere Yapılan Atıflar Kontrol Ediliyor...";
                SekillerAtiflari();
                progressPercent += 10;
                SekillerBlokAtiflari();
                progressText = "Şekillere Yapılan Blok Atıflar Kontrol Ediliyor...";
                progressPercent += 10;
            }
        }
        void SekillerBlokAtiflari()
        {
            for (int i = 0; i < duzenliIcerikSayfalari.Count; i++)
            {
                string sayfa = duzenliIcerikSayfalari[i].ToString();
                for (int j = 0; j < sayfa.Length; j++)
                {
                    int baslangic = sayfa.Substring(j).IndexOf("(");
                    if (baslangic != -1)
                    {
                        baslangic = j + baslangic;
                        int son = sayfa.Substring(baslangic).IndexOf(")") + 1;
                        if (son != -1)
                        {
                            string parantezIci = sayfa.Substring(baslangic, son);
                            BlokSekilAra((i + 1).ToString(), parantezIci);
                        }
                        j = baslangic + son;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        void BlokSekilAra(string numara, string parantezIci)
        {

            if (parantezIci.IndexOf("şekil") == -1) return;
            parantezIci = parantezIci.Replace("\r\n", "").Replace("(", "").Replace(")", "").Trim();
            string[] boslukDuzen = parantezIci.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] forSearchIT;
            int Index = 0;
            if (boslukDuzen.Length > 1)
            {
                forSearchIT = new string[boslukDuzen.Length - 1];
                for (int i = 0; i < boslukDuzen.Length - 1; i++)
                {
                    forSearchIT[Index] = boslukDuzen[i] + " " + boslukDuzen[i + 1];
                }
            }
            else
            {
                forSearchIT = new string[1];
                forSearchIT[0] = boslukDuzen[0];
            }


            for (int i = 0; i < Sekiller.Count; i++)
            {
                string[] sekilObject = Sekiller[i].ToString().Split('|');
                string sekil = sekilObject[0].TrimEnd('.').Trim();
                if (Array.IndexOf(forSearchIT, sekil) > -1)
                {
                    Raporlar.Add(numara + " Numaralı Sayfada; " + sekil + " Şekline Blok Atıf Yapılmıştır. Şekillere ve Tablolara Blok Atıf Yapılamaz.");
                }
            }
        }
        void SekillerAtiflari()
        {
            for (int i = 0; i < Sekiller.Count; i++)
            {
                string[] sekilObject = Sekiller[i].ToString().Split('|');
                string sekil = sekilObject[0].TrimEnd('.');
                string sayfaNumarasi = sekilObject[1];
                int duzenliSayfaNumarasi = Convert.ToInt32(sayfaNumarasi) - 1;
                string atiflar = "";
                for (int j = duzenliSayfaNumarasi; j >= 0; j--)
                {
                    string sayfa = duzenliIcerikSayfalari[j].ToString().Replace("\r\n", "");
                    string[] sayfaDuzen = sayfa.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    sayfa = "";
                    for (int z = 0; z < sayfaDuzen.Length; z++)
                    {
                        string DuzenliTerimler = sayfaDuzen[z].Trim().ToLower();
                        sayfa += DuzenliTerimler + " ";
                    }

                    for (int k = 0; k < sayfa.Length; k++)
                    {
                        int ilkIndex = sayfa.Substring(k).IndexOf(sekil);
                        if (ilkIndex != -1)
                        {
                            ilkIndex += k;
                            int sonIndex = sekil.Length + 1;
                            string sekilFarket = sayfa.Substring(ilkIndex, sonIndex);
                            string sonKarakter = sekilFarket.Substring(sekilFarket.Length - 1, 1);
                            if (sonKarakter != ".")
                            {
                                atiflar += (duzenliSayfaNumarasi + 1) + ",";
                            }
                            k = ilkIndex + sonIndex;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                atiflar = atiflar.TrimEnd(',');
                if (atiflar.Trim() != "")
                {
                    string[] atifsayi = atiflar.Split(',');
                    string bahset = "Sayfalarda";
                    if (atifsayi.Length < 2) bahset = "Sayfada";
                    istatistikselBilgiler.Add(sekil + " Şekline " + atiflar + " Numaralı " + bahset + " Atıf Yapılmıştır.");
                }
                else
                {
                    Raporlar.Add(sekil + " Şekline Atıf Yapılmamış. Lütfen Şekilin olduğu sayfada ve ya daha önceki sayfalarda atıf yapın.");
                }
            }
        }
        void SekillerStandartlari()
        {
            for (int i = 0; i < Sekiller.Count; i++)
            {
                string[] sekilObject = Sekiller[i].ToString().Split('|');
                string sekil = sekilObject[0];
                string sayfaNumarasi = sekilObject[1];
                string baslik = sekilObject[2].ToLower().Trim();
                int duzenliSayfaNumarasi = Convert.ToInt32(sayfaNumarasi) - 1;
                if ((duzenliSayfaNumarasi > duzenliIcerikSayfalari.Count - 1) || duzenliSayfaNumarasi < 0)
                {
                    Sekiller.RemoveAt(i);
                    Raporlar.Add("Şekiller Listesindeki " + sekil + " Şekili için verilen " + sayfaNumarasi + " numaralı sayfa yoktur ve ya sayfa numarası yanlış girilmiştir.");
                }
                else
                {
                    string sayfa = duzenliIcerikSayfalari[duzenliSayfaNumarasi].ToString().ToLower();
                    string[] sayfaSatirlar = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    bool bulunamadi = true;
                    for (int j = 0; j < sayfaSatirlar.Length; j++)
                    {
                        string satir = sayfaSatirlar[j].ToLower().Trim();
                        if (satir != "")
                        {
                            string[] satirParcala = satir.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (satirParcala.Length > 1)
                            {
                                string satirKontrol = satirParcala[0] + " " + satirParcala[1];
                                if (satirKontrol == sekil)
                                {
                                    bulunamadi = false;
                                }
                            }
                        }
                    }

                    if (bulunamadi)
                    {
                        Raporlar.Add(sekil + " Şekli " + sayfaNumarasi + " Numaralı Sayfada Bulunamadı. Lütfen Şekiller Listesinden " + sekil + " Şeklini Kaldırın veya " + sayfaNumarasi + " Numaralı Sayfaya Şekili Ekleyin");
                    }
                }
            }
        }
        bool SekillerSayisi()
        {
            bool returnIt = true;
            if (Sekiller.Count == 0)
            {
                returnIt = false;
            }
            else
            {
                istatistikselBilgiler.Add("Toplam Şekil Sayısı: " + (Sekiller.Count).ToString());
            }
            return returnIt;
        }
        void SekilleriBul()
        {
            bool sekillerBolumu = false;
            string sekillerText = "";
            for (int i = 0; i < sayfalar.Length; i++)
            {
                if (sayfalar[i].Trim() == "") continue;
                string[] sayfaBasligiBul = sayfalar[i].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string baslik = sayfaBasligiBul[0].Trim().ToLower();
                if (sekillerBolumu)
                {
                    if (baslik == "tablolar listesi" || baslik == "ekler listesi" || baslik == "simgeler ve kısaltmalar" || baslik == "1. giriş")
                    {
                        break;
                    }
                    else
                    {
                        sekillerText += " " + sayfalar[i];
                    }
                }
                else
                {
                    if (baslik == "şekiller listesi")
                    {
                        sekillerBolumu = true;
                        sekillerText += " " + sayfalar[i];
                    }
                }
            }
            if(sekillerText.Trim()=="")
            {
                Raporlar.Add("Şekiller Bölümü Bulunamadı.");
                return;
            }

            string[] sekillerSatirlari = sekillerText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int oldSatirBosluk = 0;
            ArrayList SekillerDuzen = new ArrayList();
            for (int i = 1; i < sekillerSatirlari.Length; i++)
            {
                string satir = sekillerSatirlari[i].Trim().ToLower();
                if (!IsNumeric(satir) && satir != "" && satir.Length > 5)
                {
                    if (((satir.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0]).IndexOf("şekil")) > -1)
                    {
                        oldSatirBosluk = BoslukSay(sekillerSatirlari[i].ToLower());
                        SekillerDuzen.Add(satir);
                    }
                    else
                    {
                        int nowSatirBosluk = BoslukSay(sekillerSatirlari[i].ToLower());
                        if (!(oldSatirBosluk == nowSatirBosluk) || (oldSatirBosluk < nowSatirBosluk))
                        {
                            SekillerDuzen[SekillerDuzen.Count - 1] = SekillerDuzen[SekillerDuzen.Count - 1] + " " + satir;
                        }
                    }
                }
            }
            for (int i = 0; i < SekillerDuzen.Count; i++)
            {
                string sekilSatir = SekillerDuzen[i].ToString();
                string sekilDuzenlitxt = "";
                string[] parcaParcala = sekilSatir.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                sekilDuzenlitxt = parcaParcala[0].Trim() + " " + parcaParcala[1].Trim() + "|";
                sekilDuzenlitxt += parcaParcala[parcaParcala.Length - 1].Trim() + "|";
                string duzenliBaslik = "";
                for (int j = 2; j < parcaParcala.Length - 2; j++)
                {
                    duzenliBaslik += parcaParcala[j] + " ";
                }
                string sonKelime = parcaParcala[parcaParcala.Length - 2].ToString().Replace(".", "").Trim();
                if (sonKelime != "") duzenliBaslik += sonKelime;
                sekilDuzenlitxt += duzenliBaslik;
                Sekiller.Add(sekilDuzenlitxt);
            }

        }
        void BolumSayfalar(ref int progressPercent, ref string progressText)
        {
            progressText = "Sayfalar Belirleniyor...";
            SayfalariAyir();
            progressPercent += 10;
            progressText = "Sayfa Numaraları Düzenleniyor...";
            SayfaNumaralariRaporla();
            progressPercent += 10;
            progressText = "Döküman İçeriği Bulunuyor...";
            IcerikStartEnd();
            progressPercent += 10;
        }
        void SayfaNumaralariRaporla()
        {
            bool onsozBulundu = false;
            bool giristenSonra = false;
            int giristenSonraSay = 1;
            int onsozdenSonraSay = 0;

            for (int i = 0; i < sayfalar.Length; i++)
            {
                if (sayfalar[i].Trim() == "") continue;  
                string[] sayfaParcala = sayfalar[i].Trim().ToLower().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string sonSatir = sayfaParcala[sayfaParcala.Length - 1].Trim().Replace('ı', 'i').ToLower();
                string baslik = string.Join(" ", sayfaParcala[0].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                if (baslik == "önsöz")
                {
                    onsozBulundu = true;
                    if(sonSatir=="")
                    {
                        sayfalar[i] = sayfalar[i] + "\r\n    " + romanRakam[(i - 1)] + " \r\n";
                        Raporlar.Add("Lütfen Önsöz Bölümüne Sayfa Numarası Ekleyiniz.");
                        onsozdenSonraSay = (i - 1);
                    }
                    else
                    {
                        if(Array.IndexOf(romanRakam, sonSatir) > -1)
                        {
                            onsozdenSonraSay = Array.IndexOf(romanRakam, sonSatir);
                        }
                        else
                        {
                            sayfalar[i] = sayfalar[i] + "\r\n    " + romanRakam[(i - 1)] + " \r\n";
                            onsozdenSonraSay = (i - 1);
                            Raporlar.Add("Önsöz Bölümünün Sayfa Numarası Yanlıştır.");
                        }
                    }
                }
                if (baslik == "1. giriş") giristenSonra = true;

                if(onsozBulundu)
                {
                    if (giristenSonra)
                    {
                        if(IsNumeric(sonSatir))
                        {
                            if (sonSatir != giristenSonraSay.ToString())
                            {
                                Raporlar.Add(sonSatir + ". sayfada; sayfa numarası yanlıştır.Olması Gereken Numara: " + giristenSonraSay.ToString());
                                sayfalar[i] = sayfalar[i].ToString() + "\r\n    " + giristenSonraSay.ToString() + " \r\n";
                            }
                        }
                        else
                        {
                            Raporlar.Add(giristenSonraSay.ToString() + ". sayfada; sayfa numarası yoktur. Lütfen Sayfanın En altına " + giristenSonraSay.ToString() + " numarasını ekleyiniz.");
                            sayfalar[i] = sayfalar[i].ToString() + "\r\n    " + giristenSonraSay.ToString() + " \r\n";
                        }
                        giristenSonraSay++;
                    }
                    else
                    {
                        if(Array.IndexOf(romanRakam, sonSatir)>-1)
                        {
                            if (sonSatir != romanRakam[onsozdenSonraSay])
                            {
                                Raporlar.Add(sonSatir + ". sayfada; sayfa numarası yanlıştır. Olması Gereken Numara: " + romanRakam[onsozdenSonraSay]);
                                sayfalar[i] = sayfalar[i] + "\r\n    " + romanRakam[onsozdenSonraSay] + " \r\n";
                            }
                        }
                        else
                        {
                            Raporlar.Add(sonSatir + ". sayfada; sayfa numarası yanlıştır. Olması Gereken Numara: " + romanRakam[onsozdenSonraSay]);
                            sayfalar[i] = sayfalar[i] + "\r\n    " + romanRakam[onsozdenSonraSay] + " \r\n";
                        }
                    }
                    onsozdenSonraSay++;
                }
                else
                {
                    sayfalar[i] = "";
                }
            }

            int sayfasay = 1;
            for (int i = 1; i < sayfalar.Length; i++)
            {
                if (sayfalar[i].Trim() == "") continue; 
                string[] sayfaParcala = sayfalar[i].Trim().ToLower().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string sonSatir = sayfaParcala[sayfaParcala.Length - 1].Trim().ToLower();
                if (sonSatir == sayfasay.ToString())
                {
                    duzenliIcerikSayfalari.Add(sayfalar[i]);
                    sayfasay++;
                }
            }
        }
        void IcerikStartEnd()
        {
            for (int i = 0; i < sayfalar.Length; i++)
            {
                string sayfa = sayfalar[i].Trim();
                int firstClip = sayfa.IndexOf("\r\n");
                if (firstClip != -1)
                {
                    string baslik = sayfa.Substring(0, firstClip).Trim().ToLower();
                    if (baslik.IndexOf("giriş") > -1) IcerikStartIndex = i;
                    else if (baslik.IndexOf("kaynaklar") > -1) IcerikEndIndex = i;
                }
            }
            if (IcerikStartIndex == -1)
            {
                Raporlar.Add("Giriş Bölümü Bulunamadı. Dökümanın 1. sayfası giriş bölümüyle başlamak zorunda");
                for (int i = 0; i < sayfalar.Length; i++)
                {
                    if (sayfalar[i].Trim() == "") continue; 
                    string[] sayfaParcala = sayfalar[i].Trim().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (sayfaParcala[sayfaParcala.Length - 1].Trim() == "1")
                    {
                        IcerikStartIndex = i;
                        break;
                    }
                    else if (sayfaParcala[sayfaParcala.Length - 1].Trim() == "2")
                    {
                        IcerikStartIndex = i;
                        Raporlar.Add("Sayfa Numaralarında EKsik var. 1. Sayfa Eksik. Sayfanın En Altına '1' numarasını eklemeniz gerekiyor.");
                        break;
                    }
                }
            }
            if (IcerikEndIndex == -1)
            {
                Raporlar.Add("Kaynaklar Bölümü Bulunamadı. Dökümanın altına KAYNAKLAR bölümü eklemeniz gerekmektedir.");
                firstMove = false;
            }
        }
        void SayfalariAyir()
        {
            sayfalar = thisTez.projeTezIcerik.Trim().ToLower().Split(new string[] { "evaluation warning : the document was created with spire.pdf for .net." }, StringSplitOptions.None);
        }
        void BolumKaynaklar(ref int progressPercent, ref string progressText)
        {
            progressText = "Kaynaklar Bulunuyor...";
            KaynaklariBul();
            progressPercent += 10;
            //---------------------
            progressText = "Kaynakların Adedi Sayılıyor...";
            bool devamknt=KaynakSayisi();
            progressPercent += 10;
            if(devamknt)
            {
                progressText = "Kaynak Standartları Kontrol Ediliyor...";
                KaynakStandartlari();
                progressPercent += 10;
                progressText = "Kaynaklara Yapılan Atıflar Kontrol Ediliyor...";
                KaynakAtiflari();
                progressPercent += 10;
                KaynakBlokAtiflari();
                progressText = "Kaynaklara Yapılan Blok Atıflar Kontrol Ediliyor...";
                progressPercent += 10;
            }
        }
        void KaynakBlokAtiflari()
        {
            int blokatifsay = 0;
            for (int i = IcerikStartIndex; i < IcerikEndIndex; i++)
            {
                string sayfa = sayfalar[i].ToLower().Trim();
                string[] sayfaParcalari = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string sayfaNumara = sayfaParcalari[sayfaParcalari.Length - 1].Trim();

                for (int j = 0; j < sayfa.Length; j++)
                {
                    int baslangic = sayfa.Substring(j).IndexOf("[");
                    if (baslangic == -1) break; else baslangic += j;
                    int son = sayfa.Substring(baslangic).IndexOf("]") + 1;
                    if (son == 0) break;
                    string atif = sayfa.Substring(baslangic, son);
                    if (atif.IndexOf(",") > -1 || atif.IndexOf("-") > -1)
                    {
                        string atifDuzentxt = atif.Replace("\r\n", "").Trim();
                        string[] atigDuzenleParcala = atifDuzentxt.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string atifBirlestir = string.Join(" ", atigDuzenleParcala);
                        atif = atifBirlestir.Substring(1, atifBirlestir.Length - 2);
                        bool devam = false;
                        for (int k = 0; k < atif.Length; k++)
                        {
                            if (atif.Substring(k, 1) == "," || atif.Substring(k, 1) == "-" || atif.Substring(k, 1) == "–" || atif.Substring(k, 1) == " ") { }
                            else if (IsNumeric(atif.Substring(k, 1))) { }
                            else { devam = true; break; }
                        }
                        if (devam)
                        {
                            j = baslangic + son;
                            continue;
                        }
                        istatistikselBilgiler.Add(sayfaNumara + " Numaralı Sayfada; " + atif + " Numaralı Kaynaklara Blok Atıf Yapılmıştır.");
                        blokatifsay++;
                    }
                    j = baslangic + son;
                }
            }
            istatistikselBilgiler.Add("Kaynaklara Toplamda " + blokatifsay + " adet blok atıf yapılmıştır.");
        }
        void KaynakAtiflari()
        {
            SayfalardaKaynakAtiflari();
            for (int i = 0; i < Kaynaklar.Count; i++)
            {
                string kaynakNumara = Kaynaklar[i].ToString().Trim().ToLower().Split(' ')[0].Trim().Replace("[", "").Replace("]", "");
                string kaynakEntries = "";
                for (int j = 0; j < sayfalardaKaynakAtiflari.Count; j++)
                {
                    if (sayfalardaKaynakAtiflari[j].ToString().Trim() == "") continue;
                    string[] atiflar = (sayfalardaKaynakAtiflari[j]).ToString().Split(',');
                    if (Array.IndexOf(atiflar, kaynakNumara) > -1)
                    {
                        kaynakEntries = kaynakEntries + (j + 1).ToString() + ",";
                    }
                }
                if (kaynakEntries != "")
                {
                    kaynakEntries = kaynakEntries.TrimEnd(',');
                    string duzen = "";
                    if (kaynakEntries.Split(',').Length == 1) duzen = "Sayfada";
                    else duzen = "Sayfalarda";
                    istatistikselBilgiler.Add(kaynakNumara + " Numaralı Kaynağa; " + kaynakEntries + " Numaralı " + duzen + " Atıf Yapılmıştır.");
                }
                else
                {
                    Raporlar.Add(kaynakNumara + " Numaralı Kaynağa Hiç Bir Sayfada Atıf Yapılmamıştır. Atıf Yapılması Gerekiyor. Metin içerisinde atıf yapın yada kaynaklardan çıkarın.");
                }

            }
        }
        void SayfalardaKaynakAtiflari()
        {
            int atifSay = 0;
            for (int i = 0; i < duzenliIcerikSayfalari.Count; i++)
            {
                string sayfa = duzenliIcerikSayfalari[i].ToString().ToLower().Trim();
                string duzenliAtif = "";
                string[] sayfaParcala = sayfa.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string baslik = sayfaParcala[0].Trim();
                if (baslik == "kaynaklar") break;
                sayfa = sayfa.Replace("\r\n", "");
                for (int j = 0; j < sayfa.Length; j++)
                {
                    int baslangicIndex = sayfa.Substring(j).IndexOf("[");
                    if (baslangicIndex != -1)
                    {
                        baslangicIndex += j;
                        if (IsNumeric(sayfa.Substring(baslangicIndex + 1, 1)))
                        {
                            int sonIndex = sayfa.Substring(baslangicIndex).IndexOf("]") - 1;
                            if (sonIndex != -2)
                            {
                                string blokveyadegilAtif = sayfa.Substring(baslangicIndex + 1, sonIndex);
                                string[] bol = blokveyadegilAtif.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                for (int k = 0; k < bol.Length; k++)
                                {
                                    string boluntu = bol[k].Trim().Replace("–", "-");
                                    if (boluntu.IndexOf("-") > -1)
                                    {
                                        string[] range = boluntu.Split('-');
                                        if (IsNumeric(range[0].Trim()) && IsNumeric(range[1].Trim()))
                                        {
                                            int bas = Convert.ToInt32(range[0].Trim());
                                            int son = Convert.ToInt32(range[1].Trim());
                                            for (int ii = bas; ii <= son; ii++)
                                            {
                                                duzenliAtif = duzenliAtif + (ii).ToString() + ",";
                                                atifSay++;
                                            }
                                        }
                                    }
                                    else if (IsNumeric(boluntu))
                                    {
                                        duzenliAtif = duzenliAtif + boluntu + ",";
                                        atifSay++;
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        j = baslangicIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                sayfalardaKaynakAtiflari.Add(duzenliAtif.TrimEnd(','));
            }

            istatistikselBilgiler.Add("Kaynaklara Toplamda " + atifSay.ToString() + " adet atıf yapılmıştır.");
        }
        void KaynaklariBul()
        {
            bool kaynakBolumu = false;
            string kaynaklarText = "";
            for (int i = 0; i < sayfalar.Length; i++)
            {
                if (sayfalar[i].Trim() == "") continue;
                string[] sayfaBasligiBul = sayfalar[i].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string baslik = sayfaBasligiBul[0].Trim().ToLower();
                if (kaynakBolumu)
                {
                    if (baslik == "ekler" || baslik == "özgeçmiş")
                    {
                        break;
                    }
                    else
                    {
                        kaynaklarText += " " + sayfalar[i];
                    }
                }
                else
                {
                    if (baslik == "kaynaklar")
                    {
                        kaynakBolumu = true;
                        kaynaklarText += " " + sayfalar[i];
                    }
                }
            }



            string[] kaynakSatirlari = kaynaklarText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int oldSatirBosluk = 0;
            for (int i = 1; i < kaynakSatirlari.Length; i++)
            {
                string satir = kaynakSatirlari[i].Trim().ToLower();
                if (!IsNumeric(satir) && satir != "" && satir.Length > 3)
                {
                    if (satir.Substring(0, 1) == "[")
                    {
                        oldSatirBosluk = BoslukSay(kaynakSatirlari[i].ToLower());
                        Kaynaklar.Add(satir);
                    }
                    else
                    {
                        int nowSatirBosluk = BoslukSay(kaynakSatirlari[i].ToLower());
                        if (!(oldSatirBosluk == nowSatirBosluk) || (oldSatirBosluk < nowSatirBosluk))
                        {
                            Kaynaklar[Kaynaklar.Count - 1] = Kaynaklar[Kaynaklar.Count - 1] + " " + satir;
                        }
                    }
                }
            }

        }
        int BoslukSay(string Satir)
        {
            int bosluk = 0;
            for (int i = 0; i < Satir.Length - 1; i++)
            {
                if (Satir.Substring(i, 1) != " ")
                {
                    break;
                }
                else
                {
                    bosluk++;
                }
            }
            return bosluk;
        }
        bool KaynakSayisi()
        {
            bool returnIt = true;
            if(Kaynaklar.Count==0)
            {
                returnIt = false;
                Raporlar.Add("Tezde Kaynaklar Bulunamadı. Lütfen Kaynak Bölümü Ekleyiniz");
                istatistikselBilgiler.Add("Toplam Kaynak Sayısı: " + (Kaynaklar.Count).ToString());
            }
            else
            {
                istatistikselBilgiler.Add("Toplam Kaynak Sayısı: " + (Kaynaklar.Count).ToString());
            }
            return returnIt;
        }
        void KaynakStandartlari()
        {

            for (int i = 0; i < Kaynaklar.Count; i++)
            {
                int numara = i + 1;
                string kaynak = Kaynaklar[i].ToString().Trim().ToLower();
                string kaynakKategorisi = kaynakKategoriBul(kaynak);
                string[] parcaKaynak = kaynak.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string bahis = "";
                bool throwIt = false;
                if (kaynakKategorisi == "görüşme")
                {
                    bahis = "Görüşülen Kişi";
                    throwIt = kaynakNumaraKontrol(numara.ToString(), parcaKaynak[0]);
                    if (throwIt) continue;
                    throwIt = kaynakGorusme(numara.ToString(), kaynak);
                    if (throwIt) continue;
                    throwIt = kaynakIsimKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                }
                else if (kaynakKategorisi == "dergi/makale")
                {
                    bahis = "Yazar";
                    throwIt = kaynakNumaraKontrol(numara.ToString(), parcaKaynak[0]);
                    if (throwIt) continue;
                    throwIt = kaynakTarihKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                    throwIt = kaynakIsimKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                    throwIt = kaynakDergiMakale(numara.ToString(), parcaKaynak, kaynak);
                    if (throwIt) continue;
                }
                else if (kaynakKategorisi == "kongre/konferans")
                {
                    bahis = "Konuşmacı/Anlatıcı";
                    throwIt = kaynakNumaraKontrol(numara.ToString(), parcaKaynak[0]);
                    if (throwIt) continue;
                    throwIt = kaynakTarihKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                    throwIt = kaynakIsimKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                }
                else if (kaynakKategorisi == "tez")
                {
                    bahis = "Tezin Yazarı";
                    throwIt = kaynakNumaraKontrol(numara.ToString(), parcaKaynak[0]);
                    if (throwIt) continue;
                    throwIt = kaynakTarihKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                    throwIt = kaynakIsimKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                }
                else if (kaynakKategorisi == "editör")
                {
                    bahis = "Editör";
                    throwIt = kaynakNumaraKontrol(numara.ToString(), parcaKaynak[0]);
                    if (throwIt) continue;
                    throwIt = kaynakTarihKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                    throwIt = kaynakIsimKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                    throwIt = kaynakEditor(numara.ToString(), parcaKaynak);
                    if (throwIt) continue;
                }
                else if (kaynakKategorisi == "patent")
                {
                    bahis = "Patentin Yazarı";
                    throwIt = kaynakNumaraKontrol(numara.ToString(), parcaKaynak[0]);
                    if (throwIt) continue;
                    throwIt = kaynakTarihKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                    throwIt = kaynakIsimKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                }
                else if (kaynakKategorisi == "harita")
                {
                    bahis = "Kurum";
                    throwIt = kaynakNumaraKontrol(numara.ToString(), parcaKaynak[0]);
                    if (throwIt) continue;
                    throwIt = kaynakTarihKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                    throwIt = kaynakHarita(numara.ToString(), parcaKaynak);
                    if (throwIt) continue;
                }
                else if (kaynakKategorisi == "www")
                {
                    throwIt = kaynakNumaraKontrol(numara.ToString(), parcaKaynak[0]);
                    if (throwIt) continue;
                    throwIt = kaynakWebSite(numara.ToString(), parcaKaynak);
                    if (throwIt) continue;
                }
                else//kitap
                {
                    bahis = "Yazar";
                    throwIt = kaynakNumaraKontrol(numara.ToString(), parcaKaynak[0]);
                    if (throwIt) continue;
                    throwIt = kaynakTarihKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                    throwIt = kaynakIsimKontrol(numara.ToString(), parcaKaynak, bahis);
                    if (throwIt) continue;
                }
            }

        }
        bool kaynakGorusme(string numara, string kaynak)
        {
            bool returnIt = false;
            int baslangic = kaynak.IndexOf("(") + 1;
            if (baslangic == 0)
            {
                Raporlar.Add(numara + " numaralı Kaynakta; Kişisel Görüşmelerde Görüşülen kişinin isminden sonra tarih gelmelidir.");
                return true;
            }
            int son = kaynak.Substring(baslangic).IndexOf(")");
            string tarih = kaynak.Substring(baslangic, son);
            string[] tarihParca = tarih.Trim().Split(' ');
            if (!(tarihParca.Length == 3 && IsNumeric(tarihParca[0]) && (Array.IndexOf(aylar, tarihParca[1]) > -1) && (tarihParca[2].Length == 4) && IsNumeric(tarihParca[2])))
            {
                Raporlar.Add(numara + " numaralı Kaynakta; Kişisel Görüşmede Tarih Formatı Yanlıştır. Olması Gereken: gün ayadı tarih, Örnek: 01 kasım 2000");
            }
            return returnIt;
        }
        bool kaynakWebSite(string numara, string[] parcaKaynak)
        {
            bool returnIt = false;
            if (parcaKaynak[parcaKaynak.Length - 2].Trim().Replace(":", "") != "erişim")
            {
                Raporlar.Add(numara + " numaralı kaynakta; Eğer bir web sitesinden kaynak alma var ise kaynağın en sonunda erişim tarihi olmak zorundadır. Erişim Tarihini belirtirken 'Erişim: gün-ay-yıl'  ibaresi olmak zorundadır.");
                returnIt = true;
                return returnIt;
            }
            else
            {
                string erisimTarihi = parcaKaynak[parcaKaynak.Length - 1].Trim();
                if (!(erisimTarihi.Length == 8 || erisimTarihi.Length == 9 || erisimTarihi.Length == 10))
                {
                    Raporlar.Add(numara + " numaralı kaynakta; Erişim ibaresinden sonra tarih olmalıdır.Tarih Formatı Yanlıştır. Örnek: Erişim: 15-11-1996");
                    returnIt = true;
                    return returnIt;
                }
            }
            for (int i = 1; i < parcaKaynak.Length; i++)
            {
                string parca = parcaKaynak[i];
                if (parca.IndexOf("http") > -1 || parca.IndexOf("www") > -1)
                {
                    if (i == 1)
                    {
                        Raporlar.Add(numara + " numaralı kaynakta; Web sitesinin linkinden önce yazarın adı ve ya sanal adı olmalıdır.");
                        returnIt = true;
                        break;
                    }
                }
            }
            return returnIt;
        }
        bool kaynakHarita(string numara, string[] parcaKaynak)
        {
            bool returnIt = false;
            Regex rgTarih = new Regex(@"^\([1-9][0-9][0-9][0-9]\)\.$");
            for (int i = 1; i < parcaKaynak.Length; i++)
            {
                string parca = parcaKaynak[i].Trim();
                if (rgTarih.IsMatch(parca))
                {
                    if ((i - 1) == 1)
                    {
                        returnIt = true;
                        Raporlar.Add(numara + " numaralı kaynakta eğer haritadan atıf yapılıyorsa. Kaynağın Başına tarihten önce kurum adı yazılmalıdır.");
                    }
                }
            }
            return returnIt;
        }
        bool kaynakEditor(string numara, string[] parcaKaynak)
        {
            bool returnIt = false;
            Regex rgAralik = new Regex(@"[0-9]\-[0-9]");
            if (!rgAralik.IsMatch(parcaKaynak[parcaKaynak.Length - 1]))
            {
                returnIt = true;
                Raporlar.Add(numara + " numaralı kaynakta eğer editörlü bir kitaba atıf yapılıyor ise kaynağın en sonuna sayfa aralıkları eklenmelidir. Örnek: 121-140");
            }
            return returnIt;
        }
        bool kaynakDergiMakale(string numara, string[] parcaKaynak, string kaynak)
        {
            bool returnIt = false;
            Regex rgCli = new Regex(@"c\.\ [0-9]");
            Regex rgAralik = new Regex(@"[0-9]\-[0-9]");
            bool buldum = false;
            for (int i = 0; i < parcaKaynak.Length; i++)
            {
                string parca = parcaKaynak[i].Trim();
                if (rgCli.IsMatch(parca))
                {
                    buldum = true;
                }
                else if (parca.IndexOf("doi") > -1)
                {
                    buldum = true;
                }
                else if (rgAralik.IsMatch(parca))
                {
                    buldum = true;
                }
            }
            if (rgCli.IsMatch(kaynak.ToLower().Trim()) || rgAralik.IsMatch(kaynak.ToLower().Trim()))
            {
                buldum = true;
            }

            if (!buldum)
            {
                Raporlar.Add(numara + " numaralı kaynakta. Dergi veya Makale atıfı var ise; Cilt Sayısı ve ya doi kodu kaynağa eklenmelidir. Ayrıca sayfa aralıklarınız belliyse o sayfa aralığını eklemelisiniz. Örnek: C. 46(3) ve ya 733-736 ve ya doi:10.1007/s10853-011-5");
                returnIt = true;
            }
            return returnIt;
        }
        bool kaynakIsimKontrol(string numara, string[] parcaKaynak, string bahis)
        {
            bool returnIt = false;
            Regex rgTarih = new Regex(@"^\([1-9][0-9][0-9][0-9]\)\.$");
            bool eksikMi = false;
            for (int i = 1; i < parcaKaynak.Length; i++)
            {
                string parca = parcaKaynak[i].Replace(";", "").Trim();
                if (rgTarih.IsMatch(parca))
                {
                    if (i == 1 || i == 2)
                    {
                        eksikMi = true;
                    }
                    break;
                }
                else
                {
                    if (parca.IndexOf(",") > -1)
                    {
                        if (parca.Length == 2)
                        {
                            Raporlar.Add(numara + " Numaralı Kaynakta " + bahis + " Soyadı Kısaltılamaz ve ya " + bahis + " adının baş harfi Nokta(.) ile kısaltılmalı.");
                            returnIt = true;
                            break;
                        }
                    }
                    else if (parca.IndexOf(".") > -1)
                    {
                        if (parca.Length > 2)
                        {
                            Raporlar.Add(numara + " Numaralı Kaynakta " + bahis + " Adının Sadece Baş Harfi Alınmalı");
                            returnIt = true;
                            break;
                        }
                        else if (parca.Length < 2)
                        {
                            Raporlar.Add(numara + " Numaralı Kaynakta " + bahis + " Adının Baş Harfi Eksiktir. " + bahis + " belirtmek için Kullanılması Gereken Format: Soyad,(virgül) Adının Baş Harfi.(nokta) Örnek: Şişman, A.");
                            returnIt = true;
                            break;
                        }
                    }
                    else
                    {
                        if (parca.Length == 1)
                        {
                            Raporlar.Add(numara + " Numaralı Kaynakta " + bahis + " Soyadı Kısaltılamaz ve ya " + bahis + " adının baş harfi Nokta(.) ile kısaltılmalı. Örnek: Şişman, A.");
                            returnIt = true;
                            break;
                        }
                    }
                }
            }
            if (eksikMi)
            {
                Raporlar.Add(numara + " Numaralı Kaynakta " + bahis + " Soyadı ve ya Adı eksiktir.  " + bahis + " belirtmek için Kullanılması Gereken Format: Soyad,(virgül) Adının Baş Harfi.(nokta) Örnek: Şişman, A.");
                returnIt = true;
            }
            return returnIt;
        }
        bool kaynakTarihKontrol(string numara, string[] parcaKaynak, string bahis)
        {
            bool returnIt = false;
            bool eslesti = false;
            Regex rgTarih = new Regex(@"^\([1-9][0-9][0-9][0-9]\)\.$");
            for (int i = 0; i < parcaKaynak.Length; i++)
            {
                string parca = parcaKaynak[i].Trim();
                if (rgTarih.IsMatch(parca))
                {
                    eslesti = true;
                    break;
                }
            }
            if (!eslesti)
            {
                Raporlar.Add(numara + " Numaralı Kaynakta Eşleşen Tarih Formatı Yoktu ve ya Tarih Formatı Yanlıştır. Tarih " + bahis + " isminden hemen sonra gelmeli. Tarih biçimi örneği: (2020). ");
                returnIt = true;
            }
            return returnIt;
        }
        bool kaynakNumaraKontrol(string numara, string kontrol)
        {
            bool returnIt = false;
            kontrol = kontrol.Trim();
            string kNumara = kontrol.Substring(1, kontrol.Length - 2);
            if (numara != kNumara)
            {
                Raporlar.Add(kNumara + " numaralı kaynakta numaralandırma hatası var. Kaynak numarası olması gereken kaynak numarasıyla eşleşmiyor. Olması Gereken Kaynak Numarası: " + numara);
                returnIt = true;
            }
            return returnIt;
        }
        string kaynakKategoriBul(string kaynak)
        {
            string kategori = "";
            if (KaynakKategoriAra(kaynak, new string[] { "kongre", "konferans", "congress", "conference", "basın", "press" }))//kongresi & konferansı
            {
                kategori = "kongre/konferans";
            }
            else if (KaynakKategoriAra(kaynak, new string[] { "dergi", "makale", "Journal", "pp.", "ss.", "cilt", "doi" }))//dergisi & makalesi
            {
                kategori = "dergi/makale";
            }
            else if (KaynakKategoriAra(kaynak, new string[] { "tez", "thesis", "lisansüstü", "graduate" }))//lisansüstü tezlerden
            {
                kategori = "tez";
            }
            else if (KaynakKategoriAra(kaynak, new string[] { "görüşme", "röportaj", "interview", "reportage" }))//Kişisel görüşmeden alıntı
            {
                kategori = "görüşme";
            }
            else if (KaynakKategoriAra(kaynak, new string[] { "kitab", "kitap", "yayıncılık", "yayın", "book", "publishing", "basım", "ansiklopedi", "encyclopedia", "rapor", "report", "publish" }))//kitapevi & kitabı
            {
                kategori = "kitap";
            }
            else if (KaynakKategoriAra(kaynak, new string[] { "editör", "editor", "publisher", "yayımcı" }))//editörlü kitaptan
            {
                kategori = "editör";
            }
            else if (KaynakKategoriAra(kaynak, new string[] { "patent" }))//patent bildirisi
            {
                kategori = "patent";
            }
            else if (KaynakKategoriAra(kaynak, new string[] { "harita", "chart" }))//harita
            {
                kategori = "harita";
            }
            else if (KaynakKategoriAra(kaynak, new string[] { "http", "www" }))//internet sitesindeki online yayınlardan  Yazarın soyadı, Yazarın adının baş harfi. (Yayınlanma veya güncellenme yılı). Başlık. Cilt,Sayı, Sayfa no, Alınma tarihi, internet adresi
            {
                kategori = "www";
            }
            else
            {
                string[] parcaliKaynak = kaynak.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Regex rgCli = new Regex(@"c\.\ [0-9]");
                bool yok = true;
                for (int j = 0; j < parcaliKaynak.Length; j++)
                {
                    string parca = parcaliKaynak[j].Trim();
                    if (rgCli.IsMatch(parca))
                    {
                        yok = false;
                        kategori = "dergi/makale";
                        break;
                    }
                }
                if (yok)
                {
                    kategori = "kitap";
                }
            }
            return kategori;
        }
        bool KaynakKategoriAra(string kaynak, string[] aramalist)
        {
            bool returnIfade = false;
            for (int i = 0; i < aramalist.Length; i++)
            {
                if (kaynak.IndexOf(aramalist[i]) > -1)
                {
                    returnIfade = true;
                    break;
                }
            }
            return returnIfade;
        }
        bool IsNumeric(string txt)
        {
            bool returnIt = true;
            try { double trying = Convert.ToDouble(txt); }
            catch { returnIt = false; }
            return returnIt;
        }

    }
}
