using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//HPRN
namespace Lab3_Prog
{
    class Program
    {
      public static void Main()
        {
          //Intitialize the number of processes for user input
          int num_of_processes = 0;
          Console.Write("Please Enter Number of Processes: ");
          num_of_processes = int.Parse(Console.ReadLine());

          //Initialize array to store the process arrival times
          Console.WriteLine("Please Enter process arrival times: ");
          int[] t_arr = new int[num_of_processes];
          for(int i =0; i<num_of_processes;)
          {
              t_arr[i] = int.Parse(Console.ReadLine());
              i++;
          }

          Console.Write("Arrival times have been set: " );
          foreach (int i in t_arr)
          {
              Console.Write("{0}, ",i);
          }
          Console.WriteLine();

          //Initialize the array to store the needed service times
          Console.WriteLine("Please Enter process service times: ");
          int[] t_serv = new int[num_of_processes];
          for (int i = 0; i < num_of_processes; )
          {
              t_serv[i] = int.Parse(Console.ReadLine());
              i++;
          }

          Console.Write("Service times have been set: ");
          foreach (int i in t_serv)
          {
              Console.Write("{0}, ", i);
          }

          //Initialize array to store total time in system
          // Total System time
          int[] TST = new int[num_of_processes];
          
          //Initialize array to store difference between TST and t_serv time in system
          // Mean System time
          int[] MST = new int[num_of_processes];
          for (int i = 0; i < num_of_processes; ++i)
          {
              for (int j = 0; j < num_of_processes; ++j)
              {
                  MST[i] = TST[j] - t_serv[j];
              }
          }

          //Initialize array to store t_serv/TST
          // Ratio
          double[] Ratio_R = new double[num_of_processes];
          for (int i = 0; i < num_of_processes; ++i)
          {
              for (int j = 0; j < num_of_processes; ++j)
              {
                  Ratio_R[i] = t_serv[j]/TST[j];
              }
          }

          //Initialize array to store TST/t_serv
          // Ratio
          double[] Ratio_P = new double[num_of_processes];
          for (int i = 0; i < num_of_processes; ++i)
          {
              for (int j = 0; j < num_of_processes; ++j)
              {
                  Ratio_P[i] = TST[j]/t_serv[j];
              }
          }
         
          //Initialize variable for average of t_serv,TST, MST, Ratio_R, Ratio_P values
          double avg_tserv = 0;
          avg_tserv = average_int(t_serv);

          double avg_TST = 0;
          avg_TST = average_int(TST);

          double avg_MST = 0;
          avg_MST = average_int(MST);

          //Implement Average for double arrays
          double avg_RR = 0;
          avg_RR = average_double(Ratio_R);

          double avg_RP = 0;
          avg_RP = average_double(Ratio_P);
          

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
