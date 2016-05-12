<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="explorador.aspx.cs" Inherits="Hyper2.explorador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/jquery-1.9.1.js"></script>
    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src='scripts/explorerEditor.js'></script>
    <style> 
        #wrapper {
            margin-left:15em;
        }
        #toolbar {
            position:fixed;
            width:100%;
            height:2.5em;
            background-color:#5F5F5F;
            
        }
        #listView-container {
            padding-top:35px;
            position:relative;
            float:right;
            width:100%;
            height:100%;
            background-color:#EEEEEE;
            -webkit-box-shadow: 4px 4px 3px 1px rgba(0,0,0,0.5);
            -moz-box-shadow: 4px 4px 3px 1px rgba(0,0,0,0.5);
            box-shadow: 4px 4px 3px 1px rgba(0,0,0,0.5);
        }
        #treeView-container {
            position:fixed;
            float:left;
            height:100%;
            width:15em;
            margin-left:-15em;
            overflow-x: hidden;
            overflow-y: scroll;
            background-color:#EEEEEE; 
            -webkit-box-shadow: inset 0px 0px 3px 1px rgba(0,0,0,0.5);
            -moz-box-shadow: inset 0px 0px 3px 1px rgba(0,0,0,0.5);
            box-shadow: inset 0px 0px 3px 1px rgba(0,0,0,0.5);
        }
        #cleared {
            clear:both;
        }
        table {
            empty-cells:show;
            border-collapse: collapse;
        }
        tr:nth-child(even) {
            background-color: #e6e6e6
        }
        tr:hover {
            background-color: #d2e8f9
        }
        th {
            border-right: 1px solid #808080;
            height:2.5em;
            background-color: #5F5F5F;
            color: white;
        }
        tr > th {
            width:25%;
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">
        <div id="treeView-container">
            <asp:TreeView ID="TreeView1" runat="server" NodeStyle-CssClass="treeNode" 
                RootNodeStyle-CssClass="rootNode" LeafNodeStyle-CssClass="leafNode">
            </asp:TreeView>
        </div>
        <div id="listView-container">
            <asp:ListView ID="listView1" runat="server">
                  <LayoutTemplate>
                    <table runat="server" id="table1" width="100%">
                            <tr>
                                <th>Nombre</th>
                                <th>Fecha de subida</th>
                                <th>Tipo</th>
                                <th>Tamaño</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                  </LayoutTemplate>
                  <ItemTemplate>
                    <tr runat="server">
                        <td runat="server">
                            <!--<asp:Label ID="NameLabel" runat="server" Text='</%#Eval("Name") %>' />-->
                            <td>Nombre</td>
                        </td>
                        <td runat="server" style="text-align:center;">
                            <!--<asp:Label ID="DateLabel" runat="server" Text='</%#Eval("Date") %>' />-->
                            <td>Date</td>
                        </td>
                        <td runat="server" style="text-align:center;">
                            <!--<asp:Label ID="ExtensionLabel" runat="server" Text='</%#Eval("Extension") %>' />-->
                            <td>Ext</td>
                        </td>
                        <td runat="server" style="text-align:center;">
                            <!--<asp:Label ID="SizeLabel" runat="server" Text='</%#Eval("Size") %>' />-->
                            <td>Size</td>
                        </td>
                    </tr>
                  </ItemTemplate>
                <EmptyDataTemplate>
                    <td>No existen archivos.</td>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
        <div id="toolbar">
            <p style="text-align:center; color:white;">TOOLBAR</p>
        </div>
    </div>
</asp:Content>
