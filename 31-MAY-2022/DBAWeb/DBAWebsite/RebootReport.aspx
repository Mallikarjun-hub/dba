<%@ Page Title="RebootReport" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RebootReport.aspx.cs" Inherits="DBAWebsite.RebootReport" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

    <br />
    <h2 style="text-align: center;"><b>Reboot Report</b></h2>
    <br />
    <br />
        <div style="left: 298px; top: 150px">  
            <label for="ServerName"><b>Server Name </b></label>          
            <asp:TextBox maxlength="80" size="30" ID="txt_search" runat="server"/>
            <%--<asp:Button Text="Search"  onclick="submit_Click" runat="server"/>--%>

            <label for="ServerName"><b>Location </b></label>          
            <asp:TextBox maxlength="80" size="30" ID="txt_search_location" runat="server"/>
            <asp:Button Text="Search" onclick="submit_Click_location" runat="server"/>

            <asp:Button Text="Clear" onclick="clear_Click" runat="server"/>
        </div>
    <br />
    <br />
    <br />
        <div style="width:100%; height:100%; left: 298px; top: 200px;"> 
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                AllowSorting="True" AllowPaging="false" CellPadding="8" ForeColor="#333333" GridLines="None" onpageindexchanging="GridView1_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>                                   
                    <asp:TemplateField HeaderText="ServerName">
                        <ItemTemplate><%#Eval("Server Name") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Location">
                        <ItemTemplate><%#Eval("Location") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ServerType">
                        <ItemTemplate><%#Eval("Production / Non-Production") %> </ItemTemplate>
                    </asp:TemplateField>                
                    <asp:TemplateField HeaderText="Schedule">
                        <ItemTemplate><%#Eval("Reboot / Patch Schedule") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Frequency">
                        <ItemTemplate><%#Eval("Reboot Frequency") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Day">
                        <ItemTemplate><%#Eval("Reboot Day") %> </ItemTemplate>
                    </asp:TemplateField>                
                    <asp:TemplateField HeaderText="Time">
                        <ItemTemplate><%#Eval("tempTime") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact Name">
                        <ItemTemplate><%#Eval("tempContacts") %> </ItemTemplate>
                    </asp:TemplateField>                                     
                </Columns>                                                           
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

        </div>
</asp:Content>

