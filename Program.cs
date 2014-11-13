using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3_Prog
{
    
    class Program
    { 
       public static int diag_index ;
       public struct PROCESS
        {
            public int t_arr, t_serv, TST, MST, t_wait; public double Ratio_R, Ratio_P;
            public char[] diagram;
        }
       static PROCESS Create()
       {   return new PROCESS()
            {
                diagram = new char[128],
            };
       }
      
      public static void Main()
        {
            Console.WriteLine("Created by Adetunji Openiyi, Class of 2015");
            int num_of_processes = 0;
            PROCESS[] processes = new PROCESS[num_of_processes];
            int least_arr = processes[0].t_arr;
            
       
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
            
            Console.Write("Please Enter Number of Processes: ");
            num_of_processes = int.Parse(Console.ReadLine());


            
            for(int i =0; i<num_of_processes;)
            {
              //processes[i].t_arr = 0;
              //processes[i].t_serv = 0;
              Console.Write("Please Enter Arrival Time for process {0}: ",i);
              processes[i].t_arr = int.Parse(Console.ReadLine());

              Console.Write("Please Enter Service Time for process {0}: ", i);
              processes[i].t_serv = int.Parse(Console.ReadLine());

              processes[i].MST = 0;
              processes[i].TST = 0;
              processes[i].t_wait = 0;
              processes[i].Ratio_R = 0;
              processes[i].Ratio_P = 0;
              processes[i].diagram = new char[128];
                 for (int j = 0; j < 128;)
                 {
                  
                     processes[i].diagram[j] = '=';
                     j++;
                 }
                 i++; 
              
            }
            //Console.WriteLine("Process 0 arrival time is {0}", processes[0].t_arr);

            //Determine the smallest arrival time
            

            for (int i = 0; i < num_of_processes; )
            {
                if (processes[i].t_arr < least_arr)
                    least_arr = processes[i].t_arr;
                i++;
                diag_index = least_arr;

                if (processes[i].t_arr == least_arr)
                {
                    for (int j = 0; j < processes[i].t_serv; j++)
                    {
                        processes[i].diagram[j] = 'X';
                        diag_index++;
                    }
                }
            }

            for (int i = 0; i < num_of_processes; i++)
            {
                Console.Write(processes[i].diagram[i]);
            }

           // Console.Write(least_arr);
     
         
         //Console.Write("Please Enter Number of Processes: ");
         //num_of_processes = int.Parse(Console.ReadLine());

          //Initialize array to store the process arrival times
          //Console.WriteLine("Please Enter process arrival times: ");
          //int[] t_arr = new int[num_of_processes];
          //for(int i =0; i<num_of_processes;)
          //{
          //    t_arr[i] = int.Parse(Console.ReadLine());
          //    i++;
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
         
          

        }

      public static double average_int(int[] i)
      {
          double avg = 0;
          for (int j = 0; j < i.Length; ++j)
          {
              avg += i[j];
              avg = avg / i.Length;
          }
          return avg;
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
    }
}
