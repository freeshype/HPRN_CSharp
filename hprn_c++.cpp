// cslab3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
#include "cmath"
///define variables here
#define DIAGRAM_AMOUNT   30
struct PROCESS {
	double dArrival_time;
	double dPenalty, dWait_time, dService_time;//for double operations
	int iArrival_time, iPenalty, iWait_time, iService_time; //for integer operation
	 
	char diagram[DIAGRAM_AMOUNT];

};
int number_of_processes = 0;
double highest_penalty;
int total_service_time=0;
using namespace std;
int diagram_index= 0;
double Calculate_Penalty(PROCESS processes[], int no_processes);
int Recursive_Algorithm(PROCESS processes[], double highest_penalty);

int _tmain(int argc, _TCHAR* argv[])
{
	
	
	cout<<"Please type how many processes you want: "<<endl;
	cin>> number_of_processes;

	
	PROCESS * processes = new PROCESS[number_of_processes];

	for (int i = 0; i< number_of_processes; i++)
	{
		cout<<"Enter arrival time for process: "<<i<<": ";
		cin>> processes[i].iArrival_time;
		processes[i].dArrival_time = (double)processes[i].iArrival_time;
		 
		cout<<"Enter service time for process: "<<i<<": ";
		cin>> processes[i].iService_time;
		processes[i].dService_time = (double)processes[i].iService_time;
		
		
		for (int j=0; j<DIAGRAM_AMOUNT; j++)
		{
			processes[i].diagram[j] = '-';///initialized array with all inactive (-)
			 
		}
		processes[i].dWait_time = 0;
		 processes[i].dPenalty = 0;
	}

	for (int i = 0; i< number_of_processes; i++)
	{
		total_service_time =total_service_time + processes[i].iService_time;/////////////calculate total service time

	}
	////////created proccesses dynamically
	 
	//_____________________________________________________________________________________-
	double smallest = processes[0].dArrival_time;///Find smallest arrival time
	for (int i= 0; i<number_of_processes; i++)
	{
		if ( processes[i].dArrival_time < smallest)
			 smallest = processes[i].dArrival_time;
	}
	
	
	
	for (int i= 0; i<number_of_processes; i++)/////allocate active to smallest arrival time
	{
		if ( processes[i].iArrival_time ==smallest)
		{
			int temp_arrival = processes[i].iArrival_time;
			int temp_service_time = processes[i].iService_time;
			for (int k = temp_arrival; k<temp_service_time + temp_arrival; k++)////*****************************************EDIT LATER
			{
			processes[i].diagram[k] = 'A';
			diagram_index++;
			total_service_time--;
			 processes[i].dService_time--;
			processes[i].iService_time--;
			 
			}
		}
	}

	for (int i= 0; i<number_of_processes; i++)/////allocate inactive for those pending while first process was active
	{
		 if (processes[i].iArrival_time !=smallest && processes[i].iArrival_time <= diagram_index)
		{
			int temp_arrival = processes[i].iArrival_time;
			int temp_service_time = processes[i].iService_time;
			for (int k = temp_arrival; k<diagram_index; k++)
			{
				processes[i].diagram[k] = 'w';
				processes[i].dWait_time++;
			}
		
		}
		
	}
	
	//_____________________________________________________________________________________-

	///Start main algorithm and start allocating to processes who is active and have their turn
	
	
	 
	//processes[0].dPenalty = Calculate_Penalty(processes, number_of_processes);
	/* cout<<processes[0].dPenalty<<endl;
	 cout<<processes[1].dPenalty<<endl;
	cout<<processes[2].dPenalty<<endl;
	cout<<processes[3].dPenalty<<endl;
	cout<<processes[4].dPenalty<<endl;*/
	Recursive_Algorithm(processes, highest_penalty);////TO keep calling the function to process the algorithm
	
	 







	for (int i=0; i<number_of_processes; i++)///print out diagrams
	{
		cout<<"PID "<<i<<": ";
		for (int j=0; j<DIAGRAM_AMOUNT; j++)
		{
			cout<<processes[i].diagram[j]<<" ";
		}
		cout<<endl;
	}
	

}



 double Calculate_Penalty(PROCESS processes[], int no_processes)
{
	 highest_penalty = 0.0;

	 for ( int i =0; i<no_processes; i++)//calculates all penalties
	{
		if (processes[i].iService_time >0)
		processes[i].dPenalty = (processes[i].dWait_time + processes[i].dService_time) / processes[i].dService_time;///find how to get waiting time
		
	}
	for ( int i =0; i<no_processes; i++) 
	{
	if (processes[i].iArrival_time <= diagram_index && processes[i].iService_time >0)//who is in the system
	{
		 
			if (processes[i].dPenalty >= highest_penalty)//find who has highest penalty
				highest_penalty = processes[i].dPenalty;
			   
			
	}
	}
	return highest_penalty;
	 
}
 int Recursive_Algorithm(PROCESS processes[], double highest_penalty)
 {
      highest_penalty = Calculate_Penalty(processes, number_of_processes);
	 for ( int i =0; i<number_of_processes; i++)
	{
		if (processes[i].dPenalty == highest_penalty)
		{
				int temp_service_time = processes[i].iService_time;
				int temp_arrival_time = processes[i].iArrival_time;
				int temp_diagram_index = diagram_index;
			for (int k = temp_diagram_index; k< temp_service_time + temp_diagram_index; k++)
			{
			processes[i].diagram[k] = 'A';
			diagram_index++;
		    total_service_time--;
			processes[i].dService_time--;
			processes[i].iService_time--;
			}
		     
		}
	 }
	 for ( int i =0; i<number_of_processes; i++)
	{
		if (processes[i].dPenalty !=highest_penalty && processes[i].iArrival_time <= diagram_index && processes[i].iService_time >0)//if not highest, is in the system and is not yet finished
		{
			 int temp_arrival_time = processes[i].iArrival_time;
			for (int k = temp_arrival_time; k<diagram_index; k++)
			{
				processes[i].diagram[k] = 'w';
				processes[i].dWait_time++;
			}
 
	     }

	 }

	 
	 
	 if ( total_service_time > 0  )
	 {
	return Recursive_Algorithm(processes, highest_penalty);////if not finished, recurse the algorithm
	 }

	 else
	  return 0;
     
	

 }
