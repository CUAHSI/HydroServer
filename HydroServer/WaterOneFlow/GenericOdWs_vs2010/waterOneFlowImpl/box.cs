using System;
using System.Collections.Generic;
using System.Text;
/*
 * Author
 * Valentine June 2007
 * 
 * TODO add documentation
 * 
 * */
namespace WaterOneFlowImpl.geom
{
    public class box : basicGeometry
    {
        public static new String geomType = "BOX";
        public static new String geomFormat = "BOX((W S, E N))";
        private Double N;
        private Double S;
        private Double E;
        private Double W;

        public Double North
        {
            get
            {
                return N;
            }
            set
            {
                N = value;
            }
        }
        public Double South
        {
            get
            {
                return S;
            }
            set
            {
                S = value;
            }
        }
        public Double East
        {
            get
            {
                return E;
            }
            set
            {
                E = value;
            }
        }
        public Double West
        {
            get
            {
                return W;
            }
            set
            {
                W = value;
            }
        }

        public box(Double West, Double South, Double East, Double North)
        {
            
            this.West = West;
            this.South = South;
            this.East = East;
            this.North = North;
            
        }

        public box(String geom)
        {
            if (geom == null)
            {
                throw new WaterOneFlowException("Invalid Parameter to create a geometry. Null Parameter passed");
            }
            if (geom.StartsWith(geomNetworkID, StringComparison.InvariantCultureIgnoreCase)) 
        {
            geom = geom.Substring(geomNetworkID.Length + 1);

        }
        if (geom.StartsWith(geomType, StringComparison.InvariantCultureIgnoreCase))
        {
                parseBox(geom);
            } else {
            throw new WaterOneFlowException("Unable to create geometry for box from string. String does not include string '"+geomType +"'");

            }
        }

        private void parseBox (String bs) {
            bs = bs.Trim();
            if (bs.StartsWith(geomType,StringComparison.InvariantCultureIgnoreCase))
            {
               
                // remove point, and matching brackets
                bs = bs.Substring(geomType.Length);
                if (bs.StartsWith("(("))
                {
                    bs = bs.Substring(2);
                }
                
                if (bs.EndsWith("))"))
                {
                    bs = bs.Remove(bs.Length - 2);
                }
            if (bs.StartsWith("("))
                {
                    bs = bs.Substring(1);
                }
            }
            if (bs.EndsWith(")"))
            {
                bs = bs.Remove(bs.Length - 1);
            }

            bs = bs.Trim();
            String[] xy = bs.Split(XYPairSeparator.ToCharArray());
            if (xy.Length == 2)
            {
                point ws = new point(xy[0]);
                this.West = ws.X;
                this.South = ws.Y;

                point en = new point(xy[1]);
                this.North = en.Y;
                this.East = en.X;


            }
            else if (xy.Length == 4)
            { // not completeltly correct, but why not make four coordinates work
                this.North = Double.Parse(xy[0]);
                this.East = Double.Parse(xy[1]);
                this.West = Double.Parse(xy[2]);
                this.South = Double.Parse(xy[3]);

            }
        }

        public override String  ToString() {
            
                StringBuilder sb = new StringBuilder();
                sb.Append(geomType);
                sb.Append("((");
                sb.Append(West.ToString() + " " + South.ToString());
                sb.Append(XYPairSeparator);
                sb.Append(East.ToString() + " " + North.ToString());
                sb.Append("))");
                return sb.ToString();
            
        }
    }
}
