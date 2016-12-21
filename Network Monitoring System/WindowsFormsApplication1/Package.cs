using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    abstract class AbstractFactory
    {
        public abstract Package CreatePackage(string sourceaddr, string destaddr, string message);
    }
    class PingFactory : AbstractFactory
    {
        public override Package CreatePackage(string sourceaddr, string destaddr, string message)
        {
            return new PingPackage(sourceaddr, destaddr, message);
        }
    }
    class MessageFactory : AbstractFactory
    {
        public override Package CreatePackage(string sourceaddr, string destaddr, string message)
        {
            return new MessagePackage(sourceaddr, destaddr, message);
        }
    }
    public abstract class Package
    {
        public string SourceAddress;
        public string DestAddress;
        public string Message;
        public Package(string sourceaddr, string destaddr, string message)
        {
            this.SourceAddress = sourceaddr;
            this.DestAddress = destaddr;
            this.Message = message;
        }
    }
    class PingPackage : Package
    {
        public PingPackage(string sourceaddr, string destaddr, string message) : base(sourceaddr, destaddr, message) { }
        public override string ToString()
        {
            return "ICMP";
        }
    }
    class MessagePackage : Package
    {
        public MessagePackage(string sourceaddr, string destaddr, string message) : base(sourceaddr, destaddr, message) { }
        public override string ToString()
        {
            return "TCP";
        }
    } 
}
