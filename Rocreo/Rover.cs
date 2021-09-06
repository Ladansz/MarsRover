using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Recreo
{
    public class Rover
    {
        public Point Point { get; private set; }
        public Orientation Orientation { get; private set; }
        private readonly Plateau _plateau;

        public Rover(List<string> position, Plateau _plateau)
        {
            Point = new Point(Convert.ToInt32(position[0]), Convert.ToInt32(position[1]));
            Orientation = (Orientation)Enum.Parse(typeof(Orientation), position[2]);
            this._plateau = _plateau;
        }

        public void Explore(string instructionString)
        {
            if (string.IsNullOrWhiteSpace(instructionString))
                throw new ArgumentNullException(instructionString, "No Instructions!");
            foreach (var instructionChar in instructionString)
            {
                InstructionType instruction = GetInstruction(instructionChar);
                switch (Orientation)
                {
                    case Orientation.N:
                        HeadingNorth(instruction);
                        break;
                    
                    case Orientation.E:
                        HeadingEast(instruction);
                        break;
                    
                    case Orientation.S:
                        HeadingSouth(instruction);
                        break;
                    
                    case Orientation.W:
                        HeadingWest(instruction);
                        break;
                }
            }
        }

        private void HeadingWest(InstructionType instruction)
        {
            switch (instruction)
            {
                case InstructionType.R:
                    Orientation = Orientation.N;
                    break;
                case InstructionType.L:
                    Orientation = Orientation.S;
                    break;
                case InstructionType.M:
                    if (Point.X > _plateau.LowerLeft.X)
                    {
                        Point = new Point((Point.X) - 1, Point.Y);
                    }
                    break;
            }
        }

        private void HeadingSouth(InstructionType instructionType)
        {
            switch (instructionType)
            {
                case InstructionType.R:
                    Orientation = Orientation.W;
                    break;
                case InstructionType.L:
                    Orientation = Orientation.E;
                    break;
                case InstructionType.M:
                    if (Point.Y > _plateau.LowerLeft.Y)
                    {
                        Point = new Point(Point.X, (Point.Y) - 1);
                    }
                    break;
            }
        }

        private void HeadingEast(InstructionType instructionType)
        {
            switch (instructionType)
            {
                case InstructionType.R:
                    Orientation = Orientation.S;
                    break;
                case InstructionType.L:
                    Orientation = Orientation.N;
                    break;
                case InstructionType.M:
                    if (Point.X < _plateau.UpperRight.X)
                    {
                        Point = new Point((Point.X) + 1, Point.Y);
                    }
                    break;
            }
        }

        private void HeadingNorth(InstructionType instruction)
        {
            switch (instruction)
            {
                case InstructionType.R:
                    Orientation = Orientation.E;
                    break;
                case InstructionType.L:
                    Orientation = Orientation.W;
                    break;
                case InstructionType.M:
                    if(Point.Y < _plateau.UpperRight.Y)
                        Point = new Point(Point.X,(Point.Y) + 1);
                    break;
            }
        }

        private static InstructionType GetInstruction(char instructionChar)
        {
            Regex regex = new Regex(@"[LRM]");
            if (!regex.IsMatch(instructionChar.ToString()))
            {
                throw new InvalidEnumArgumentException("No instruction is defined for: " + instructionChar);
            }
            return (InstructionType)Enum.Parse(typeof(InstructionType), instructionChar.ToString());
        }
    }
}