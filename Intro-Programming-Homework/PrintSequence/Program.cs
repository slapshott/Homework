﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            for ( int i = 2; i<12; i++)
            {
                if( i%2==0) 
                {
                    System.Console.WriteLine(i);
                }
                else
                {
                    System.Console.WriteLine(-i);
                }
            }    
        }
    }
}
