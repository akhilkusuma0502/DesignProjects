using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_Entities
{
    public class Disciplines
    {
        private int _disciplineId;

        public int DisciplineId
        {
            get { return _disciplineId; }
            set { _disciplineId = value; }
        }

        private string _disciplineName;

        public string DisciplineName
        {
            get { return _disciplineName; }
            set { _disciplineName = value; }
        }

        public Disciplines()
        {

        }

        public Disciplines(int DisciplineId, string DisciplineName)
        {
            this.DisciplineId = DisciplineId;
            this.DisciplineName = DisciplineName;
        }

    }
}
