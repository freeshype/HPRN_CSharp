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
       public static int diag_index ;
       public static int width_of_cmd = 126;
       public static char[] process_name = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
       public static double main_gs =0 ;
       public static int num_of_processes = 0;   
       
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
            Console.WriteLine("Created by Adetunji Openiyi, Class of 2015"); //Opening Credits
          // Initialize variable for holding the number of processes dynamocally
          //int num_of_processes = 0;    
           
          //Enable user input of number of prosecces                        
           Console.Write("Please Enter Number of Processes: ");
          num_of_processes = int.Parse(Console.ReadLine());

          //Declare array of structures
          PROCESS[] processes = new PROCESS[num_of_processes]; 
            
          
           
          int least_arr = processes[0].t_arr;
          double highest_pen = 0;

          #region Hardcode Inits
          //Intitialize the of processes
            //PROCESS A, B, C, D, E;
            //// Assign arrival 
            //A.t_arr = 2;
            //B.t_arr = 4;
            //C.t_arr = 0;
            //D.t_arr = 1;
            //E.t_arr = 5;

            ////Initialize service
            //A.t_serv = 10;
            //B.t_serv = 4;
            //C.t_serv = 6;
            //D.t_serv = 3;
            //E.t_serv = 5;

            //A.TST= 0 ;
            //B.TST = 0;
            //C.TST = 0;
            //D.TST = 0;
          //E.TST = 0;
          #endregion


          #region Initialization
          // Initialization of all fields in the structure array
            for(int i =0; i<num_of_processes;)
            {
              //processes[i].t_arr = 0;
              //processes[i].t_serv = 0;
              Console.Write("Please Enter Arrival Time for process {0}: ",i);
              processes[i].t_arr = int.Parse(Console.ReadLine());

              Console.Write("Please Enter Service Time for process {0}: ", i);
              processes[i].t_serv = double.Parse(Console.ReadLine());

              processes[i].MST = 0;
              processes[i].TST = 0;
              processes[i].t_wait = 0;
              processes[i].Ratio_R = 0;
              processes[i].Ratio_P = 0;
              processes[i].penalty = 0;
              processes[i].diagram = new char[width_of_cmd];
                 for (int j = 0; j < width_of_cmd;)
                 {
                  
                     processes[i].diagram[j] = '=';
                     j++;
                 }
                 i++;

            }
          #endregion
            //Console.WriteLine("Process 0 arrival time is {0}", processes[0].t_arr);
            main_gs = global_serv(processes, num_of_processes);
            //Determine the smallest arrival time
            diag_index = least_arr;


            
            for (int i = 0; i < num_of_processes; i++)
            {
                #region find_least
                if (processes[i].t_arr < least_arr)
                    least_arr = processes[i].t_arr;
                #endregion

                // If a process has the smallest time give it X
                #region first_process
                if (processes[i].t_arr == least_arr)
                {
                    for (int j = 0; j < processes[i].t_serv; j++)
                    {
                        processes[i].diagram[j] = 'X';
                        diag_index++;
                        processes[i].TST++;
                        
                        
                    }
                    processes[i].t_serv = 0;
                    i++; 
                    //Console.WriteLine("!!! "+processes[i].t_serv);
                     //Because finished
                }
                #endregion
                
            } 
            
            //Console.WriteLine("!!! " + processes[2].t_serv);

            
            // Add "o" if a process is waiting
            for (int i = 0; i < num_of_processes; i++)
            {
                #region Assign_first wait
                if (processes[i].t_arr > least_arr)
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
          



            //for (int i = 0; i < num_of_processes; i++)
            //{
            //    processes[i].penalty = (processes[i].t_wait + processes[i].t_serv) / processes[i].t_serv;

            //    if (processes[i].TST == diag_index)
            //    {
            //        processes[i].penalty = 0;
            //    }
      
            //}
            //highest_pen = processes[0].penalty;
            //Testing loop
            #region test
            //for (int i = 0; i < num_of_processes; i++)
            //{
            //    Console.WriteLine(String.Format("{0:0.00}", processes[i].penalty));
            //    //Console.WriteLine();
            //    //Console.WriteLine(processes[i].TST);
            //    //Console.WriteLine(processes[i].penalty);
               

            //}
            #endregion
            // Console.WriteLine(diag_index);
            // Console.Write(least_arr);

            #region code_for_highest pen
            // Assign the highest penalty
            //for (int i = 0; i < num_of_processes; i++)
            //{
            //    if (processes[i].penalty > highest_pen)
            //        highest_pen = processes[i].penalty;
            //}
            #endregion


            // Calculate highest penalty
               //for (int i = 0; i < num_of_processes; i++)
               // {
               //     #region Assign_wait
               //     // Assign wait zeroes
               //     if (processes[i].penalty < highest_pen)
               //     {

               //         for (int k = processes[i].t_arr; k < diag_index && processes[i].t_serv != 0; k++)
               //         {
                            
               //             processes[i].diagram[k] = 'o';
               //             processes[i].TST++;
               //             processes[i].t_wait++;


               //         }

               //     }
               //     #endregion

               //     #region assign X
               //     ////Assign X
               //     //if (processes[i].penalty == highest_pen)
               //     //{
               //     //    for (int j = 0; j < processes[i].t_serv; j++)
               //     //    {

               //     //        processes[i].diagram[diag_index] = 'X';
               //     //        diag_index++;
               //     //        processes[i].TST++;
                           

               //     //    }
               //     //    processes[i].t_serv = 0;

               //     //}
               //     #endregion


               // }

               #region Other stuff
               //for (int i = 0; i < num_of_processes; i++)
            //{

            //    if (processes[i].penalty < highest_pen)
            //    {

            //        for (int k = processes[i].t_arr; k < diag_index; k++)
            //        {

            //            processes[i].diagram[k] = 'o';
            //            processes[i].TST++;
            //            processes[i].t_wait++;

                        
            //        }

            //    }
                
            //}

          //Initialize array to store difference between TST and t_serv time in system
          // Mean System time
          //int[] MST = new int[num_of_processes];
          //for (int i = 0; i < num_of_processes; ++i)
          //{
          //    for (int j = 0; j < num_of_processes; ++j)
          //    {
          //        MST[i] = TST[j] - t_serv[j];
          //    }
          //}

          //Initialize array to store t_serv/TST
          // Ratio
          //double[] Ratio_R = new double[num_of_processes];
          //for (int i = 0; i < num_of_processes; ++i)
          //{
          //    for (int j = 0; j < num_of_processes; ++j)
          //    {
          //        Ratio_R[i] = t_serv[j]/TST[j];
          //    }
          //}

          //Initialize array to store TST/t_serv
          // Ratio
          //double[] Ratio_P = new double[num_of_processes];
          //for (int i = 0; i < num_of_processes; ++i)
          //{
          //    for (int j = 0; j < num_of_processes; ++j)
          //    {
          //        Ratio_P[i] = TST[j]/t_serv[j];
          //    }
               //}

               #endregion
            highest_pen = calc_high_pen(processes, diag_index);
            Assign_o(processes, diag_index, num_of_processes);
            Assign_X(processes, highest_pen, num_of_processes,main_gs,diag_index);
            show_diagram(num_of_processes, processes);


            for (int i = 0; i < num_of_processes; i++)
            {
                Console.WriteLine(String.Format("{0:0.00}", processes[i].penalty));
                //Console.WriteLine();
                //Console.WriteLine(processes[i].TST);
                //Console.WriteLine(processes[i].penalty);


            }
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

      public static void press_key ()
      {
          Console.WriteLine("Press any key to continue...");
          Console.ReadKey();
      }
      public static void show_diagram (int num_of_processes, PROCESS[] processes)
      {
          //To display the diargram of process
          for (int i = 0; i < num_of_processes; i++)
          {
              Console.WriteLine();
              Console.Write(process_name[i]+" ");
              for (int j = 0; j < width_of_cmd; ++j)
              {
                  
                  Console.Write(processes[i].diagram[j]);
              }
          }
      }

      public static int Assign_o (PROCESS[] processes, int diag_index, int num_of_processes)
      {
          for (int i = 0; i < num_of_processes; i++)
          {
              #region Assign_wait
              // Assign wait zeroes
              if (processes[i].penalty < calc_high_pen(processes, diag_index))
              {

                  for (int k = processes[i].t_arr; k < diag_index && processes[i].t_serv != 0; k++)
                  {

                      processes[i].diagram[k] = 'o';
                      processes[i].TST++;
                      processes[i].t_wait++;


                  }

              }
              #endregion
          }
          return Assign_o(processes, diag_index,num_of_processes);
      }

      public static int Assign_X (PROCESS[] processes, double highest_pen, int num_of_processes, double main_gs, int diag_index)
      {
          for (int i = 0; i < num_of_processes; i++)
          {
              if (processes[i].penalty == calc_high_pen(processes,diag_index))
              {
                  for (int j = 0; j < processes[i].t_serv; j++)
                  {

                      processes[i].diagram[diag_index] = 'X';
                      diag_index++;
                      processes[i].TST++;
                      main_gs--;

                  }
                  processes[i].t_serv = 0;

              }
          }
          //Console.WriteLine(main_gs);
          //Calls Highest Penalty Calculator
          calc_high_pen(processes, diag_index); 

          if (main_gs != 0)
          {
              return Assign_X(processes, highest_pen, num_of_processes, main_gs, diag_index);
          }
            
          else return 0;
        
      }

      public static double calc_high_pen (PROCESS[] processes, int diag_index)
      {
          double highest_pen = 0;
          for (int i = 0; i < num_of_processes; i++)
          {
              processes[i].penalty = (processes[i].t_wait + processes[i].t_serv) / processes[i].t_serv;

              if (processes[i].TST == diag_index)
              {
                  processes[i].penalty = 0;
              }

              if (processes[i].penalty > highest_pen)
                  highest_pen = processes[i].penalty;
          }

          

          return highest_pen;
      }


    }
}
