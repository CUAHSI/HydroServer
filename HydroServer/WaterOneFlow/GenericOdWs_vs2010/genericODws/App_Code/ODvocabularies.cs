using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WaterOneFlow.odm.v1_1;

using WaterOneFlow.odws.v1_1;
using adapters = WaterOneFlow.odm.v1_1.ControlledVocabularyDatasetTableAdapters;

/// <summary>
/// Summary description for ODvocabularies
/// </summary>
public class ODvocabularies
{
    public ODvocabularies()
    {
        //
        // TODO: Add constructor logic here
        //
 
    }      
    
        public static ControlledVocabularyDataset GetVocabularyDataset()
        {
           ControlledVocabularyDataset ds = new ControlledVocabularyDataset();

           adapters.QualityControlLevelsTableAdapter qcApapter = new adapters.QualityControlLevelsTableAdapter();

            qcApapter.Connection.ConnectionString = Config.ODDB();

            qcApapter.Fill(ds.QualityControlLevels);

            return ds;
        }
}
