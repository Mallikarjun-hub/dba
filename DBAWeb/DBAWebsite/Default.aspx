<%@ Page Title="DBA Website: Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DBAWebsite._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>License Info 
    </h2>
   <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
     <%--   <table id="dtest" style="width: 50%; text-align: center; background-color: skyblue;">  
            <tr>  
                <td valign="top" style="width:300px;">
                        <asp:DropDownList ID="dtable" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
            </tr>  
        </table>  --%>
    <%--<asp:GridView ID="Tournament" runat="server"></asp:GridView>--%>
   <%-- <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" />
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="Dispatched" HeaderText="Dispatched" />
        </Columns>
        </asp:GridView>--%>
 <%--   <h2>Latest Installations
    </h2>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>--%>
<%--  <h2>Links
    </h2>
     <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
          <Columns>
        <asp:HyperLinkField DataTextField="Link" DataNavigateUrlFields="Link" DataNavigateUrlFormatString="~/Details.aspx?Link={0}"
            HeaderText="Name" ItemStyle-Width = "150" />
        <asp:BoundField DataField="LinkName" HeaderText="LinkName" ItemStyle-Width = "150" />
    </Columns>
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>--%>
    
    <%--<h3>DO's:
    </h3>
    <ul>
        <li>PATIENCE</li>
        <li>PRIORITIZE</li>
        <li>TEAM PLAYER</li>
        <li>CHAIN OF COMMAND</li>
    </ul>
    <h3>DONT'S:
    </h3>
    <ul>
        <li>SA ACCESS WITHOUT MANAGERS APPROVAL</li>
    </ul>--%>
    <div style="width: 800px; height: 500px; overflow: hidden; text-align:center;margin-left:105px;margin-bottom:50px;margin-top:50px;">
        <img id="Img2" runat="server" src="~/Images/database.jpg" align="middle"/>
    </div>
</asp:Content>
