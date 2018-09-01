using System;

namespace Sigef.Poc.Ftcapp.Entidade.Commands
{
    public class ConfigCommands : BaseModelCommand
    {

        public ConfigCommands()
        {

        }

        //public override bool CanExecute(object parameter)
        //{
        //    return true ;

        //}


        //public void Execute(Comando e)
        //{

        //    ConfiguraUserControllerValorComando(e);
        //}

        //public override void Execute(object parameter)
        //{

        //   var c =  (ObservableCollection<Comando>)parameter;

        //    ObservableCollection<Comando> ocs = c;
        //    ocs.ToList().ForEach(e=>ConfiguraTipoControle(e));
        //    ocs.ToList().ForEach(e => ConfiguraComboBoxComandosTipo(e));
        //    ocs.ToList().ForEach(e => ConfiguraUserControllerValorComando(e));
        //}


        //private static void ConfiguraTipoControle(Sigef.Poc.Ftcapp.Entidade;.Comando cmd)
        //{
        //    cmd.ComandosTipo = new ObservableCollection<ComandoUITipo>();
        //    if (cmd.Elemento.TagName == "input" && cmd.Elemento.Type == "image") {
        //        cmd.TipoControle = Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_BUTTON;
        //    }

        //    if (cmd.Elemento.TagName == "input" && cmd.Elemento.Type == "button")
        //    {
        //        cmd.TipoControle = Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_BUTTON;
        //    }

        //    if (cmd.Elemento.TagName == "input" && cmd.Elemento.Type == "text")
        //    {
        //        cmd.TipoControle = Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_TEXTBOX;
        //    }

        //    if (cmd.Elemento.TagName == "select" )
        //    {
        //        cmd.TipoControle = Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_COMBOBOX;
        //    }

        //    if (cmd.Elemento.TagName == "input" && cmd.Elemento.Type == "checkbox")
        //    {
        //        cmd.TipoControle = Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_CHECKBOX;
        //    }

        //}

        //private static void ConfiguraComboBoxComandosTipo(Sigef.Poc.Ftcapp.Entidade;.Comando cmd)
        //{


        //    switch (cmd.TipoControle)
        //    {
        //        case Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_BUTTON:
        //            ConfiguraComboBoxComandoBTN(cmd);
        //            cmd.ComandoTipoSelecionado = Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_BTN;
        //            cmd.ValueText = Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOF_BUTTON;
        //            break;
        //        case Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_COMBOBOX:
        //            ConfiguraComboBoxComandoCOMBOBOX(cmd);
        //            break;
        //        case Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_CHECKBOX:
        //            cmd.ComandosTipo = ConfiguraComboBoxComandoCHECKBOX(cmd);
        //            break;
        //        case Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_TEXTBOX:

        //            ConfiguraComboBoxComandoTEXTBOX(cmd);
        //            break;

        //    }
        //}
        //private static ObservableCollection<ComandoUITipo> ConfiguraComboBoxComandoCHECKBOX(Comando cmd)
        //{
        //    var lt = cmd.ComandosTipo;
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_CHECKBOX);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_CHECKED);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_UNCHECKED);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_ENABLE);

        //    return lt;
        //}

        //private static void ConfiguraComboBoxComandoBTN(Comando cmd)
        //{
        //    var lt = cmd.ComandosTipo;

        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_BTN);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_ENABLE);


        //}

        //private static void ConfiguraComboBoxComandoTEXTBOX(Comando cmd)
        //{
        //    var lt = cmd.ComandosTipo;

        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_TEXTBOX);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_ENABLE);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_MAIOR);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_CONTAIS);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_IGUAL);

        //    cmd.ComandoTipoSelecionado = Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_TEXTBOX;

        //}

        //private static void ConfiguraComboBoxComandoCOMBOBOX(Comando cmd)
        //{
        //    var lt = cmd.ComandosTipo;

        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_TEXTBOX);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_ENABLE);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_MAIOR);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_CONTAIS);
        //    lt.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_IGUAL);

        //    cmd.ComandoTipoSelecionado = Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPO_TEXTBOX;

        //}

        //private static void ConfiguraUserControllerValorComando(Sigef.Poc.Ftcapp.Entidade;.Comando cmd)
        //{
        //    cmd.Values = new ObservableCollection<string>();
        //    switch (cmd.ComandoTipoSelecionado.Selenium)
        //    {

        //        case Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_ENABLE:
        //            cmd.Values.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.VALUEF_TRUE);
        //            cmd.Values.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.VALUEF_FALSE);
        //            cmd.Values = new ObservableCollection<string>(cmd.Values);
        //            cmd.ValueText = cmd.Values.FirstOrDefault();
        //            cmd.SelectedValue = cmd.Values.FirstOrDefault();
        //            break;
        //        case Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_MAIOR:
        //            //cmd.TemplateValorUserController = Sigef.Poc.Ftcapp.Entidade;.Const.ConstComandoUITipo.TEMPLATE_COMBOBOX;
        //            break;
        //        case Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_CHECKBOX:
        //            cmd.Values.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.VALUEF_TRUE);
        //            cmd.Values.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.VALUEF_FALSE);
        //            cmd.Values = new ObservableCollection<string>(cmd.Values);
        //            cmd.ValueText = cmd.Values.FirstOrDefault();
        //            cmd.SelectedValue = cmd.Values.FirstOrDefault();
        //            break;
        //        case Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_TEXTBOX:
        //            //cmd.TemplateValorUserController = Sigef.Poc.Ftcapp.Entidade;.Const.ConstComandoUITipo.TEMPLATE_TEXTBOX;
        //            break;
        //        case Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.TIPOC_BUTTON:
        //            cmd.Values.Add(Sigef.Poc.Ftcapp.Entidade;.Const.ConstActionCommand.VALUEF_TRUE);
        //            cmd.Values = new ObservableCollection<string>(cmd.Values);
        //            cmd.ValueText = cmd.Values.FirstOrDefault();
        //            cmd.SelectedValue = cmd.Values.FirstOrDefault();
        //            break;

        //    }

        //}


        //internal void Execute(ObservableCollection<Comando> _Comandos, ObservableCollection<Comando> _ComandosTodos)
        //{
        //    var c = _Comandos;

        //    ObservableCollection<Comando> ocs = c;
        //    ocs.ToList().ForEach(e => ConfiguraTipoControle(e));
        //    ocs.ToList().ForEach(e => ConfiguraComboBoxComandosTipo(e));
        //    ocs.ToList().ForEach(e => ConfiguraUserControllerValorComando(e));



        //}

        public override bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }


}
