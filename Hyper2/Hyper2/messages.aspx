<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="Hyper2.messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <!--<link rel="stylesheet" type="text/css" href="Content/messages.css" />-->
    <script src="scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src='scripts/explorerEditor.js'></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="exploradorTreeView">
        <asp:TreeView ID="TreeView1" runat="server" NodeStyle-CssClass="treeNode" 
            RootNodeStyle-CssClass="rootNode" LeafNodeStyle-CssClass="leafNode">

        </asp:TreeView>
    </div>    
</asp:Content>
