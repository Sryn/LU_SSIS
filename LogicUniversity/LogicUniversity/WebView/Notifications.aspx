<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master"
     AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="LogicUniversity.WebView.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblNotiTitle" 
        style="font-family:'Arial Rounded MT'; font-weight:bold; 
font-size:40px; margin-left:60px;"
        runat="server" Text="Notifications"></asp:Label>
    <br />
    <br />
    <br />
    <table class="auto-style1">
        <tr>
            <td><asp:Label ID="lblTxtDeptID" runat="server" Text="DepartmentID"></asp:Label></td>
            <td><asp:Label ID="lblDeptID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtEmpID" runat="server" Text="EmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblEmpID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
            <td><asp:Label ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
  
    <% 
        if(Session["NotiList"]!=null)
        {
        %>

 
 <div style="width:90%; margin-left:140px;">
  

                                        <table
                                            aria-describedby="dataTables-example_info" 
                                            role="grid" 
                                            class="table table-striped table-bordered table-hover dataTable no-footer" 
                                            id="dataTables-example">
                                    <thead>
                                        <tr role="row">
                                            <th aria-label="Rendering engine: activate to sort column ascending" 
                                                style="width: 154.333px;" colspan="1" rowspan="1" 
                                                aria-controls="dataTables-example" tabindex="0" class="sorting">
                                                Date</th>
                                            <th aria-label="Browser: activate to sort column ascending" 
                                                style="width: 182.333px;" colspan="1" rowspan="1" 
                                                aria-controls="dataTables-example" tabindex="0" class="sorting">
                                                Message
                                            </th>
                                            <th aria-sort="ascending" aria-label="Platform(s): activate to sort column descending" 
                                                style="width: 166.333px;" colspan="1" rowspan="1" aria-controls="dataTables-example" 
                                                tabindex="0" class="sorting_asc">
                                             From</th>
                                           </tr>
                                    </thead>
                                    <tbody>
    <%
        List<LogicUniversity.Model.FilNotiLstEle> lstNotification = new List<LogicUniversity.Model.FilNotiLstEle>();
        lstNotification = (List<LogicUniversity.Model.FilNotiLstEle>)Session["NotiList"];

        foreach (LogicUniversity.Model.FilNotiLstEle data in lstNotification)
        { 
         %>
         <tr>
             <td><%=data.dateTimeFilNoti%>  </td>
             <td><%=data.fromUserFilNoti%>  </td>
             <td><%=data.msgFilNoti%>  </td>
         </tr>


                                         
                               

    <%    }
          }
        
         %>
                                    </tbody>
                                </table></div>
    <!-- /#wrapper -->
     <!-- jQuery -->
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>


             <!-- jQuery -->
    <script src='<%= Page.ResolveUrl("~/bower_components/jquery/dist/jquery.min.js")%>'></script>

    <!-- Bootstrap Core JavaScript -->
    <script src='<%= Page.ResolveUrl("~/bower_components/bootstrap/dist/js/bootstrap.min.js")%>'></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../bower_components/metisMenu/dist/metisMenu.min.js"></script>

            

    <!-- DataTables JavaScript -->
    <script src="../bower_components/datatables/media/js/jquery.dataTables.min.js"></script>
    <script src="../bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="../dist/js/sb-admin-2.js"></script>

    <!-- Page-Level Demo Scripts - Tables - Use for reference -->
            <script>
                $(document).ready(function () {
                    $('#dataTables-example').DataTable({
                        responsive: true
                    });
                });
            </script>
</asp:Content>
