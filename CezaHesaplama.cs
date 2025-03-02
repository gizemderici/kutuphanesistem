using System;

namespace kutup
{

    public class CezaHesaplama:CezaHesaplamaBase
    {
        public override int GecikmeCezasiHesapla(DateTime oduncTarih, int gunFarki)
        {

            MessageBox.Show("GÖREVLİYE GİDİNİZ!");
           
            
            
                return (gunFarki - 10) * 5;
            
            

        }
    }
}

