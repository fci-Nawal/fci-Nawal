using System;
namespace nawal;
public  class Person{
    
    private string _name;
    private int _age;
    
    public Person(string name, int age ){
        if(name==null  name==""  name.Length>=32)
        {
            throw new Exception("Invalid name");
        }
        if(age<=0 || age>128)
        {
            throw new Exception("Invalid age");
        }
        this.name=name;
        this.age=age;
    }
    public string GetName() => _name;
    public int GetAge()=>_age;
    public void SetName(string name){
        if(name==null||  name=="" || name.Length>=32)
        {
            throw new Exception("Invalid name");
        }
        this.name=name;
    }
    public void SetAge(int age){
        if(age<=0||age>128)
        {
            throw new Exception("Invalid age");
        }
        this.age=age;
    }
    public virtual void Print(){
        Console.WriteLine($"My name is {GetName()}, my age is {GetAge()}");
    }
}

public class Student :Person{
    private int _year;
    private float _gpa;
    
    public Student (string name,int age,int year,float gpa ):base(name,age){
        if(year<1||year>5){
            throw new Exception("Invalid year");
        }
        if(gpa<0||gpa>4){
            throw new Exception("Invalid gpa");
        }
        _year=year;
        _gpa=gpa;
    }
    public int GetYear() => _year;
    public float GetGpa()=>_gpa;
    public void SetYear(int year){
        if(year<1||year>5){
            throw new Exception("Invalid year");
        }
        _year=year;
    }
    public void SetGpa(float gpa){
        if(gpa<0||gpa>4){
            throw new Exception("Invalid gpa");
        }
        _gpa=gpa;
    }
    public override void Print(){
        Console.WriteLine($"My name is {GetName()}, my age is {GetAge()}, and gpa is {GetGpa()}");
    }
}
public class Databass{
	public person[] pepole = new person[50];
	private int currentIndex=0;
	public void AddStudent(Student std){
		people[currentIndex++]=std;
	}
		public void AddStaff(Staff staff){
			people[currentIndex++]=staff;
		}
		public void AddPerson(Person person){
			people[currentIndex++]=person;
		}
		public void PrintAll(){
			for(int i=0;i<=currentIndex;i++){
				People[i].Print();
			}

		}
}
public class Staff:Person{
	public double Salary;
	public int JoinYear;
	public Staff(string name,int age,double salary,int joinyear):base(name,age){
        if(salary<0 || salary>120000){
            throw new Exception("Invalid salary");
        }
        int diff=joinyear-age;
        if(diff<21){
            throw new Exception("Invalid join year");
        }
    _salary=salary;
    _joinYear=joinyear;
    }
    public double GetSalary() => _salary;
    public int GetJoinYear()=>_joinYear;
    public void SetSalary(double salary){
        if(salary<0 || salary>120000){
            throw new Exception("Invalid salary");
        }
        _salary=salary;
    }
    public void SetJoinYear(int joinyear){
        int diff=GetJoinYear()-GetAge();
        if(diff<21){
            throw new Exception("Invalid join year");
        }
        _joinYear=joinyear;
    }
    public override void Print(){
            Console.WriteLine($"My name is {GetName()}, my age is {GetAge()}, and my salary is {GetSalary()}");
        }

	
}
public class Program{
private static void main(){
	Console.WriteLine("enter a number 1)student 2)staff 3)print all peaple 4)person \"not a student and not a staff\"");
    int x=1;
    var database=new Database();
    while (x!=0)
    {
        Console.Write("Option: ");
        x=Convert.ToInt32(Console.ReadLine());
        switch (x)
    {
        case 1:
        Console.Write("Name: ");
        var name=Console.ReadLine();
        Console.Write("Age: ");
        var age =Convert.ToInt32(Console.ReadLine());
        Console.Write("Year: ");
        var year =Convert.ToInt32(Console.ReadLine());
        Console.Write("Gpa: ");
        var gpa = Convert.ToSingle(Console.ReadLine());
        try
        {
            var student =new Student(name,age,year,gpa);
            database.AddStudent(student);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        break;
                
        case 2:
        Console.Write("Name: ");
        name=Console.ReadLine();
        Console.Write("Age: ");
        age =Convert.ToInt32(Console.ReadLine());
        Console.Write("Salary: ");
        var salary = Convert.ToDouble(Console.ReadLine());
        Console.Write("JoinYear: ");
        var joinyear = Convert.ToInt32(Console.ReadLine());
        try
        {
            var staff =new Staff(name,age,salary,joinyear);
            database.AddStaff(staff);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        break;
                
        case 3:
            database.PrintAll();
        break;
                
        case 4:
        Console.Write("Name: ");
        name=Console.ReadLine();
        Console.Write("Age: ");
        age =Convert.ToInt32(Console.ReadLine());
        try
        {
            var person=new Person(name,age);
            database.AddPerson(person);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        break;
                
        default:
        return;
    }
    }

}
}