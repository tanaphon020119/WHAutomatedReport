using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coderush
{
    public class Pages
    {
        private Pages(string value) { Value = value; }

        public string Value { get; set; }

        //Dashboard
        public static Pages Dashboard1 { get { return new Pages("Dashboard1"); } }
        public static Pages Dashboard2 { get { return new Pages("Dashboard2"); } }
        public static Pages Dashboard3 { get { return new Pages("Dashboard3"); } }

        //Widgets
        public static Pages Widgets { get { return new Pages("Widgets"); } }

        //MailBox
        public static Pages Inbox { get { return new Pages("Inbox"); } }
        public static Pages Compose { get { return new Pages("Compose"); } }
        public static Pages Template { get { return new Pages("Template"); } }

        //Elements
        public static Pages Accordians { get { return new Pages("Accordians"); } }
        public static Pages Buttons { get { return new Pages("Buttons"); } }
        public static Pages Badges { get { return new Pages("Badges"); } }
        public static Pages Pagination { get { return new Pages("Pagination"); } }
        public static Pages Cards { get { return new Pages("Cards"); } }
        public static Pages Dropdowns { get { return new Pages("Dropdowns"); } }
        public static Pages Modal { get { return new Pages("Modal"); } }
        public static Pages ProgressBar { get { return new Pages("ProgressBar"); } }
        public static Pages BootstrapTabs { get { return new Pages("BootstrapTabs"); } }
        public static Pages LineTabs { get { return new Pages("LineTabs"); } }
        public static Pages Typography { get { return new Pages("Typography"); } }
        public static Pages Tooltips { get { return new Pages("Tooltips"); } }
        public static Pages Notifications { get { return new Pages("Notifications"); } }
        public static Pages Thumbnails { get { return new Pages("Thumbnails"); } }

        //Miscellaneous
        public static Pages Dragula { get { return new Pages("Dragula"); } }
        public static Pages Clipboard { get { return new Pages("Clipboard"); } }
        public static Pages ContextMenu { get { return new Pages("ContextMenu"); } }
        public static Pages Sliders { get { return new Pages("Sliders"); } }
        public static Pages Carousel { get { return new Pages("Carousel"); } }
        public static Pages Loaders { get { return new Pages("Loaders"); } }

        //Forms
        public static Pages Layouts { get { return new Pages("Layouts"); } }
        public static Pages Controls { get { return new Pages("Controls"); } }
        public static Pages Selects { get { return new Pages("Selects"); } }
        public static Pages Pickers { get { return new Pages("Pickers"); } }
        public static Pages Editors { get { return new Pages("Editors"); } }
        public static Pages FileUpload { get { return new Pages("FileUpload"); } }
        public static Pages Validation { get { return new Pages("Validation"); } }
        public static Pages Wizard { get { return new Pages("Wizard"); } }
        public static Pages DualList { get { return new Pages("DualList"); } }

        //Charts
        public static Pages C3 { get { return new Pages("C3"); } }
        public static Pages Chartist { get { return new Pages("Chartist"); } }
        public static Pages ChartJS { get { return new Pages("ChartJS"); } }
        public static Pages Dygraph { get { return new Pages("Dygraph"); } }
        public static Pages FlotChart { get { return new Pages("FlotChart"); } }
        public static Pages Morris { get { return new Pages("Morris"); } }
        public static Pages Plottable { get { return new Pages("Plottable"); } }

        //Tables
        public static Pages BasicTable { get { return new Pages("BasicTable"); } }
        public static Pages DataTable { get { return new Pages("DataTable"); } }

        //Maps
        public static Pages VectorMap { get { return new Pages("VectorMap"); } }
        public static Pages GoogleMap { get { return new Pages("GoogleMap"); } }

        //Icons
        public static Pages MaterialIcon { get { return new Pages("MaterialIcon"); } }
        public static Pages FontAwesomeIcon { get { return new Pages("FontAwesomeIcon"); } }
        public static Pages SimpleIcon { get { return new Pages("SimpleIcon"); } }

        //App
        public static Pages MemberProfile { get { return new Pages("MemberProfile"); } }
        public static Pages NewsGrid { get { return new Pages("NewsGrid"); } }
        public static Pages FAQ { get { return new Pages("FAQ"); } }
        public static Pages FAQ2 { get { return new Pages("FAQ2"); } }
        public static Pages Timeline { get { return new Pages("Timeline"); } }
        public static Pages SearchResults { get { return new Pages("SearchResults"); } }
        public static Pages Portfolio { get { return new Pages("Portfolio"); } }

        //Ecommerce
        public static Pages Orders { get { return new Pages("Orders"); } }
        public static Pages Invoice { get { return new Pages("Invoice"); } }
        public static Pages PricingTable { get { return new Pages("PricingTable"); } }

        //Auth
        public static Pages Login { get { return new Pages("Login"); } }
        public static Pages Login2 { get { return new Pages("Login2"); } }
        public static Pages Login3 { get { return new Pages("Login3"); } }
        public static Pages Register { get { return new Pages("Register"); } }
        public static Pages Register2 { get { return new Pages("Register2"); } }
        public static Pages Register3 { get { return new Pages("Register3"); } }

        //Maintenance
        public static Pages LockScreen { get { return new Pages("LockScreen"); } }
        public static Pages Page404 { get { return new Pages("Page404"); } }
        public static Pages Page500 { get { return new Pages("Page500"); } }


    }
}
