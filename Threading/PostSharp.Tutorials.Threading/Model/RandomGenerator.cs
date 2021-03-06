﻿using System;
using System.Collections.Immutable;
using System.Linq;
using System.Windows.Media;
using PostSharp.Patterns.Threading;

namespace PostSharp.Tutorials.Threading.Model
{
    [Synchronized]
    internal class RandomGenerator
    {

        public static readonly RandomGenerator Instance = new RandomGenerator();

        private readonly Random random = new Random();

        private readonly ImmutableArray<string> colors = typeof(Brushes).GetProperties().Select(p => p.Name).ToImmutableArray();

        public string GetRandomColor()
        {
            return this.colors[this.random.Next(this.colors.Length)];
        }

        public Creature CreateCreature()
        {
            return new Creature
            {
                X = this.random.NextDouble() * 20 - 10,
                Y = this.random.NextDouble() * 20 - 10,
                Orientation = this.random.Next(359),
                Color = this.GetRandomColor()
            };
                
        }
    }


}

