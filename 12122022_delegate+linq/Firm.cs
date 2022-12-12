using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12122022_delegate_linq
{
    internal class Firm
    {
        private string name;
        private List<Staff> staff_list;

        public Firm(string name, List<Staff> staff)
        {
            this.name = name;
            this.staff_list = staff;
        }

        public Firm()
        {
            this.name = "Sad firm s.r.o";
            this.staff_list = new List<Staff>
            {
                new Staff("Jhon","Beckham",200000,Rank.Boss,new DateTime(2000,01,23)),
                new Staff("Don","Beckham",200000,Rank.Cap,new DateTime(2000,01,23)),
                new Staff("Azz","Man",2000,Rank.Leutenant,new DateTime(2005,11,23)),
                new Staff("Zan","Dam",100,Rank.Eights,new DateTime(2007,2,3))
            };
        }

        public IEnumerable<Staff> FindMostPayed()
        {
            var amount = staff_list.Max(x => x.Salary);
            var z = staff_list.OrderByDescending(x => x.Salary).TakeWhile(x => x.Salary == amount);

            foreach (var staff in z)
                yield return staff;
        }

        public double FindMidSalary()
        {
            return staff_list.Average(s => s.Salary);
        }

        public double FindMidSalaryForRank(Rank rank)
        {
            return staff_list.Where(s => s.Rank == rank).Average(s => s.Salary);
        }

        public IEnumerable<Staff> FindThreeSmallestSalary()
        {
            var z = staff_list.OrderBy(x => x.Salary).Take(3);

            foreach (var staff in z)
                yield return staff;
        }

    }


    enum Rank
    {
        Boss,
        Cap,
        Leutenant,
        Eights,
    }

    internal class Staff
    {
        private string name;
        private string surname;
        private int salary;
        private Rank rank;
        private DateTime started_since;

        public Staff(string name, string surname, int salary, Rank rank, DateTime started_since)
        {
            this.name = name;
            this.surname = surname;
            this.salary = salary;
            this.rank = rank;
            this.started_since = started_since;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Salary { get => salary; set => salary = value; }
        public DateTime Started_since { get => started_since; set => started_since = value; }
        internal Rank Rank { get => rank; set => rank = value; }

        public override string ToString()
        {
            return Name + " : " + Surname + " : " + Salary;
        }
    }
}