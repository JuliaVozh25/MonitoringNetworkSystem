using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DeviceRepository
    {
        List<Device> Devices;
        public DeviceRepository(List<Device> newdevice)
        {
            Devices = newdevice;
        }
        public List<Device> GetStructure(Query query)
        {
            List<Device> queryStruct = new List<Device>();
            foreach (Device device in Devices)
            {
                if (query.IsSatisfiedBy(device))
                    queryStruct.Add(device);
            }
            return queryStruct;
        }
    }
}
