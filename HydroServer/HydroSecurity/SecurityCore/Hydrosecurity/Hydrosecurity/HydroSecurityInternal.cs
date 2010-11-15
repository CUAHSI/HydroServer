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

        public ResourcesList ResolveResources()
        {
            ResourcesList resList = new ResourcesList();
            return resList;

        }

        public bool SetAccess()
        {
            bool flag = false;
            return flag;
        }

        public bool ValidateCertificate()
        {
            bool flag = false;
            return flag;
        }
    }
}
