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
            position:relative;
            width:100%;
            height:2.5em;
            background-color:#5F5F5F;
            
        }
        #listView-container {
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
            position:absolute;
            float:left;
            height:100%;
            width:15em;
            margin-left:-15em;
            overflow:hidden;
            background-color:#EEEEEE; 
            -webkit-box-shadow: inset 0px 0px 3px 1px rgba(0,0,0,0.5);
            -moz-box-shadow: inset 0px 0px 3px 1px rgba(0,0,0,0.5);
            box-shadow: inset 0px 0px 3px 1px rgba(0,0,0,0.5);
        }
        #cleared {
            clear:both;
        }
        table {
            border-collapse: collapse;
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
        <div id="toolbar">
            <p style="text-align:center; color:white;">TOOLBAR</p>
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
                        <!-- Data-bound content. -->
                            <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
                        </td>
                        <td style="text-align:center;">1/1/1970</td>
                        <td style="text-align:center;">.txt</td>
                        <td style="text-align:center;">10 MB</td>
                    </tr>
                  </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
