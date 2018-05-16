using System.Web.Optimization;

namespace Loja.Mvc
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/datejs.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/methods_pt.js",
                        "~/Validacoes/idadeMinima.js"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                        //~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
                        "~/Scripts/Inputmask/inputmask.js",
                        "~/Scripts/Inputmask/jquery.inputmask.js",
                        "~/Scripts/Inputmask/inputmask.extensions.js",
                        "~/Scripts/Inputmask/inputmask.date.extensions.js",
                        //and other extensions you want to include
                        "~/Scripts/Inputmask/inputmask.numeric.extensions.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/flags.css",
                      "~/Content/site.css"));
        }
    }
}