#nullable disable
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModels
{
    public static class GlobalVar
    {
        public static string ApplicationName { get; set; } = "Remittance Solution";
        public static bool IsProcessing { get; set; } = false;
        public static int StartPage { get; set; } = 1;

        public static string UserId { get; set; } = string.Empty;
        public static string UserName { get; set;} = string.Empty;
        public static string Org { get; set; } = string.Empty;
        public static string OrgFullName { get;set; } = string.Empty;

        public static string DbConnection { get; set; }=string.Empty;
        public static string SecurityId { get; set;} = string.Empty;
        public static string SecurityValue { get; set; } = string.Empty;
        public static string TokenLive { get; set;}
        public static string RefreshTokenLive { get; set;}
    }
}
