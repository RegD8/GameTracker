<%--
 //* Author: Reg Desgroseilliers
 //* Student # 100160167
 //* Date Modified:  June 15th, 2016
 //* Version 1.2
 //* Description: This page will include a form that will allow a logged in user 
 //* to add games to the list.
 //*/  --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="SaveGame.aspx.cs" Inherits="GameTracker.Add_Game" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6 form-container">
                <h1>Game Details</h1>
                <h5>Please fill out all fields</h5>
            
            <div class="form-group">
                <label class="control-label" for="homeTeamName">Home Team Name:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="homeTeamName" placeholder="Home Team" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label" for="awayTeamName">Away Team Name:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="awayTeamName" placeholder="Away Team" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label" for="homeScore">Home Team Score:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="homeScore" placeholder="Home Team Score" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label" for="awayScore">Away Team Score:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="awayScore" placeholder="Away Team Score" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label" for="description">Game Description:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="description" placeholder="Enter Game Description" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                    <label class="control-label" for="gameDateTextBox">Game Date:</label>
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="gameDateTextBox" placeholder="Game Date Format: mm/dd/yyyy" required="true"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Invalid Date! Format: mm/dd/yyyy"
                        ControlToValidate="gameDateTextBox" MinimumValue="01/01/2000" MaximumValue="01/01/2999"
                        Type="Date" Display="Dynamic" BackColor="Red" ForeColor="White" Font-Size="Large"></asp:RangeValidator>
            </div>
            <div class="form-group">
                <label class="control-label" for="spectators">Spectators:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="spectators" placeholder="# of spectators" required="true"></asp:TextBox>
            </div>
            <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
            </div>


            </div>


        </div>
      </div>
    
</asp:Content>
