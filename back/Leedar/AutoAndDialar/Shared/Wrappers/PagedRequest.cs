using System.Collections.Generic;

namespace Shared.Wrappers
{
    public class PagedRequest<T>
    {
        public T Filters { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; } 

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public bool IsExport { get; set; } = false;
    }
    public class PagedRequest<T, S> : PagedRequest<T>
    {
        public Dictionary<string,string> Sortings { get; set; }
        //public Dictionary<S, byte?> Sortings { get; set; }
    }
}