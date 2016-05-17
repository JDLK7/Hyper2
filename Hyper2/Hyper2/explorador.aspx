<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="explorador.aspx.cs" Inherits="Hyper2.explorador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/jquery-1.9.1.js"></script>
    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src='scripts/explorerEditor.js'></script>
    <title>Explorador de archivos</title>
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
            z-index:2;
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
        .toolbarButton {
            margin-left:1em;
            margin-top:0.25em;
        }
        .buttonMore {
            vertical-align:middle;
            height:0.5em;
            width:1em;
        }
        .toolbarTextBox {
            margin-left: 1em;
            vertical-align: sub;
        }
        .ModalPopupBG
        {
            background-color: #6c6c6c;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
        .HellowWorldPopup
        {
            min-width:200px;
            min-height:150px;
            background:white;
        }
        .commentTextBox {
            width:inherit;
            margin:1em;
        }
        .buttonPopup {
            margin:1em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <cc1:modalpopupextender id="ModalPopupExtender1" runat="server" 
	    cancelcontrolid="buttonDownload" okcontrolid="buttonDownload" 
	    targetcontrolid="buttonDummy" popupcontrolid="Panel1" 
	    popupdraghandlecontrolid="PopupHeader" drag="true" 
	    backgroundcssclass="ModalPopupBG">
    </cc1:modalpopupextender>

    <asp:panel id="Panel1" style="display: none" runat="server">
	    <div class="HellowWorldPopup">
            <div class="PopupHeader" id="PopupHeader">Header</div>
            <div class="PopupBody">
                <asp:TextBox ID="textBoxComment" runat="server" CssClass="form-control commentTextBox" style="width:80%" placeholder="Escribe un comentario..."></asp:TextBox>
                <asp:Button ID="buttonComment" runat="server" CssClass="btn btn-default" Text="Enviar" />
            </div>
            <div class="Controls">
                <asp:LinkButton ID="buttonDownload" runat="server" CssClass="btn btn-default buttonPopup" onclick="buttonDownload_Click">
                    <span aria-hidden="true" class="glyphicon glyphicon-cloud-download"></span>
                    Descargar
                </asp:LinkButton>
                <asp:LinkButton ID="buttonShare" runat="server" CssClass="btn btn-default buttonPopup">
                    <span aria-hidden="true" class=" glyphicon glyphicon-share"></span>
                    Compartir
                </asp:LinkButton>
                <asp:LinkButton ID="buttonPublic" runat="server" CssClass="btn btn-default buttonPopup">
                    <span aria-hidden="true" class="glyphicon glyphicon-eye-open"></span>
                    Hacer público
                </asp:LinkButton>
                <asp:LinkButton ID="buttonRemove" runat="server" CssClass="btn btn-default buttonPopup">
                    <span aria-hidden="true" class="glyphicon glyphicon-remove"></span>
                    Eliminar
                </asp:LinkButton>                
		    </div>
        </div>
    </asp:panel>

    <div id="wrapper">
        <div id="treeView-container">
            <asp:TreeView ID="TreeView1" runat="server" NodeStyle-CssClass="treeNode" RootNodeStyle-CssClass="rootNode" 
                LeafNodeStyle-CssClass="leafNode" OnSelectedNodeChanged="onClickedNode"
                ExpandImageUrl="IMG/folder-closed.png" NoExpandImageUrl="IMG/folder-closed.png" CollapseImageUrl="IMG/folder-open.png" style="margin-left:1em; margin-top:1em;">
                <NodeStyle CssClass="node" />
            </asp:TreeView>
        </div>
        <div id="listView-container">
            <asp:UpdatePanel runat="server" ID="updatePanelListView" UpdateMode="Conditional">
                <ContentTemplate>
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
                            <tr runat="server">
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
                                    <asp:LinkButton ID="buttonMore" runat="server" CssClass="btn btn-default" CommandName="more" CommandArgument='<%# Container.DataItemIndex %>'>
                                        <span aria-hidden="true" class="glyphicon glyphicon-option-horizontal"></span>
                                    </asp:LinkButton>
                                </td>
                            </tr>
                          </ItemTemplate>
                        <EmptyDataTemplate>
                            <td>No existen archivos.</td>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="toolbar">
            <asp:Panel runat="server" DefaultButton="buttonOk">
                <asp:LinkButton ID="buttonUpload" runat="server" CssClass="btn btn-default toolbarButton" OnClick="buttonUpload_Click">
                    <span aria-hidden="true" class="glyphicon glyphicon-cloud-upload"></span>
                    Subir
                </asp:LinkButton>
                <asp:LinkButton ID="buttonNewFolder" runat="server" CssClass="btn btn-default toolbarButton" OnClick="buttonNewFolder_Click">
                    <span aria-hidden="true" class="glyphicon glyphicon-folder-open"></span>
                    Nueva carpeta
                </asp:LinkButton>
                <asp:TextBox ID="newFolderName" runat="server" CssClass="form-control toolbarTextBox" Visible="false" placeholder="Introduce el nombre"></asp:TextBox>
                <asp:Button ID="buttonOk" runat="server" OnClick="buttonOk_Click" style="display:none"/>
            </asp:Panel>

            <asp:Button id="buttonDummy" runat="server" style="display:none" />
        </div>
    </div>
</asp:Content>
