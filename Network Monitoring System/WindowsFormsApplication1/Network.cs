using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface IObserver
    {
        void Update(Object ob);
    }
    public interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers(object ob);
    }
    public class Network : IObservable
    {
        public static List<Device> Devices;
        List<IObserver> Observers;
        public Network()
        {
            Devices = new List<Device>();
            Devices.Add(new LocalDevice("Компьютер","User1","192.168.0.25"));
            Devices.Add(new NetworkDevice("Компьютер", "Acer", "192.168.0.221"));
            Devices.Add(new NetworkDevice("Принтер", "HP-0959", "192.168.0.124"));
            Devices.Add(new NetworkDevice("Компьютер", "User2", "192.168.0.3"));
            Devices.Add(new NetworkDevice("Телефон", "Android", "192.168.0.86"));
            Observers = new List<IObserver>();
        }
        public void RegisterObserver(IObserver o)
        {
            Observers.Add(o);
        }
        public void RemoveObserver(IObserver o)
        {
            Observers.Remove(o);
        }
        public void NotifyObservers(object statisticparam)
        {
            foreach (IObserver o in Observers)
                o.Update(statisticparam);
        }
        public List<Device> GetAllDevice()
        {
            return Devices;
        }
        public List<NetworkDevice> GetNetworkDevice()
        {
            List<NetworkDevice> netdevices=new List<NetworkDevice>();
            foreach (var netdevice in Devices.Where(item => item.GetType() == typeof(NetworkDevice)))
                netdevices.Add((NetworkDevice)netdevice);
            return netdevices;
        }
        public LocalDevice GetLocalDevice()
        {
            return (LocalDevice)Devices.Find(item => item.GetType() == typeof(LocalDevice));
        } 
        public int SendPackage(Package package)
        {
            Random rnd = new Random();
            int time = rnd.Next(0,100);
            NotifyObservers(new Parametres(package.SourceAddress, package.DestAddress, time, package.ToString(),package.Message));
            return time;
        }
        public int ReceivePackage(Package package)
        {
            Random rnd = new Random();
            int time = rnd.Next(0, 100);
            NotifyObservers(new Parametres(package.DestAddress, package.SourceAddress, time, package.ToString(), package.Message));
            return time;
        } 
    }
}
