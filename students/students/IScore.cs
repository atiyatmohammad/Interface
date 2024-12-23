using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students
{
    internal interface IScore
    {
        void AddScore(int studentId,int courseId, float score);
        void DeleteScore(int id);
        void DisplayScore(string query);
        void UpdataScore(string query);
        void DisplayScoreTextFile(string query);
    }
}
