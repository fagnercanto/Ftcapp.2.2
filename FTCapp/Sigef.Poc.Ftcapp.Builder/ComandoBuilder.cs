


namespace Sigef.Poc.Ftcapp.Entidade
{
    public class ComandoBuilder : BuilderBase
    {

        ////public ResultadoBuilder _ResultadoBuilder;
        ////public FormulaBuilder _FormulaBuilder;
        //public ElementoBuilder _ElementoBuilder;
        ////public ConceitoBuilder _ConceitoBuilder;
        ////public ComandoBuilder _ComandoBuilder;
        ////public CasoBuilder _CasoBuilder;

        ////public ResultadoBuilder ResultadoBuilder;
        ////public FormulaBuilder FormulaBuilder;
        //public ElementoBuilder ElementoBuilder
        //{
        //    get
        //    {
        //        if (_ElementoBuilder == null)
        //        {
        //            _ElementoBuilder = new ElementoBuilder();
        //        }
        //        return _ElementoBuilder;
        //    }
        //}
        ////public ConceitoBuilder ConceitoBuilder;
        ////public ComandoBuilder ComandoBuilder;
        ////public CasoBuilder CasoBuilder;


        ////public Comando BuildComando(int p1,    bool p2, s      tring p3,     bool p4,      bool p5,         string p6,    string p7, string p8,    string p9,    string p10,     int p11, int p12, object p13, string p14)
        //public Comando BuildComando(bool Selected, string TagName, bool Enabled, bool Displayed, string text, string type, string Acao, string Altura, string Largura, int X, int Y, string ClassName, string ID, DBObj VM, string Label)
        //{
        //    Elemento elemento = ElementoBuilder.BuildElemento(Selected, TagName, Enabled, Displayed,
        //      text, type, Altura, Largura, X, Y, ClassName,
        //      ID, Label);
        //    var comando = new Comando();
        //    comando.Acao = Acao;
        //    comando.Cor = ConstCOR.NORMAL;
        //    ConfigComando(comando);
        //    comando.Elemento = elemento;
        //    return comando;
        //}

        //public Comando BuildComando(Comando cmd, string TagName, string type, string Acao, string ClassName)
        //{

        //    cmd.Acao = Acao;
        //    cmd.Cor = ConstCOR.NORMAL;
        //    cmd.TipoControle = GetTipoControle(TagName, type, ClassName);
        //    cmd.ComandosSugeridos = new ObservableCollection<string>(GetComandosSugeridos(cmd.TipoControle));
        //    cmd.SelectedComandoSugerido = GetSelectedComandosSugeridos(cmd.TipoControle, cmd.ComandosSugeridos);
        //    cmd.Values = new ObservableCollection<string>(GetValues());

        //    return cmd;
        //}



        //private void ConfigComando(Comando comando)
        //{
        //    //comando.TipoControle = GetTipoControle(comando);
        //    //comando.ComandosSugeridos = new ObservableCollection<string>(GetComandosSugeridos(comando.TipoControle));
        //    //comando.SelectedComandoSugerido = GetSelectedComandosSugeridos(comando.TipoControle, comando.ComandosSugeridos);
        //    //comando.Values = new ObservableCollection<string>(GetValues());

        //}

        //public List<Comando> ConfigComandos(List<Comando> ComandoLista, DBObj VM)
        //{
        //    foreach (var item in ComandoLista)
        //    {
        //        item.Elemento.IsCampoPesquisa = item.Elemento.ClassName == ConstClassName.SIGEFPesquisa_INPUT;
        //        item.Elemento.IsObrigatorio = item.Elemento.Nome.Contains("*");

        //        var comandosNomesIguais = ComandoLista.Where(e => e.Elemento.Nome == item.Elemento.Nome).ToList();

        //        if (CollectionUtil.IsNullOrEmptyReturnCount<Comando>(comandosNomesIguais) > 1)
        //        {
        //            var Cod = ComandoLista.Max(a => a.Elemento.CodigoComandoComposto);
        //            Cod = Cod++;
        //            foreach (var comandoComposto in comandosNomesIguais)
        //            {

        //                comandoComposto.Elemento.IsComposto = true;
        //                comandoComposto.Elemento.CodigoComandoComposto = Cod;
        //            }
        //        }

