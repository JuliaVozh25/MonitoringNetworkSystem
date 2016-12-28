using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class Device
    {
        public string Type;
        public string Name;
        public string IP;
        public enum DeviceType
        {
            LocalDevice,
            NetworkDevice
        };
        public virtual DeviceType deviceType { get; set; }
        public Device(string type, string name, string ip)
        {
            this.Type = type;
            this.Name = name;
            this.IP = ip;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class LocalDevice : Device
    {
        public LocalDevice(string type, string name, string ip) : base(type, name, ip) { }
        public override DeviceType deviceType
        {
            get
            {
                return DeviceType.LocalDevice;
            }
        }

    }
    public class NetworkDevice : Device
    {
        public NetworkDevice(string type, string name, string ip) : base(type, name, ip) { }
        public override DeviceType deviceType
        {
            get
            {
                return DeviceType.NetworkDevice;
            }
        }
    }
}
