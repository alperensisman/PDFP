public class Tez
{
    private string _projeAdi;
    private string _tezSahibi;
    private string _projeTezIcerik;
    private string _projeRaporlar;
    private string _projeIstatistikselBilgiler;
    private string _projeTarih;
    public string projeAdi
    {
        get { return _projeAdi; }
        set { _projeAdi = value; }
    }

    public string tezSahibi
    {
        get { return _tezSahibi; }
        set { _tezSahibi = value; }
    }

    public string projeTezIcerik
    {
        get { return _projeTezIcerik; }
        set { _projeTezIcerik = value; }
    }

    public string projeRaporlar
    {
        get { return _projeRaporlar; }
        set { _projeRaporlar = value; }
    }

    public string IstatistikselBilgiler
    {
        get { return _projeIstatistikselBilgiler; }
        set { _projeIstatistikselBilgiler = value; }
    }

    public string Tarih
    {
        get { return _projeTarih; }
        set { _projeTarih = value; }
    }
}