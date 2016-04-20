using System;
using System.Threading;
using System.IO;

namespace Grunt
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Random random = new Random();
			Console.Clear();
			while (true) {
				string[] files = Directory.GetFiles("/etc/");
				foreach (string file in files)
				{
					int y = 0;
					
					string[] text = File.ReadAllLines(file);
					
					for (int line = 0; line < text.Length; line++)
					{
						Console.SetCursorPosition(0, y);
						Console.WriteLine(text[line]);
						Thread.Sleep(random.Next(8, 50));
						y++;
						if (y >= Console.BufferHeight-1) {
							y = 0;
							Console.Clear();
						}
					}
					Console.Clear();
				}
			}
		}
	}
}
