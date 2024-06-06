using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSSdkClient.Demo
{
    public class CustomSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("id", DefaultValue = "", IsRequired = true)]
        public string id
        {
            get => (string)this["id"];
            set => this["id"] = value;
        }

        [ConfigurationProperty("name", DefaultValue = "", IsRequired = true)]
        public string name
        {
            get => (string)this["name"];
            set => this["name"] = value;
        }
    }
}
