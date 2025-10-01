/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Railway
*--------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.IO;

using RailwayEngine;

Console.WriteLine("Railway");
Console.WriteLine("======");

const string fileName = "Locomotive.csv";
const string fileNameMoved = "LocomotiveSorted.csv";

//TODO Load and sort locomotives here
List<Locomotive> locomotives = new List<Locomotive>();
locomotives = LocomotiveContainer.LoadFromCsv(fileName);
locomotives = LocomotiveContainer.SortByPower(locomotives);
//TODO Print all locomotive
foreach (Locomotive l in locomotives)
{
    Console.WriteLine($"ID={l.ID}; Name={l.GetTypeName()}; EngineName={l.EngineNumber};{l.YearOfConstruction};{l.Gauge};Power={l.CalculatePower()}");
}

double power = 0;

foreach (Locomotive l in locomotives)
{
    power += l.CalculatePower();
}

Console.WriteLine($"Power: {power}");

LocomotiveContainer.StoreToCsv(fileNameMoved, locomotives);
//TODO Print total power off all locomotives