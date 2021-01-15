<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateQrCodes.aspx.cs" Inherits="DisplayQrCodes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
        <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.10.2.js"></script>
<script src="PageScript/DisplayQrCode.js" type="text/javascript"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="datatable/datatables.css" rel="stylesheet" />
    
    <script src="datatable/datatables.js"></script>
    <link href="datatable/datatables.min.css" rel="stylesheet" />
    <script src="datatable/datatables.min.js"></script>
    <script src="Scripts/qrcode.js"></script>
    <link href="Scripts/qrCode.css" rel="stylesheet" />
   
    <script>
         $(".imgdtl").click(function(event){
    event.stopPropagation();
    alert("The span element was clicked.");
  });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Repeater ID="Repeater1" runat="server">
             <HeaderTemplate>  
    <table style="width:390px;margin-left:-1.2em">  
     
    </HeaderTemplate> 
             
<ItemTemplate>
     <tr style=" font-size: large; font-weight: bold;border:1px solid black;border-right:none;border-left:none;margin:-4px">  
    <td style="width:250px;">  
<asp:ImageButton ID="ImageButton1" runat="server" Height="172px" Width="190px" style="margin:4px;" CssClass="imgdtl" ImageUrl='<%#Eval("QR_Code")%>' OnClientClick="this.onclick=new Function('return false;');" />      
    </td> 
         <td>
             <span style="margin-left:-8.9em;margin-top:-4px">
                 <asp:ImageButton ID="ImageButton2" runat="server" Height="50px" Width="50px" CssClass="imgdtl" ImageUrl='<%#Eval("ilogo")%>'  />

             </span><br />

         </td> 
         <td>
             
             <span style="font-size:12px;margin-left:-6em;"><u>Web-Site</u>:- <asp:Label ID="Label5" runat="server" Text="www.ausadha.org" style="color:blueviolet"></asp:Label></span><br />
              <span style="font-size:12px;margin-left:-6em;"><u>Email ID</u>:- <asp:Label ID="Label4" runat="server" Text="info@ausadha.org" style="color:blueviolet;margin-top:-1em;"></asp:Label></span><br />
           
 <span style="font-size:12px;margin-left:-6em;"><u>Name</u> :- <asp:Label ID="Label2" runat="server" Text='<%#Eval("Name")%>'  ></asp:Label></span><br />
  <span style="font-size:12px;margin-left:-6em;"><u> Batch No.</u>:- <asp:Label ID="Label1" runat="server" Text='<%#Eval("BName")%>' ></asp:Label></span><br />
   <span style="font-size:12px;margin-left:-6em;"> <u>ID</u> :- <asp:Label ID="Label3" runat="server" Text='<%#Eval("IID")%>' ></asp:Label> </span>
         </td>
    </tr>  
</ItemTemplate>  
             <FooterTemplate>  
    </table>  
    </FooterTemplate>  
</asp:Repeater>
<%--Created By Anil Vishwakarma MailID(anilvishwakrma125@gmail.com)--%>

    </div>
    </form>
</body>
</html>
