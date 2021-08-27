<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128536724/15.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T297497)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* **[Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))**
<!-- default file list end -->
# ASPxGridViewExporter - How to save a file to a disk


In addition to downloading a file via <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewExporterMembersTopicAll">ASPxGridViewExporter.Write***ToResponse</a> methods, it is possible to save the file to a disk to the specified location:<br />- Write ASPxGridView data to a MemoryStream object via ASPxGridViewExporter.<strong>Write***</strong> (but <strong>not</strong> ASPxGridViewExporter.<strong>Write***ToResponse</strong>) methods.<br />- Save the populated MemoryStream object as a file (via standard System.IO methods) to the specified location where you have permissions to create files.<br /><br />


```cs
using System;
using System.Linq;
using System.IO;        
...        
using (MemoryStream memoryStream = new MemoryStream()) {
    ASPxGridViewExporter_Instance_Here.WriteXlsx(memoryStream);
    memoryStream.Seek(0, SeekOrigin.Begin);
    using (FileStream fileStream = new FileStream(Full_File_Name_Here, FileMode.Create,  FileAccess.Write)) {
        memoryStream.WriteTo(fileStream);
    }
}
```


<br />


```vb
Imports System
Imports System.Linq
Imports System.IO
...
Using memoryStream As New MemoryStream()
	ASPxGridViewExporter_Instance_Here.WriteXlsx(memoryStream)
	memoryStream.Seek(0, SeekOrigin.Begin)
	Using fileStream As New FileStream(Full_File_Name_Here, FileMode.Create, FileAccess.Write)
		memoryStream.WriteTo(fileStream)
	End Using
End Using
```



<br/>


