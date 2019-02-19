using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace benchmark {
    public static class Program {

        private static int[][] init (int width, int height) {
            int[][] fase = new int[height][];
            for (int i = 0; i < fase.Length; i++)
                fase[i] = new int[width];

            for (int i = 0; i < fase.Length; i++) {
                for (int j = 0; j < fase[i].Length; j++) {
                    if (j % fase[i].Length == 0 || j % fase[i].Length == fase[i].Length - 1 || i == 0 || i == fase.Length - 1)
                        fase[i][j] = 0;
                    else
                        fase[i][j] = -1;
                }
            }
            return fase;
        }

        private static double printConsole (int width, int height) {
            Stopwatch sw = new Stopwatch ();

            int[][] fase = init (width, height);

            sw.Start ();

            // low efficiency
            Console.Clear ();
            for (int i = 0; i < fase.Length; i++) {
                for (int j = 0; j < fase[i].Length; j++) {
                    if (j % fase[i].Length == 0 || j % fase[i].Length == fase[i].Length - 1 || i == 0 || i == fase.Length - 1)
                        Console.Write ("0");
                    else
                        Console.Write (" ");
                }
                Console.WriteLine ();
            }

            sw.Stop ();
            Console.WriteLine ("printed in " + sw.Elapsed.TotalMilliseconds + " miliseconds");
            Console.ReadKey (true);
            return sw.Elapsed.TotalMilliseconds;
        }

        private static double printConsoleBetter (int width, int height) {
            Stopwatch sw = new Stopwatch ();

            int[][] fase = init (width, height);

            sw.Start ();

            // better efficiency
            Console.Clear ();
            for (int i = 0; i < fase.Length; i++) {
                for (int j = 0; j < fase[i].Length; j++) {
                    if (fase[i][j] == 0) {
                        Console.SetCursorPosition (j, i);
                        Console.Write ("0");
                    }
                }
                Console.WriteLine ();
            }

            sw.Stop ();
            Console.WriteLine ("printed in " + sw.Elapsed.TotalMilliseconds + " miliseconds");
            Console.ReadKey (true);
            return sw.Elapsed.TotalMilliseconds;
        }

        private static double printConsoleWayBetter (int width, int height) {
            Stopwatch sw = new Stopwatch ();

            int[][] fase = init (width, height);
            StringBuilder sb = new StringBuilder ();

            sw.Start ();

            for (int i = 0; i < fase.Length; i++) {
                for (int j = 0; j < fase[i].Length; j++) {
                    if (fase[i][j] == 0)
                        sb.Append ("0");
                    else
                        sb.Append (" ");
                }
                sb.Append ("\n");
            }

            // better efficiency
            Console.Clear ();
            Console.Write (sb);

            sw.Stop ();
            Console.WriteLine ("printed in " + sw.Elapsed.TotalMilliseconds + " miliseconds");
            Console.ReadKey (true);
            return sw.Elapsed.TotalMilliseconds;
        }

        public static void Main (String[] args) {
            const int altura_fase = 20;
            const int largura_fase = 80;

            double printTime1 = printConsole (largura_fase, altura_fase);
            double printTime2 = printConsoleBetter (largura_fase, altura_fase);
            double printTime3 = printConsoleWayBetter (largura_fase, altura_fase);

            Console.Clear ();
            Console.WriteLine ("Elapsed = {0}", printTime1);
            Console.WriteLine ("Elapsed = {0}", printTime2);
            Console.WriteLine ("Elapsed = {0}", printTime3);
            Console.WriteLine ("Second method is {0:N2}x faster than the First", printTime1 / printTime2);
            Console.WriteLine ("Third method is {0:N2}x faster than the Second", printTime2 / printTime3);
            Console.WriteLine ("Third method is {0:N2}x faster than the First", printTime1 / printTime3);
            Console.ReadKey (true);
        }
    }
}