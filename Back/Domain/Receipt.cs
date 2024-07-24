using System.Diagnostics.Contracts;

namespace Domain;
public class Receipt
{
    public decimal TotalPrice { get; set; }
    public int Id { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<ReceiptItem> Items { get; set; }
    public string CustomerName { get; set; }

    public Receipt(List<ReceiptItem> items)
    {
        Items = items;
        TotalPrice = Items.Sum(i => i.ItemTotalPrice);
        RegistrationDate = DateTime.Now;
        CustomerName = "Customer";
    }

}

