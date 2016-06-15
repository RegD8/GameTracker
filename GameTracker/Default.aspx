<%--
 //* Author: Reg Desgroseilliers
 //* Student # 100160167
 //* Date Modified:  June 8th, 2016
 //* Version 1.0
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
            <div class="col-md-12"><h1>Baseball Game Tracker</h1></div>
        </div>
        <div class="row">
            <div class="col-md-6 game-module">
                

                <asp:GridView runat="server" ID="GamesGridView" AutoGenerateColumns="false" OnRowCreated="GamesGridView_RowCreated" CssClass="table table-bordered table-striped special-table">
                    <Columns>
                        <asp:BoundField ItemStyle-CssClass="hidden-cell" DataField="homeTeamName"  Visible="true" ShowHeader="false"/>
                        <asp:BoundField DataField="awayTeamName" Visible="true" ShowHeader="false" />
                    </Columns>      
                </asp:GridView>

                <asp:GridView runat="server" ID="GamesGridView1"   AutoGenerateColumns="false" CssClass="table table-bordered table-striped special-table">
                    <Columns>
                    <asp:BoundField HeaderText="Final" DataField="homeScore" Visible="true" />

                    <asp:BoundField HeaderText="Final" DataField="awayScore" Visible="true" />
                    </Columns>
                </asp:GridView> 
                
                <asp:GridView runat="server" ID="GamesGridView2"  AutoGenerateColumns="false" CssClass="table table-bordered table-striped special-table">
                   <Columns>
                        <asp:BoundField DataField="description" HeaderText="Description" Visible="true" />
                      </Columns>
                </asp:GridView>

            </div>    
        </div>
    </div>
</asp:Content>
