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

    //TODO: implement class SteamEngine with Properties, overrides     
    public class SteamEngine : Locomotive
    {
        public double BoilerPressure { set; get; }
        public double Power { set; get; }
        public override string GetTypeName()
        {
            return $"SteamEngine";
        }
        public override double CalculatePower()
        {
            return Math.Round(Power * BoilerPressure);
        }
        public override void FromCsv(string[] items)
        {
            base.FromCsv(items);
            BoilerPressure = double.Parse(items[5], CultureInfo.InvariantCulture);
            Power = double.Parse(items[6], CultureInfo.InvariantCulture);
        }
    }
}