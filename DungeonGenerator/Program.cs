/*
 * Automata procedual dungeon generation proof-of-concept
 *
 *
 * Developed by Adam Rakaska 
 *  http://www.csharpprogramming.tips
 *    http://www.adam-rakaska.codes
 * 
 * 
 */
using System;
using System.Collections.Generic;
using Microsoft.Win32;

using AutomataMapGenerator;

namespace DungeonGenerator
{
	class Program
	{
		public static void Main(string[] args)
		{
			char key		= new Char();
			MapHandler Map = new MapHandler();
			
			string instructions =
				"[Q]uit [N]ew [+][-]Percent walls [R]andom [B]lank" + Environment.NewLine +
				"Press any other key to smooth/step";

			Map.MakeCaverns();
			Map.PrintMap();
			Console.WriteLine(instructions);
			
			key = Char.ToUpper(Console.ReadKey(true).KeyChar);
			while(!key.Equals('Q'))
			{
				if(key.Equals('+')) {
					Map.PercentAreWalls+=1;
					Map.RandomFillMap();
					Map.MakeCaverns();
					Map.PrintMap();
				} else if(key.Equals('-')) {
					Map.PercentAreWalls-=1;
					Map.RandomFillMap();
					Map.MakeCaverns();
					Map.PrintMap();
				} else if(key.Equals('R')) {
					Map.RandomFillMap();
					Map.PrintMap();
				} else if(key.Equals('N')) {
					Map.RandomFillMap();
					Map.MakeCaverns();
					Map.PrintMap();
				} else if(key.Equals('B')) {
					Map.BlankMap();
					Map.PrintMap();
				} else if(key.Equals('D')) {
					// I set a breakpoint here...
				} else {
					Map.MakeCaverns();
					Map.PrintMap();
				}
				Console.WriteLine(instructions);
				key = Char.ToUpper(Console.ReadKey(true).KeyChar);
			}
			Console.Clear();
			Console.Write(" Thank you for playing!");
			Console.ReadKey(true);
		}
	}
}