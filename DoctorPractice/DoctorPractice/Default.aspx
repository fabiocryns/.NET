<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DoctorPractice.Default" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            Welcome to our doctor&#39;s office website. You can <a href="Login.aspx">log in</a> to view your appointments or create a new appointment.
        </AnonymousTemplate>
    <LoggedInTemplate> 
        Welcom back, <asp:LoginName ID="LoginName1" runat="server" />
        ! You can <a href="Patients/Appointments.aspx">view your appointments</a> or <a href="Patients/CreateAppointment.aspx">create a new one</a>.
    </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
