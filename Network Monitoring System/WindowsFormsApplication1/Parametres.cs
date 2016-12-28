using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Parametres
    {
        public string SourceAddress;
        public string DestAddress;
        public int Time;
        public string Protocol;
        public string Message;
        public Parametres(string sourceAddress, string destAddress, int time, string protocol, string message)
        {
            this.SourceAddress = sourceAddress;
            this.DestAddress = destAddress;
            this.Time = time;
            this.Protocol = protocol;
            this.Message = message;
        }
    }                                                          
    public class StatisticList : IObserver
    {
        public List<Parametres> Statistic;
        public IObservable ObserverbleNetwork;
        public StatisticList(IObservable obs)
        {
            this.Statistic = new List<Parametres>();
            ObserverbleNetwork = obs;
            ObserverbleNetwork.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            Parametres netstatistic = (Parametres)ob;
            Statistic.Add(netstatistic);
        }
        public void StopTrade()
        {
            ObserverbleNetwork.RemoveObserver(this);
            ObserverbleNetwork = null;
        }
        public List<Parametres> GetStatistic(Query query)
        {
            List<Parametres> queryStatistic = new List<Parametres>();
            foreach (Parametres param in Statistic)
            {
                if (query.IsSatisfiedBy(param))
                    queryStatistic.Add(param);
            }
            return queryStatistic;
        }
    }
}
