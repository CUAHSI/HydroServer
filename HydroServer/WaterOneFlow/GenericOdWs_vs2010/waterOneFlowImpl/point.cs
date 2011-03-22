using System;
using System.Collections.Generic;
using System.Text;
using WaterOneFlow;

/*
 * Author:
 * Valentine June 2007
 * 
 * TODO add documentation
 * 
 * */
namespace WaterOneFlowImpl.geom
{
    public class point : basicGeometry
    {
        public static new String geomType = "POINT";
        public static new String geomFormat = "POINT(X Y)";
        /// <summary>
        /// X, Longitude, or Easting
        /// </summary>
        public Double X;
        /// <summary>
        /// Y, Latitude or Northing
        /// </summary>
        public Double Y;

       /// <summary>
       /// Latitude.
       /// returns Y (aka lat) to prevent logic  mistakes.
       /// </summary>
        public Double Lat
        {
            get { return Y; }

        }
        /// <summary>
        /// Longitude.
        /// Returns X (aka long) to prevent logic mistakes.
        /// </summary>
        public Double Lon
        {
            get { return X; }
        }

        public point(Double Xin, Double Yin)
        {

            X = Xin;
            Y = Yin;

        }
        // accept either a POINT(X Y) or a "X Y"
        public point(String ps)
        {

            if (ps.StartsWith(geomType, StringComparison.InvariantCultureIgnoreCase))
            {
                // remove point, and matching brackets
                ps = ps.Substring(geomType.Length);
                if (ps.StartsWith("("))
                {
                    ps = ps.Substring(1);
                }
                if (ps.EndsWith(")"))
                {
                    ps = ps.Remove(ps.Length - 1);
                }


            }
            ps = ps.Trim(); // trim leading and trailing spaces
            String[] coord = ps.Split(CoordSeparator.ToCharArray());
            if (coord.Length == 2)
            {
                X = Double.Parse(coord[0]);
                Y = Double.Parse(coord[1]);
            }
            else
            {
                throw new WaterOneFlowException("Could not create a point. Coordinates are separated by a space 'X Y'");
            }
        }

        public override String ToString()
        {

            return geomType+ "(" + X.ToString() + CoordSeparator + Y.ToString() + ")";

        }
    }
}
