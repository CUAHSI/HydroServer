using System;
using System.Collections.Generic;
using System.Text;
using WaterOneFlowImpl.geom;
/*
 * 
 *  methods
 *   locationParam(inputParamString)
 *   locationParam(NetworkString,SiteCodeSting)
 *   locationParam(Lat,Long)  // geom by default
 *   locationParam(N,W,S,E)   // GEOM BOX
 *   locationParam(coords[]) // GEOM Polygon
 * 
 */
namespace WaterOneFlowImpl
{
    public class locationParam
    {
        private static String locationParamFormat = "Acceptable locationParam formats: \n Netowrk:siteCode \n GEOM:Point(X Y)\n GEOM:BOX(N W,S E) GEOM:POLYGON(X1 Y1,X2 Y2,X3 Y3,X1 Y1) \n";
        private static String networkSeparator = ":";
        private static String siteIDNetwork = "BYID"; // SITEID means code is a siteID
        private String networkField;
        private Boolean isGeometryField; // is this a location that is a geometry
        private Boolean isIdField = false;


        private String SiteCodeField;
        private basicGeometry GeometryField;
        private String location;

        /// <summary>
        /// Leading and trailing spaces are trimmed.
        /// </summary>
        public String Network
        {
            get
            {
                return networkField;
            }
            set
            {
                this.networkField = value.Trim();
            }
        }

        public Boolean IsId
        {
            get { return isIdField; }
            set { isIdField = value; }
        }

        /// <summary>
        /// Leading and trailing spaces are trimmed.
        /// </summary>
        public String SiteCode
        {
            get
            {
                return SiteCodeField;
            }
            set
            {

                this.SiteCodeField =
                    WaterOneFlow.Utilities.text.CodeFieldCheck.Encode(value);
            }
        }
        public Boolean isGeometry
        {
            get
            {
                return isGeometryField;
            }
            set
            {
                isGeometryField = value;
            }
        }
        public basicGeometry Geometry
        {
            get { return GeometryField; }
            set { GeometryField = value; }
        }

        public locationParam(String inputParam)
        {
            location = inputParam;
           
            String[] lp = new String[2];
            if (inputParam.Contains(networkSeparator))
            {
                int sepPosition = inputParam.IndexOf(networkSeparator);

                lp[0] = inputParam.Substring(0, sepPosition).Trim();
                lp[1] = inputParam.Substring(sepPosition + 1).Trim();
                Network = lp[0];
                SiteCode = lp[1].Trim();
                if (Network.Equals(siteIDNetwork, StringComparison.InvariantCultureIgnoreCase))
                {
                    IsId = true;
                    try
                    {
                        int.Parse(SiteCode);
                    }
                    catch (Exception e)
                    {
                        throw new WaterOneFlowException("SITEID must be an integer. '" + location + "'");
                    }
                }
                if (Network.Equals(basicGeometry.geomNetworkID))
                {
                    isGeometry = true;
                    if (lp[1].StartsWith(box.geomType, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Geometry = new box(lp[1]);
                    }
                    else if (lp[1].StartsWith(point.geomType, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Geometry = new point(lp[1]);
                    }
                    else
                    {
                        // unsupported geometry
                        throw new WaterOneFlowException("Unsupported Geometry :'" + SiteCode + "' " +
                                                        "Must be BOX or POINT");
                    }

                }
                else
                {
                    isGeometry = false;
                }
            }
        }

        public static string getSiteCode(string location)
        {
            if (location.Contains(networkSeparator))
            {
                int sepPosition = location.IndexOf(networkSeparator);
                return location.Substring(sepPosition + 1).Trim();
            }
            else
            {
                return null;
            }
        }

        /* public box getBox()
            
         {
         }

         public Double[] getBoxCoords()
         {
         }

         public point getPoint()
         {
         }

         public Double[] getPointCoords()
         {
         }
         */

        public override String ToString()
        {
            return location;
        }


    }
}
