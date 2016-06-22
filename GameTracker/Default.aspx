<%--
 //* Author: Reg Desgroseilliers
 //* Student # 100160167
 //* Date Modified:  June 15th, 2016
 //* Version 1.2
 //* Description: This is the main home page that will contain the game information for the selected week.
 //*
 //*/  --%>



<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GameTracker.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row weekly-tracker">
            <div class="col-md-2">
                <asp:Button Text="Last Week" ID="PreviousWeek" runat="server" OnClick="PreviousWeek_Click" />
            </div>

            <div class="col-md-8"><p>Week of: <%= dateRange %></p></div>
            <div class="col-md-2">
                <asp:Button Text="Next Week" ID="NextWeek" runat="server" OnClick="NextWeek_Click" />
            </div>
        </div>
        <div class="row">
            

         <% for (int i=0; i < gamesArray.Length; i++) { %> <!-- loop through the array -->
         <div class="col-sm-3 game-module-new">
             <div class="game-date"><%= gamesArray[i].gameDate.ToString() %></div><div class="spectators"><%= gamesArray[i].spectators %> Fans in attendence</div>
             <div class="team-names"><div class="home-team-name"> <%= gamesArray[i].homeTeamName %></div> <div class="away-team-name"><%= gamesArray[i].awayTeamName %> </div></div>
             <div class="scores-container"><div class="home-score"><%= gamesArray[i].homeScore %></div><div class="away-score"><%= gamesArray[i].awayScore %></div></div>
             <div class="description"><p><%= gamesArray[i].description %></p></div>
         </div>
          <% } %> <!--End the for loop -->

        </div>
    </div>
</asp:Content>
