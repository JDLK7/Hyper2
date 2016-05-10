<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="Hyper2.messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" NodeStyle-CssClass="treeNode" 
            RootNodeStyle-CssClass="rootNode" LeafNodeStyle-CssClass="leafNode">

        </asp:TreeView>
    </div>    
</asp:Content>
