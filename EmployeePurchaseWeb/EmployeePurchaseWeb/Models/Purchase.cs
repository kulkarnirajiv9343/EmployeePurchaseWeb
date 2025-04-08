using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EmployeePurchaseWeb.Models
{
    public class Purchase
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "The amount must have maximum two decimal places.")]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        [DisplayName("Receipt Image")]
        public byte[] ReceiptImage { get; set; }

    }
}