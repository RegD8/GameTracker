//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class baseballgametracker
    {
        public int gameID { get; set; }
        public string homeTeamName { get; set; }
        public string awayTeamName { get; set; }
        public Nullable<int> homeScore { get; set; }
        public Nullable<int> awayScore { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> gameDate { get; set; }
        public string spectators { get; set; }
    }
}