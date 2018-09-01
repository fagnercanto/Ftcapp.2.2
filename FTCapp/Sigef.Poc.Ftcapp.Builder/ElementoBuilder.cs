


using Sigef.Poc.Ftcapp.Entidade.Const;
using System.Collections.Generic;

namespace Sigef.Poc.Ftcapp.Entidade
{
    public class ElementoBuilder : BuilderBase
    {

        //public Elemento BuildElemento(bool Selected, string TagName, bool Enabled, bool Displayed,
        //    string text, string type, string Altura, string Largura, int X, int Y, string ClassName,
        //    string ID, string Label)
        //{
        //    var elemento = new Elemento();
        //    elemento.Nome = Label;
        //    elemento.CodigoUi = ID;
        //    elemento.ClassName = ClassName;
        //    elemento.Altura = Altura;
        //    elemento.Largura = Largura;
        //    elemento.X = X.ToString();
        //    elemento.Y = Y.ToString();
        //    elemento.Type = type;
        //    elemento.Displayed = Displayed;
        //    elemento.Enabled = Enabled;
        //    elemento.Selected = Selected;
        //    elemento.TagName = TagName;
        //    elemento.Text = text;
        //    elemento.TipoControle = GetTipoControle(TagName, type, ClassName);
        //    return elemento;
        //}

        public Elemento BuildElemento(Elemento elemento, bool Selected, string TagName, bool Enabled, bool Displayed,
            string text, string type, string Altura, string Largura, int X, int Y, string ClassName,
            string ID, string Label,string onclick,bool isGrid, bool isCampoPesquisa,string tabIndex)
        {
            elemento.Nome = Label!=null?Label:"";
            elemento.CodigoUi = ID != null ? ID : "";
            elemento.ClassName = ClassName != null ? ClassName : "";
            elemento.Altura = Altura != null ? Altura : "";
            elemento.Largura = Largura != null ? Largura : "";
            elemento.X = X.ToString();
            elemento.Y = Y.ToString();
            elemento.Type = type != null ? type : "";
            elemento.Displayed = Displayed;
            elemento.Enabled = Enabled;
            elemento.Selected = Selected;
            elemento.TagName = TagName != null ? TagName : "";
            elemento.Text = text != null ? text : "";
            elemento.onclick = onclick != null ? onclick : "";
            elemento.IsObrigatorio = Label != null ? Label.Contains("*") : false;
            elemento.IsCampoPesquisa = isCampoPesquisa;
            elemento.isGrid = isGrid;
            elemento.IsBtnPesquisa = ID.Contains("BtnPesquisa");
            elemento.OptionValues = GetOptionsSugeridos(elemento.TipoControle);
            elemento.TabIndex = tabIndex;
            elemento.TipoControle = GetTipoControle(TagName, type, ClassName, tabIndex, elemento.CodigoUi);
            return elemento;
        }

        private string GetTipoControle(string tagName, string type, string className, string Tabindex, string codigou)
        {
            string result = "";
            if (className.Equals(ConstClassName.SIGEFMensagemSucesso) || className.Equals(ConstClassName.SIGEFMensagemErro))
            {
                result = ConstControlTypeUI.TYPE_MSG;
            }
            else if (tagName == "a")
            {
                result = ConstControlTypeUI.TYPE_LINK;
            }
            else if (tagName == "iframe")
            {

            }
            else if (codigou.Contains("_BtnPesquisa") && type != "text")
            {
                result = ConstControlTypeUI.TYPE_PESQUISA;
            }
            else if (className.Equals(ConstClassName.SIGEFPesquisa_INPUT) && type == "text" && tagName == "input")
            {
                result = ConstControlTypeUI.TYPE_TEXTBOX_PESQUISA;
            }
            else if (className.Contains("GridLinha")) {
                result = ConstControlTypeUI.TYPE_CELL_GRID;
            }
            else
            {

                if (tagName == "input")
                {
                    if (type == "text" || type == "password")
                    {
                        result = ConstControlTypeUI.TYPE_TEXTBOX;
                    }
                    if (type == "checkbox")
                    {
                        result = ConstControlTypeUI.TYPE_CHECKBOX;
                    }
                    if (type == "image")
                    {
                        if (Tabindex != null && Tabindex!="")
                        {
                            result = ConstControlTypeUI.TYPE_TAB;
                        }
                        else {
                            result = ConstControlTypeUI.TYPE_BUTTON;
                        }
                        
                    }
                }
                else if (tagName == "img" || tagName == "a" || tagName == "button")
                {
                    result = ConstControlTypeUI.TYPE_BUTTON;
                }
                else if (tagName == "select")
                {
                    result = ConstControlTypeUI.TYPE_COMBOBOX;
                }
                else if (tagName == "textarea")
                {
                    result = ConstControlTypeUI.TYPE_TEXTBOX;
                }

            }

            return result;
        }

