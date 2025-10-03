using Application.Common.Interfaces;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commons
{
    public class VirtualPathService : IVirtualPathService
    {
        private readonly VirtualPathSetting _virtualPathSetting;
        public VirtualPathService(VirtualPathSetting virtualPathSetting)
        {
            _virtualPathSetting = virtualPathSetting;
        }
        public string GetFesicalPath(string alias)
        {
           return _virtualPathSetting.VirtualPaths.FirstOrDefault(x => x.Alias == alias)?.RealPath ?? "";
        }
    }
}
