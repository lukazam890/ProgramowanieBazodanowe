using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.ServiceInterfaces.IProducts;

namespace BLL.DTOModels
{
    public enum SortBy
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc,
        GroupNameAsc,
        GroupNameDesc,
    };
    public class GetProductsDTO
    {
        public SortBy Sort { get; set; } = SortBy.NameAsc;
        public string? nameFilter { get; set; } = null;
        public string? groupNameFilter { get; set; } = null;
        public int? idGroupFilter { get; set; } = null;
        public bool onlyActive { get; set; } = false;
    }
}
