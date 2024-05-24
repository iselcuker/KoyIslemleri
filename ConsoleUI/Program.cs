using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        //GelirManager gelirManager = new GelirManager(new EfGelirDal());

        //foreach (var gelir in gelirManager.GetGelirDetails())
        //{
        //    Console.WriteLine(gelir.GelirId+"/"+gelir.KoyAdi + "/" +gelir.DonemAdi + "/" +gelir.GelirKategorAdi + "/" +gelir.Tutar + "/" +gelir.EvrakNo + "/" +gelir.Veren);
        //}

        //EkButceGiderManager ekButceGiderManager = new EkButceGiderManager(new EfEkButceGiderDal());

        //foreach (var ekButceGider in ekButceGiderManager.GetEkButceGiderDetails())
        //{
        //    Console.WriteLine(ekButceGider.EkButceGiderId + "/" + ekButceGider.KoyAdi + "/" + ekButceGider.DonemAdi + "/" + ekButceGider.EkGiderTutari);
        //}

        IlceManager ilceManager = new IlceManager(new EfIlceDal());

        foreach (var ilceler in ilceManager.GetAll())
        {
            Console.WriteLine(ilceler.IlceAdi);
        }
    }
}