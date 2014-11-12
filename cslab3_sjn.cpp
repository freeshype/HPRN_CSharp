// cslab3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
#include "cmath"
///define variables here
struct PROCESS {
	int service_time, arrival_time, time_served, delta;
	char diagram[50];

};
using namespace std;
int diagram_index= 0;
int _tmain(int argc, _TCHAR* argv[])
{
	//ASSIGN initial VALUES
	 PROCESS A, B, C, D, E; 
	 for (int a= 0; a<50; a++)
	 {
		 A.diagram[a] = '-';
		 B.diagram[a] = '-';
		 C.diagram[a] = '-';
		 D.diagram[a] = '-';
		 E.diagram[a] = '-';
	 }

	 
	/* A.service_time = 8;
	 A.arrival_time = 3;
	
	 
	 B.service_time = 4;
	 B.arrival_time = 1;

	 
	 C.service_time = 6;
	 C.arrival_time = 0;

	 
	 D.service_time = 3;
	 D.arrival_time = 2;

	 
	 E.service_time = 5;
	 E.arrival_time = 4;*/

	 cout<<"Enter service time for Process A: "; cin >> A.service_time; cout<<endl;
	 cout<<"Enter arrival time for Process A: "; cin >> A.arrival_time; cout<<endl;

	 cout<<"Enter service time for Process B: "; cin >> B.service_time; cout<<endl;
	 cout<<"Enter arrival time for Process B: "; cin >> B.arrival_time; cout<<endl;

	 cout<<"Enter service time for Process C: "; cin >> C.service_time; cout<<endl;
	 cout<<"Enter arrival time for Process C: "; cin >> C.arrival_time; cout<<endl;

	 cout<<"Enter service time for Process D: "; cin >> D.service_time; cout<<endl;
	 cout<<"Enter arrival time for Process D: "; cin >> D.arrival_time; cout<<endl;

	 cout<<"Enter service time for Process E: "; cin >> E.service_time; cout<<endl;
	 cout<<"Enter arrival time for Process E: "; cin >> E.arrival_time; cout<<endl;

	 //////////////////////START ALLOCATING TICKS
	 ////////////////////////////////////////check who comes first 
	 int smallest = min(min( min(A.arrival_time,B.arrival_time), min(C.arrival_time,D.arrival_time)), E.arrival_time);
	  

	 if (A.arrival_time ==smallest)
	 {
		  
		 A.diagram[diagram_index] = 'A';
		 diagram_index++;
		 A.service_time--;
	 }

	 else if (B.arrival_time ==smallest)
	 {
		 B.diagram[diagram_index] = 'A';
		 diagram_index++;
		 B.service_time--;
	 }

	  else if (C.arrival_time ==smallest)
	 {
		 C.diagram[diagram_index] = 'A';
		 diagram_index++;
		 C.service_time--;
	 }

	 else if (D.arrival_time ==smallest)
	 {
		 D.diagram[diagram_index] = 'A';
		 diagram_index++;
		 D.service_time--;
	 }

	 else if (E.arrival_time ==smallest)
	 {
		 E.diagram[diagram_index] = 'A';
		 diagram_index++;
		 E.service_time--;
	 }
	
	 /////////////////////////////////////////check if another process's turn to activate
	for (int i = 0; i <50; i++)
	{

	 int shortest_job = min(min( min(A.service_time,B.service_time), min(C.service_time,D.service_time)), E.service_time);
	   
	 if (A.service_time ==shortest_job && A.service_time !=500)
	 {
		  
		
		 
		 A.diagram[diagram_index] = 'A';
		 B.diagram[diagram_index] = 'w';
		 C.diagram[diagram_index] = 'w';
		 D.diagram[diagram_index] = 'w';
		 E.diagram[diagram_index] = 'w';
		 

		  
		  ///check and fill if inactive
		  if (   diagram_index <A.arrival_time  || A.service_time ==500)
		 {
			A.diagram[diagram_index] = '-';
		 }
		 
		   if (   diagram_index <B.arrival_time  || B.service_time ==500)
		 {
			 B.diagram[diagram_index] = '-';
		 }

		  if (  diagram_index <C.arrival_time  || C.service_time ==500)
		 {
			C.diagram[diagram_index] = '-';
		 }
		  if (  diagram_index <D.arrival_time || D.service_time ==500)
		 {
			 D.diagram[diagram_index] = '-';
		 }
		  if (   diagram_index <E.arrival_time || E.service_time ==500)
		 {
			 E.diagram[diagram_index] = '-';
		 }

		  diagram_index++;
		 A.service_time--;
		 if (A.service_time <=0)
			 A.service_time = 500;///meaning finished


	 }

	 else if (B.service_time ==shortest_job && B.service_time !=500)
	 {
		 
		 
		 

		 A.diagram[diagram_index] = 'w';
		 B.diagram[diagram_index] = 'A';
		 C.diagram[diagram_index] = 'w';
		 D.diagram[diagram_index] = 'w';
		 E.diagram[diagram_index] = 'w';
		 

		   ///check and fill if inactive
		  if (   diagram_index <A.arrival_time  || A.service_time ==500)
		 {
			A.diagram[diagram_index] = '-';
		 }
		 
		   if (   diagram_index <B.arrival_time  || B.service_time ==500)
		 {
			 B.diagram[diagram_index] = '-';
		 }

		  if (  diagram_index <C.arrival_time  || C.service_time ==500)
		 {
			C.diagram[diagram_index] = '-';
		 }
		  if (  diagram_index <D.arrival_time || D.service_time ==500)
		 {
			 D.diagram[diagram_index] = '-';
		 }
		  if (   diagram_index <E.arrival_time || E.service_time ==500)
		 {
			 E.diagram[diagram_index] = '-';
		 }

		 diagram_index++;
		 B.service_time--;
		  if (B.service_time <=0)
			B.service_time = 500;///meaning finished
	 }

	  else if (C.service_time ==shortest_job && C.service_time !=500)
	 {
		 
		 
		 A.diagram[diagram_index] = 'w';
		 B.diagram[diagram_index] = 'w';
		 C.diagram[diagram_index] = 'A';
		 D.diagram[diagram_index] = 'w';
		 E.diagram[diagram_index] = 'w';
		 

		  ///check and fill if inactive
		  if (   diagram_index <A.arrival_time  || A.service_time ==500)
		 {
			A.diagram[diagram_index] = '-';
		 }
		 
		   if (   diagram_index <B.arrival_time  || B.service_time ==500)
		 {
			 B.diagram[diagram_index] = '-';
		 }

		  if (  diagram_index <C.arrival_time  || C.service_time ==500)
		 {
			C.diagram[diagram_index] = '-';
		 }
		  if (  diagram_index <D.arrival_time || D.service_time ==500)
		 {
			 D.diagram[diagram_index] = '-';
		 }
		  if (   diagram_index <E.arrival_time || E.service_time ==500)
		 {
			 E.diagram[diagram_index] = '-';
		 }
		 diagram_index++;
		 C.service_time--;

		  if (C.service_time <=0)
			 C.service_time = 500;///meaning finished

	 }

	 else if (D.service_time ==shortest_job && D.service_time !=500)
	 {
		
		 
		 A.diagram[diagram_index] = 'w';
		 B.diagram[diagram_index] = 'w';
		 C.diagram[diagram_index] = 'w';
		 D.diagram[diagram_index] = 'A';
		 E.diagram[diagram_index] = 'w';
		 

		  ///check and fill if inactive
		  if (   diagram_index <A.arrival_time  || A.service_time ==500)
		 {
			A.diagram[diagram_index] = '-';
		 }
		 
		   if (   diagram_index <B.arrival_time  || B.service_time ==500)
		 {
			 B.diagram[diagram_index] = '-';
		 }

		  if (  diagram_index <C.arrival_time  || C.service_time ==500)
		 {
			C.diagram[diagram_index] = '-';
		 }
		  if (  diagram_index <D.arrival_time || D.service_time ==500)
		 {
			 D.diagram[diagram_index] = '-';
		 }
		  if (   diagram_index <E.arrival_time || E.service_time ==500)
		 {
			 E.diagram[diagram_index] = '-';
		 }
		 diagram_index++;
		 D.service_time--;

		  if (D.service_time <=0)
			 D.service_time = 500;///meaning finished

		



	 }

	 else if (E.service_time ==shortest_job && E.service_time !=500 )
	 {
		  
		 
		 A.diagram[diagram_index] = 'w';
		 B.diagram[diagram_index] = 'w';
		 C.diagram[diagram_index] = 'w';
		 D.diagram[diagram_index] = 'w';
		 E.diagram[diagram_index] = 'A';
		  

		   ///check and fill if inactive
		  if (   diagram_index <A.arrival_time  || A.service_time ==500)
		 {
			A.diagram[diagram_index] = '-';
		 }
		 
		   if (   diagram_index <B.arrival_time  || B.service_time ==500)
		 {
			 B.diagram[diagram_index] = '-';
		 }

		  if (  diagram_index <C.arrival_time  || C.service_time ==500)
		 {
			C.diagram[diagram_index] = '-';
		 }
		  if (  diagram_index <D.arrival_time || D.service_time ==500)
		 {
			 D.diagram[diagram_index] = '-';
		 }
		  if (   diagram_index <E.arrival_time || E.service_time ==500)
		 {
			 E.diagram[diagram_index] = '-';
		 }
		 diagram_index++;
		 E.service_time--;

		  if (E.service_time <=0)
			 E.service_time = 500;///meaning finished

	 }
	
	 

	}

	////////////////////////print results
	cout<<"A: ";
	for (int i = 0; i <50; i++)
	{
	cout<<A.diagram[i];

	}
	cout<<endl;
	cout<<"B: ";
	for (int i = 0; i <50; i++)
	{
	cout<<B.diagram[i];

	}cout<<endl;
	cout<<"C: ";
	for (int i = 0; i <50; i++)
	{
	cout<<C.diagram[i];

	}cout<<endl;
	cout<<"D: ";
	for (int i = 0; i <50; i++)
	{
	cout<<D.diagram[i];

	}cout<<endl;
	cout<<"E: ";
	for (int i = 0; i <50; i++)
	{
	cout<<E.diagram[i];

	}cout<<endl;



	return 0;
}
