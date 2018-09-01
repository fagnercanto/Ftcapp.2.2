using System;
using Sigef.Poc.Ftcapp.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sigef.Poc.Ftcapp.Entidade
{
    public class Resultado 
    {

        public Resultado()
        {
            DataInicio = DateTime.Now;
            Diferenca = new TimeSpan(1);
        }
        
        public int Id { get; set; }


        public string ScrenShot { get; set; }
        public byte[] ScrenShotBytes { get; set; }

        public string Valor { get; set; }

        public string status;

        public DateTime DataInicio { get; set; }

        public TimeSpan Diferenca { get; set; }

        public string feedBack { get; set; }

    }

}
