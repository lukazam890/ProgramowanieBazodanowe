using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.ServiceInterfaces.Products;

namespace BLL.DTOModels
{
    enum SortBy
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
        SortBy Sort { get; set; } = SortBy.NameAsc;
        string? nameFilter { get; set; } = null;
        string? groupNameFilter { get; set; } = null;
        int? idGroupFilter { get; set; } = null;
        bool onlyActive { get; set; } = true;
    }
}
