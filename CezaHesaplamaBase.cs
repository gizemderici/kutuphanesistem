using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutup
{
    public class CezaHesaplamaBase
    {
        public virtual int GecikmeCezasiHesapla(DateTime oduncTarih, int gunFarki)
        {

            return (gunFarki - 10) * 5;


        }
    }
}