        public static string GetLabel(string Id)
        {
            string result = "";
            if (Isbotao(Id))
            {
                result = Id.Replace("btnManutencao_", "");
            }

            if (result == "")
            {
                result = Id;
            }
            return result;
        }
        private static bool Isbotao(string id)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(id) && id.ToUpper().Contains("btnManutencao".ToUpper()))
            {
                result = true;
            }

            return result;
        }

        private List<ValorSugestao> GetOptionsSugeridos(string p)
        {
            List<ValorSugestao> result = new List<ValorSugestao>();
            switch (p)
            {
                case ConstControlTypeUI.TYPE_CHECKBOX:
                    result.Add(new ValorSugestao{ valor = ConstActionCommand.ACTION_CHECK});
                    result.Add(new ValorSugestao { valor = ConstAssertionValueCommand.UI_VALUE_CHECKED });
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_VISIBLE});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_ENABLE});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_CHECKED});

                    break;
                case ConstControlTypeUI.TYPE_COMBOBOX:
                    result.Add(new ValorSugestao{ valor = ConstActionCommand.ACTION_SELECT});
                    result.Add(new ValorSugestao{ valor = ConstAssertionValueCommand.UI_VALUE_CONTAINS});
                    result.Add(new ValorSugestao{ valor = ConstAssertionValueCommand.UI_VALUE_IGUAL});
                    result.Add(new ValorSugestao{ valor = ConstAssertionValueCommand.UI_VALUE_MAIOR});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_VISIBLE});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_ENABLE});
                    break;
                case ConstControlTypeUI.TYPE_TEXTBOX:
                    result.Add(new ValorSugestao{ valor = ConstActionCommand.ACTION_INSERT});
                    result.Add(new ValorSugestao{ valor = ConstAssertionValueCommand.UI_VALUE_CHECKED});
                    result.Add(new ValorSugestao{ valor = ConstAssertionValueCommand.UI_VALUE_CONTAINS});
                    result.Add(new ValorSugestao{ valor = ConstAssertionValueCommand.UI_VALUE_MAIOR});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_VISIBLE});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_ENABLE});
                    result.Add(new ValorSugestao{ valor = ConstControlTypeUI.TYPE_FORMULA});
                    break;
                case ConstControlTypeUI.TYPE_TEXTBOX_PESQUISA:
                    result.Add(new ValorSugestao { valor = ConstActionCommand.ACTION_INSERT });
                    result.Add(new ValorSugestao { valor = ConstAssertionValueCommand.UI_VALUE_CHECKED });
                    result.Add(new ValorSugestao { valor = ConstAssertionValueCommand.UI_VALUE_CONTAINS });
                    result.Add(new ValorSugestao { valor = ConstAssertionValueCommand.UI_VALUE_MAIOR });
                    result.Add(new ValorSugestao { valor = ConstValidationCommand.IS_VISIBLE });
                    result.Add(new ValorSugestao { valor = ConstValidationCommand.IS_ENABLE });
                    result.Add(new ValorSugestao { valor = ConstControlTypeUI.TYPE_FORMULA });
                    break;
                case ConstControlTypeUI.TYPE_BUTTON:
                    result.Add(new ValorSugestao{ valor = ConstActionCommand.ACTION_CLICK});
                    result.Add(new ValorSugestao{ valor = ConstAssertionValueCommand.UI_VALUE_CHECKED});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_VISIBLE});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_ENABLE});
                    break;
                case ConstControlTypeUI.TYPE_VARIAVEL:
                    result.Add(new ValorSugestao{ valor = ConstAssertionUIVariavelCommand.UI_CASO});
                    result.Add(new ValorSugestao{ valor = ConstAssertionUIVariavelCommand.UI_FORMULA});
                    break;
                case ConstControlTypeUI.TYPE_MSG:
                    result.Add(new ValorSugestao{ valor = ConstAssertionValueCommand.UI_VALUE_CONTAINS});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_VISIBLE});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_ENABLE});
                    result.Add(new ValorSugestao{ valor = ConstControlTypeUI.TYPE_FORMULA});
                    break;
                case ConstControlTypeUI.TYPE_PESQUISA:
                    result.Add(new ValorSugestao{ valor = ConstActionCommand.ACTION_CLICK});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_VISIBLE});
                    result.Add(new ValorSugestao{ valor = ConstValidationCommand.IS_ENABLE});
                    break;
                default:
                    break;
            }
            return result;
        }


































    }
}
