using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace WaterOneFlowImpl
{
    public class StandardServices
    {
        public StandardServices()
        { }

        public Networks GetNetworks()
        {
            string mainSQL = @"SELECT NetworkID, Organization, NetworkName, LongNetworkName, URL, StationNumber, ObsStartDate, ObsEndDate, LastUpdate, Contact FROM t_Network";
            SqlCommand aCommand;
            SqlDataReader aReader;
            Networks aNetworkSet = new Networks();
            List<NetworksNetwork> aNetworkList = new List<NetworksNetwork>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.enterpriseOD))
            {
                aCommand = new SqlCommand();
                aCommand.Connection = conn;
                aCommand.CommandType = System.Data.CommandType.Text;
                aCommand.CommandText = mainSQL;
                conn.Open();
                aReader = aCommand.ExecuteReader();
                while (aReader.Read())
                {
                    NetworksNetwork aNetwork = new NetworksNetwork();
                    aNetwork.NetworkID = aReader.GetInt32(aReader.GetOrdinal("NetworkID"));
                    aNetwork.Organization = aReader["Organization"].ToString();
                    aNetwork.NetworkName = aReader["NetworkName"].ToString();
                    aNetwork.LongNetworkName = aReader["LongNetworkName"].ToString();
                    aNetwork.URL = aReader["URL"].ToString();
                    aNetwork.StationNumber = aReader.GetInt32(aReader.GetOrdinal("StationNumber"));
                    if (aReader["ObsStartDate"] is DBNull)
                        aNetwork.ObsStartDateSpecified = false;
                    else
                    {
                        aNetwork.ObsStartDate = aReader.GetDateTime(aReader.GetOrdinal("ObsStartDate"));
                        aNetwork.ObsStartDateSpecified = true;
                    }

                    if (aReader["ObsEndDate"] is DBNull)
                        aNetwork.ObsEndDateSpecified = false;
                    else
                    {
                        aNetwork.ObsEndDate = aReader.GetDateTime(aReader.GetOrdinal("ObsEndDate"));
                        aNetwork.ObsEndDateSpecified = true;
                    }

                    if (aReader["LastUpdate"] is DBNull)
                        aNetwork.LastUpdateSpecified = false;
                    else
                    {
                        aNetwork.LastUpdate = aReader.GetDateTime(aReader.GetOrdinal("LastUpdate"));
                        aNetwork.LastUpdateSpecified = true;
                    }
                    aNetwork.Contact = aReader["Contact"].ToString();

                    aNetworkList.Add(aNetwork);
                }
                aReader.Close();
            }
            aCommand.Dispose();
            aNetworkSet.Network = aNetworkList.ToArray();
            return aNetworkSet;
        }

        public int? RegisterNetwork(string organizationName, string networkName, string longNetworkName, string contactUrl, long numberOfMonitoredStations, DateTime? startDateForObservations, DateTime? endDateForObservations, DateTime? lastUpdate, string contactInfo)
        {
            int? pk= null;
            string mainSQL = @"INSERT INTO t_Network (Organization, NetworkName, LongNetworkName, URL, StationNumber, ObsStartDate, ObsEndDate, LastUpdate, Contact)
VALUES (@Org, @NetworkName,@LongName,@URL,@StationNumber,@StartDate,@EndDate,@LastUpdate,@Contact)";

            string getPk = @"SELECT NetworkID FROM t_Networks WHERE Organization = @Org AND NetworkName = @NetworkName";
            SqlCommand aCommand;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.enterpriseOD))
            {
                conn.Open();
                aCommand = new SqlCommand();
                aCommand.Connection = conn;
                aCommand.CommandType = System.Data.CommandType.Text;
                aCommand.CommandText = mainSQL;
                aCommand.Parameters.Add(new SqlParameter("@Org", organizationName));
                aCommand.Parameters.Add(new SqlParameter("@NetworkName", networkName));
                aCommand.Parameters.Add(new SqlParameter("@LongName", longNetworkName));
                aCommand.Parameters.Add(new SqlParameter("@URl", contactUrl));
                aCommand.Parameters.Add(new SqlParameter("@StationNumber",numberOfMonitoredStations));
                if(startDateForObservations.HasValue)
                    aCommand.Parameters.Add(new SqlParameter("@StartDate", startDateForObservations));
                else
                    aCommand.Parameters.Add(new SqlParameter("@StartDate", DBNull.Value));
                if (endDateForObservations.HasValue)
                    aCommand.Parameters.Add(new SqlParameter("@EndDate", endDateForObservations));
                else
                    aCommand.Parameters.Add(new SqlParameter("@EndDate", DBNull.Value));
                if (lastUpdate.HasValue)
                    aCommand.Parameters.Add(new SqlParameter("@LastUpdate", lastUpdate));
                else
                    aCommand.Parameters.Add(new SqlParameter("@LastUpdate", DBNull.Value));
                aCommand.Parameters.Add(new SqlParameter("@Contact", contactInfo));
                aCommand.ExecuteNonQuery();
                aCommand.CommandText = getPk;
                pk = (int?)aCommand.ExecuteScalar();
            }
            return pk;
        }
    }
}
