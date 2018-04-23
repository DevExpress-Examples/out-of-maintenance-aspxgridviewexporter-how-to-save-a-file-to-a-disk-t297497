<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmMain" runat="server">
    <dx:ASPxGridView ID="Grid" runat="server" KeyFieldName="ID" OnDataBinding="Grid_DataBinding">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="C1" />
            <dx:GridViewDataSpinEditColumn FieldName="C2" />
            <dx:GridViewDataTextColumn FieldName="C3" />
            <dx:GridViewDataCheckColumn FieldName="C4" />
            <dx:GridViewDataDateColumn FieldName="C5" />
        </Columns>
    </dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="Exporter" runat="server" GridViewID="Grid">
    </dx:ASPxGridViewExporter>
    <dx:ASPxButton ID="BtnExportToCSV" runat="server" Text="Export To CSV" OnClick="BtnExportToCSV_Click">
    </dx:ASPxButton>
    <dx:ASPxButton ID="BtnExportToPDF" runat="server" Text="Export To PDF" OnClick="BtnExportToPDF_Click">
    </dx:ASPxButton>
    <dx:ASPxButton ID="BtnExportToRTF" runat="server" Text="Export To RTF" OnClick="BtnExportToRTF_Click">
    </dx:ASPxButton>
    <dx:ASPxButton ID="BtnExportToXLS" runat="server" Text="Export To XLS" OnClick="BtnExportToXLS_Click">
    </dx:ASPxButton>
    <dx:ASPxButton ID="BtnExportToXLSX" runat="server" Text="Export To XLSX" OnClick="BtnExportToXLSX_Click">
    </dx:ASPxButton>
    </form>
</body>
</html>
