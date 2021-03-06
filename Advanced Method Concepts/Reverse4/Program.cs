﻿/*Author:   Peter Eugene Mbanda
**Date:     2/12/2016
**Purpose:  Application to reverse the position of variables
**
**@all rights reserved
**@not for unauthorised use
*/
using System;

namespace Reverse4
{
    class Program
    {

        static void Main(string[] args)
        {
            // declare local variables 
            int firstInt = 98, secondInt = 30, thirdInt = 356, fourthInt = 526;

            Original_position(firstInt, secondInt, thirdInt, fourthInt);

            Console.WriteLine();

            // pass variables to the method to reverse the positions
            Reverse_position(firstInt, secondInt, thirdInt, fourthInt);

            Console.ReadLine();
        }
        static void Reverse_position( params int[] numbers)
        {
            // sort numbers
            Array.Sort(numbers);

            // reverse the list positions by reverse iteration over the loop
            Console.WriteLine("List of reversed positions ");
            for (int i = (numbers.Length - 1); i >= 0; --i)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();
        }

        static void Original_position(params int[] numbers)
        {
            // reverse the list positions by reverse iteration over the loop
            Console.WriteLine("List of original positions ");
            for (int i = 0; i < numbers.Length; ++i)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();
        }
    }
}
