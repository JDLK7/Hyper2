<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="explorador.aspx.cs" Inherits="Hyper2.explorador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
