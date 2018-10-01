<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Notifications.aspx.cs" Inherits="NHUB.Notifications" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
        <div class="auto-style1" style="height: 100%; z-index: 1; width: 100%; position: relative; top: 22px; left: -5px; text-align: right;">
            <h1 class="text-left">Notifications:</h1>
            <p class="text-left">
               <asp:PlaceHolder ID="NotificationPlaceHolder" runat="server"></asp:PlaceHolder>
            </p>

                    <strong>
                          
                    <asp:TreeView ID="TreeView1" runat="server" style="height: 196px; font-family: Arial; font-size: large; color: #0000FF;" Width="122px" BackColor="White" ExpandDepth="0" ForeColor="#0066FF" ImageSet="Arrows">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                       
            
          
             </strong>
            
          
             <br />

       <asp:Button ID="AddNotificationButton" runat="server" style="margin-top: 0;" Text="Add Notification" OnClick="AddNotificationButton_Click" Height="58px" BackColor="Blue" BorderStyle="Ridge" ForeColor="White" />
    </div>
</asp:Content>