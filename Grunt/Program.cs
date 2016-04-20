using System;
using System.Threading;
using System.IO;

namespace Grunt
{
	class MainClass
	{
		public static readonly bool DISABLE_COMMENT_OUTPUT = true;
		
		public static void Main (string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Thread thread = new Thread(() => {
				Random random = new Random();
				Console.Clear();
				while (true) {
					string[] files = Directory.GetFiles("/etc/");
					foreach (string file in files)
					{
						int y = 0;
						
						string[] text = File.ReadAllLines(file);
						bool DO_SLEEP = true;
						for (int line = 0; line < text.Length; line++)
						{
							DO_SLEEP = true;
							
							Console.SetCursorPosition(0, y);
							
							int toPrintLength = line + 1;
							
							for (; toPrintLength < text.Length; toPrintLength++) {
								if (!text[toPrintLength].StartsWith("#")) break;
							}
							
							for (; line < toPrintLength; line++) {
								if ((text[line].StartsWith("#") && DISABLE_COMMENT_OUTPUT))
								{
									DO_SLEEP = false;
								}
								else {
									Console.WriteLine(text[line]);
									Console.SetCursorPosition(0, y);
									y++;
									if (y >= Console.BufferHeight-1) {
										y=0;
										Console.Clear();
									}
								}
							}
							if (DO_SLEEP)
								Thread.Sleep(random.Next(8, 50));
							if (y >= Console.BufferHeight-1) {
								y = 0;
								Console.Clear();
							}
						}
						Console.Clear();
					}
				}
			});
			thread.Start();
			
			Console.ReadKey();
			thread.Abort();
			Console.ResetColor();
		}
	}
}