        //        //item.Elemento.Nome = FormatNome(item.Elemento.Nome, VM, item.Cod);
        //    }

        //    return ComandoLista;
        //}

        //private string GetSelectedComandosSugeridos(string p, ObservableCollection<string> ComandosSugeridos)
        //{
        //    string result = "";
        //    switch (p)
        //    {
        //        case ConstControlTypeUI.TYPE_CHECKBOX:
        //            result = ConstActionCommand.ACTION_CHECK;
        //            break;
        //        case ConstControlTypeUI.TYPE_COMBOBOX:
        //            result = ConstActionCommand.ACTION_SELECT;

        //            break;
        //        case ConstControlTypeUI.TYPE_TEXTBOX:
        //            result = ConstActionCommand.ACTION_INSERT;

        //            break;
        //        case ConstControlTypeUI.TYPE_BUTTON:
        //            result = ConstActionCommand.ACTION_CLICK;

        //            break;
        //        default:
        //            break;
        //    }
        //    return result;
        //}

        //private ObservableCollection<string> GetValues()
        //{
        //    ObservableCollection<string> result = new ObservableCollection<string>();

        //    result.Add(ConstSugestionValue.Assertion_Value_FALSE);
        //    result.Add(ConstSugestionValue.Assertion_Value_TRUE);

        //    return result;
        //}

        //private ObservableCollection<string> GetComandosSugeridos(string p)
        //{
        //    ObservableCollection<string> result = new ObservableCollection<string>();
        //    switch (p)
        //    {
        //        case ConstControlTypeUI.TYPE_CHECKBOX:
        //            result.Add(ConstActionCommand.ACTION_CHECK);
        //            result.Add(ConstAssertionValueCommand.UI_VALUE_CHECKED);
        //            result.Add(ConstValidationCommand.IS_VISIBLE);
        //            result.Add(ConstValidationCommand.IS_ENABLE);
        //            result.Add(ConstValidationCommand.IS_CHECKED);

        //            break;
        //        case ConstControlTypeUI.TYPE_COMBOBOX:
        //            result.Add(ConstActionCommand.ACTION_SELECT);
        //            result.Add(ConstAssertionValueCommand.UI_VALUE_CONTAINS);
        //            result.Add(ConstAssertionValueCommand.UI_VALUE_IGUAL);
        //            result.Add(ConstAssertionValueCommand.UI_VALUE_MAIOR);
        //            result.Add(ConstValidationCommand.IS_VISIBLE);
        //            result.Add(ConstValidationCommand.IS_ENABLE);
        //            break;
        //        case ConstControlTypeUI.TYPE_TEXTBOX:
        //            result.Add(ConstActionCommand.ACTION_INSERT);
        //            result.Add(ConstAssertionValueCommand.UI_VALUE_CHECKED);
        //            result.Add(ConstAssertionValueCommand.UI_VALUE_CONTAINS);
        //            result.Add(ConstAssertionValueCommand.UI_VALUE_MAIOR);
        //            result.Add(ConstValidationCommand.IS_VISIBLE);
        //            result.Add(ConstValidationCommand.IS_ENABLE);
        //            result.Add(ConstControlTypeUI.TYPE_FORMULA);
        //            break;
        //        case ConstControlTypeUI.TYPE_BUTTON:
        //            result.Add(ConstActionCommand.ACTION_CLICK);
        //            result.Add(ConstAssertionValueCommand.UI_VALUE_CHECKED);
        //            result.Add(ConstValidationCommand.IS_VISIBLE);
        //            result.Add(ConstValidationCommand.IS_ENABLE);
        //            break;
        //        case ConstControlTypeUI.TYPE_VARIAVEL:
        //            result.Add(ConstAssertionUIVariavelCommand.UI_CASO);
        //            result.Add(ConstAssertionUIVariavelCommand.UI_FORMULA);
        //            break;
        //        case ConstControlTypeUI.TYPE_MSG:
        //            result.Add(ConstAssertionValueCommand.UI_VALUE_CONTAINS);
        //            result.Add(ConstValidationCommand.IS_VISIBLE);
        //            result.Add(ConstValidationCommand.IS_ENABLE);
        //            result.Add(ConstControlTypeUI.TYPE_FORMULA);
        //            break;
        //        case ConstControlTypeUI.TYPE_PESQUISA:
        //            result.Add(ConstActionCommand.ACTION_CLICK);
        //            result.Add(ConstValidationCommand.IS_VISIBLE);
        //            result.Add(ConstValidationCommand.IS_ENABLE);
        //            break;
        //        default:
        //            break;
        //    }
        //    return result;
        //}



