using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1
{
    public class Type
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
    }

    public class Departament
    {
        [Key]
        public int DepartamentId { get; set; }
        public string DepartamentName { get; set; }
    }
    public class Administrator
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public partial class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string fullName { get; set; }
        public string position { get; set; }
        public int? DepartamentId { get; set; }
        [ForeignKey("DepartamentId")]
        public Departament departament { get; set; }
        public int? ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        public Computer computer { get; set; }
    }

    public class PeripheralDevice
    {
        [Key]
        public int PDID { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public int? TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Type type { get; set; }
        public int? DepartamentId { get; set; }
        [ForeignKey("DepartamentId")]
        public Departament departament { get; set; }
        public int? ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer manufacturer { get; set; }
        public int? ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        public Computer computer { get; set; }
    }

    public class Motherboard
    {
        public int? ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer manufacturer { get; set; }
        [Key]
        public int MotherboardId { get; set; }
        public string MotherboardName { get; set; }
    }

    public class CPU
    {
        public int? ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer manufacturer { get; set; }
        [Key]
        public int CpuId { get; set; }
        public string CpuName { get; set; }
        public string rate { get; set; }
    }

    public class HDD
    {
        public int? ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer manufacturer { get; set; }
        public int capacity { get; set; }
        [Key]
        public int HddId { get; set; }
        public string HddName { get; set; }
    }

    public class Computer
    {
        [Key]
        public int ComputerId { get; set; }
        public string status { get; set; }
        public int? MotherboardId { get; set; }
        [ForeignKey("MotherboardId")]
        public Motherboard motherboard { get; set; }
        public int? HddId { get; set; }
        [ForeignKey("HddId")]
        public HDD hdd { get; set; }
        public int? CpuId { get; set; }
        [ForeignKey("CpuId")]
        public CPU cpu { get; set; }
    }
}
