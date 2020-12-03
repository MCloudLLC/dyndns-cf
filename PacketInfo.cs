using System;
using System.Collections.Generic;
using System.Text;

namespace MCloudDNSCF
{
    class PacketInfo
    {
        private string _record_type;
        private string _record_name;
        private string _record_content;
        private int _record_ttl;
        private bool _record_proxied;

        public string Type
        {
            get { return _record_type; }
            set { _record_type = value; }
        }
        public string Name
        {
            get { return _record_name; }
            set { _record_name = value; }
        }
        public string Content
        {
            get { return _record_content; }
            set { _record_content = value; }
        }
        public int TTL
        {
            get { return _record_ttl; }
            set { _record_ttl = value; }
        }
        public bool Proxied
        {
            get { return _record_proxied; }
            set { _record_proxied = value; }
        }
        public string SerializeData()
        {
            return "{" +
                "\"type\": \"" + _record_type + "\"," +
                "\"name\": \"" + _record_name + "\"," +
                "\"content\": \"" + _record_content + "\"," +
                "\"ttl\": " + _record_ttl + "," +
                "\"proxied\": " + _record_proxied.ToString().ToLower() +
                "}";
        }
    }
}
