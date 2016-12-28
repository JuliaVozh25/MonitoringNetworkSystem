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
        public List<Device> Devices;
        public List<IObserver> Observers;
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
        public List<Device> GetNetworkDevice()
        {
            List<Device> netdevices=new List<Device>();
            Device.DeviceType type = Device.DeviceType.NetworkDevice;
            foreach (var netdevice in Devices.Where(item => item.deviceType == type))
                netdevices.Add(netdevice);
            return netdevices;
        }
        public Device GetLocalDevice()
        {
            Device.DeviceType type = Device.DeviceType.LocalDevice;
            return Devices.Find(item => item.deviceType == type);
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
