using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MonitoringDeviceAdministrator
{
    class InfoContext: DbContext
    {
        public InfoContext()
            :base("DbConnection")
        { }

        public DbSet<Info> Infos { get; set; }
    }
}
