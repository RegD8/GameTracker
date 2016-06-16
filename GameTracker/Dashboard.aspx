<%--
 //* Author: Reg Desgroseilliers
 //* Student # 100160167
 //* Date Modified:  June 8th, 2016
 //* Version 1.0
 //* Description: This page will contain user quick links to add games, edit profile and to view a list of all the games in the application.
 //*/  --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="GameTracker.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
        <h1>User Dashboard</h1>

            <div class="col-md-offset-3 col-md-2 dashboard-div">
                <a href="edituser.aspx"><i class="fa fa-pencil-square-o fa-lg"> </i> Edit Profile</a>
            </div>
            <div class="col-md-2 dashboard-div">
                <a href="SaveGame.aspx"><i class="fa fa-plus-square-o fa-lg"> Add Game</i></a>
            </div>
            <div class="col-md-2 dashboard-div">
                <a href="ViewGames.aspx"><i class="fa fa-eye fa-lg"> View Games</i></a>
            </div>

        </div>
    </div>
</asp:Content>
