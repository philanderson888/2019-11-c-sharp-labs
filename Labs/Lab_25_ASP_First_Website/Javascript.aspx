<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Javascript.aspx.cs" Inherits="Lab_25_ASP_First_Website.Javascript" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<script>
var x = 0;
function runSomeTestData() {
    x++;
    alert('the value of x is ' + x);
    var genius = confirm('are you a computer genius');
    var name = prompt('OK then fine!  Whats your name???');
    if (genius) {
        alert('Thanks, ' + name + ', I will come to you for advice!!!');
    }
    else {
        alert('No problem thanks for your help');
    }
    console.log(genius);
    console.log(name);
}
</script>

    <button onclick="runSomeTestData()">Run Some Test Data</button>
    <div id="test-data"></div>




</asp:Content>
