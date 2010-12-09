using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
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

        public ResourceCatalog  GetByDate(DateTime startDate,DateTime endDate)
        {
            List<Guid> timeSeriesGuidList = new List<Guid>();
            List<Guid> documentGuidList = new List<Guid>();
            ResourceCatalog resCat = new ResourceCatalog();
            DataTable dt = new DataTable();
            DateTime nullDate= new DateTime();
            if (startDate == nullDate && endDate == nullDate)
            {

                dt = resCat.GetEntireByDate();
            }
            else
                if (endDate == nullDate)
                {

                    dt = resCat.GetByStartDate(startDate);
                }
                else
                    if (startDate == nullDate)
                    {
                        dt = resCat.GetByEndDate(endDate);
                    }
                    else
                        dt = resCat.GetBetweenDates(startDate, endDate);




            foreach (DataRow row in dt.Rows)
            {
                int resourceTypeId = Convert.ToInt16(row["resourcetype"].ToString());
                if (resourceTypeId == 1)
                {
                    Guid timeGuid = new Guid(row["resourceid"].ToString());
                    timeSeriesGuidList.Add(timeGuid);
                }
                else
                {
                    Guid docGuid = new Guid(row["resourceid"].ToString());
                    documentGuidList.Add(docGuid);
                }
            }

            foreach (Guid g in timeSeriesGuidList)
            {
                TimeSeriesResource tm = new TimeSeriesResource();
                tm = tm.GetTimeSeriesObject(g);
                resCat.timeSeriesCatalog.Add(tm);
            }

            foreach (Guid g in documentGuidList)
            {
                Document doc = new Document();
                doc = doc.GetDocumentById(g);
                resCat.documentCatalog.Add(doc);
            }


            return resCat;
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

        public ResourceTypeList GetResourceTypes()
        {
            ResourceTypeList resTypeList = new ResourceTypeList();
            resTypeList = resTypeList.GetResourceType();
            return resTypeList;
        }
    }
}
