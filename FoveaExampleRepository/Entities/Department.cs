using System.ComponentModel.DataAnnotations;
using FoveaExampleRepository.Core;

namespace FoveaExampleRepository.Entities
{
    public class Department : IIdentifier
    {
        public string Name { get; set; }
        public int MyProperty { get; set; }

        [Key]
        public int Id { get; set; }
    }
}