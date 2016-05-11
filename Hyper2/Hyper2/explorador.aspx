<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="explorador.aspx.cs" Inherits="Hyper2.explorador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src='scripts/explorerEditor.js'></script>

    <style> 
        #wrapper {
            margin-left:15em;
        }
        #listView-container {
            position:absolute;
            float:right;
            width:100%;
            height:100%;
            background-color:burlywood;
        }
        #treeView-container {
            position:absolute;
            float:left;
            height:100%;
            width:15em;
            margin-left:-15em;
            overflow:hidden;
            background-color:#169be6; 
        }
        #cleared {
            clear:both;
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
                    <table runat="server" id="table1" >
                      <tr runat="server" id="itemPlaceholder" ></tr>
                    </table>
                  </LayoutTemplate>
                  <ItemTemplate>
                    <tr runat="server">
                      <td runat="server">
                        <!-- Data-bound content. -->
                        <asp:Label ID="NameLabel" runat="server" 
                          Text='<%#Eval("Name") %>' />
                      </td>
                    </tr>
                  </ItemTemplate>
            </asp:ListView>
        </div>
        <!--<div id="cleared"></div>-->
    </div>
</asp:Content>
