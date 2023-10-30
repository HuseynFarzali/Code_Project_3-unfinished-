namespace Code_Project_3._2.Models.Domain_Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Department() : this(default) { }

        public Department(string name)
        {
            Name = name;
        }
    }
}
