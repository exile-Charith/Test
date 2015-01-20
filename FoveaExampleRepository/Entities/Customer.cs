using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoveaExampleRepository.Core;

namespace FoveaExampleRepository.Entities
{
    public class Customer : IIdentifier
    {
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public ICollection<File> Files { get; set; }

        [Key]
        public int Id { get; set; }
    }
}