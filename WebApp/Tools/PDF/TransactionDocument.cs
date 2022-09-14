using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace WebApp.Tools.PDF
{
    public class TransactionDocument : IDocument
    {
        public TransactionModel Model { get; set; }
        public IDocumentContainer Container { get; set; }

        public TransactionDocument(TransactionModel model)
        {
            this.Model = model;
        }
        
        internal void GeneratePdf(string filePath)
        {
            Document.Create(Compose).GeneratePdf(filePath);
        }

        public void Compose(IDocumentContainer container)
        {
            container
           .Page(page =>
              {
                  page.Margin(50);

                  page.Header().Element(ComposeHeader);
                  page.Content().Element(ComposeContent);
                  page.Footer().Height(50).Background(Colors.Grey.Lighten1);
              });
        }

        private void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);

                column.Item().Element(ComposeTable);
            });
        }

        void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(5);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.ConstantColumn(25);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // step 2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("Id");
                    header.Cell().Element(CellStyle).AlignCenter().Text("Date Time");
                    header.Cell().Element(CellStyle).AlignCenter().Text("Product Id");
                    header.Cell().Element(CellStyle).AlignCenter().Text("Product Name");
                    header.Cell().Element(CellStyle).AlignCenter().Text("Price");
                    header.Cell().Element(CellStyle).AlignCenter().Text("Quantity Before");
                    header.Cell().Element(CellStyle).AlignCenter().Text("Quantity Now");
                    header.Cell().Element(CellStyle).AlignCenter().Text("Cashier Name");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.Bold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                // step 3
                foreach (var item in Model.Items)
                {
                    table.Cell().Element(CellStyle).Text(item.TransactionId);
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.TimeStamp);
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.ProductId);
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.ProductName);
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.Price);
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.BeforeQuantity);
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.Quantity);
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.CashierName);

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }

        private void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text(Model.Title).Style(titleStyle);

                    //column.Item().Text(text =>
                    //{
                    //    text.Span("Issue date: ").SemiBold();
                    //    text.Span($"{Model.IssueDate:d}");
                    //});

                    //column.Item().Text(text =>
                    //{
                    //    text.Span("Due date: ").SemiBold();
                    //    text.Span($"{Model.DueDate:d}");
                    //});
                });
                row.ConstantItem(100).Height(50).Placeholder();
            });
        }

        public DocumentMetadata GetMetadata()
        {
            return DocumentMetadata.Default;
        }
    }
}
