using NCalc;
using Sigef.Poc.Ftcapp.Entidade;
using System.Linq;
using System.Text;

namespace Sigef.Poc.Ftcapp.Entidade
{
    public class FormulaBuilder
    {


        //public string Run(string math, DBObj VM)
        //{
        //    Expression e = new Expression(GetMathConvert(math, VM));

        //    return e.Evaluate().ToString();

        //}

        //public string GetMathConvert(string teste, DBObj VM)
        //{
        //    StringBuilder result = new StringBuilder();

        //    var listc = VM.SelectedCaso.Comandos;
        //    var list = teste.Split(':');

        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        var item = list[i];
        //        var cmd = listc.FirstOrDefault(e => e.Elemento.Nome == item);
        //        if (cmd != null)
        //        {
        //            list[i] = cmd.Acao;
        //        }
        //    }

        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        var item = list[i];


        //        result.Append(list[i]);
        //    }

        //    return result.ToString();

        //}


    }
}
