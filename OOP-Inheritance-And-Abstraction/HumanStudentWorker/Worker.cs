namespace HumanStudentWorker
{
    class Worker : Human
    {
        public Worker(string firstName, string lastName, decimal weekSalary, uint workHoursPerDay) : base (firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary { get; private set; }
        public uint WorkHoursPerDay { get; private set; }

        public decimal MoneyPerHour()
        {
            decimal moneyPerDay = this.WeekSalary / 7;
            decimal moneyPerHour = moneyPerDay / this.WorkHoursPerDay;
            return moneyPerHour;
        }
    }
}
