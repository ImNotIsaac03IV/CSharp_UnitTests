/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Railway
*--------------------------------------------------------------
*/
using System;
using System.IO;
namespace RailwayEngine
{
    using System.Globalization;

    public abstract class Locomotive
    {
        public double Col1 { set; get; }
        public double Col2 { set; get; }
        public int ID { set; get; }
        public int YearOfConstruction { set; get; }
        public double Gauge { set; get; }
        public string EngineNumber { set; get; }

        public static Locomotive CreateNew(string name)
        {
            if (name == "ElectricLocomotive")
            {
                return new ElectricLocomotive();
            }
            else if (name == "SteamEngine")
            {
                return new SteamEngine();
            }

            return null;
        }
        public abstract double CalculatePower();
        public abstract string GetTypeName();
        public virtual void FromCsv(string[] items)
        {
            ID = int.Parse(items[0]);
            YearOfConstruction = int.Parse(items[3]);
            Gauge = double.Parse(items[4], CultureInfo.InvariantCulture);
            EngineNumber = items[2];
            Col1 = double.Parse(items[5], CultureInfo.InvariantCulture);
            Col2 = double.Parse(items[6], CultureInfo.InvariantCulture);
        }
        public virtual string ToCsv()
        {
            return $"{ID};{GetTypeName()};{EngineNumber};{YearOfConstruction};{Gauge.ToString(CultureInfo.InvariantCulture)};{Col1};{Col2}";
        }
    }
}