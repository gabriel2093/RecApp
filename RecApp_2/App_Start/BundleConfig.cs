﻿using System.Web;
using System.Web.Optimization;

namespace RecApp_2
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css",
            //           "~/Content/fullcalendar.css",
            //            "~/Content/fullcalendar.print.css",
            //          "~/Content/custom.css"));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //          "~/Content/themes/base/jquery.ui.core.css",
            //          "~/Content/themes/base/jquery.ui.resizable.css",
            //          "~/Content/themes/base/jquery.ui.selectable.css",
            //          "~/Content/themes/base/jquery.ui.accordion.css",
            //          "~/Content/themes/base/jquery.ui.autocomplete.css",
            //          "~/Content/themes/base/jquery.ui.button.css",
            //          "~/Content/themes/base/jquery.ui.dialog.css",
            //          "~/Content/themes/base/jquery.ui.slider.css",
            //          "~/Content/themes/base/jquery.ui.tabs.css",
            //          "~/Content/themes/base/jquery.ui.datepicker.css",
            //          "~/Content/themes/base/jquery.ui.progressbar.css",
            //          "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                       "~/Scripts/jquery-{version}.js",
                       // needed for drag/move events in fullcalendar
                       "~/Scripts/jquery-ui-{version}.js",
                       //"~/Scripts/lang-all.js",
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/bootstrap-modal.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/modalform").Include(
                        "~/Scripts/modalform.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/site.css",
                    "~/Content/bootstrap.css",
                    "~/Content/Custom.css"
                    ));

            //bundles.Add(new StyleBundle("~/Content/fullcalendarcss").Include(
            //   "~/Content/themes/jquery.ui.all.css",

            //   "~/Content/fullcalendar.css"));

            ////Calendar Script file

            //bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
            //            "~/Scripts/jquery-{version}.js",
            //            "~/Scripts/moment.min.js",
            //            "~/Scripts/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
