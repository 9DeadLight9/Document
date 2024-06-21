using System;

namespace DocumentFactoryExample
{
    public abstract class Document
    {
        public abstract void Print();

        public void PrepareForPrinting()
        {
            Console.WriteLine("Preparing the document for printing...");
            Print();
        }
    }

  
    public class PDFDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Printing PDF document.");
        }
    }

    public class WordDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Printing Word document.");
        }
    }

    public class ExcelDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Printing Excel document.");
        }
    }

    public class DocumentFactory
    {
        public enum DocumentType
        {
            PDF,
            Word,
            Excel
        }

        public static Document CreateDocument(DocumentType type)
        {
            switch (type)
            {
                case DocumentType.PDF:
                    return new PDFDocument();
                case DocumentType.Word:
                    return new WordDocument();
                case DocumentType.Excel:
                    return new ExcelDocument();
                default:
                    throw new ArgumentException("Invalid document type.");
            }
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            
            Document pdfDocument = DocumentFactory.CreateDocument(DocumentFactory.DocumentType.PDF);
            Document wordDocument = DocumentFactory.CreateDocument(DocumentFactory.DocumentType.Word);
            Document excelDocument = DocumentFactory.CreateDocument(DocumentFactory.DocumentType.Excel);

            pdfDocument.PrepareForPrinting();
            wordDocument.PrepareForPrinting();
            excelDocument.PrepareForPrinting();
        }
    }
}
