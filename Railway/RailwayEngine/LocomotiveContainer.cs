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
    using System.Collections.Generic;
    using System.IO;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    public class LocomotiveContainer
    {
        public static List<Locomotive> LoadFromCsv(string fileName)
        {
            List<Locomotive> locomotives = new List<Locomotive>();
            string[] lines = File.ReadAllLines(fileName);
            string[][] fileContents = new string[lines.Length - 1][];

            for (int i = 1; i < lines.Length; i++)
            {
                fileContents[i - 1] = lines[i].Split(';');
                Locomotive item = Locomotive.CreateNew(fileContents[i - 1][1]);
                item.FromCsv(fileContents[i - 1]);
                locomotives.Add(item);
            }

            return locomotives;
        }
        public static void StoreToCsv(string fileMoved, List<Locomotive> locomotives)
        {
            List<string> list = new List<string>
            {
                $"ID;TypeName;EngineNumber;YearOfConstruction;Gauge;Col1;Col2"
            };

            if (fileMoved != null && locomotives != null)
            {
                foreach (Locomotive locomotive in locomotives)
                {
                    list.Add(locomotive.ToCsv());
                }
            }
            string tempFile = Path.ChangeExtension(fileMoved, "$$$");

            File.WriteAllLines(tempFile, list);

            if (File.Exists(fileMoved))
            {
                File.Delete(fileMoved);
            }

            File.Move(tempFile, fileMoved);
        }
        public static List<Locomotive> SortByPower(List<Locomotive> locomotives)
        {
            List<Locomotive> copiedList = new List<Locomotive>(locomotives);

            foreach (Locomotive cl in copiedList)
            {
                cl.CalculatePower();
            }

            for (int i = 0; i < copiedList.Count; i++)
            {
                for (int j = i + 1; j < copiedList.Count; j++)
                {
                    if (copiedList[i].CalculatePower() > copiedList[j].CalculatePower())
                    {
                        Locomotive temp = copiedList[i];
                        copiedList[i] = copiedList[j];
                        copiedList[j] = temp;
                    }
                }
            }

            return copiedList;
        }
    }
}