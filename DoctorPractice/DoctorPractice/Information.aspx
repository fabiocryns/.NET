<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="DoctorPractice.Information" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/OpeningHours.xml" XPath="/OpeningHours/Day"></asp:XmlDataSource>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="XmlDataSource1">
        <ItemTemplate>
            <h1><%# XPath("@name") %></h1>
            <ul>
                <asp:Repeater ID="Repeater2" runat="server" DataSource='<%#XPathSelect("./Hour")%>'>
                    <ItemTemplate>
                            <li><p><%# XPath("@begin") %></p></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>