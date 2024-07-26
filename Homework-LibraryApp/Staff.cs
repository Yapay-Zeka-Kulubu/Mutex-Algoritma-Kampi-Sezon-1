namespace LibraryManagementApp;

public abstract class Staff : Human
{
    //Change here to enumerable
    public List<Weekdays> WorkDays { get; set;} = new();
    public string Shift { get; set; }

    public Staff(List<Weekdays> workDays, string shift, string password, string name, string surname, int age) : base(password, name, surname, age)
    {
        WorkDays.AddRange(workDays);
        Shift = shift;
    }
}