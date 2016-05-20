<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="buscador.aspx.cs" Inherits="Hyper2.buscador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="scripts/jquery-1.9.1.js"></script>
    <script src="scripts/jquery-1.9.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Content/buscador.css" />
    <title>Buscador</title>
    
    <script type="text/javascript">
        $(document).ready(function () {
            /*
            $("input[id*='ButtonMore']").click(function (e) {

                //alert the id of the row
                alert($(this).addClass("btn btn-default"));
                

                //submit the form...
            });*/

            $("a[id*='ButtonMore']").addClass("btn btn-default");
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div id="wrapper">

        <div id="listView-container">
            <asp:UpdatePanel runat="server" ID="updatePanelListView" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ListView ID="explorerListView" runat="server" OnItemCommand="onClickedMore">
                          <LayoutTemplate>
                            <table runat="server" id="itemPlaceHolderContainer" width="100%">
                                    <tr>
                                        <th>Nombre</th>
                                        <th>Tipo</th>
                                        <th>Tamaño</th>
                                        <th>Opciones</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceHolder"></tr>
                            </table>
                          </LayoutTemplate>
                          <ItemTemplate>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="labelName" runat="server" Text='<%#Eval("Name") %>' CssClass='<%#Eval("Path") %>' />
                                </td>
                                <td runat="server" style="text-align:center;">
                                    <asp:Label ID="labelDate" runat="server" Text='<%#Eval("Tipo") %>' />
                                </td>
                                <td style="text-align:center;">10 MB</td>
                                <td runat="server" style="text-align:center;">

                                    <asp:LinkButton ID="ButtonMore" runat="server" CssClass='<%#Eval("Path") %>' OnClick="descargarArchivo">
                                        <span>Descargar</span>
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

    </div>
</asp:Content>
