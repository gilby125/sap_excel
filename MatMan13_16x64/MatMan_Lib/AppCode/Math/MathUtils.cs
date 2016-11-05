﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iiiwave.MatManLib
{
    public static class MathUtils
    {    
        private static void GetCombinationsRec<T>(IList<IEnumerable<T>> sources, T[] chain, int index, ICollection<T[]> combinations) 
        { 
            foreach (var element in sources[index]) 
            { 
                chain[index] = element; 
                if (index == sources.Count - 1) 
                { 
                    var finalChain = new T[chain.Length]; 
                    chain.CopyTo(finalChain, 0); 
                    combinations.Add(finalChain); 
                } 
                else 
                { 
                    GetCombinationsRec(sources: sources, chain: chain, index: index + 1, combinations: combinations); 
                } 
            } 
        } 
        public static List<T[]> GetCombinations<T>(params IEnumerable<T>[] enumerables) 
        { 
            var combinations = new List<T[]>(enumerables.Length); 
            if (enumerables.Length > 0) 
            { 
                var chain = new T[enumerables.Length]; 
                GetCombinationsRec(sources: enumerables, chain: chain, index: 0, combinations: combinations); 
            } 
            return combinations; 
        } 
    }
}