using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Web.Blazor.Models
{
    public class ItemDetailsModel<TItem>
    {
        public string ItemName { get; set; }
        public TItem Item { get; set; }

    }
}
