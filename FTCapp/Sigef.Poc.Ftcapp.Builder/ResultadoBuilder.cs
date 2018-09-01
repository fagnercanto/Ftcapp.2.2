


namespace Sigef.Poc.Ftcapp.Entidade
{

    public class ResultadoBuilder : BuilderBase
    {




        //public Resultado CriaObjResultado(string nome, string nomeEditavel, int idCaso)
        //{
        //    var rs = new Resultado();

        //    rs.CodigoCaso = idCaso;
        //    rs.Nome = nome;
        //    rs.NomeEditavel = nomeEditavel;
        //    rs.IsRodou = false;
        //    return rs;

        //}

        //public ObservableCollection<Resultado> CriaObjResultados(ObservableCollection<Resultado> current)
        //{
        //    if (current != null && current.Count() > 0)
        //    {
        //        return current;
        //    }
        //    else
        //    {
        //        return new ObservableCollection<Resultado>();

        //    }

        //}






        //public Resultado NewResultado(DBObj VM)
        //{
        //    Resultado Resultado = new Resultado(); ;
        //    if (VM.SelectedCaso.Resultados == null || VM.SelectedCaso.Resultados.Count == 0)
        //    {
        //        VM.SelectedCaso.Resultados = new ObservableCollection<Resultado>();

        //    }


        //    Resultado.CodigoCaso = VM.SelectedCaso.Cod;
        //    Resultado.IsPassou = false;
        //    Resultado.IsRodou = false;
        //    Resultado.Nome = VM.SelectedCaso.Nome;
        //    Resultado.NomeEditavel = VM.SelectedCaso.NomeEditavel;
        //    return Resultado;
        //}




        //public Resultado BuildResultadoComando(Resultado rs, DBObj VM)
        //{
        //    rs.IsRodou = true;
        //    VM.SelectedCaso.IsRodou = true;
        //    bool isMsgErro = !string.IsNullOrEmpty(rs.MSG);
        //    bool isComandoNoPass = rs.Comandos.Where(e => e.IsPassou == false).Count() > 0;

        //    if (isMsgErro || isComandoNoPass)
        //    {
        //        NPassou(rs, VM);
        //    }
        //    else
        //    {
        //        Passou(rs, VM);

        //    }
        //    return rs;
        //}

        //private void NPassou(Resultado rs, DBObj VM)
        //{
        //    rs.IsPassou = false;

        //    VM.SelectedCaso.MSG = rs.MSG;
        //    VM.SelectedCaso.IsPassou = false;
        //}

        //private void Passou(Resultado rs, DBObj VM)
        //{
        //    VM.SelectedCaso.IsPassou = true;
        //    rs.IsPassou = true;
        //    rs.MSG = "Passou";
        //    VM.SelectedCaso.MSG = "Passou";

        //}


    }
}
