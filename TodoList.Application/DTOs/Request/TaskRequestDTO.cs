using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodoList.Application.DTOs.Request;

public class TaskRequestDTO
{

    [Required(ErrorMessage = "The Title is obrigatory")]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required(ErrorMessage = "The Description is obrigatory")]
    [MinLength(30)]
    [MaxLength(280)]
    public string Description { get; set; }

    [Required(ErrorMessage = "")]
    public bool Completed { get; set; }

    [JsonIgnore]
    public DateTime CreatedAt { get; set; }


}
