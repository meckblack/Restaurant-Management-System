using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FMS_DbConnections.DAL
{
    public class MyDbInitializer : CreateDatabaseIfNotExists<FMS_DB>
    {
        protected override void Seed(FMS_DB context)
        {

        }
    }
}