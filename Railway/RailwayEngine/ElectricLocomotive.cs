/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Shapes
*--------------------------------------------------------------
*/
using System;
using System.IO;
namespace RailwayEngine
{
    using System.Globalization;

    //TODO: implement class ElectricLocomotive with Properties, overrides
    public class ElectricLocomotive : Locomotive
    {
        public double Voltage { set; get; }
        public double Current { set; get; }
        public override string GetTypeName()
        {
            return "ElectricLocomotive";
        }
        public override double CalculatePower()
        {
            return Math.Round(Voltage * Current);
        }
        public override void FromCsv(string[] items)
        {
            base.FromCsv(items);
            Voltage = double.Parse(items[5], CultureInfo.InvariantCulture);
            Current = double.Parse(items[6], CultureInfo.InvariantCulture);
        }
    }
}