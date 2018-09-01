namespace Sigef.Poc.Ftcapp.DB.Migrations
{
    using Sigef.Poc.Ftcapp.Entidade;
    using Sigef.Poc.Ftcapp.Entidade.Const;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Sigef.Poc.Ftcapp.DB.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Sigef.Poc.Ftcapp.DB.DataContext context)
        {








           

            //var cmdPagina = ADDCMD("Pagina Login", "", ConstControlTypeUI.TYPE_PAGINA, ConstActionCommand.ACTION_GO_TO, "http://flnserv013/sigef/SIGEFPortal.html?p=1");


            

            //var cmdframe = ADDCMD(
            //    "iframe",
            //    "",
            //    ConstControlTypeUI.TYPE_IFRAME,
            //    ConstActionCommand.ACTION_SWITCH_TO_FRAME,
            //    "//iframe");



            ///*
            //  * SENHA
            //  * */

            //var senha = ADDCMD(
            //    "SENHA",
            //    "txtSenha",
            //    ConstControlTypeUI.TYPE_TEXTBOX,
            //    ConstActionCommand.ACTION_INSERT,
            //    "123");



            ///*
            // * CPF
            // * */

            //var cpf = ADDCMD(
            //    "CPF",
            //    "txtCPF",
            //    ConstControlTypeUI.TYPE_TEXTBOX,
            //    ConstActionCommand.ACTION_INSERT,
            //    "04088701925");



            ///*
            // * ENVIAR
            // * */

            //var enviar = ADDCMD(
            //    "enviar",
            //    "txtCPF",
            //    ConstControlTypeUI.TYPE_BUTTON,
            //    ConstActionCommand.ACTION_CLICK,
            //    "");



            ///*
            // * IR PARA PAGINA PRINCIPAL
            // * */

            //var last = ADDCMD(
            //    "Swith",
            //    "",
            //    ConstControlTypeUI.TYPE_PAGINA,
            //    ConstActionCommand.ACTION_SWITCH_TO_LAST,
            //    "");



            //Caso casoLogin = new Caso();
            //casoLogin.Data = DateTime.Now;
            //casoLogin.Nome = "Login";


            //casoLogin.ComandoLista.Add(cmdPagina);
            //casoLogin.ComandoLista.Add(cmdframe);
            //casoLogin.ComandoLista.Add(senha);
            //casoLogin.ComandoLista.Add(cpf);
            //casoLogin.ComandoLista.Add(enviar);
            //casoLogin.ComandoLista.Add(last);
            //Suite suite = new Suite();
            //suite.Nome = "Suite Login";
            //suite.CasoLista.Add(casoLogin);
            //context.Suites.Add(suite);

            /*
            Professor professor2 = new Professor();
            professor2.Nome = "Professor Dois";

            Curso curso1 = new Curso();
            curso1.Numero = "70-480";
            curso1.Descricao = "Programming in HTML5 with JavaScript and CSS3";
            curso1.ProfessorLista.Add(professor1);
            curso1.ProfessorLista.Add(professor2);

            Curso curso2 = new Curso();
            curso2.Numero = "70-486";
            curso2.Descricao = "Developing ASP.NET MVC 4 Web Applications";
            curso2.ProfessorLista.Add(professor2);

            context.Cursos.Add(curso1);
            context.Cursos.Add(curso2);
            */
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<TEntity>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

        //private Comando ADDCMD(string elNome, string elcodigo, string elTipocontrole, string valor, string valorElemento)
        //{

        //    Comando cmd = new Comando();
        //    Elemento el = new Elemento();
        //    Resultado rs = new Resultado();
        //    rs.DataInicio = DateTime.Now;
        //    rs.Diferenca = new TimeSpan(4);
        //    rs.feedBack = elNome + elcodigo;
        //    el.Nome = elNome;
        //    el.CodigoUi = elcodigo;
        //    el.TipoControle = elTipocontrole;

        //    cmd.Acao = valor;
        //    cmd.ValorElemento = valorElemento;

        //    //ADD
        //    cmd.Elemento = el;
        //    cmd.Resultado = rs;
        //    return cmd;
        //}

    }
}
