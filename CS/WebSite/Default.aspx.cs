using System;
using System.Linq;
using System.IO;

public partial class _Default: System.Web.UI.Page {
    protected string DocumentsFolder = "~/App_Data/";
    protected string DocumentFileName = "Document";
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsCallback && !IsPostBack) {
            Directory.EnumerateFiles(MapPath(DocumentsFolder)).ToList().ForEach(File.Delete);
            Grid.DataBind();
        }
    }
    protected void Grid_DataBinding(object sender, EventArgs e) {
        Grid.DataSource = Enumerable.Range(0, 100).Select(i => new {
            ID = i,
            C1 = i % 2,
            C2 = i * 0.5 % 3,
            C3 = "C3 " + i,
            C4 = i % 2 == 0,
            C5 = new DateTime(2015 + i, 12, 16)
        }).ToList();
    }
    protected void BtnExportToCSV_Click(object sender, EventArgs e) {
        SaveFile(actionToCall => Exporter.WriteCsv(actionToCall), "csv");
    }
    protected void BtnExportToPDF_Click(object sender, EventArgs e) {
        SaveFile(actionToCall => Exporter.WritePdf(actionToCall), "pdf");
    }
    protected void BtnExportToRTF_Click(object sender, EventArgs e) {
        SaveFile(actionToCall => Exporter.WriteRtf(actionToCall), "rtf");
    }
    protected void BtnExportToXLS_Click(object sender, EventArgs e) {
        SaveFile(actionToCall => Exporter.WriteXls(actionToCall), "xls");
    }
    protected void BtnExportToXLSX_Click(object sender, EventArgs e) {
        SaveFile(actionToCall => Exporter.WriteXlsx(actionToCall), "xlsx");
    }
    protected void SaveFile(Action<Stream> action, string format) {
        using (MemoryStream memoryStream = new MemoryStream()) {
            action(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            using (FileStream fileStream = new FileStream(MapPath(
                    string.Format("{0}/{1}.{2}",
                    DocumentsFolder,
                    DocumentFileName,
                    format)
                ),
                FileMode.Create,
                FileAccess.Write)) {
                memoryStream.WriteTo(fileStream);
            }
        }
    }
}