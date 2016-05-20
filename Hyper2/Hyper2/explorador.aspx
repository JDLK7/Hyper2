<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="explorador.aspx.cs" Inherits="Hyper2.explorador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/jquery-1.9.1.js"></script>
    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src='scripts/explorerEditor.js'></script>
    <link rel="stylesheet" type="text/css" href="Content/explorador.css" />

    <title>Explorador de archivos</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <cc1:modalpopupextender id="ModalPopupExtender1" runat="server" 
	    cancelcontrolid="buttonClose" okcontrolid="buttonClose" 
	    targetcontrolid="buttonDummy" popupcontrolid="Panel1" 
	    popupdraghandlecontrolid="PopupHeader" drag="true" 
	    backgroundcssclass="ModalPopupBG">
    </cc1:modalpopupextender>

    <asp:panel id="Panel1" style="display: none" runat="server">
	    <div class="HellowWorldPopup">
            <div class="PopupHeader" id="PopupHeader">
                <asp:LinkButton ID="buttonClose" runat="server" CssClass="btn btn-default" style="margin-left:1em; border:none;">
                    <span aria-hidden="true" class=" glyphicon glyphicon-remove-circle"></span>
                </asp:LinkButton>
            </div>

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
                <asp:LinkButton ID="buttonRemove" runat="server" CssClass="btn btn-default buttonPopup" OnClick="buttonRemove_Click">
                    <span aria-hidden="true" class="glyphicon glyphicon-remove"></span>
                    Eliminar
                </asp:LinkButton>                
		    </div>
        </div>
    </asp:panel>

    <div id="wrapper">
        <div id="treeView-container">
            <asp:LinkButton runat="server" ID="buttonHome" CssClass="btn btn-lg" OnClick="buttonHome_Click">
                <span aria-hidden="true" class="glyphicon glyphicon-home"></span>
                <asp:Label runat="server" ID="labelUsername"></asp:Label>
            </asp:LinkButton>
            <asp:TreeView ID="TreeView1" runat="server" NodeStyle-CssClass="treeNode" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" 
                RootNodeStyle-CssClass="rootNode" LeafNodeStyle-CssClass="leafNode" SelectedNodeStyle-Font-Bold="true" 
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
                                        <!--<span aria-hidden="true" class="glyphicon glyphicon-option-horizontal"></span>-->
                                        <span>Opciones</span>
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
                <asp:LinkButton ID="buttonNewFolder" runat="server" CssClass="btn btn-default toolbarButton" OnClick="buttonNewFolder_Click">
                    <span aria-hidden="true" class="glyphicon glyphicon-folder-open"></span>
                    Nueva carpeta
                </asp:LinkButton>
                <asp:TextBox ID="newFolderName" runat="server" CssClass="form-control toolbarTextBox" Visible="false" placeholder="Introduce el nombre"></asp:TextBox>
                <asp:Button ID="buttonOk" runat="server" OnClick="buttonOk_Click" style="display:none"/>
                <!--<asp:LinkButton ID="buttonBrowse" runat="server" CssClass="btn btn-default toolbarButton" OnClientClick="showBrowseDialog()">
                    <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                    Examinar
                </asp:LinkButton>-->
                <asp:LinkButton ID="buttonUploadOk" runat="server" CssClass="btn btn-default toolbarButton" OnClick="buttonUpload_Click">
                    <span aria-hidden="true" class="glyphicon glyphicon-cloud-upload"></span>
                    Subir
                </asp:LinkButton>
                <asp:FileUpload id="uploadControl" runat="server" style="display:inline; margin-left:1em; vertical-align:sub;" AllowMultiple="true"/>

                <!--
                <div class="progress" style="width:80%; margin-left:2.5em; margin-top:0.5em">
                  <div id="progressBar" class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="45" aria-valuemin="0" aria-valuemax="100" style="width: 45%">
                    <span id="progressBarLabel" class="sr-only">Subiendo...</span>
                  </div>
                </div>
                -->
            </asp:Panel>

            <asp:Button id="buttonDummy" runat="server" style="display:none" />
        </div>
    </div>
</asp:Content>
