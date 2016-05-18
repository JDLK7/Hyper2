<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Prueba_progressBar.aspx.cs" Inherits="Hyper2.Prueba_progressBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $('#btn').click(function () {
                $('#progressbar').css('width', '80%');
            });
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <select id="ddlPercentage">
        <option value="10">10</option>
        <option value="20">20</option>
        <option value="30">30</option>
        <option value="40">40</option>
        <option value="50">50</option>
        <option value="60">60</option>
        <option value="70">70</option>
        <option value="80">80</option>
        <option value="90">90</option>
        <option value="100">100</option>
    </select>
    <input type="button" id="btn" value="Set Value" />
    <br /><br />
    
    <div class="progress">
      <div id="progressbar" class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="45" aria-valuemin="0" aria-valuemax="100" style="width: 0%">
        <span class="sr-only">45% Complete</span>
      </div>
    </div>
</asp:Content>
