﻿using System;
using System.Windows.Media;
using PostSharp.Patterns.Contracts;
using PostSharp.Patterns.Model;
using PostSharp.Patterns.Threading;

namespace PostSharp.Tutorials.Threading
{
    [Immutable]
    [NotifyPropertyChanged]
    internal class CreatureViewModel
    {
        private static readonly BrushConverter brushConverter = new BrushConverter();

        [Reference]
        private readonly BoardViewModel board;

        [Reference]
        public Creature Creature { get; }

        public CreatureViewModel([Required] Creature creature, [Required] BoardViewModel board)
        {
            this.Creature = creature;
            this.board = board;
        }

        public Guid Id => this.Creature.Id;

        public double X => this.Creature.X * 20 + 200;

        public double Y => this.Creature.Y * 20 + 200;

        public bool IsSelected => this.board.SelectedCreature == this;

        public double Orientation => this.Creature.Orientation;

        [SafeForDependencyAnalysis]
        public Brush FillColor => (SolidColorBrush)brushConverter.ConvertFromString(this.Creature.Color);
      
        public Brush StrokeColor => this.IsSelected ? Brushes.MediumAquamarine : Brushes.Transparent;

        public double Opacity => this.IsSelected ? 1 : 0.4;

        
    }


}

