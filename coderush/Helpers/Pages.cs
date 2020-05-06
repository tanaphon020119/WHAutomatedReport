using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coderush
{
    public class Pages
    {
        private Pages(string value, string text) { Value = value; Text = text; }

        public string Value { get; set; }
        public string Text { get; set; }

        //Dashboard
        public static Pages Dashboard1 { get { return new Pages("Dashboard1", "Dashboard1"); } }
        public static Pages Dashboard2 { get { return new Pages("Dashboard2", "Dashboard2"); } }
        public static Pages Dashboard3 { get { return new Pages("Dashboard3", "Dashboard3"); } }

        //Report
        public static Pages Report1 { get { return new Pages("Report", "Report"); } }

        public static Pages Report_LPC010 { get { return new Pages("Report_LPC010", "Report_LPC010"); } }
        public static Pages Report_LPC007 { get { return new Pages("Report_LPC007", "Report_LPC007"); } }
        public static Pages Report_LPC004 { get { return new Pages("Report_LPC004", "Report_LPC004"); } }

        public static Pages Report_LPC004_LPC_FIX_ALL_FLEET_SRB { get { return new Pages("Report_LPC004_LPC_FIX_ALL_FLEET_SRB", "ปูนผง สระบุรี"); } }
        public static Pages Report_LPC004_Cement_Bulk_FLEET_LP { get { return new Pages("Report_LPC004_Cement_Bulk_FLEET_LP", "ปูนผง ลำปาง"); } }
        public static Pages Report_LPC004_Cement_Bulk_TS { get { return new Pages("Report_LPC004_Cement_Bulk_TS", "ปูนผง ทุ่งสง"); } }
        public static Pages Report_LPC004_Mortar_Bulk_FLEET_SRB { get { return new Pages("Report_LPC004_Mortar_Bulk_FLEET_SRB", "Mortar สระบุรี"); } }
        public static Pages Report_LPC004_Mortar_Bulk_FLEET_KW { get { return new Pages("Report_LPC004_Mortar_Bulk_FLEET_KW", "Mortar เขาวง"); } }
        public static Pages Report_LPC004_Mortar_Bulk_FLEET_TS { get { return new Pages("Report_LPC004_Mortar_Bulk_FLEET_TS", "Mortar ทุ่งสง"); } }
        public static Pages Report_LPC004_PFA_PPD { get { return new Pages("Report_LPC004_PFA_PPD", "PFA พระประแเดง"); } }
        public static Pages Report_LPC004_Cement_Bulk_PPD { get { return new Pages("Report_LPC004_Cement_Bulk_PPD", "ปูนผง พระประแเดง"); } }
        public static Pages Report_LPC004_Cement_Bulk_SRC { get { return new Pages("Report_LPC004_Cement_Bulk_SRC", "ปูนผง ศรีราชา"); } }
        public static Pages Report_LPC004_KCL { get { return new Pages("Report_LPC004_KCL", "KCL"); } }
        public static Pages Report_LPC004_Fly_Ash { get { return new Pages("Report_LPC004_Fly_Ash", "Fly_Ash"); } }
        public static Pages Report_LPC004_Cement_White_Bulk { get { return new Pages("Report_LPC004_Cement_White_Bulk", "ปูนขาว"); } }
        public static Pages Report_LPC004_Cementh_Rajasri { get { return new Pages("Report_LPC004_Cementh_Rajasri", "ปูนราชสีห์"); } }
        public static Pages Report_LPC004_Barite { get { return new Pages("Report_LPC004_Barite", "แบร์ไรท์"); } }

        public static Pages Report_LPC010_All { get { return new Pages("Report_LPC010_All", "Conso Report"); } }


        //ReportChart
        public static Pages ReportChart1 { get { return new Pages("ReportChart", "ReportChart"); } }

        //Widgets
        public static Pages Widgets { get { return new Pages("Widgets", "Widgets"); } }

        //MailBox
        public static Pages Inbox { get { return new Pages("Inbox", "Inbox"); } }
        public static Pages Compose { get { return new Pages("Compose", "Compose"); } }
        public static Pages Template { get { return new Pages("Template", "Template"); } }

        //Elements
        public static Pages Accordians { get { return new Pages("Accordians", "Accordians"); } }
        public static Pages Buttons { get { return new Pages("Buttons", "Buttons"); } }
        public static Pages Badges { get { return new Pages("Badges", "Badges"); } }
        public static Pages Pagination { get { return new Pages("Pagination", "Pagination"); } }
        public static Pages Cards { get { return new Pages("Cards", "Cards"); } }
        public static Pages Dropdowns { get { return new Pages("Dropdowns", "Dropdowns"); } }
        public static Pages Modal { get { return new Pages("Modal", "Modal"); } }
        public static Pages ProgressBar { get { return new Pages("ProgressBar", "ProgressBar"); } }
        public static Pages BootstrapTabs { get { return new Pages("BootstrapTabs", "BootstrapTabs"); } }
        public static Pages LineTabs { get { return new Pages("LineTabs", "LineTabs"); } }
        public static Pages Typography { get { return new Pages("Typography", "Typography"); } }
        public static Pages Tooltips { get { return new Pages("Tooltips", "Tooltips"); } }
        public static Pages Notifications { get { return new Pages("Notifications", "Notifications"); } }
        public static Pages Thumbnails { get { return new Pages("Thumbnails", "Thumbnails"); } }

        //Miscellaneous
        public static Pages Dragula { get { return new Pages("Dragula", "Dragula"); } }
        public static Pages Clipboard { get { return new Pages("Clipboard", "Clipboard"); } }
        public static Pages ContextMenu { get { return new Pages("ContextMenu", "ContextMenu"); } }
        public static Pages Sliders { get { return new Pages("Sliders", "Sliders"); } }
        public static Pages Carousel { get { return new Pages("Carousel", "Carousel"); } }
        public static Pages Loaders { get { return new Pages("Loaders", "Loaders"); } }

        //Forms
        public static Pages Layouts { get { return new Pages("Layouts", "Layouts"); } }
        public static Pages Controls { get { return new Pages("Controls", "Controls"); } }
        public static Pages Selects { get { return new Pages("Selects", "Selects"); } }
        public static Pages Pickers { get { return new Pages("Pickers", "Pickers"); } }
        public static Pages Editors { get { return new Pages("Editors", "Editors"); } }
        public static Pages FileUpload { get { return new Pages("FileUpload", "FileUpload"); } }
        public static Pages Validation { get { return new Pages("Validation", "Validation"); } }
        public static Pages Wizard { get { return new Pages("Wizard", "Wizard"); } }
        public static Pages DualList { get { return new Pages("DualList", "DualList"); } }

        //Charts
        public static Pages C3 { get { return new Pages("C3", "C3"); } }
        public static Pages Chartist { get { return new Pages("Chartist","Chartist"); } }
        public static Pages ChartJS { get { return new Pages("ChartJS", "ChartJS"); } }
        public static Pages Dygraph { get { return new Pages("Dygraph", "Dygraph"); } }
        public static Pages FlotChart { get { return new Pages("FlotChart", "FlotChart"); } }
        public static Pages Morris { get { return new Pages("Morris", "Morris"); } }
        public static Pages Plottable { get { return new Pages("Plottable", "Plottable"); } }

        //Tables
        public static Pages BasicTable { get { return new Pages("BasicTable", "BasicTable"); } }
        public static Pages DataTable { get { return new Pages("DataTable", "DataTable"); } }

        //Maps
        public static Pages VectorMap { get { return new Pages("VectorMap", "VectorMap"); } }
        public static Pages GoogleMap { get { return new Pages("GoogleMap", "GoogleMap"); } }

        //Icons
        public static Pages MaterialIcon { get { return new Pages("MaterialIcon", "MaterialIcon"); } }
        public static Pages FontAwesomeIcon { get { return new Pages("FontAwesomeIcon", "FontAwesomeIcon"); } }
        public static Pages SimpleIcon { get { return new Pages("SimpleIcon", "SimpleIcon"); } }

        //App
        public static Pages MemberProfile { get { return new Pages("MemberProfile", "MemberProfile"); } }
        public static Pages NewsGrid { get { return new Pages("NewsGrid", "NewsGrid"); } }
        public static Pages FAQ { get { return new Pages("FAQ", "FAQ"); } }
        public static Pages FAQ2 { get { return new Pages("FAQ2", "FAQ2"); } }
        public static Pages Timeline { get { return new Pages("Timeline", "Timeline"); } }
        public static Pages SearchResults { get { return new Pages("SearchResults", "SearchResults"); } }
        public static Pages Portfolio { get { return new Pages("Portfolio", "Portfolio"); } }

        //Ecommerce
        public static Pages Orders { get { return new Pages("Orders", "Orders"); } }
        public static Pages Invoice { get { return new Pages("Invoice", "Invoice"); } }
        public static Pages PricingTable { get { return new Pages("PricingTable", "PricingTable"); } }

        //Auth
        public static Pages Login { get { return new Pages("Login", "Login"); } }
        public static Pages Login2 { get { return new Pages("Login2", "Login2"); } }
        public static Pages Login3 { get { return new Pages("Login3", "Login3"); } }
        public static Pages Register { get { return new Pages("Register", "Register"); } }
        public static Pages Register2 { get { return new Pages("Register2", "Register2"); } }
        public static Pages Register3 { get { return new Pages("Register3", "Register3"); } }

        //Maintenance
        public static Pages LockScreen { get { return new Pages("LockScreen", "LockScreen"); } }
        public static Pages Page404 { get { return new Pages("Page404", "Page404"); } }
        public static Pages Page500 { get { return new Pages("Page500", "Page500"); } }


    }
}
