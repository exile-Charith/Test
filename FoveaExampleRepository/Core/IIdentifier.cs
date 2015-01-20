using System.ComponentModel.DataAnnotations;

namespace FoveaExampleRepository.Core
{
    public interface IIdentifier
    {
        [Key]
        int Id { get; set; }
    }
}