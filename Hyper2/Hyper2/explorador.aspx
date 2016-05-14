<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="explorador.aspx.cs" Inherits="Hyper2.explorador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
            height:3em;
            background-color:#5F5F5F;
            z-index:2;
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
            width:20%;
            text-align:center;
        }
        .node {
            font-size:large;
        }
        .botonsito {
            margin-left:1em;
            margin-top:0.2em;
        }
        .buttonMore {
            vertical-align:middle;
            height:0.5em;
            width:1em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">
        <div id="treeView-container">
            <asp:TreeView ID="TreeView1" runat="server" NodeStyle-CssClass="treeNode" RootNodeStyle-CssClass="rootNode" LeafNodeStyle-CssClass="leafNode">
                <NodeStyle CssClass="node"/>
            </asp:TreeView>
        </div>
        <div id="listView-container">
            <asp:ListView ID="explorerListView" runat="server" OnItemCommand="onClickedMore">
                  <LayoutTemplate>
                    <table runat="server" id="itemPlaceHolderContainer" width="100%">
                            <tr>
                                <th>Nombre</th>
                                <th>Fecha de subida</th>
                                <th>Tipo</th>
                                <th>Tamaño</th>
                                <th></th>
                            </tr>
                            <tr runat="server" id="itemPlaceHolder"></tr>
                    </table>
                  </LayoutTemplate>
                  <ItemTemplate>
                    <tr runat="server" onclick="onClickedRow">
                        <td runat="server">
                            <asp:Label ID="labelName" runat="server" Text='<%#Eval("Name") %>' />
                        </td>
                        <td runat="server" style="text-align:center;">
                            <asp:Label ID="labelDate" runat="server" Text='<%#Eval("CreationTime") %>' />
                        </td>
                        <td runat="server" style="text-align:center;">
                            <asp:Label ID="labelExtension" runat="server" Text='<%#Eval("Extension") %>' />
                        </td>    
                        <td style="text-align:center;">10 MB</td>
                        <td runat="server" style="text-align:center;">
                            <asp:LinkButton ID="buttonMore" runat="server" CssClass="btn btn-default btn-lg" CommandName="more" CommandArgument='<%# Container.DataItemIndex %>'>
                                <span aria-hidden="true" class="glyphicon glyphicon-option-horizontal"></span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                  </ItemTemplate>
                <EmptyDataTemplate>
                    <td>No existen archivos.</td>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
        <div id="toolbar">
            <asp:Button runat="server" ID="buttonUpload" Text="Subir" CssClass="btn btn-default botonsito"/>
            <asp:Button runat="server" ID="buttonNewFolder" Text="Nueva carpeta" CssClass="btn btn-default botonsito"/>
            <asp:Button runat="server" ID="buttonDownload" Text="Descargar" CssClass="btn btn-default botonsito"/>
            <asp:Button runat="server" ID="buttonPublic" Text="Hacer público" CssClass="btn btn-default botonsito"/>
            <asp:Button runat="server" ID="buttonShare" Text="Compartir" CssClass="btn btn-default botonsito"/>
            <asp:Label runat="server" ID="labelResultado" Text="Nada" />
        </div>
    </div>
</asp:Content>
