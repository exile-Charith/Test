using System.ComponentModel.DataAnnotations;
using FoveaExampleRepository.Core;

namespace FoveaExampleRepository.Entities
{
    public class File : IIdentifier
    {
        public string Week { get; set; }
        public int Sequence { get; set; }
        public double Weight { get; set; }
        public Customer Customer { get; set; }

        [Key]
        public int Id { get; set; }
    }
}