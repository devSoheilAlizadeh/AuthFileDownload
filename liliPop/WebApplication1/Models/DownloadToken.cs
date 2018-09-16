using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class DownloadToken
    {
        public DownloadToken(Guid key , string token)
        {
            Key = key;
            Token = token;
        }
        
        public Guid Key { get; set; }

        public string Token { get; set; }    
    }


    public static class DownloadProvider
    {
        public static List<DownloadToken> Tokens { get; set; } = new List<DownloadToken>();
    }
}        