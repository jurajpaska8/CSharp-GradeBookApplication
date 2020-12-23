using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            int groupsCount = 5;
            int gradeGroupSize = Students.Count / groupsCount;

            List<double> grades = new List<double>();
            foreach(var student in Students)
            {
                grades.Add(student.AverageGrade);
            }

            grades.Sort();

            char g = 'A';
            for (int i = groupsCount - 1; i > 0; i--, g++)
            {
                if (averageGrade >= grades[i * gradeGroupSize])
                {
                    return g;
                }
            }


            return 'F';
        }
    }
}