        //private string GetTipoControle(Comando cmd)
        //{

        //    string tagName = cmd.Elemento.TagName;
        //    string type = cmd.Elemento.Type;
        //    string className = cmd.Elemento.ClassName;

        //    string result = "";
        //    if (className.Equals(ConstClassName.SIGEFMensagemSucesso) || className.Equals(ConstClassName.SIGEFMensagemErro))
        //    {
        //        result = ConstControlTypeUI.TYPE_MSG;
        //    }
        //    else if (className.Equals(ConstClassName.SIGEFPesquisa_INPUT))
        //    {
        //        result = ConstControlTypeUI.TYPE_PESQUISA;
        //    }
        //    else
        //    {

        //        if (tagName == "input")
        //        {
        //            if (type == "text")
        //            {
        //                result = ConstControlTypeUI.TYPE_TEXTBOX;
        //            }
        //            if (type == "checkbox")
        //            {
        //                result = ConstControlTypeUI.TYPE_CHECKBOX;
        //            }
        //            if (type == "image")
        //            {
        //                result = ConstControlTypeUI.TYPE_BUTTON;
        //            }
        //        }
        //        else if (tagName == "img" || tagName == "a")
        //        {
        //            result = ConstControlTypeUI.TYPE_BUTTON;
        //        }
        //        else if (tagName == "select")
        //        {
        //            result = ConstControlTypeUI.TYPE_COMBOBOX;
        //        }

        //    }

        //    return result;
        //}

        //public string FormatNome(string Label, DBObj VM, int idComando)
        //{
        //    if (Label == null)
        //    {
        //        return "";
        //    }
        //    if (idComando > 0)
        //    {
        //        Label = Label + "[" + idComando + "]";
        //    }

        //    return Label;
        //}

        //public ObservableCollection<Comando> LimpaComandos(ObservableCollection<Comando> observableCollection)
        //{



        //    observableCollection.ToList().ForEach(
        //       e =>
        //       {
        //           LimpaComando(e);
        //       }

        //       );

        //    return observableCollection;
        //}

        //public ObservableCollection<Comando> RetiraComandosErro(ObservableCollection<Comando> observableCollection)
        //{
        //    var noactions = observableCollection.Where(e => e.SelectedComandoSugerido == ConstActionCommand.ACTION_NO);
        //    if (noactions != null && noactions.Count() > 0)
        //    {
        //        noactions.ToList().ForEach(
        //        e =>
        //        {
        //            observableCollection.Remove(e);

        //        }

        //        );
        //    }

        //    return observableCollection;
        //}

        //public void LimpaComando(Comando e)
        //{
        //    e.Acao = "";
        //    e.Cor = ConstCOR.NORMAL;
        //    e.IsPassou = false;
        //}


        //public Comando GetDefaultSelectedComando(DBObj VM)
        //{
        //    Comando selected = null;
        //    if (VM.SelectedCaso.Comandos != null)
        //    {
        //        selected = VM.SelectedCaso.Comandos.FirstOrDefault();

        //    }

        //    return selected;
        //}


        //public Comando CreateNewComando(DBObj pVM, Comando newComando)
        //{


        //    if (pVM.SelectedCaso != null && pVM.SelectedCaso.Comandos != null && pVM.SelectedCaso.Comandos.Count > 0)
        //    {
        //        newComando.TipoControle = ConstControlTypeUI.TYPE_VARIAVEL;
        //        newComando.ComandosSugeridos = GetComandosSugeridos(newComando.TipoControle);
        //    }

        //    return newComando;

        //}


        ///*bool Selected, string TagName, bool Enabled, bool Displayed, string text, string type, string Acao, string Altura, string Largura, int X, int Y, string ClassName, string ID, DBObj VM, string Label*/
        //public void BuildComando(bool p1, string p2, bool p3, object p4, string p5, string p6, string p7, string p8, string p9, int p10, int p11, string p12, string p13, DBObj VM, string p14)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
