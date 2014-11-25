using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3_Prog
{

    class Program
    {
        public static int diag_index = 0;
        public static int width_of_cmd = 60;
        public static char[] process_name = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public static double[] service_holder;
        public static char[] diag_dash;
        public static double main_gs = 0;
        public static int num_of_processes = 0;
        public static double highest_pen = 0;
        public static int least_arr = 1000;
        public static int temp_diag_index;
        public struct PROCESS
        {
            public int t_arr, TST, MST; public double Ratio_R, Ratio_P, penalty, t_wait, t_serv;
            public char[] diagram;
        }
        static PROCESS Create()
        {
            return new PROCESS()
            {
                diagram = new char[width_of_cmd],
            };
        }

        public static void Main()
        {
            Console.Title = "Highest Penalty Ratio Next Process Calculator";
            Console.SetWindowSize(128, 38);
            Console.SetBufferSize(128, 300);
            ConsoleColor st_color;
            st_color = ConsoleColor.Cyan;
            Console.ForegroundColor = st_color;
            Console.WriteLine("Created by Adetunji Openiyi, Class of 2015"); //Opening Credits
            Console.ResetColor();

            // Initialize variable for holding the number of processes dynamically 
            //Enable user input of number of prosecces                        
            Console.Write("Please Enter Number of Processes: ");
            num_of_processes = int.Parse(Console.ReadLine());

            //Declare array of structures
            PROCESS[] processes = new PROCESS[num_of_processes];

            service_holder = new double[num_of_processes];
            diag_dash = new char[width_of_cmd];

            
            //double highest_pen = 0;


            #region Initialization
            // Initialization of all fields in the structure array
            for (int i = 0; i < num_of_processes; )
            {
                //processes[i].t_arr = 0;
                //processes[i].t_serv = 0;
                Console.Write("Please Enter Arrival Time for process {0}: ", process_name[i]);
                processes[i].t_arr = int.Parse(Console.ReadLine());

                Console.Write("Please Enter Service Time for process {0}: ", process_name[i]);
                processes[i].t_serv = double.Parse(Console.ReadLine());

                processes[i].MST = 0;
                processes[i].TST = 0;
                processes[i].t_wait = 0;
                processes[i].Ratio_R = 0;
                processes[i].Ratio_P = 0;
                processes[i].penalty = 0;
                processes[i].diagram = new char[width_of_cmd];
                service_holder = new double[num_of_processes];
                for (int j = 0; j < width_of_cmd; )
                {

                    processes[i].diagram[j] = '=';
                    diag_dash[j] = '_';
                    j++;
                }
                i++;

                for (int k = 0; k < num_of_processes; k++)
                {
                    service_holder[k] = processes[k].t_serv;
                }

            }
            #endregion
            //Console.WriteLine("Process 0 arrival time is {0}", processes[0].t_arr);
            for (int i = 0; i < num_of_processes; i++)
            {
                main_gs = main_gs + processes[i].t_serv;

            }

           // diag_index = least_arr;


             
            for (int i = 0; i < num_of_processes; i++)
            {
                //Determine the smallest arrival time
                #region find_least
                if (processes[i].t_arr < least_arr)
                    least_arr = processes[i].t_arr;
                #endregion
                 
            }
            diag_index = least_arr;
            temp_diag_index = diag_index;
                // If a process has the smallest time give it X
                #region first_process
            for (int i = 0; i < num_of_processes; i++)
            {
                if (processes[i].t_arr == least_arr)
                {

                    int temp_serv = (int)processes[i].t_serv;
                    for (int j = temp_diag_index; j < temp_serv+temp_diag_index; j++)
                    {

                        processes[i].diagram[j] = 'X';
                        diag_index++;
                        processes[i].TST++;
                        processes[i].t_serv--;

                    }

                    i++;

                    //Because finished

                }
                #endregion

            }



            // Add "o" if a process is waiting
            for (int i = 0; i < num_of_processes; i++)
            {
                #region Assign_first wait
                if (processes[i].t_arr != least_arr && processes[i].t_arr <= diag_index)
                {

                    for (int k = processes[i].t_arr; k < diag_index; k++)
                    {
                        processes[i].diagram[k] = 'o';
                        processes[i].TST++;
                        processes[i].t_wait++;
                    }

                }
                #endregion
            }

            calc_high_pen(processes, diag_index);
            Assign_X(processes, num_of_processes, main_gs, diag_index);


            #region Other Calculations

            for (int i = 0; i < num_of_processes; ++i)
            {

                processes[i].MST = processes[i].TST - (int)service_holder[i];

                processes[i].Ratio_R = service_holder[i] / processes[i].TST;

                processes[i].Ratio_P = processes[i].TST / service_holder[i];

            }

            #endregion




            Console.WriteLine();
            //   show_diagram(num_of_processes, processes);
            show_diagram(num_of_processes, processes);
            //String.Format("{0:0.00}", processes[i].penalty)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" | " + "Arrival" + "  |  " + "Service" + "  |  " + "TST" + "  | " + "MST" + "  |  " + "Ratio R" + "  |  " + "Ratio P" + "  |");
            Console.WriteLine();
            Console.ResetColor();
            //Console.WriteLine();

            for (int i = 0; i < num_of_processes; i++)
            {
                Console.Write(process_name[i]);
                Console.Write("|       " + processes[i].t_arr + "  |       " + service_holder[i] + "  |    " + processes[i].TST + "  |  " + processes[i].MST + " |      " + String.Format("{0:0.00}", processes[i].Ratio_R) + " |      " + String.Format("{0:0.00}", processes[i].Ratio_P) + " |");
                Console.WriteLine();
            }
            //for (int i = 0; i < num_of_processes; i++)
            //{
            //    Console.WriteLine(String.Format("{0:0.00}", processes[i].penalty));
            //    //Console.WriteLine();
            //    //Console.WriteLine(processes[i].TST);
            //    //Console.WriteLine(highest_pen);
            //}
            //Console.WriteLine(main_gs);



            press_key();
        }

        public static double global_serv(PROCESS[] processes, int num_of_processes)
        {
            double gs = 0;
            for (int j = 0; j < num_of_processes; ++j)
            {
                gs += processes[j].t_serv;
                //avg = avg / i.Length;
            }

            return gs;
        }

        public static double average_double(double[] i)
        {
            double avg = 0;
            for (int j = 0; j < i.Length; ++j)
            {
                avg += i[j];
                avg = avg / i.Length;
            }
            return avg;
        }

        public static void press_key()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void show_diagram(int num_of_processes, PROCESS[] processes)
        {
            //To display the diargram of process
            for (int i = 0; i < num_of_processes; i++)
            {
                // Console.WriteLine();
                for (int j = 0; j < width_of_cmd; j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(diag_dash[j] + "_");
                    Console.ResetColor();

                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(process_name[i] + " ");
                Console.ResetColor();


                for (int j = 0; j < width_of_cmd; ++j)
                {

                    Console.Write(processes[i].diagram[j] + "|");


                }
                //
                Console.WriteLine();

            }


            Console.WriteLine();
        }



        public static int Assign_X(PROCESS[] processes, int num_of_processes, double main_gs, int diag_index)
        {
            double high_pen = calc_high_pen(processes, diag_index);

            for (int i = 0; i < num_of_processes; i++)
            {
                #region Assign_X
                if (processes[i].penalty == high_pen)
                {
                    int temp_service = (int)processes[i].t_serv;
                    int temp_diag = diag_index;
                    for (int j = temp_diag; j < temp_service + temp_diag; j++)
                    {

                        processes[i].diagram[j] = 'X';

                        diag_index++;
                        main_gs--;
                        processes[i].TST++;
                        processes[i].t_serv--;


                    }
                    // processes[i].t_serv = 0;for (int i = 0; i < num_of_processes; i++)

                    if (processes[i].t_serv == 0)
                    {
                        processes[i].penalty = 0;
                    }


                }
                // highest_pen = processes[0].penalty;
                #endregion


            }

            for (int i = 0; i < num_of_processes; i++)
            {
                #region Assign_wait
                // Assign wait zeroes
                //double high_pen = calc_high_pen(processes, diag_index);
                if (processes[i].penalty != high_pen && processes[i].t_arr <= diag_index && processes[i].t_serv > 0)
                {
                    int temp_arr = processes[i].t_arr;
                    for (int k = temp_arr; k < diag_index; k++)
                    {

                        processes[i].diagram[k] = 'o';
                        processes[i].TST++;
                        processes[i].t_wait++;


                    }

                }
                #endregion

            }
            //Console.WriteLine(main_gs);
            //Calls Highest Penalty Calculator
            // calc_high_pen(processes, diag_index); 

            if (main_gs > 0)
            {
                return Assign_X(processes, num_of_processes, main_gs - 1, diag_index);
            }

            else return 0;

        }

        public static double calc_high_pen(PROCESS[] processes, int diag_index)
        {
            double highest_pen = 0;
            for (int i = 0; i < num_of_processes; i++)
            {
                if (processes[i].t_serv > 0)
                    processes[i].penalty = (processes[i].t_wait + processes[i].t_serv) / processes[i].t_serv;


            }



            for (int i = 0; i < num_of_processes; i++)
            {
                if (processes[i].penalty > highest_pen)
                    highest_pen = processes[i].penalty;


            }


            return highest_pen;
        }


    }
}
