<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="DoctorPractice.Patients.Appointments" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Appointments.xml"/>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="XmlDataSource1" Width="233px">
        <ItemTemplate>
            Date:
            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
            <br />
            Doctor:
            <asp:Label ID="DoctorLabel" runat="server" Text='<%# Eval("Doctor") %>' />
            <br />
            Reason:
            <asp:Label ID="ReasonLabel" runat="server" Text='<%# Eval("Reason") %>' />
<br />
            <br />
        </ItemTemplate>
    </asp:DataList>
    </asp:Content>
