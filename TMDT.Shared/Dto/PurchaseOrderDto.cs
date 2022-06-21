using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Shared.Dto
{
    public class PurchaseOrderDto
    {
        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string VoucherNo { get; set; }
        public string Note { get; set; }
        public bool SentMail { get; set; }
        public int ProcessStatusCode { get; set; }
        public string ProcessStatus { get; set; }
        public string Status { get; set; }
        public double InTheProcessDay { get; set; }
        public PurchaseOrderDto()
        {

        }
        public PurchaseOrderDto(int orderNo, DateTime orderDate, string deliveryAddress, string customerName, string employeeName, string voucherNo, string note, 
            bool sentMail, int processStatus, bool status)
        {
            this.OrderNo = orderNo; 
            this.OrderDate = orderDate;
            this.DeliveryAddress = deliveryAddress;
            this.CustomerName = customerName;
            this.EmployeeName = employeeName;
            this.VoucherNo = voucherNo;
            this.Note = note;
            this.SentMail = sentMail;
            this.ProcessStatusCode = processStatus;
            switch(processStatus)
            {
                case 0:
                    this.ProcessStatus = "Failed";
                    break;
                case 1:
                    this.ProcessStatus = "Received";
                    break;
                case 2:
                    this.ProcessStatus = "Processing";
                    break;
                case 3:
                    this.ProcessStatus = "Confirmed";
                    break;
                case 4:
                    this.ProcessStatus = "Arrived at shipping partner";
                    break;
                case 5:
                    this.ProcessStatus = "Delivered";
                    break;
                case 6:
                    this.ProcessStatus = "Waiting to complete";
                    break;
                case 7:
                    this.ProcessStatus = "Return and Refund";
                    break;
                case 8:
                    this.ProcessStatus = "Done";
                    break;
            }
            this.Status = string.Format(status ? "Y" : "N");
            this.InTheProcessDay = DateTime.Now.Subtract(this.OrderDate).Days;
        }
    }
}
