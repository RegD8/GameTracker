<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test-Page.aspx.cs" Inherits="GameTracker.Test_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
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
