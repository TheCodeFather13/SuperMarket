using Plugins.DataStore.Sql;
using Plugins.DataStore.Sql.Repositories;
using System.Configuration;
using System.Diagnostics;

namespace WebApp.Tools.PDF
{
    public class TransactionPDFGenerator
    {
        private readonly SuperMarketDbContext _dbContext;

        public TransactionPDFGenerator(SuperMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       public void Generate()
        {
            var filePath = "Transactions.pdf";

            var model = new TransactionModel();
            model.Title = "Transactions";


            var transactions = _dbContext.Transactions.ToList();
            model.Items = transactions;

            // read transactions from db
            var document = new TransactionDocument(model);
            document.GeneratePdf(filePath);

            Process.Start("explorer.exe", filePath);
        }
    }
}
