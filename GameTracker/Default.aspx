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
        <div class="row">
            <div class="col-md-12"><h1>Baseball Game Tracker
                 </h1><p><asp:Literal runat="server" id="todaysDate"></asp:Literal></p></div>
        </div>
        
        <div class="row weekly-tracker">
            <div class="col-md-2">
                <asp:Button Text="Last Week" ID="PreviousWeek" runat="server" OnClick="PreviousWeek_Click" />
            </div>

            <div class="col-md-8"></div>
            <div class="col-md-2">
                <asp:Button Text="Next Week" ID="NextWeek" runat="server" OnClick="NextWeek_Click" />
            </div>
        </div>

        
        <div class="row">
            <div class="col-md-3 game-module">
                <asp:GridView runat="server" ID="GamesGridView3" AutoGenerateColumns="false" OnRowCreated="GamesGridView_RowCreated" CssClass="table table-bordered table-striped special-table" ShowHeader="false">
                    <Columns>
                        <asp:BoundField ItemStyle-CssClass="date-cell" DataField="gameDate"  Visible="true" DataFormatString="{0:MMM dd, yyyy}" />
                    </Columns>      
                </asp:GridView>

                <asp:GridView runat="server" ID="GamesGridView" AutoGenerateColumns="false" OnRowCreated="GamesGridView_RowCreated" CssClass="table table-bordered table-striped special-table" ShowHeader="false">
                    <Columns>
                        <asp:BoundField ItemStyle-CssClass="hidden-cell" DataField="homeTeamName"  Visible="true"/>
                        <asp:BoundField DataField="awayTeamName" Visible="true" ShowHeader="false" />
                    </Columns>      
                </asp:GridView>

                <asp:GridView runat="server" ID="GamesGridView1"   AutoGenerateColumns="false" OnRowCreated="GamesGridView_RowCreated" CssClass="table table-bordered table-striped special-table" ShowHeader="false">
                    <Columns>
                    <asp:BoundField HeaderText="Final" DataField="homeScore" Visible="true" />

                    <asp:BoundField HeaderText="Final" DataField="awayScore" Visible="true" />
                    </Columns>
                </asp:GridView> 
                
                <asp:GridView runat="server" ID="GamesGridView2"  AutoGenerateColumns="false"  OnRowCreated="GamesGridView_RowCreated" CssClass="table special-table" ShowHeader="false">
                   <Columns>
                        <asp:BoundField DataField="description" HeaderText="Description" Visible="true" />
                      </Columns>
                </asp:GridView>

                <asp:GridView runat="server" ID="GamesGridView4"  AutoGenerateColumns="false"  OnRowCreated="GamesGridView_RowCreated" CssClass="table special-table">
                   <Columns>
                        <asp:BoundField DataField="spectators" HeaderText="# of Spectators" Visible="true" />
                      </Columns>
                </asp:GridView>

            </div>    
        </div>
    </div>
</asp:Content>
