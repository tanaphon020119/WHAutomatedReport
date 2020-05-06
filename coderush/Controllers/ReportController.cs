using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using coderush.Models;
using System.Net.Http;
using System.Data.SqlClient;

namespace coderush.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report

        //All Report Index

        #region Report View
        public ActionResult Report()
        {
            DateTime startDateTime = DateTime.Now;

            DateTime endDateTime = DateTime.Now;

            ViewBag.PROCESSINGTIME = Math.Round((endDateTime - startDateTime).TotalSeconds,1);

            return View();
        }
        public ActionResult ReportTest()
        {
            return View();
        }
        public ActionResult Report_LPC010()
        {
            DateTime startDateTime = DateTime.Now;

            DateTime endDateTime = DateTime.Now;

            ViewBag.PROCESSINGTIME = Math.Round((endDateTime - startDateTime).TotalSeconds, 1);

            return View();
        }
        public ActionResult Report_LPC007()
        {
            DateTime startDateTime = DateTime.Now;

            DateTime endDateTime = DateTime.Now;

            ViewBag.PROCESSINGTIME = Math.Round((endDateTime - startDateTime).TotalSeconds, 1);

            return View();
        }
        public ActionResult Report_LPC004()
        {
            DateTime startDateTime = DateTime.Now;

            DateTime endDateTime = DateTime.Now;

            ViewBag.PROCESSINGTIME = Math.Round((endDateTime - startDateTime).TotalSeconds, 1);

            return View();
        }
        public ActionResult Report_LPC004_Fly_Ash()
        {
            return View();
        }
        public ActionResult Report_LPC004_LPC_FIX_ALL_FLEET_SRB()
        {
            return View();
        }
        public ActionResult Report_LPC004_LPC_FIX_M1_FLEET_SRB()
        {
            return View();
        }
        public ActionResult Report_LPC004_LPC_FIX_M2_FLEET_SRB()
        {
            return View();
        }
        public ActionResult Report_LPC004_LPC_FIX_M3_FLEET_SRB()
        {
            return View();
        }
        public ActionResult Report_LPC004_LPC_FIX_M4_FLEET_SRB()
        {
            return View();
        }
        public ActionResult Report_LPC004_LPC_FIX_M5_FLEET_SRB()
        {
            return View();
        }
        public ActionResult Report_LPC004_LPC_FIX_M6_FLEET_SRB()
        {
            return View();
        }
        public ActionResult Report_LPC004_LPC_FIX_MA_FLEET_SRB()
        {
            return View();
        }
        public ActionResult Report_LPC004_Mortar_Bulk_FLEET_SRB()
        {
            return View();
        }
        public ActionResult Report_LPC004_Mortar_Bulk_FLEET_TS()
        {
            return View();
        }
        public ActionResult Report_LPC004_PFA_PPD()
        {
            return View();
        }
        public ActionResult Report_LPC004_Cement_Bulk_PPD()
        {
            return View();
        }
        public ActionResult Report_LPC004_Cement_Bulk_SRC()
        {
            return View();
        }
        public ActionResult Report_LPC004_Cement_White_Bulk()
        {
            return View();
        }
        public ActionResult Report_LPC004_Cement_Bulk_TS()
        {
            return View();
        }
        public ActionResult Report_LPC004_KCL()
        {
            return View();
        }
        public ActionResult Report_LPC004_Mortar_Bulk_FLEET_KW()
        {
            return View();
        }
        public ActionResult Report_LPC004_Cement_Bulk_FLEET_LP()
        {
            return View();
        }
        public ActionResult Report_LPC004_Cementh_Rajasri()
        {
            return View();
        }
        public ActionResult Report_LPC004_Barite()
        {
            return View();
        }

        public ActionResult Report_LPC010_All()
        {
            return View();
        }

        #endregion

        //LPC 040
        [HttpPost]
        public JsonResult GetLPC004Data_Table_ByType(string selectyear, string selectmonth, string selectday, string reporttype)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username=datalakero; Password=d@t@SCGL; Database=pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command = con.CreateCommand();

            var sql = " select distinct on (tmsdnh.delivery_number) " +
                " tmsdnh.ship_to_name" +
                " , tmsdnh.order_number" +
                " , case when scvdnh.gross_weight is not null then round(scvdnh.gross_weight/1000, 2) else round(tmssmh.total_weight/1000, 2) end as DNWeight" +
                " , tmsdnh.delivery_number " +
                " , scvst.actual_gi_date" +
                " , tmssmh.load_id" +
                " , '' as Accept" +
                " , tmssmh.equipment_type" +
                " , tmssmh.carrier_name" +
                " , to_char(scvst.actual_tender,'dd/mm/yyyy hh:MM') as \"ReqDate\"" +
                " , tmsdnh.shipping_point" +
                " , tmsdnh.shipping_name" +
                " , tmssmh.total_distance" +
                " , scvst.actual_delivery_date" +
                " , scvsmmm.load_prtb_ctnt" +
                " , tmssmh.truck_license" +
                " , tmsdnh.ship_to_code" +
                " , tmsdnh.region" +
                " , tmsdnh.sold_to_code" +
                " , tmsdnh.commodity_code" +
                " , omscom.cdty_desc" +
                " , tmssmh.load_desc" +
                " , to_char(scvst.actual_tender,'dd/mm/yyyy hh:MM') as TenderDate" +
                " , to_char(scvst.actual_tender_accept,'dd/mm/yyyy hh:MM') as AcceptDate" +
                " , tmsdnh.ship_to_city" +
                " , tmssmh.load_status" +
                " , omsdnh.created_by" +
                " , omsdnh.created_date" +
                " , tmsdni.item_desc" +
                " , tmsdnh.po_number" +
                " , tmssmd.commodity_code" +
                " , tmssmh.user_create_date" +
                " from dom.scvmvc_tms_delivery_header tmsdnh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmsdnh.delivery_number = tmssmd.delivery_number" +
                " inner join dom.scvmvc_tms_load_leg tmssmh on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.omsord_delivery_sap_header omsdnh on tmsdnh.delivery_number = omsdnh.refdnnumber" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " inner join dom.scvmvc_tms_delivery_item tmsdni on tmsdnh.delivery_number = tmsdni.delivery_number" +
                " left join dom.scvmvc_sap_delivery_header scvdnh on scvst.delivery_number = scvdnh.delivery_number" +
                " left join dom.scvmvc_tms_load_memo scvsmmm on tmssmh.load_id = scvsmmm.load_id" +
                " left JOIN dom.omswmp_tms_cdty omscom on tmsdnh.commodity_code = omscom.cdty_cd";

            switch (reporttype)
            {
                case "Fly_Ash":
                    sql += " where tmsdnh.commodity_code in ('BRFLY','BCFYA') " +
                        " and tmsdnh.shipping_point in ('3520000603','2210000897','6700000620','6710000500','2210000906','2250000410','6710000503','4400001149')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_SRB":
                    sql += " where tmsdnh.commodity_code = 'BCBGR'" +
                        " and tmsdnh.shipping_point in ('2190000635','2190000637','2190000894','2190000968')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_LP":
                    sql += " where tmsdnh.commodity_code in ('BCBGR','BCMTA','BRGYP')" +
                        " and tmsdnh.shipping_point in ('3520000594','3520000597','3520001431','3520000612')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_SRB":
                    sql += " where tmsdnh.commodity_code = 'BCMTA'" +
                        " and tmsdnh.shipping_point in ('2190000642','2190000898','2200001644')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_KW":
                    sql += " where tmsdnh.shipping_point in ('2190000938')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_TS":
                    sql += " where tmsdnh.commodity_code in ('BCMTA' , 'BRCCN')" +
                        " and tmsdnh.shipping_point in ('5800000746')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "PFA_PPD":
                    sql += " where tmsdnh.shipping_point in ('1110001558')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_PPD":
                    sql += " where tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('1110001519')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_SRC":
                    sql += " where tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2200001646')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_White_Bulk":
                    sql += " where tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2190000643')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_TS":
                    sql += " where tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('5800000742')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "KCL":
                    sql += " where tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('4480000395')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cementh_Rajasri":
                    sql += " where tmsdnh.commodity_code in ('BCRAC')" +
                        " and tmsdnh.shipping_point in ('2190000953')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Barite":
                    sql += " where tmsdnh.commodity_code in ('BMINE','BRCCN')" +
                        " and tmsdnh.shipping_point in ('2190000957','2190000642')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                default: sql += " where 1 = 0"; break;
            }

            if (!string.IsNullOrEmpty(selectmonth))
            {
                sql += " and extract('month' from tmssmh.user_create_date) = @month";
                command.Parameters.AddWithValue("@month", Convert.ToInt32(selectmonth));
            }
            if (!string.IsNullOrEmpty(selectday))
            {
                sql += " and extract('day' from tmssmh.user_create_date) = @day";
                command.Parameters.AddWithValue("@day", Convert.ToInt32(selectday));
            }

            sql += " order by tmsdnh.delivery_number";

            
            command.CommandText = sql;
            NpgsqlDataReader dr = command.ExecuteReader();

            //var cmd = new NpgsqlCommand(sql, con);
            //NpgsqlDataReader dr = cmd.ExecuteReader();

            List<Report004ViewModel> lsReportViewModels = new List<Report004ViewModel>();
            int i = 1;

            while (dr.Read())
            {
                Report004ViewModel reportViewModels = new Report004ViewModel();
                reportViewModels.No = i.ToString();
                reportViewModels.DestinationName = dr[0].ToString();
                reportViewModels.OrderNumber = dr[1].ToString();
                reportViewModels.SMWeight = dr[2].ToString();
                reportViewModels.DNNumber = dr[3].ToString();
                reportViewModels.GIDate = dr[4].ToString();
                reportViewModels.SMNumber = dr[5].ToString();
                reportViewModels.ActualTenderStatus = dr[6].ToString();
                reportViewModels.EquipmentTypeName = dr[7].ToString();
                reportViewModels.CarrierName = dr[8].ToString();
                reportViewModels.RequestDate = dr[9].ToString();
                reportViewModels.ShippingPointCode = dr[10].ToString();
                reportViewModels.ShippingPointName = dr[11].ToString();
                reportViewModels.TotalDistance = dr[12].ToString();
                reportViewModels.ActualDeliveryDate = dr[13].ToString();
                reportViewModels.SMRemark = dr[14].ToString();
                reportViewModels.TruckLicense = dr[15].ToString();
                reportViewModels.ShiptoCode = dr[16].ToString();
                reportViewModels.ShiptoRegion = dr[17].ToString();
                reportViewModels.CustomerName = dr[18].ToString();
                reportViewModels.CommodityCode = dr[19].ToString();
                reportViewModels.CommodityDescrition = dr[20].ToString();
                reportViewModels.SMDescription = dr[21].ToString();
                reportViewModels.ActualTenderDate = dr[22].ToString();
                reportViewModels.ActualTenderAcceptDate = dr[23].ToString();
                reportViewModels.ShiptoCity = dr[24].ToString();
                reportViewModels.SMStatus = dr[25].ToString();
                reportViewModels.Planner = dr[26].ToString();
                reportViewModels.SMCreateDate = dr[27].ToString();
                reportViewModels.MaterialDescription = dr[28].ToString();
                reportViewModels.PONumber = dr[29].ToString();
                lsReportViewModels.Add(reportViewModels);

                i++;
            }

            dr.Close();
            con.Close();

            var jsonResult = Json(new { data = lsReportViewModels });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        [HttpPost]
        public JsonResult GetLPC004_Summary_Shipment_status(string selectyear, string selectmonth, string selectday, string reporttype)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username=datalakero; Password=d@t@SCGL; Database=pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command = con.CreateCommand();

            string condition = string.Empty;

            switch (reporttype)
            {
                case "Fly_Ash":
                    condition = " and tmsdnh.commodity_code in ('BRFLY','BCFYA') " +
                        " and tmsdnh.shipping_point in ('3520000603','2210000897','6700000620','6710000500','2210000906','2250000410','6710000503','4400001149')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_SRB":
                    condition = " and tmsdnh.commodity_code = 'BCBGR'" +
                        " and tmsdnh.shipping_point in ('2190000635','2190000637','2190000894','2190000968')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_LP":
                    condition = " and tmsdnh.commodity_code in ('BCBGR','BCMTA','BRGYP')" +
                        " and tmsdnh.shipping_point in ('3520000594','3520000597','3520001431','3520000612')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_SRB":
                    condition = " and tmsdnh.commodity_code = 'BCMTA'" +
                        " and tmsdnh.shipping_point in ('2190000642','2190000898','2200001644')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_KW":
                    condition = " and tmsdnh.shipping_point in ('2190000938')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_TS":
                    condition = " and tmsdnh.commodity_code in ('BCMTA' , 'BRCCN')" +
                        " and tmsdnh.shipping_point in ('5800000746')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "PFA_PPD":
                    condition = " and tmsdnh.shipping_point in ('1110001558')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_PPD":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('1110001519')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_SRC":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2200001646')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_White_Bulk":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2190000643')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_TS":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('5800000742')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "KCL":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('4480000395')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cementh_Rajasri":
                    condition = " and tmsdnh.commodity_code in ('BCRAC')" +
                        " and tmsdnh.shipping_point in ('2190000953')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Barite":
                    condition = " and tmsdnh.commodity_code in ('BMINE','BRCCN')" +
                        " and tmsdnh.shipping_point in ('2190000957','2190000642')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                default: break;
            }

            command.CommandText = "select " +
                " (select count(distinct tmssmh.load_id) as \"SM_Tender\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " )" +
                " , (select count(tmssmh.load_id) as \"SM_Accept\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " " +
                " and scvst.actual_tender_accept is not null)" +
                " , (select count(tmssmh.load_id) as \"SM_Inbound\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " " +
                " and scvst.actual_in_origin is not null)" +
                " , (select count(tmssmh.load_id) as \"SM_GI\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id" +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " " +
                " and scvst.actual_gi_date is not null)";

            

            //if (!string.IsNullOrEmpty(selectmonth))
            //{
            //    sql += " and extract('month' from tmssmh.user_create_date) = @month";
            //    command.Parameters.AddWithValue("@month", Convert.ToInt32(selectmonth));
            //}
            //if (!string.IsNullOrEmpty(selectday))
            //{
            //    sql += " and extract('day' from tmssmh.user_create_date) = @day";
            //    command.Parameters.AddWithValue("@day", Convert.ToInt32(selectday));
            //}

            //command.Parameters.AddWithValue("@condition", condition);
            NpgsqlDataReader dr_SM_status = command.ExecuteReader();

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

            var jsonResult = Json(new { SM_Tender = SM_Tender, SM_Accept = SM_Accept, SM_Inbound = SM_Inbound, SM_GI = SM_GI });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        //LPC010
        [HttpPost]
        public JsonResult GetLPC010Data_Table_ByType(string selectmonth, string selectday, string reporttype)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username=datalakero; Password=d@t@SCGL; Database=pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command = con.CreateCommand();

            var sql = " SELECT DISTINCT ON (ll.load_id) ll.load_status AS \"StatusDescription\", " +
                " odsh.plannername AS \"User\"," +
                " ll.user_create_date AS \"Date\"," +
                " ll.load_id AS \"ReqID\"," +
                " ll.load_id AS \"เลขที่ Shipment\"," +
                " ll.total_shipments AS \"จำนวน DN\"," +
                " ll.load_desc AS \"Tracking No\"," +
                " lld.customer_name AS \"ลูกค้า\"," +
                " ll.equipment_type AS \"ประเภทรถ\"," +
                " ll.carrier_name AS \"ผรม\"," +
                " ll.total_stops AS \"จำนวน Drop\"," +
                " round(ll.total_weight, 2) AS weight," +
                " round(ll.total_volume, 2) AS volume," +
                " round(ll.total_weight / mmtu.max_weight * 100::numeric, 2) AS uniwgt," +
                " round(ll.total_volume / mmtu.max_volume * 100::numeric, 2) AS univol," +
                " CASE" +
                " WHEN lld.origin_code::text = ANY (ARRAY['1130000009'::character varying::text, '6140000022'::character varying::text]) THEN 'DC Inside'::text" +
                " WHEN lld.origin_code::text = ANY (ARRAY['1130000011'::character varying::text, '6140000023'::character varying::text]) THEN 'DC Outside'::text" +
                " WHEN lld.origin_code::text = ANY (ARRAY['3500000029'::character varying::text, '3520000017'::character varying::text, '3530000011'::character varying::text, '3570000020'::character varying::text, '3600000017'::character varying::text, '3650000011'::character varying::text, '3670000013'::character varying::text, '4300000035'::character varying::text, '4340000027'::character varying::text, '4400000029'::character varying::text, '4410000023'::character varying::text, '4450000022'::character varying::text, '4490000009'::character varying::text, '5800000025'::character varying::text, '5800000027'::character varying::text, '5830000005'::character varying::text, '5840000022'::character varying::text, '5900000024'::character varying::text]) THEN 'HUB'::text" +
                " ELSE 'งานโอน'::text" +
                " END AS type" +
                " FROM dom.scvmvc_tms_load_leg ll" +
                " LEFT JOIN dom.scvmvc_tms_load_leg_detail lld ON ll.load_id::text = lld.load_id::text" +
                " LEFT JOIN dom.metadata_master_truck_utilization mmtu ON ll.equipment_type::text = mmtu.truck_type::text" +
                " LEFT JOIN dom.omsord_delivery_sap_header odsh ON lld.delivery_number::text = odsh.refdnnumber::text";

            if (!string.IsNullOrEmpty(selectmonth))
            {
                sql += " where extract('month' from ll.user_create_date) = @month";
                command.Parameters.AddWithValue("@month", Convert.ToInt32(selectmonth));
            }
            if (!string.IsNullOrEmpty(selectday))
            {
                sql += " and extract('day' from ll.user_create_date) = @day";
                command.Parameters.AddWithValue("@day", Convert.ToInt32(selectday));
            }

            sql += " order by ll.load_id";

            command.CommandText = sql;
            NpgsqlDataReader dr = command.ExecuteReader();

            //var cmd = new NpgsqlCommand(sql, con);
            //NpgsqlDataReader dr = cmd.ExecuteReader();

            List<Report010ViewModel> lsReportViewModels = new List<Report010ViewModel>();
            int i = 1;

            while (dr.Read())
            {
                Report010ViewModel reportViewModels = new Report010ViewModel();
                reportViewModels.No = i.ToString();
                reportViewModels.StatusDescription = dr[0].ToString();
                reportViewModels.User = dr[1].ToString();
                reportViewModels.SMCreateDate = dr[2].ToString();
                reportViewModels.ReqID = dr[3].ToString();
                reportViewModels.SMNumber = dr[4].ToString();
                reportViewModels.NumberofDN = dr[5].ToString();
                reportViewModels.TrackingNo = dr[6].ToString();
                reportViewModels.CustomerName = dr[7].ToString();
                reportViewModels.EquipmentTypeName = dr[8].ToString();
                reportViewModels.CarrierCode = dr[9].ToString();
                reportViewModels.TotalStop = dr[10].ToString();
                reportViewModels.TotalWeight = dr[11].ToString();
                reportViewModels.TotalVolume = dr[12].ToString();
                reportViewModels.UtiWeight = dr[13].ToString();
                reportViewModels.UtiVol = dr[14].ToString();
                reportViewModels.Type = dr[15].ToString();
                lsReportViewModels.Add(reportViewModels);

                i++;
            }

            dr.Close();
            con.Close();

            var jsonResult = Json(new { data = lsReportViewModels });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        [HttpPost]
        public JsonResult GetLPC010_Summary_Shipment_status(string selectmonth, string selectday, string reporttype)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username=datalakero; Password=d@t@SCGL; Database=pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command = con.CreateCommand();

            string condition = string.Empty;

            switch (reporttype)
            {
                case "Fly_Ash":
                    condition = " and tmsdnh.commodity_code in ('BRFLY','BCFYA') " +
                        " and tmsdnh.shipping_point in ('3520000603','2210000897','6700000620','6710000500','2210000906','2250000410','6710000503','4400001149')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_SRB":
                    condition = " and tmsdnh.commodity_code = 'BCBGR'" +
                        " and tmsdnh.shipping_point in ('2190000635','2190000637','2190000894','2190000968')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_LP":
                    condition = " and tmsdnh.commodity_code in ('BCBGR','BCMTA','BRGYP')" +
                        " and tmsdnh.shipping_point in ('3520000594','3520000597','3520001431','3520000612')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_SRB":
                    condition = " and tmsdnh.commodity_code = 'BCMTA'" +
                        " and tmsdnh.shipping_point in ('2190000642','2190000898','2200001644')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_KW":
                    condition = " and tmsdnh.shipping_point in ('2190000938')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_TS":
                    condition = " and tmsdnh.commodity_code in ('BCMTA' , 'BRCCN')" +
                        " and tmsdnh.shipping_point in ('5800000746')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "PFA_PPD":
                    condition = " and tmsdnh.shipping_point in ('1110001558')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_PPD":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('1110001519')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_SRC":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2200001646')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_White_Bulk":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2190000643')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_TS":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('5800000742')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "KCL":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('4480000395')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cementh_Rajasri":
                    condition = " and tmsdnh.commodity_code in ('BCRAC')" +
                        " and tmsdnh.shipping_point in ('2190000953')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Barite":
                    condition = " and tmsdnh.commodity_code in ('BMINE','BRCCN')" +
                        " and tmsdnh.shipping_point in ('2190000957','2190000642')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                default: break;
            }

            command.CommandText = "select " +
                " (select count(distinct tmssmh.load_id) as \"SM_Tender\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " )" +
                " , (select count(tmssmh.load_id) as \"SM_Accept\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " " +
                " and scvst.actual_tender_accept is not null)" +
                " , (select count(tmssmh.load_id) as \"SM_Inbound\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " " +
                " and scvst.actual_in_origin is not null)" +
                " , (select count(tmssmh.load_id) as \"SM_GI\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id" +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " " +
                " and scvst.actual_gi_date is not null)";



            //if (!string.IsNullOrEmpty(selectmonth))
            //{
            //    sql += " and extract('month' from tmssmh.user_create_date) = @month";
            //    command.Parameters.AddWithValue("@month", Convert.ToInt32(selectmonth));
            //}
            //if (!string.IsNullOrEmpty(selectday))
            //{
            //    sql += " and extract('day' from tmssmh.user_create_date) = @day";
            //    command.Parameters.AddWithValue("@day", Convert.ToInt32(selectday));
            //}

            //command.Parameters.AddWithValue("@condition", condition);
            NpgsqlDataReader dr_SM_status = command.ExecuteReader();

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

            var jsonResult = Json(new { SM_Tender = SM_Tender, SM_Accept = SM_Accept, SM_Inbound = SM_Inbound, SM_GI = SM_GI });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        //LPC007
        [HttpPost]
        public JsonResult GetLPC007ata_Table_ByType(string selectmonth, string selectday, string reporttype)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username=datalakero; Password=d@t@SCGL; Database=pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command = con.CreateCommand();

            var sql = " SELECT DISTINCT ON (ll.load_id) ll.load_status AS \"StatusDescription\", " +
                " odsh.plannername AS \"User\"," +
                " ll.user_create_date AS \"Date\"," +
                " ll.load_id AS \"ReqID\"," +
                " ll.load_id AS \"เลขที่ Shipment\"," +
                " ll.total_shipments AS \"จำนวน DN\"," +
                " ll.load_desc AS \"Tracking No\"," +
                " lld.customer_name AS \"ลูกค้า\"," +
                " ll.equipment_type AS \"ประเภทรถ\"," +
                " ll.carrier_name AS \"ผรม\"," +
                " ll.total_stops AS \"จำนวน Drop\"," +
                " round(ll.total_weight, 2) AS weight," +
                " round(ll.total_volume, 2) AS volume," +
                " round(ll.total_weight / mmtu.max_weight * 100::numeric, 2) AS uniwgt," +
                " round(ll.total_volume / mmtu.max_volume * 100::numeric, 2) AS univol," +
                " CASE" +
                " WHEN lld.origin_code::text = ANY (ARRAY['1130000009'::character varying::text, '6140000022'::character varying::text]) THEN 'DC Inside'::text" +
                " WHEN lld.origin_code::text = ANY (ARRAY['1130000011'::character varying::text, '6140000023'::character varying::text]) THEN 'DC Outside'::text" +
                " WHEN lld.origin_code::text = ANY (ARRAY['3500000029'::character varying::text, '3520000017'::character varying::text, '3530000011'::character varying::text, '3570000020'::character varying::text, '3600000017'::character varying::text, '3650000011'::character varying::text, '3670000013'::character varying::text, '4300000035'::character varying::text, '4340000027'::character varying::text, '4400000029'::character varying::text, '4410000023'::character varying::text, '4450000022'::character varying::text, '4490000009'::character varying::text, '5800000025'::character varying::text, '5800000027'::character varying::text, '5830000005'::character varying::text, '5840000022'::character varying::text, '5900000024'::character varying::text]) THEN 'HUB'::text" +
                " ELSE 'งานโอน'::text" +
                " END AS type" +
                " FROM dom.scvmvc_tms_load_leg ll" +
                " LEFT JOIN dom.scvmvc_tms_load_leg_detail lld ON ll.load_id::text = lld.load_id::text" +
                " LEFT JOIN dom.metadata_master_truck_utilization mmtu ON ll.equipment_type::text = mmtu.truck_type::text" +
                " LEFT JOIN dom.omsord_delivery_sap_header odsh ON lld.delivery_number::text = odsh.refdnnumber::text";

            if (!string.IsNullOrEmpty(selectmonth))
            {
                sql += " where extract('month' from ll.user_create_date) = @month";
                command.Parameters.AddWithValue("@month", Convert.ToInt32(selectmonth));
            }
            if (!string.IsNullOrEmpty(selectday))
            {
                sql += " and extract('day' from ll.user_create_date) = @day";
                command.Parameters.AddWithValue("@day", Convert.ToInt32(selectday));
            }

            sql += " order by ll.load_id";

            command.CommandText = sql;
            NpgsqlDataReader dr = command.ExecuteReader();

            //var cmd = new NpgsqlCommand(sql, con);
            //NpgsqlDataReader dr = cmd.ExecuteReader();

            List<Report010ViewModel> lsReportViewModels = new List<Report010ViewModel>();
            int i = 1;

            while (dr.Read())
            {
                Report010ViewModel reportViewModels = new Report010ViewModel();
                reportViewModels.No = i.ToString();
                reportViewModels.StatusDescription = dr[0].ToString();
                reportViewModels.User = dr[1].ToString();
                reportViewModels.SMCreateDate = dr[2].ToString();
                reportViewModels.ReqID = dr[3].ToString();
                reportViewModels.SMNumber = dr[4].ToString();
                reportViewModels.NumberofDN = dr[5].ToString();
                reportViewModels.TrackingNo = dr[6].ToString();
                reportViewModels.CustomerName = dr[7].ToString();
                reportViewModels.EquipmentTypeName = dr[8].ToString();
                reportViewModels.CarrierCode = dr[9].ToString();
                reportViewModels.TotalStop = dr[10].ToString();
                reportViewModels.TotalWeight = dr[11].ToString();
                reportViewModels.TotalVolume = dr[12].ToString();
                reportViewModels.UtiWeight = dr[13].ToString();
                reportViewModels.UtiVol = dr[14].ToString();
                reportViewModels.Type = dr[15].ToString();
                lsReportViewModels.Add(reportViewModels);

                i++;
            }

            dr.Close();
            con.Close();

            var jsonResult = Json(new { data = lsReportViewModels });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        [HttpPost]
        public JsonResult GetLPC007_Summary_Shipment_status(string selectmonth, string selectday, string reporttype)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username=datalakero; Password=d@t@SCGL; Database=pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command = con.CreateCommand();

            string condition = string.Empty;

            switch (reporttype)
            {
                case "Fly_Ash":
                    condition = " and tmsdnh.commodity_code in ('BRFLY','BCFYA') " +
                        " and tmsdnh.shipping_point in ('3520000603','2210000897','6700000620','6710000500','2210000906','2250000410','6710000503','4400001149')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_SRB":
                    condition = " and tmsdnh.commodity_code = 'BCBGR'" +
                        " and tmsdnh.shipping_point in ('2190000635','2190000637','2190000894','2190000968')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "All_Bulk_FLEET_LP":
                    condition = " and tmsdnh.commodity_code in ('BCBGR','BCMTA','BRGYP')" +
                        " and tmsdnh.shipping_point in ('3520000594','3520000597','3520001431','3520000612')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_SRB":
                    condition = " and tmsdnh.commodity_code = 'BCMTA'" +
                        " and tmsdnh.shipping_point in ('2190000642','2190000898','2200001644')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_KW":
                    condition = " and tmsdnh.shipping_point in ('2190000938')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Mortar_Bulk_FLEET_TS":
                    condition = " and tmsdnh.commodity_code in ('BCMTA' , 'BRCCN')" +
                        " and tmsdnh.shipping_point in ('5800000746')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "PFA_PPD":
                    condition = " and tmsdnh.shipping_point in ('1110001558')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_PPD":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('1110001519')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_SRC":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2200001646')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_White_Bulk":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('2190000643')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cement_Bulk_TS":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('5800000742')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "KCL":
                    condition = " and tmsdnh.commodity_code in ('BCBGR')" +
                        " and tmsdnh.shipping_point in ('4480000395')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Cementh_Rajasri":
                    condition = " and tmsdnh.commodity_code in ('BCRAC')" +
                        " and tmsdnh.shipping_point in ('2190000953')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                case "Barite":
                    condition = " and tmsdnh.commodity_code in ('BMINE','BRCCN')" +
                        " and tmsdnh.shipping_point in ('2190000957','2190000642')" +
                        " and tmssmh.equipment_type in ('10CC','18CS','18CT','22CS','22CT')";
                    break;
                default: break;
            }

            command.CommandText = "select " +
                " (select count(distinct tmssmh.load_id) as \"SM_Tender\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " )" +
                " , (select count(tmssmh.load_id) as \"SM_Accept\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " " +
                " and scvst.actual_tender_accept is not null)" +
                " , (select count(tmssmh.load_id) as \"SM_Inbound\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id " +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " " +
                " and scvst.actual_in_origin is not null)" +
                " , (select count(tmssmh.load_id) as \"SM_GI\"" +
                " from dom.scvmvc_tms_load_leg tmssmh" +
                " inner join dom.scvmvc_tms_load_leg_detail tmssmd on tmssmh.load_id = tmssmd.load_id" +
                " inner join dom.scvmvc_tms_delivery_header tmsdnh on tmssmd.delivery_number = tmsdnh.delivery_number" +
                " inner join dom.scvcor_delivery_tracking_status scvst on tmsdnh.delivery_number = 'A' || right('0000' || scvst.delivery_number , 10)" +
                " where tmssmh.user_create_date >= current_date" +
                " " + condition + " " +
                " and scvst.actual_gi_date is not null)";



            //if (!string.IsNullOrEmpty(selectmonth))
            //{
            //    sql += " and extract('month' from tmssmh.user_create_date) = @month";
            //    command.Parameters.AddWithValue("@month", Convert.ToInt32(selectmonth));
            //}
            //if (!string.IsNullOrEmpty(selectday))
            //{
            //    sql += " and extract('day' from tmssmh.user_create_date) = @day";
            //    command.Parameters.AddWithValue("@day", Convert.ToInt32(selectday));
            //}

            //command.Parameters.AddWithValue("@condition", condition);
            NpgsqlDataReader dr_SM_status = command.ExecuteReader();

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

            var jsonResult = Json(new { SM_Tender = SM_Tender, SM_Accept = SM_Accept, SM_Inbound = SM_Inbound, SM_GI = SM_GI });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        [HttpPost]
        public JsonResult GetLPC007_ShipmentStatusChart_ByType(string selectmonth, string selectday, string reporttype)
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

        #region Test Zone
        [HttpPost]
        public JsonResult GetLPC007Data(string Selectmonth)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username =liluna_datalake; Password =Liluna@SCGL; Database =pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = "select * from dom.\"Reporting_LPC007_2\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            List<Report007ViewModel> lsReportViewModels = new List<Report007ViewModel>();

            int i = 1;

            while (dr.Read())
            {
                Report007ViewModel reportViewModels = new Report007ViewModel();
                reportViewModels.No = i.ToString() ;
                reportViewModels.SMCreateDate = dr[0].ToString();
                reportViewModels.SONumber = dr[1].ToString();
                reportViewModels.CustomerName = dr[2].ToString();
                reportViewModels.Incoterm1 = dr[3].ToString();
                reportViewModels.TotalWeight = dr[4].ToString();
                reportViewModels.ShiptoDistrict = dr[5].ToString();
                reportViewModels.ShiptoStreet = dr[6].ToString();
                reportViewModels.ShiptoName = dr[7].ToString();
                reportViewModels.MaterialDescription = dr[8].ToString();
                reportViewModels.ShiptoRegionCode = dr[9].ToString();
                reportViewModels.DNNumber = dr[10].ToString();
                reportViewModels.SMNumber = dr[11].ToString();
                reportViewModels.CarrierName = dr[12].ToString();
                reportViewModels.EquipmentTypeName = dr[13].ToString();
                reportViewModels.SMDescription = dr[14].ToString();
                reportViewModels.ShippingPointName = dr[15].ToString();
                reportViewModels.RequestDeliveryDate = dr[16].ToString();
                reportViewModels.GIDate = dr[17].ToString();
                reportViewModels.TruckLicense = dr[22].ToString();
                reportViewModels.ActualDeliveryDate = dr[23].ToString();
                reportViewModels.ActualDocumentReturnDate = dr[24].ToString();
                reportViewModels.PlannerName = dr[31].ToString();
                lsReportViewModels.Add(reportViewModels);

                i++;
            }

            dr.Close();
            con.Close();

            var jsonResult = Json(new { data = lsReportViewModels });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        [HttpPost]
        public JsonResult GetLPC004Data(string Selectmonth)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username =liluna_datalake; Password =Liluna@SCGL; Database =pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = "select * from dom.\"Reporting_LPC004\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            List<Report004ViewModel> lsReportViewModels = new List<Report004ViewModel>();
            int i = 1;

            while (dr.Read())
            {
                Report004ViewModel reportViewModels = new Report004ViewModel();
                reportViewModels.No = i.ToString();
                reportViewModels.DestinationName = dr[0].ToString();
                reportViewModels.OrderNumber = dr[1].ToString();
                reportViewModels.SMWeight = dr[2].ToString();
                reportViewModels.DNNumber = dr[3].ToString();
                reportViewModels.GIDate = dr[4].ToString();
                reportViewModels.SMNumber = dr[5].ToString();
                reportViewModels.ActualTenderStatus = dr[6].ToString();
                reportViewModels.EquipmentTypeName = dr[7].ToString();
                reportViewModels.CarrierName = dr[8].ToString();
                reportViewModels.RequestDate = dr[9].ToString();
                reportViewModels.ShippingPointCode = dr[10].ToString();
                reportViewModels.ShippingPointName = dr[11].ToString();
                reportViewModels.TotalDistance = dr[12].ToString();
                reportViewModels.ActualDeliveryDate = dr[13].ToString();
                reportViewModels.SMRemark = dr[14].ToString();
                reportViewModels.TruckLicense = dr[15].ToString();
                reportViewModels.ShiptoCode = dr[16].ToString();
                reportViewModels.ShiptoRegion = dr[17].ToString();
                reportViewModels.CustomerName = dr[18].ToString();
                reportViewModels.CommodityCode = dr[19].ToString();
                reportViewModels.CommodityDescrition = dr[20].ToString();
                reportViewModels.SMDescription = dr[21].ToString();
                reportViewModels.ActualTenderDate = dr[22].ToString();
                reportViewModels.ActualTenderAcceptDate = dr[23].ToString();
                reportViewModels.ShiptoCity = dr[24].ToString();
                reportViewModels.SMStatus = dr[25].ToString();
                reportViewModels.Planner = dr[26].ToString();
                reportViewModels.SMCreateDate = dr[27].ToString();
                reportViewModels.MaterialDescription = dr[28].ToString();
                reportViewModels.PONumber = dr[29].ToString();
                lsReportViewModels.Add(reportViewModels);

                i++;
            }

            dr.Close();
            con.Close();

            var jsonResult = Json(new { data = lsReportViewModels });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        [HttpPost]
        public JsonResult GetLPC010Data(string Selectmonth)
        {
            var cs = "Host=qa-datalake-pg.cluster-ctg0nvlybzpq.ap-southeast-1.rds.amazonaws.com; Username =liluna_datalake; Password =Liluna@SCGL; Database =pd_datalake";
            var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = "select * from dom.\"Reporting_LPC010\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            List<Report010ViewModel> lsReportViewModels = new List<Report010ViewModel>();
            int i = 1;

            while (dr.Read())
            {
                Report010ViewModel reportViewModels = new Report010ViewModel();
                reportViewModels.No = i.ToString();
                reportViewModels.StatusDescription = dr[0].ToString();
                reportViewModels.User = dr[1].ToString();
                reportViewModels.SMCreateDate = dr[2].ToString();
                reportViewModels.ReqID = dr[3].ToString();
                reportViewModels.SMNumber = dr[4].ToString();
                reportViewModels.NumberofDN = dr[5].ToString();
                reportViewModels.TrackingNo = dr[6].ToString();
                reportViewModels.CustomerName = dr[7].ToString();
                reportViewModels.EquipmentTypeName = dr[8].ToString();
                reportViewModels.CarrierCode = dr[9].ToString();
                reportViewModels.TotalStop = dr[10].ToString();
                reportViewModels.TotalWeight = dr[11].ToString();
                reportViewModels.TotalVolume = dr[12].ToString();
                reportViewModels.UtiWeight = dr[13].ToString();
                reportViewModels.UtiVol = dr[14].ToString();
                reportViewModels.Type = dr[15].ToString();
                lsReportViewModels.Add(reportViewModels);
                i++;
            }

            dr.Close();
            con.Close();

            var jsonResult = Json( new { data = lsReportViewModels });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        #endregion
    }
}