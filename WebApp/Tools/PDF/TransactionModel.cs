using CoreBusiness;

namespace WebApp.Tools.PDF
{
    public class TransactionModel
    {
        public string Title { get; set; }
        public List<Transaction> Items { get; set; }
    }
}
