using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBLayer;

namespace Hydrosecurity
{
    public class HydroSecurityInternal
    {
        public RequestManagementList GetPendingAuthorizationInfo(string siteCode)
        {
            ResourcesList rsList = new ResourcesList();
            List<Guid> rsGuids = new List<Guid>();
            rsGuids = rsList.load(siteCode);
            RequestManagementList rmList = new RequestManagementList();
            rmList.Load(rsGuids);
            return rmList;
        }

        public AuthorizationList GetApprovedAuthorizationInfo(string siteCode)
        {
            ResourcesList rsList = new ResourcesList();
            List<Guid> rsGuids = new List<Guid>();
            rsGuids = rsList.load(siteCode);
            AuthorizationList authList = new AuthorizationList();
            authList.Load(rsGuids);
            return authList;
        }

        public void QueueAuthorizationRequest(string operationType, int userId,List<Guid> resourcesGuids)
        {
            RequestManagement rm = new RequestManagement();
            Priviledge pr = new Priviledge();
            pr.Load(operationType);
            rm.AddRequest(pr.priviledgeId, 2, resourcesGuids);
        }

        public bool RegisterUser()
        {
            bool flag = false;
            return flag;
        }

        public TimeSeriesResourcesList ResolveResources(TimeSeriesResource tmObj)
        {
            TimeSeriesResourcesList tmList = new TimeSeriesResourcesList();
            tmList.Load(tmObj);
            return tmList;

        }
        public TimeSeriesResourcesList GetResourceByGuid(Guid guid)
        {
            TimeSeriesResourcesList tmList = new TimeSeriesResourcesList();
            tmList.Load(guid);
            return tmList;
        }

        public TimeSeriesResourcesList GetByDate(DateTime startDateTime, DateTime endDateTime)
        {
            DateTime nullDateTime = new DateTime();
            TimeSeriesResourcesList tmList = new TimeSeriesResourcesList();
            if (startDateTime == nullDateTime && endDateTime == nullDateTime)
            {
                tmList.GetEntireByDate();
            }
            else
                if (endDateTime == nullDateTime)
                {
                    tmList.GetByStartDate(startDateTime);
                }
                else
                    if (startDateTime == nullDateTime)
                    {
                        tmList.GetByEndDate(endDateTime);
                    }
                    else
                        tmList.GetBetweenDates(startDateTime,endDateTime);
            return tmList;
        }
        
        public void SetAccess(int userId, Guid resourceGuid, string privilege)
        {
            Authorization auth = new Authorization();
            Priviledge priv = new Priviledge();
            priv.Load(privilege);
            auth.SetAccess(userId, resourceGuid, priv.priviledgeId);

        }

        public bool ValidateCertificate()
        {
            bool flag = false;
            return flag;
        }

        public bool IsAuthorized(string operationType, string resourceType, string resourceGuid, int userId)
        {
            bool flag = false;
            Guid g = new Guid(resourceGuid);
            PersonResouces prRes = new PersonResouces();
            Priviledge priv = new Priviledge();
            priv.Load(operationType);
            List<Guid> authorizedGuids = new List<Guid>();
            authorizedGuids = prRes.PersonAuthorized(userId, priv.priviledgeId);
            if(authorizedGuids.Contains(g))
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public ResourceConsumerList ResolveUserInfo(List<string> userEmailAddList)
        {
            ResourceConsumerList resConList = new ResourceConsumerList();
            resConList.Load(userEmailAddList);

            return resConList;
        }
    }
}
