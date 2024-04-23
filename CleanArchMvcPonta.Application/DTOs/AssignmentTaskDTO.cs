using CleanArchMvcPonta.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleanArchMvcPonta.Application.DTOs
{
    public class AssignmentTaskDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description is Required")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Description { get; set; }

        public Status Status { get; set; }

        [JsonIgnore]
        public string? CreatedBy { get; set; }

    }
}
