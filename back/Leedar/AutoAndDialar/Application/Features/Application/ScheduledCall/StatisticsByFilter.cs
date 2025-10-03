using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.ScheduledCall
{
    public class StatisticsByFilter
    {
        public List<StatisticsCustomList> AssignedToUser { get; set; }
        public List<StatisticsCustomList> SchadulaedToUser { get; set; }
        public List<StatisticsCustomList> SchadulaedToUserAtMonth { get; set; }
        public List<StatisticsCustomList> SchadulaedToUserAtDate { get; set; }
        public List<StatisticsCustomList> AssignedToTeam { get; set; }
        public List<StatisticsCustomList> SchadulaedToTeam { get; set; }
        public List<StatisticsCustomList> SchadulaedToTeamAtMonth { get; set; }
        public List<StatisticsCustomList> SchadulaedToTeamAtDate{ get; set; }
        public List<StatisticsCustomList> Campaign { get; set; }
        public List<StatisticsCustomList> Category { get; set; }
    }
    
    public class StatisticsCustomList
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
