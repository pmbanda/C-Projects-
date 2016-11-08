﻿//Author:   Peter eugene Mbanda
//Date:     3/2/2016
//Purpose:  Application to display tax owed by the tax payer

using System;
using static System.Console;

namespace TaxPayerDemo2
{
    class Program
    {
        //class variables
        static double income;
        static string socialNum;
        static double result;

        static void Main(string[] args)
        {
            //number of Tax payers objects created
            const int NUM_OBJECTS = 4;

            //array of objects 
            Tax[] tax = new Tax[NUM_OBJECTS];

            //data for each object
            UserEntry(tax, ref socialNum, ref income);

            WriteLine();//whiteline spacing

            //display the objects
            WriteLine("Before Sorting: ");
            WriteLine("----------------------------------");
            Display(tax);

            WriteLine();//whiteline spacing

            WriteLine("After sorting: ");
            WriteLine("----------------------------------");
            Array.Sort(tax);
            Display(tax);

            Console.ReadLine();
        }

        private static void UserEntry(Tax[] tax, ref string socialNum, ref double income)
        {
            for (int i = 0; i < tax.Length; i++)
            {
                WriteLine();

                //prompt the user for ssn 
                Write("Enter the user SSN >> ");
                socialNum = ReadLine();
                //user prompt for gross income
                Write("Enter the user yearly gross income >> ");
                string numString = ReadLine();

                if (Double.TryParse(numString, out result))
                    income = result;
                else
                    WriteLine("Sorry {0} is not in range of double ", numString);

                tax[i] = new Tax(socialNum, income);//assign values to the object

            }
        }

        //display the object values
        private static void Display(Tax[] obj)
        {
            WriteLine();
            for (int i = 0; i < obj.Length; i++)
            {
                WriteLine("Social Security Number #{0} ", obj[i].SSN);
                WriteLine("Tax Owed {0} ", obj[i].taxOwed.ToString("C2"));
                WriteLine();
            }
        }
    }
    class Tax : IComparable
    {
        //data fieds
        public readonly double taxOwed;
        private string ssn;
        private double grossIncome;
        const double LOW_TAX_BRACKET = (15 / 100.0);
        const double HIGH_TAX_BRACKET = (28 / 100.0);

        //class constructor
        public Tax(string ssNumber, double gross)
        {
            ssn = ssNumber;
            grossIncome = gross;
            taxOwed =  CalculateTax();
        }

        private double CalculateTax()
        {
            //assign higher rate if the gross is greater than 30000 else low rate tax
            if (grossIncome >= 30000)
                grossIncome *= HIGH_TAX_BRACKET;
            else
                grossIncome *= LOW_TAX_BRACKET;

            return grossIncome;
        }

        public int CompareTo(object obj)
        {
            //implementation of icomparable interface 
            Tax temp = (Tax)obj;

            if (this.taxOwed > temp.taxOwed)
                return 1;
            else
            {
                if (this.taxOwed < temp.taxOwed)
                    return -1;
                else
                    return 0;
            }
        }

        //ssn getter methods
        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }

        //gross income setter and getter methods
        public double GrossIncome
        {
            get { return grossIncome; }
            set { grossIncome = value; }
        }

    }
}
