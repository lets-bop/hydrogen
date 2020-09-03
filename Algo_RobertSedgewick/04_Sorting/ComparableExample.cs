public class Employee : IComparable<Employee>
{
    int wage;
    string name;

    public int CompareTo(Employee emp)
    {
        // if wage is same, sort by name
        if (this.wage == emp.wage) return this.name.CompareTo(emp.name);
        return this.wage - emp.wage;
    }
}