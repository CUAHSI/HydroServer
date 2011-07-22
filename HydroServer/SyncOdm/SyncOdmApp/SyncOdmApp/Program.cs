using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization;


namespace SyncOdmApp
{
    class Program
    {

        public static string sqlazureConnectionString = Properties.Settings.Default.RemoteDatabaseConnectionString; //"Server=.\\sqlexpress;Database=LittleBear11Sync;Trusted_Connection=True";
        public static string sqllocalConnectionString = Properties.Settings.Default.LocalDatabaseConnectionString;// "Server=.\\sqlexpress;Database=LittleBear11;Trusted_Connection=True";
        public static readonly string scopeName =Properties.Settings.Default.scopeName;
        public static int transactionCount;

        public static uint BatchSize = 50000;
        public static uint MemorySize = 100000;

        static void Main(string[] args)
        {
            // Test if input arguments were supplied:
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter an argument.");
                System.Console.WriteLine("Usage: SyncTest.exe -setup");
                System.Console.WriteLine("       SyncTest.exe -sync");
            }
            else if (args[0] == "-setup")
                Setup();
            else if (args[0] == "-sync")
                Sync();

            Console.ReadLine();
        }

        public static void Setup()
        {
            try
            {

                SqlConnection sqlServerConn = new SqlConnection(sqllocalConnectionString);
                SqlConnection sqlAzureConn = new SqlConnection(sqlazureConnectionString);
                DbSyncScopeDescription myScope = new Microsoft.Synchronization.Data.DbSyncScopeDescription(scopeName);

                List<String> tableList = new List<String> {
                        "Sites", "SeriesCatalog", "Variables","DataValues","Units",
                        "CensorCodeCV", "DataTypeCV", "GeneralCategoryCV",
                        "ISOMetadata", "LabMethods","Methods","OffsetTypes"
, "Qualifiers","QualityControlLevels","SampleMediumCV","Samples"
,"SpeciationCV", "TopicCategoryCV","VerticalDatumCV"
, "SpatialReferences","ValueTypeCV","Sources","VariableNameCV",
"SampleTypeCV"
                    };
                foreach (var aTable in tableList)
                {
                    Microsoft.Synchronization.Data.DbSyncTableDescription aTableDescription = SqlSyncDescriptionBuilder.GetDescriptionForTable(aTable, sqlServerConn);
                    myScope.Tables.Add(aTableDescription);
                }
                //Microsoft.Synchronization.Data.DbSyncTableDescription Customer = SqlSyncDescriptionBuilder.GetDescriptionForTable("Customer", sqlServerConn);
                //Microsoft.Synchronization.Data.DbSyncTableDescription Product = SqlSyncDescriptionBuilder.GetDescriptionForTable("Product", sqlServerConn);

                //// Add the tables from above to the scope
                //myScope.Tables.Add(Customer);
                //myScope.Tables.Add(Product);

                // Setup SQL Server for sync
                SqlSyncScopeProvisioning sqlServerProv = new SqlSyncScopeProvisioning(sqlServerConn, myScope);
                if (!sqlServerProv.ScopeExists(scopeName))
                {
                    // Apply the scope provisioning.
                    Console.WriteLine("Provisioning SQL Server for sync " + DateTime.Now);
                    sqlServerProv.Apply();
                    Console.WriteLine("Done Provisioning SQL Server for sync " + DateTime.Now);
                }
                else
                    Console.WriteLine("SQL Server Database server already provisioned for sync " + DateTime.Now);

                // Setup SQL Azure for sync
                SqlSyncScopeProvisioning sqlAzureProv = new SqlSyncScopeProvisioning(sqlAzureConn, myScope);
                if (!sqlAzureProv.ScopeExists(scopeName))
                {
                    // Apply the scope provisioning.
                    Console.WriteLine("Provisioning Remote Sql for sync " + DateTime.Now);
                    sqlAzureProv.Apply();
                    Console.WriteLine("Done Provisioning Remote Sql for sync " + DateTime.Now);
                }
                else
                    Console.WriteLine("Remote Sql Database server already provisioned for sync " + DateTime.Now);

                sqlAzureConn.Close();
                sqlServerConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }

        public static void Sync()
        {
            try
            {

                SqlConnection sqlLocalConn = new SqlConnection(sqllocalConnectionString);
                SqlConnection sqlRemoteConn = new SqlConnection(sqlazureConnectionString);

                //Set memory allocation to the database providers
                SqlSyncProvider remoteProvider = new SqlSyncProvider(scopeName, sqlRemoteConn);
                SqlSyncProvider localProvider = new SqlSyncProvider(scopeName, sqlLocalConn);
                localProvider = new SqlSyncProvider(scopeName, sqlRemoteConn);
                remoteProvider = new SqlSyncProvider(scopeName, sqlLocalConn);
                remoteProvider.MemoryDataCacheSize = MemorySize;
                localProvider.MemoryDataCacheSize = MemorySize;

                //Set application transaction size on destination provider.
                remoteProvider.ApplicationTransactionSize = BatchSize;

                //Count transactions
                remoteProvider.ChangesApplied += new EventHandler<DbChangesAppliedEventArgs>(RemoteProvider_ChangesApplied);

                SyncOrchestrator orch = new SyncOrchestrator
                {
                    RemoteProvider = remoteProvider,
                    LocalProvider = localProvider,
                    Direction = SyncDirectionOrder.Download
                };
                Console.WriteLine("ScopeName={0} ", scopeName.ToUpper());
                Console.WriteLine("Starting Sync " + DateTime.Now);
                ShowStatistics(orch.Synchronize());

                sqlRemoteConn.Close();
                sqlLocalConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }

        public static void RemoteProvider_ChangesApplied(object sender, DbChangesAppliedEventArgs e)
        {
            transactionCount += 1;
            int totalBytes = transactionCount * Convert.ToInt32(BatchSize);
            Console.WriteLine("Changes Applied event fired: Transaction " + totalBytes + " bytes.");

        }

        public static void ShowStatistics(SyncOperationStatistics syncStats)
        {
            string message;

            message = "\tSync Start Time :" + syncStats.SyncStartTime.ToString();
            Console.WriteLine(message);
            message = "\tSync End Time   :" + syncStats.SyncEndTime.ToString();
            Console.WriteLine(message);
            message = "\tUpload Changes Applied :" + syncStats.UploadChangesApplied.ToString();
            Console.WriteLine(message);
            message = "\tUpload Changes Failed  :" + syncStats.UploadChangesFailed.ToString();
            Console.WriteLine(message);
            message = "\tUpload Changes Total   :" + syncStats.UploadChangesTotal.ToString();
            Console.WriteLine(message);
            message = "\tDownload Changes Applied :" + syncStats.DownloadChangesApplied.ToString();
            Console.WriteLine(message);
            message = "\tDownload Changes Failed  :" + syncStats.DownloadChangesFailed.ToString();
            Console.WriteLine(message);
            message = "\tDownload Changes Total   :" + syncStats.DownloadChangesTotal.ToString();
            Console.WriteLine(message);
        }

    }
}
