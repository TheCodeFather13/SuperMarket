using QuestPDF.Drawing;
using QuestPDF.Infrastructure;

namespace WebApp.Tools.PDF
{
    public interface IDocument
    {
        DocumentMetadata GetMetadata();
        void Compose(IDocumentContainer container);
    }
}
