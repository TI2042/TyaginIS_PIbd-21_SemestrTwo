using DocumentFormat.OpenXml.Spreadsheet;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.Text;


namespace SecuritySystemBusinessLogic.HelperModels
{
    class PdfCellParameters
    {
        public MigraDoc.DocumentObjectModel.Tables.Cell Cell { get; set; }

        public string Text { get; set; }

        public string Style { get; set; }

        public ParagraphAlignment ParagraphAlignment { get; set; }

        public Unit BorderWidth { get; set; }
    }
}
