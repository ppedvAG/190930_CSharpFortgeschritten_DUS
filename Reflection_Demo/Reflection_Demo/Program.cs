using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Allgemeine Typeninformation auslesen
            // Reflection mit Integer
            //int zahl = 42;

            //Type integerType = zahl.GetType();

            //Console.WriteLine(integerType);
            //Console.WriteLine(integerType.IsClass);
            //Console.WriteLine(integerType.IsInterface); 
            #endregion

            #region Typeninformation von anonymen Objekten
            //object o1 = new { Vorname = "Tom", Nachname = "Ate" };

            //Type annoType = o1.GetType();

            //PropertyInfo[] info = annoType.GetProperties();
            //Console.WriteLine(info[0].Name);
            //Console.WriteLine(info[1].Name); 
            #endregion

            #region Instanzen zur Laufzeit erstellen
            //int zahl = 42;
            //Type intType = zahl.GetType();

            //// Neue Instanz:

            //object neuesDing = Activator.CreateInstance(intType); // Zur laufzeit ein neues Int erstellt

            //Console.WriteLine(neuesDing.GetType());
            //Console.WriteLine(neuesDing); 
            #endregion

            // DLL zur Laufzeit laden

            Assembly loaded = Assembly.LoadFrom("MeineDLL.dll");
            // Wenn man den Namespace + Namen der Klasse kennt
            Type rechnerTyp = loaded.GetType("MeineDLL.Taschenrechner");

            // Wenn man nichts kennt:
            // Type[] allTypes = loaded.GetTypes();
            object taschenrechnerInstanz = Activator.CreateInstance(rechnerTyp);
            // Problem: auf object die Methode .Add() und .Sub() ausführen geht nicht :/

            // Lösung 1) Interfaces
            // Lösung 2) Zur Laufzeit die Methodeninfos herausbekommen

            // "Suche eine Add-Methode mit (int,int) als Parameter
            MethodInfo addInfo = rechnerTyp.GetMethod("Add", new Type[] { typeof(int), typeof(int) });

            object result = addInfo.Invoke(taschenrechnerInstanz, new object[] { 2, 2 });
            Console.WriteLine(result);


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
