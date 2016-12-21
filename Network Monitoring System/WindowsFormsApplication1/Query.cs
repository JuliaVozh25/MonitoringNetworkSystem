using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class Query
    {
        public abstract bool IsSatisfiedBy(object candidate);
        public Query And(Query newquery)
        {
            return new AndQuery(this, newquery);
        }
        public Query Or(Query newquery)
        {
            return new OrQuery(this, newquery);
        }
    }
    public class AndQuery : Query
    {
        private Query firstquery;
        private Query newquery;
        public AndQuery(Query a, Query b)
        {
            firstquery = a;
            newquery = b;
        }
        public override bool IsSatisfiedBy(object candidate)
        {
            return firstquery.IsSatisfiedBy(candidate) && newquery.IsSatisfiedBy(candidate);
        }
    }
    public class OrQuery : Query
    {
        private Query firstquery;
        private Query newquery;
        public OrQuery(Query a, Query b)
        {
            firstquery = a;
            newquery = b;
        }
        public override bool IsSatisfiedBy(object candidate)
        {
            return firstquery.IsSatisfiedBy(candidate) || newquery.IsSatisfiedBy(candidate);
        }
    }
    public class IPQuery : Query
    {
        string sample;
        public IPQuery(string sample)
        {
            this.sample = sample;
        }
        public override bool IsSatisfiedBy(object candidate)
        {
            return candidate is Device && (sample.Equals("") || ((Device)candidate).IP.Equals(sample));
        }
    }
    public class TypeQuery : Query
    {
        string sample;
        public TypeQuery(string sample)
        {
            this.sample = sample;
        }
        public override bool IsSatisfiedBy(object candidate)
        {
            return candidate is Device && (sample.Equals("") || ((Device)candidate).Type.Equals(sample));
        }
    }
    public class SourceQuery : Query
    {
        string sample;
        public SourceQuery(string sample)
        {
            this.sample = sample;
        }
        public override bool IsSatisfiedBy(object candidate)
        {
            return candidate is Parametres && (sample.Equals("") || ((Parametres)candidate).SourceAddress.Equals(sample));
        }
    }
    public class DestQuery : Query
    {
        string sample;
        public DestQuery(string sample)
        {
            this.sample = sample;
        }
        public override bool IsSatisfiedBy(object candidate)
        {
            return candidate is Parametres && (sample.Equals("") || ((Parametres)candidate).DestAddress.Equals(sample));
        }
    }
    public class ProtocolQuery : Query
    {
        string sample;
        public ProtocolQuery(string sample)
        {
            this.sample = sample;
        }
        public override bool IsSatisfiedBy(object candidate)
        {
            return candidate is Parametres && (sample.Equals("") || ((Parametres)candidate).Protocol.Equals(sample));
        }
    }
}
