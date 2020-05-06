using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using coderush.Models;

namespace coderush.Controllers
{
    public class ReportChartController : Controller
    {
        // GET: ReportChart
        public ActionResult ReportChart()
        {
            DateTime startDateTime = DateTime.Now;

            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username =liluna_datalake; Password =Liluna@SCGL; Database =pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();

            #region old
            ////SM_Tender
            //var sql_SM_Tender = "select* from dom.\"Reporting_SM_Tender\"";
            //var cmd_SM_Tender = new NpgsqlCommand(sql_SM_Tender, con);
            //var dr_SM_Tender = cmd_SM_Tender.ExecuteScalar();

            ////SM_Accept
            //var sql_SM_Accept = "select* from dom.\"Reporting_SM_Accept\"";
            //var cmd_SM_Accept = new NpgsqlCommand(sql_SM_Accept, con);
            //var dr_SM_Accept = cmd_SM_Accept.ExecuteScalar();

            ////SM_Inbound
            //var sql_SM_Inbound = "select* from dom.\"Reporting_SM_Inbound\"";
            //var cmd_SM_Inbound = new NpgsqlCommand(sql_SM_Inbound, con);
            //var dr_SM_Inbound = cmd_SM_Inbound.ExecuteScalar();

            ////SM_GI
            //var sql_SM_GI = "select* from dom.\"Reporting_SM_GI\"";
            //var cmd_SM_GI = new NpgsqlCommand(sql_SM_GI, con);
            //var dr_SM_GI = cmd_SM_GI.ExecuteScalar();
            #endregion

            var sql_SM_status = "select* from dom.\"Reporting_SM_Status\"";
            var cmd_SM_status = new NpgsqlCommand(sql_SM_status, con);
            NpgsqlDataReader dr_SM_status = cmd_SM_status.ExecuteReader();

            string SM_Tender = string.Empty;
            string SM_Accept = string.Empty;
            string SM_Inbound = string.Empty;
            string SM_GI = string.Empty;

            while (dr_SM_status.Read())
            {
                SM_Tender = dr_SM_status[0].ToString();
                SM_Accept = dr_SM_status[1].ToString();
                SM_Inbound = dr_SM_status[2].ToString();
                SM_GI = dr_SM_status[3].ToString();
            }
            dr_SM_status.Close();

            ////monthly summary
            //var sql = "select * from dom.\"Reporting_MonthlySummary\"";
            //var cmd = new NpgsqlCommand(sql, con);
            //NpgsqlDataReader dr = cmd.ExecuteReader();

            //List<int> lsRep = new List<int>();
            //List<string> lsLabel = new List<string>();
            //List<string> lsbgcolor = new List<string>();
            //List<string> lsbdcolor = new List<string>();

            //string c1 = "rgba(255, 99, 132, 0.2)";
            //string c2 = "rgba(54, 162, 235, 0.2)";
            //string c3 = "rgba(255, 206, 86, 0.2)";
            //string c4 = "rgba(75, 192, 192, 0.2)";
            //string c5 = "rgba(153, 102, 255, 0.2)";
            //string c6 = "rgba(255, 159, 64, 0.2)";

            //while (dr.Read())
            //{
            //    lsLabel.Add(dr[0].ToString());
            //    lsRep.Add(Convert.ToInt32(dr[1].ToString()));
            //    lsbgcolor.Add(c1);
            //    lsbdcolor.Add(c1);
            //}
            //dr.close();

            ////Mock the data
            //BarChartDataSet dataset = new BarChartDataSet()
            //{
            //    label = "จำนวน Shipment",
            //    data = lsRep.ToArray(),
            //    backgroundColor = lsbgcolor.ToArray(),
            //    borderColor = lsbdcolor.ToArray(),
            //    borderWidth = 1
            //};

            //BarChartData data = new BarChartData()
            //{
            //    labels = lsLabel.ToArray(),
            //    datasets = new BarChartDataSet[] { dataset }
            //};

            //ViewBag.CHART = data;

            con.Close();

            DateTime endDateTime = DateTime.Now;

            ViewBag.SM_Tender = SM_Tender;
            ViewBag.SM_Accept = SM_Accept;
            ViewBag.SM_Inbound = SM_Inbound;
            ViewBag.SM_GI = SM_GI;

            ViewBag.PROCESSINGTIME = Math.Round((endDateTime - startDateTime).TotalSeconds,1);

            return View();
        }
        public ActionResult ReportChartTest()
        {
            return View();
        }
        public ActionResult ReportChartTest2()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData()
        {
            #region old
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username =liluna_datalake; Password =Liluna@SCGL; Database =pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = "select * from dom.\"Reporting_MonthlySummary2\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            List<double> lsTotalSM = new List<double>();
            List<double> lsTotalWeight = new List<double>();
            List<string> lsLabel = new List<string>();
            List<string> lsbgcolorTotalSM = new List<string>();
            List<string> lsbdcolorTotalSM = new List<string>();
            List<string> lsbgcolorTotalWeight = new List<string>();
            List<string> lsbdcolorTotalWeight = new List<string>();

            string c1 = "rgba(255, 99, 132, 0.2)";
            string c2 = "rgba(54, 162, 235, 0.2)";
            string c3 = "rgba(255, 206, 86, 0.2)";
            string c4 = "rgba(75, 192, 192, 0.2)";
            string c5 = "rgba(153, 102, 255, 0.2)";
            string c6 = "rgba(255, 159, 64, 0.2)";

            while (dr.Read())
            {
                lsLabel.Add(dr[0].ToString());

                if(!string.IsNullOrEmpty(dr[2].ToString())) lsTotalSM.Add(Convert.ToInt32(dr[2].ToString()));
                if (!string.IsNullOrEmpty(dr[2].ToString())) lsTotalWeight.Add(Convert.ToDouble(dr[3]));

                lsbgcolorTotalSM.Add(c1);
                lsbdcolorTotalSM.Add(c1);

                lsbgcolorTotalWeight.Add(c2);
                lsbdcolorTotalWeight.Add(c2);
            }


            //Mock the data
            BarChartDataSet datasetTotalSM = new BarChartDataSet()
            {
                type = "bar",
                label = "จำนวน Shipment",
                data = lsTotalSM.ToArray(),
                backgroundColor = lsbgcolorTotalSM.ToArray(),
                borderColor = lsbdcolorTotalSM.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetTotalWeight = new BarChartDataSet()
            {
                type = "bar",
                label = "จำนวน Volumn (x 100 Ton.)",
                data = lsTotalWeight.ToArray(),
                backgroundColor = lsbgcolorTotalWeight.ToArray(),
                borderColor = lsbdcolorTotalWeight.ToArray(),
                borderWidth = 1
            };

            BarChartData data = new BarChartData()
            {
                labels = lsLabel.ToArray(),
                datasets = new BarChartDataSet[] { datasetTotalSM, datasetTotalWeight }
            };

            return Json(data);
            #endregion
        }
        [HttpPost]
        public JsonResult GetShipmentStatusChart(string Selectdate)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username =liluna_datalake; Password =Liluna@SCGL; Database =pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = "select * from dom.\"Reporting_MonthlySummary_ShipmentStatus\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            List<string> lsLabel = new List<string>();
            List<double> lsSMTotal = new List<double>();
            List<double> lsSMCompletet = new List<double>();
            List<double> lsSMGI = new List<double>();
            List<double> lsSMTenderAccept = new List<double>();

            List<string> lsbgcolorSMTotal = new List<string>();
            List<string> lsbdcolorSMTotal = new List<string>();
            List<string> lsbgcolorSMCompletet = new List<string>();
            List<string> lsbdcolorSMCompletet = new List<string>();
            List<string> lsbgcolorSMGI = new List<string>();
            List<string> lsbdcolorSMGI = new List<string>();
            List<string> lsbgcolorSMTenderAccept = new List<string>();
            List<string> lsbdcolorSMTenderAccept = new List<string>();

            string c1 = "rgba(255, 99, 132, 0.2)";
            string c2 = "rgba(54, 162, 235, 0.2)";
            string c3 = "rgba(255, 206, 86, 0.2)";
            string c4 = "rgba(75, 192, 192, 0.2)";
            string c5 = "rgba(153, 102, 255, 0.2)";
            string c6 = "rgba(255, 159, 64, 0.2)";

            while (dr.Read())
            {
                lsLabel.Add(dr[0].ToString());
                if (!string.IsNullOrEmpty(dr[2].ToString())) lsSMTotal.Add(Convert.ToInt32(dr[2].ToString()));
                if (!string.IsNullOrEmpty(dr[3].ToString())) lsSMCompletet.Add(Convert.ToInt32(dr[3]));
                if (!string.IsNullOrEmpty(dr[4].ToString())) lsSMGI.Add(Convert.ToInt32(dr[4]));
                if (!string.IsNullOrEmpty(dr[5].ToString())) lsSMTenderAccept.Add(Convert.ToInt32(dr[5]));

                //set color
                lsbgcolorSMTotal.Add(c1);
                lsbdcolorSMTotal.Add(c1);
                lsbgcolorSMCompletet.Add(c2);
                lsbdcolorSMCompletet.Add(c2);
                lsbgcolorSMGI.Add(c3);
                lsbdcolorSMGI.Add(c3);
                lsbgcolorSMTenderAccept.Add(c4);
                lsbdcolorSMTenderAccept.Add(c4);
            }

            //Mock the data
            BarChartDataSet datasetSMTotal = new BarChartDataSet()
            {
                type = "line",
                label = "All Shipment",
                data = lsSMTotal.ToArray(),
                backgroundColor = lsbgcolorSMTotal.ToArray(),
                borderColor = lsbdcolorSMTotal.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetSMCompletet = new BarChartDataSet()
            {
                type = "bar",
                label = "Complete Delivery",
                data = lsSMCompletet.ToArray(),
                backgroundColor = lsbgcolorSMCompletet.ToArray(),
                borderColor = lsbdcolorSMCompletet.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetSMGI = new BarChartDataSet()
            {
                type = "bar",
                label = "GI",
                data = lsSMGI.ToArray(),
                backgroundColor = lsbgcolorSMGI.ToArray(),
                borderColor = lsbdcolorSMGI.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetSMTenderAccept = new BarChartDataSet()
            {
                type = "bar",
                label = "Accept",
                data = lsSMTenderAccept.ToArray(),
                backgroundColor = lsbgcolorSMTenderAccept.ToArray(),
                borderColor = lsbdcolorSMTenderAccept.ToArray(),
                borderWidth = 1
            };

            BarChartData data = new BarChartData()
            {
                labels = lsLabel.ToArray(),
                datasets = new BarChartDataSet[] { datasetSMTotal, datasetSMCompletet , datasetSMGI , datasetSMTenderAccept }
            };

            var jsonResult = Json(data);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public JsonResult GetShipmentStatusChart_ByType(string selectmonth, string selectday, string reporttype)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username=datalakero; Password=d@t@SCGL; Database=pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command = con.CreateCommand();
            var sql = " SELECT a.date_part, b.date, b.\"SMTotal\", b.\"SMComplete\", b.\"SMGI\", b.\"SMTenderAccept\" " +
                " FROM ( SELECT date_part('day'::text, dates_this_month.dates_this_month) AS date_part" +
                " FROM generate_series(date_trunc('month'::text, now()), date_trunc('month'::text, now()) + '1 mon'::interval - '1 day'::interval, '1 day'::interval) dates_this_month(dates_this_month)) a" +
                " LEFT JOIN " +
                " ( select stat.date " +
                " , stat.day" +
                " , count(distinct stat.load_id) as \"SMTotal\"" +
                " , sum(stat.\"SMComplete\") as \"SMComplete\"" +
                " , sum(\"SMGI\") as \"SMGI\"" +
                " , sum(stat.\"SMTenderAccept\") as \"SMTenderAccept\"" +
                " from (" +
                " select distinct" +
                " date(scvdnst.actual_open) as \"date\"" +
                " , date_part('day', scvdnst.actual_open) AS \"day\"" +
                " , scvdnst.load_id as \"load_id\"" +
                " , case when scvdnst.actual_delivery_date is not null then 1 else 0 end as \"SMComplete\"" +
                " , case when scvdnst.actual_delivery_date is not null then 0 " +
                " when scvdnst.actual_gi_date is not null then 1 else 0 end as \"SMGI\"" +
                " , case when scvdnst.actual_gi_date is not null then 0 " +
                " when scvdnst.actual_tender_accept is not null then 1 else 0 end as \"SMTenderAccept\"" +
                " from dom.scvcor_delivery_tracking_status scvdnst" +
                " inner join dom.scvmvc_tms_load_leg tmssmh on scvdnst.load_id = tmssmh.load_id" +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on 'A' || right('0000' || scvdnst.delivery_number , 10) = tmsdnh.delivery_number" +
                " where extract('month' from tmssmh.user_create_date) = @month";

            if (!string.IsNullOrEmpty(selectday))
                sql += " and extract('day' from tmssmh.user_create_date) = @day";

            switch (reporttype)
            {
                case "Fly_Ash":
                    sql += " and tmsdnh.commodity_code in ('BRFLY','BCFYA')" +
                        " and tmsdnh.shipping_point in ('3520000603','2210000897','6700000620','6710000500','2210000906','2250000410','6710000503','4400001149')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_SRB":
                    sql += " and tmsdnh.commodity_code = 'BCBGR'" +
                        " and tmsdnh.shipping_point in ('2190000635','2190000637','2190000894','2190000968')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_LP":
                    sql += " and tmsdnh.commodity_code in ('BCBGR','BCMTA','BRGYP')" +
                        " and tmsdnh.shipping_point in ('3520000594','3520000597','3520001431','3520000612')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_SRB":
                    sql += " and tmsdnh.commodity_code = 'BCMTA'" +
                        " and tmsdnh.shipping_point in ('2190000642','2190000898','2200001644')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_KW":
                    sql += " and tmsdnh.shipping_point in ('2190000938')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_TS":
                    sql += " and tmsdnh.commodity_code in ('BCMTA' , 'BRCCN')" +
                        " and tmsdnh.shipping_point in ('5800000746')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "PFA_PPD":
                    sql += " and tmsdnh.shipping_point in ('1110001558')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_PPD":
                    sql += " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('1110001519')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_SRC":
                    sql += " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2200001646')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_White_Bulk":
                    sql += " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2190000643')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_TS":
                    sql += " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('5800000742')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "KCL":
                    sql += " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('4480000395')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cementh_Rajasri":
                    sql += " and tmsdnh.commodity_code in ('BCRAC')" +
                        " and tmsdnh.shipping_point in ('2190000953')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Barite":
                    sql += " and tmsdnh.commodity_code in ('BMINE','BRCCN')" +
                        " and tmsdnh.shipping_point in ('2190000957','2190000642')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                default: break;
            }

            sql += " ) stat group by stat.date, stat.day) b ON a.date_part = b.day";

            
            command.CommandText = sql;
            command.Parameters.AddWithValue("@month", Convert.ToInt32(selectmonth));
            command.Parameters.AddWithValue("@day", Convert.ToInt32(selectday));
            NpgsqlDataReader dr = command.ExecuteReader();

            List<string> lsLabel = new List<string>();
            List<double> lsSMTotal = new List<double>();
            List<double> lsSMCompletet = new List<double>();
            List<double> lsSMGI = new List<double>();
            List<double> lsSMTenderAccept = new List<double>();

            List<string> lsbgcolorSMTotal = new List<string>();
            List<string> lsbdcolorSMTotal = new List<string>();
            List<string> lsbgcolorSMCompletet = new List<string>();
            List<string> lsbdcolorSMCompletet = new List<string>();
            List<string> lsbgcolorSMGI = new List<string>();
            List<string> lsbdcolorSMGI = new List<string>();
            List<string> lsbgcolorSMTenderAccept = new List<string>();
            List<string> lsbdcolorSMTenderAccept = new List<string>();

            string c1 = "rgba(255, 99, 132, 0.2)";
            string c2 = "rgba(54, 162, 235, 0.2)";
            string c3 = "rgba(255, 206, 86, 0.2)";
            string c4 = "rgba(75, 192, 192, 0.2)";
            string c5 = "rgba(153, 102, 255, 0.2)";
            string c6 = "rgba(255, 159, 64, 0.2)";
            string c7 = "rgb(12, 202, 142, 0.5)";
            string c8 = "rgb(255, 205, 86, 0.5)";
            string c9 = "rgb(255, 99, 132, 0.5)";
            string c10 = "rgb(54, 162, 235, 0.9)";
            string c11 = "rgb(51, 102, 0, 0.9)";

            while (dr.Read())
            {
                lsLabel.Add(dr[0].ToString());
                if (!string.IsNullOrEmpty(dr[2].ToString())) lsSMTotal.Add(Convert.ToInt32(dr[2].ToString()));
                else lsSMTotal.Add(0);
                if (!string.IsNullOrEmpty(dr[3].ToString())) lsSMCompletet.Add(Convert.ToInt32(dr[3]));
                else lsSMCompletet.Add(0);
                if (!string.IsNullOrEmpty(dr[4].ToString())) lsSMGI.Add(Convert.ToInt32(dr[4]));
                else lsSMGI.Add(0);
                if (!string.IsNullOrEmpty(dr[5].ToString())) lsSMTenderAccept.Add(Convert.ToInt32(dr[5]));
                else lsSMTenderAccept.Add(0);

                //set color
                lsbgcolorSMTotal.Add(c11);
                lsbdcolorSMTotal.Add(c11);
                lsbgcolorSMCompletet.Add(c7);
                lsbdcolorSMCompletet.Add(c7);
                lsbgcolorSMGI.Add(c8);
                lsbdcolorSMGI.Add(c8);
                lsbgcolorSMTenderAccept.Add(c9);
                lsbdcolorSMTenderAccept.Add(c9);
            }

            //Mock the data
            BarChartDataSet datasetSMTotal = new BarChartDataSet()
            {
                type = "line",
                label = "All Shipment",
                data = lsSMTotal.ToArray(),
                backgroundColor = lsbgcolorSMTotal.ToArray(),
                borderColor = lsbdcolorSMTotal.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetSMCompletet = new BarChartDataSet()
            {
                type = "bar",
                label = "Complete Delivery",
                data = lsSMCompletet.ToArray(),
                backgroundColor = lsbgcolorSMCompletet.ToArray(),
                borderColor = lsbdcolorSMCompletet.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetSMGI = new BarChartDataSet()
            {
                type = "bar",
                label = "GI",
                data = lsSMGI.ToArray(),
                backgroundColor = lsbgcolorSMGI.ToArray(),
                borderColor = lsbdcolorSMGI.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetSMTenderAccept = new BarChartDataSet()
            {
                type = "bar",
                label = "Accept",
                data = lsSMTenderAccept.ToArray(),
                backgroundColor = lsbgcolorSMTenderAccept.ToArray(),
                borderColor = lsbdcolorSMTenderAccept.ToArray(),
                borderWidth = 1
            };

            BarChartData data = new BarChartData()
            {
                labels = lsLabel.ToArray(),
                datasets = new BarChartDataSet[] { datasetSMTotal, datasetSMTenderAccept, datasetSMGI, datasetSMCompletet }
            };

            var jsonResult = Json(data);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public JsonResult GetShipmentStatusYearlyChart(string Selectyear)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username =liluna_datalake; Password =Liluna@SCGL; Database =pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = "select * from dom.\"Reporting_YearlySummary_ShipmentStatus\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            List<string> lsLabel = new List<string>();
            List<double> lsSMTotal = new List<double>();

            List<string> lsbgcolorSMTotal = new List<string>();
            List<string> lsbdcolorSMTotal = new List<string>();

            string c1 = "rgba(255, 99, 132, 0.2)";
            string c2 = "rgba(54, 162, 235, 0.2)";
            string c3 = "rgba(255, 206, 86, 0.2)";
            string c4 = "rgba(75, 192, 192, 0.2)";
            string c5 = "rgba(153, 102, 255, 0.2)";
            string c6 = "rgba(255, 159, 64, 0.2)";

            while (dr.Read())
            {
                lsLabel.Add(dr[2].ToString());
                if (!string.IsNullOrEmpty(dr[1].ToString())) lsSMTotal.Add(Convert.ToInt32(dr[1].ToString()));

                //set color
                lsbgcolorSMTotal.Add(c1);
                lsbdcolorSMTotal.Add(c1);
            }

            //Mock the data
            BarChartDataSet datasetSMTotal = new BarChartDataSet()
            {
                type = "bar",
                label = "All Shipment",
                data = lsSMTotal.ToArray(),
                backgroundColor = lsbgcolorSMTotal.ToArray(),
                borderColor = lsbdcolorSMTotal.ToArray(),
                borderWidth = 1
            };

            BarChartData data = new BarChartData()
            {
                labels = lsLabel.ToArray(),
                datasets = new BarChartDataSet[] { datasetSMTotal }
            };

            var jsonResult = Json(data);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public JsonResult GetLPC010_ShipmentStatusChart_ByType(string selectmonth, string selectday, string reporttype)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username=datalakero; Password=d@t@SCGL; Database=pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command = con.CreateCommand();
            var sql = " select a.*, b.count, b.DC_Inside, b.DC_Outside, b.Transfer, b.HUB" +
                " from ( " +
                " SELECT date_part('day'::text, dates_in_month) AS date_part " +
                " FROM generate_series(date_trunc('month'::text, now()) , date_trunc('month'::text, now()) + '1 mon'::interval - '1 day'::interval, '1 day'::interval) dates_in_month" +
                " ) a" +
                " left join (" +
                " select tmp.groupdate" +
                " , date_part('day'::text, tmp.groupdate) AS date_part" +
                " , count(distinct tmp.load_id)" +
                " , sum( case when tmp.type = 'DC_Inside' then 1 else 0 end) as DC_Inside" +
                " , sum( case when tmp.type = 'DC_Outside' then 1 else 0 end) as DC_Outside" +
                " , sum( case when tmp.type = 'HUB' then 1 else 0 end) as HUB" +
                " , sum( case when tmp.type = 'Transfer' then 1 else 0 end) as Transfer" +
                " from (" +
                " SELECT DISTINCT ON (ll.load_id)" +
                " ll.load_id AS load_id" +
                " , date(ll.user_create_date) as groupdate" +
                " , CASE" +
                " WHEN lld.origin_code::text = ANY (ARRAY['1130000009'::character varying::text, '6140000022'::character varying::text]) THEN 'DC_Inside'::text" +
                " WHEN lld.origin_code::text = ANY (ARRAY['1130000011'::character varying::text, '6140000023'::character varying::text]) THEN 'DC_Outside'::text" +
                " WHEN lld.origin_code::text = ANY (ARRAY['3500000029'::character varying::text, '3520000017'::character varying::text, '3530000011'::character varying::text, '3570000020'::character varying::text, '3600000017'::character varying::text, '3650000011'::character varying::text, '3670000013'::character varying::text, '4300000035'::character varying::text, '4340000027'::character varying::text, '4400000029'::character varying::text, '4410000023'::character varying::text, '4450000022'::character varying::text, '4490000009'::character varying::text, '5800000025'::character varying::text, '5800000027'::character varying::text, '5830000005'::character varying::text, '5840000022'::character varying::text, '5900000024'::character varying::text]) THEN 'HUB'::text" +
                " ELSE 'Transfer'::text" +
                " END AS type" +
                " FROM dom.scvmvc_tms_load_leg ll" +
                " left JOIN dom.scvmvc_tms_load_leg_detail lld ON ll.load_id::text = lld.load_id::text" +
                " where extract('month' from ll.user_create_date) = " + selectmonth +
                " ) tmp" +
                " group by tmp.groupdate, date_part('day'::text, tmp.groupdate)" +
                ") b on a.date_part = b.date_part";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@month", Convert.ToInt32(selectmonth));
            command.Parameters.AddWithValue("@day", Convert.ToInt32(selectday));
            NpgsqlDataReader dr = command.ExecuteReader();

            List<string> lsLabel = new List<string>();
            List<double> lsConsoTotal = new List<double>();
            List<double> lsDC_Inside = new List<double>();
            List<double> lsDC_Outside = new List<double>();
            List<double> lsHub = new List<double>();
            List<double> lsTransfer = new List<double>();

            List<string> lsbgcolorConsoTotal = new List<string>();
            List<string> lsbdcolorConsoTotal = new List<string>();
            List<string> lsbgcolorDC_Inside = new List<string>();
            List<string> lsbdcolorDC_Inside = new List<string>();
            List<string> lsbgcolorDC_Outside = new List<string>();
            List<string> lsbdcolorDC_Outside = new List<string>();
            List<string> lsbgcolorHub = new List<string>();
            List<string> lsbdcolorHub = new List<string>();
            List<string> lsbgcolorTransfer = new List<string>();
            List<string> lsbdcolorTransfer = new List<string>();

            string c1 = "rgba(255, 99, 132, 0.2)";
            string c2 = "rgba(54, 162, 235, 0.2)";
            string c3 = "rgba(255, 206, 86, 0.2)";
            string c4 = "rgba(75, 192, 192, 0.2)";
            string c5 = "rgba(153, 102, 255, 0.2)";
            string c6 = "rgba(255, 159, 64, 0.2)";
            string c7 = "rgb(12, 202, 142, 0.5)";
            string c8 = "rgb(255, 205, 86, 0.5)";
            string c9 = "rgb(255, 99, 132, 0.5)";
            string c10 = "rgb(54, 162, 235, 0.9)";
            string c11 = "rgb(51, 102, 0, 0.9)";

            while (dr.Read())
            {
                lsLabel.Add(dr[0].ToString());
                if (!string.IsNullOrEmpty(dr[1].ToString())) lsConsoTotal.Add(Convert.ToInt32(dr[1].ToString()));
                else lsConsoTotal.Add(0);
                if (!string.IsNullOrEmpty(dr[2].ToString())) lsDC_Inside.Add(Convert.ToInt32(dr[2]));
                else lsDC_Inside.Add(0);
                if (!string.IsNullOrEmpty(dr[3].ToString())) lsDC_Outside.Add(Convert.ToInt32(dr[3]));
                else lsDC_Outside.Add(0);
                if (!string.IsNullOrEmpty(dr[4].ToString())) lsTransfer.Add(Convert.ToInt32(dr[4]));
                else lsTransfer.Add(0);
                if (!string.IsNullOrEmpty(dr[5].ToString())) lsHub.Add(Convert.ToInt32(dr[5]));
                else lsHub.Add(0);

                //set color
                lsbgcolorConsoTotal.Add(c11);
                lsbdcolorConsoTotal.Add(c11);
                lsbgcolorDC_Inside.Add(c7);
                lsbdcolorDC_Inside.Add(c7);
                lsbgcolorDC_Outside.Add(c8);
                lsbdcolorDC_Outside.Add(c8);
                lsbgcolorHub.Add(c9);
                lsbdcolorHub.Add(c9);
                lsbgcolorTransfer.Add(c10);
                lsbdcolorTransfer.Add(c10);
            }

            //Mock the data
            BarChartDataSet datasetConsoTotal = new BarChartDataSet()
            {
                type = "line",
                label = "Conso Shipment",
                data = lsConsoTotal.ToArray(),
                backgroundColor = lsbgcolorConsoTotal.ToArray(),
                borderColor = lsbdcolorConsoTotal.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetDC_Inside = new BarChartDataSet()
            {
                type = "bar",
                label = "DC_Inside",
                data = lsDC_Inside.ToArray(),
                backgroundColor = lsbgcolorDC_Inside.ToArray(),
                borderColor = lsbdcolorDC_Inside.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetDC_Outside = new BarChartDataSet()
            {
                type = "bar",
                label = "DC_Outside",
                data = lsDC_Outside.ToArray(),
                backgroundColor = lsbgcolorDC_Outside.ToArray(),
                borderColor = lsbdcolorDC_Outside.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetTransfer = new BarChartDataSet()
            {
                type = "bar",
                label = "Transfer",
                data = lsTransfer.ToArray(),
                backgroundColor = lsbgcolorTransfer.ToArray(),
                borderColor = lsbdcolorTransfer.ToArray(),
                borderWidth = 1
            };

            BarChartDataSet datasetHub = new BarChartDataSet()
            {
                type = "bar",
                label = "Hub",
                data = lsHub.ToArray(),
                backgroundColor = lsbgcolorHub.ToArray(),
                borderColor = lsbdcolorHub.ToArray(),
                borderWidth = 1
            };

            BarChartData data = new BarChartData()
            {
                labels = lsLabel.ToArray(),
                datasets = new BarChartDataSet[] { datasetConsoTotal, datasetDC_Inside, datasetDC_Outside, datasetTransfer, datasetHub }
            };

            var jsonResult = Json(data);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

    }
}