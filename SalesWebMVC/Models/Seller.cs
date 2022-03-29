using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Seller : Identity
    {
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]  
        public DateTime BirthDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Base Salary")]
        public double BaseSalary { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public Seller()
        {
        }

        public Seller(int id,string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = Id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }
        public void AddSales(SalesRecord sale)
        {
            Sales.Add(sale);
        }
        public void RemoveSales(SalesRecord sale)
        {
            Sales.Remove(sale);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
        

    }
}
