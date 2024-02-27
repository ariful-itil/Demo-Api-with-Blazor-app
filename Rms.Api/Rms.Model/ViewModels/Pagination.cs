using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class Pagination
    {
        public int page_no { get; set; } = 1;
        public byte row_per_page { get; set; } = 20;
    }
    public static class Paging
    {
        public static int pages { get; set; } = 1;
        public static int rows { get; set; } = 20;
    }
    public class Pages
    {
        public int PageNo { get; set; }    
        public  int TotalPages { get; set;}
    }
 
}
