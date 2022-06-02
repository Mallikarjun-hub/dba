<%@ Page Title="LicenseForm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LicenseForm.aspx.cs" Inherits="DBAWebsite.LicenseForm" EnableEventValidation="false" %>

<asp:Content ID="content1" ContentPlaceHolderID="headcontent" runat="server">
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="maincontent" runat="server">
    <br />
    <h2 style="text-align: center;">License Form for server: 
        <asp:Label ID="lblhead_servername" runat="server"></asp:Label></h2>
    <br />

    <form id="container" method="post" action="Web.config" style="width: 100%; margin-bottom: 500px;">
        <div id="Licensepane" style="float: left; width: 100%; line-height: 4.0em;">
            <table>
                <tr>
                    <td valign="top" style="width: 180px;">
                        <label for="pordernumber"><b>Purchase order Number:</b></label>
                    </td>                    
                    <td valign="top" style="width: 300px;">                                                
                        <asp:TextBox maxlength="40" size="20" ID="license_purchaseorderNumber" runat="server"/>
                    </td>
                   <td valign="top"  style="width: 150px;">
                        <label for="license_purchasedate"><b>Purchase Date:</b></label>
                    </td>
                    <td valign="top"  style="width: 100px;">
                        <input type="text" id="purchasedate" name ="purchasedate"  style="width: 100px;" />  
                        <input id="Hidden1" type="hidden" runat="server" />                                                
                    </td>                   
                </tr>
                <tr>
                    <td valign="top">
                        <label for="noofcores"><b>Purchase Quantity:</b></label>
                    </td>
                     <td valign="top">                                                
                         <asp:TextBox maxlength="40" size="20" ID="license_purchaseQuantity" runat="server"/>
                    </td>   
                    <td valign="top">
                        <label for="contactperson"><b>Contact Person:</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="contactperson_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>                           
                </tr>     
                <tr>
                    <td valign="top">
                        <label for="contactteam"><b>Contact Team:</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="contactTeam_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>     
                    <td valign="top">
                        <label for="licenseCategory"><b>License Category:</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="licenseCategory_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>                    
                </tr> 
                <tr>
                    <td valign="top">
                        <label for="licenseLocation"><b>License Location:</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="licenseLocation_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <label for="licensePurchaseby"><b>License Purchased By:</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="licensePurchaseby_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>                    
                </tr>    
                 <tr>                                         
                     <td valign="top">
                        <label for="licenseNumber"><b>License Other Number:</b></label>
                    </td>
                     <td valign="top">                                                
                         <asp:TextBox maxlength="40" size="20" ID="licenseNumber_txt" runat="server"/>
                    </td>      
                      <td valign="top">
                        <label for="noofusers"><b>Number of users:</b></label>
                    </td>
                     <td valign="top">                                                
                         <asp:TextBox maxlength="40" size="20" ID="Noofusers_txt" runat="server"/>
                    </td>                            
                </tr>               
            </table>
        </div>

        <div style="line-height: 6em;">
                <table width="1000px">
                    <tr>
                        <td valign="top">
                            <label for="notes"><b>Overall License Notes:</b></label>
                        </td>
                        <td>
                            <textarea id="license_overall_notes" name="license_overall_notes" cols="62" rows="6"></textarea>
                        </td>
                        <td>

                        </td>
                    </tr>
                </table>                
            </div>

        <div style="text-align: center;line-height: 3em;">
                <asp:Button Text="Submit" OnClick="submit_Click" runat="server"/>
        </div>
    </form>

   

</asp:Content>
