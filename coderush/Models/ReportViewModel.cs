using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Models
{
    public class ReportViewModel
    {
        public string ActualTenderDate { get; set; }
        public string SONumber { get; set; }
        public string SoldToName { get; set; }
        public string Incoterm1 { get; set; }
        public double TotalWeight { get; set; }
        public string ShiptoDistrict { get; set; }
        public string ShiptoProvince { get; set; }
        public string ShiptoName { get; set; }
        public string ItemDescription { get; set; }
        public string ShiptoRegion { get; set; }
        public string DNNumber { get; set; }
        public string SMNumber { get; set; }
        public string CarrierName { get; set; }
        public string EquipmentTypeName { get; set; }
        public string SMDescription { get; set; }
        public string ShippingPointName { get; set; }
        public string RequestDeliveryDate { get; set; }
        public string GIDate { get; set; }
        public string TruckLicense { get; set; }
        public string ActualDeliveryDate { get; set; }
        public string ActualDocumentReturnDate { get; set; }
        public string PlannerName { get; set; }
    }

    public class Report010ViewModel
    {
        public string No { get; set; }
        public string StatusDescription { get; set; }
        public string User { get; set; }
        public string SMCreateDate { get; set; }
        public string ReqID { get; set; }
        public string SMNumber { get; set; }
        public string NumberofDN { get; set; }
        public string TrackingNo { get; set; }
        public string CustomerName { get; set; }
        public string EquipmentTypeName { get; set; }
        public string CarrierCode { get; set; }
        public string TotalStop { get; set; }
        public string TotalWeight { get; set; }
        public string TotalVolume { get; set; }
        public string UtiWeight { get; set; }
        public string UtiVol { get; set; }
        public string Type { get; set; }
    }

    public class Report004ViewModel
    {
        public string No { get; set; }
        public string DestinationName { get; set; }
        public string OrderNumber { get; set; }
        public string SMWeight { get; set; }
        public string DNNumber { get; set; }
        public string GIDate { get; set; }
        public string SMNumber { get; set; }
        public string ActualTenderStatus { get; set; }
        public string EquipmentTypeName { get; set; }
        public string CarrierName { get; set; }
        public string RequestDate { get; set; }
        public string ShippingPointCode { get; set; }
        public string ShippingPointName { get; set; }
        public string TotalDistance { get; set; }
        public string ActualDeliveryDate { get; set; }
        public string SMRemark { get; set; }
        public string TruckLicense { get; set; }
        public string ShiptoCode { get; set; }
        public string ShiptoRegion { get; set; }
        public string CustomerName { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityDescrition { get; set; }
        public string SMDescription { get; set; }
        public string ActualTenderDate { get; set; }
        public string ActualTenderAcceptDate { get; set; }
        public string ShiptoCity { get; set; }
        public string SMStatus { get; set; }
        public string Planner { get; set; }
        public string SMCreateDate { get; set; }
        public string MaterialDescription { get; set; }
        public string PONumber { get; set; }
    }

    public class Report007ViewModel
    {
        public string No { get; set; }
        public string SMCreateDate { get; set; }
        public string SONumber { get; set; }
        public string CustomerName { get; set; }
        public string Incoterm1 { get; set; }
        public string TotalWeight { get; set; }
        public string ShiptoDistrict { get; set; }
        public string ShiptoStreet { get; set; }
        public string ShiptoName { get; set; }
        public string MaterialDescription { get; set; }
        public string ShiptoRegionCode { get; set; }
        public string DNNumber { get; set; }
        public string SMNumber { get; set; }
        public string CarrierName { get; set; }
        public string EquipmentTypeName { get; set; }
        public string SMDescription { get; set; }
        public string ShippingPointName { get; set; }
        public string RequestDeliveryDate { get; set; }
        public string GIDate { get; set; }
        public string TruckLicense { get; set; }
        public string ActualDeliveryDate { get; set; }
        public string ActualDocumentReturnDate { get; set; }
        public string PlannerName { get; set; }
    }
}