using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (Students.Count < 5) throw new InvalidOperationException("Need minimium 5 students ");

            var limit =  (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[limit - 1] <= averageGrade) return 'A';
            else if (grades[limit - 2] <= averageGrade) return 'B';
            else if (grades[limit - 3] <= averageGrade) return 'C';
            else if (grades[limit - 4] <= averageGrade) return 'D';
            else return 'F';
            
            
                return base.GetLetterGrade(averageGrade);
        }   


       

    }
}
