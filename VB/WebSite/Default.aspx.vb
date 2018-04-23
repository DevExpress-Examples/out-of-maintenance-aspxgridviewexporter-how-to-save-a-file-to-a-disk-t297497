Imports System
Imports System.Linq
Imports System.IO

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected DocumentsFolder As String = "~/App_Data/"
	Protected DocumentFileName As String = "Document"
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsCallback) AndAlso (Not IsPostBack) Then
            Directory.EnumerateFiles(MapPath(DocumentsFolder)).ToList().ForEach(Sub(f) File.Delete(f))
            Grid.DataBind()
		End If
	End Sub
	Protected Sub Grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		Grid.DataSource = Enumerable.Range(0, 100).Select(Function(i) New With {Key .ID = i, Key .C1 = i Mod 2, Key .C2 = i * 0.5 Mod 3, Key .C3 = "C3 " & i, Key .C4 = i Mod 2 = 0, Key .C5 = New Date(2015 + i, 12, 16)}).ToList()
	End Sub
	Protected Sub BtnExportToCSV_Click(ByVal sender As Object, ByVal e As EventArgs)
		SaveFile(Sub(actionToCall) Exporter.WriteCsv(actionToCall), "csv")
	End Sub
	Protected Sub BtnExportToPDF_Click(ByVal sender As Object, ByVal e As EventArgs)
		SaveFile(Sub(actionToCall) Exporter.WritePdf(actionToCall), "pdf")
	End Sub
	Protected Sub BtnExportToRTF_Click(ByVal sender As Object, ByVal e As EventArgs)
		SaveFile(Sub(actionToCall) Exporter.WriteRtf(actionToCall), "rtf")
	End Sub
	Protected Sub BtnExportToXLS_Click(ByVal sender As Object, ByVal e As EventArgs)
		SaveFile(Sub(actionToCall) Exporter.WriteXls(actionToCall), "xls")
	End Sub
	Protected Sub BtnExportToXLSX_Click(ByVal sender As Object, ByVal e As EventArgs)
		SaveFile(Sub(actionToCall) Exporter.WriteXlsx(actionToCall), "xlsx")
	End Sub
	Protected Sub SaveFile(ByVal action As Action(Of Stream), ByVal format As String)
		Using memoryStream As New MemoryStream()
			action(memoryStream)
			memoryStream.Seek(0, SeekOrigin.Begin)
			Using fileStream As New FileStream(MapPath(String.Format("{0}/{1}.{2}", DocumentsFolder, DocumentFileName, format)), FileMode.Create, FileAccess.Write)
				memoryStream.WriteTo(fileStream)
			End Using
		End Using
	End Sub
End Class