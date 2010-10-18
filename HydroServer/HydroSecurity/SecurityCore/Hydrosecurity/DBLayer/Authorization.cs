using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public class Authorization
    {
        /* Return back the TimeSeriesResourcesList object for which the ResourceConsumer is Authorized*/
        public TimeSeriesResourcesList AuthorizatizedTimeSeriesList(string siteCode, int resourceConsumerId , string accessType)
        {
            TimeSeriesResourcesList tr = new TimeSeriesResourcesList();
            List<Guid> entireResourceGuidList = new List<Guid>();
            List<Guid> authorizedResourceGuidList = new List<Guid>();
            List<Guid> finalAuthorizedGuid = new List<Guid>();
            Priviledge pv = new Priviledge();
            ResourcesList rs = new ResourcesList();
            PersonResouces pr = new PersonResouces();
            pv.Load(accessType);
            entireResourceGuidList =  rs.load(siteCode);
            authorizedResourceGuidList = pr.PersonAuthorized(resourceConsumerId,pv.priviledgeId);

            foreach (Guid g in entireResourceGuidList)
            {
                foreach (Guid d in authorizedResourceGuidList)
                {
                    if (g == d)
                    {
                        finalAuthorizedGuid.Add(g);
                    }
                }
            }

            tr = tr.AuthorizedTimeSeriesList(finalAuthorizedGuid);

            string test = "test";

            return tr;
        }
    }
}
