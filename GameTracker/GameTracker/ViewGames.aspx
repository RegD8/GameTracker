<%--
 //* Author: Reg Desgroseilliers
 //* Student # 100160167
 //* Date Modified:  June 24th, 2016
 //* Version 1.3
 //* Description: This page is the administrator view of all of the entered games. From here an admin will be able to select the 
    game he/she wishes to edit or delete.
 //*/  --%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewGames.aspx.cs" Inherits="GameTracker.View_Games" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-12"><h1>All Games</h1></div>
        </div>
        <div class="row">
            <div class="col-sm-12 all-games-module">
                
                <asp:GridView runat="server" ID="AllGamesGridView" AutoGenerateColumns="false" CssClass="table table-bordered table-striped"
                    OnRowDeleting="GamesGridView_RowDeleting" DataKeyNames="gameID" >
                    <Columns>
                        <asp:BoundField DataField="gameDate" Visible="true" HeaderText="Game Date" DataFormatString="{0:MMM dd, yyyy}"/>
                        <asp:BoundField DataField="homeTeamName"  Visible="true" HeaderText="Home Team"/>
                        <asp:BoundField DataField="awayTeamName" Visible="true" ShowHeader="false" HeaderText="Away Team" />
                        <asp:BoundField HeaderText="Home Team Score" DataField="homeScore" Visible="true" />
                        <asp:BoundField HeaderText="Away Team Score" DataField="awayScore" Visible="true" />
                        <asp:BoundField DataField="description" HeaderText="Description" Visible="true" />
                        <asp:BoundField DataField="spectators" HeaderText="Spectators" Visible="true" />
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="/GameTracker/SaveGame.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="gameID" DataNavigateUrlFormatString="/GameTracker/SaveGame.aspx?gameID={0}" />
                        <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                      </Columns>
                </asp:GridView>

            </div>    
        </div>
    </div>
</asp:Content>
