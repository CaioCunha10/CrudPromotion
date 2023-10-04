using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudSundayTst.Models;

public class Premium
{
        [Key]
        [DisplayName("Id")]
        public int Id {get; set;}

        [Required(ErrorMessage = "Informe o título do premium")]
        [StringLength(80, ErrorMessage = "O título deve conter até 80 caractéres")]
        [MinLength(5, ErrorMessage = "O título deve conter pelo menos 5 caractéres")]
        [DisplayName("Título")]
        public string Title {get; set;} = string.Empty;
        
        [DataType(DataType.DateTime)]
        [DisplayName("Início")]
        public DateTime StartDate {get; set;}
        
        [DataType(DataType.DateTime)]
        [DisplayName("Término")]
        public DateTime EndDate {get; set;}
        
        [DisplayName("Aluno")]
        [Required(ErrorMessage = "Aluno inválido")]
        public int StudentId { get; set;}
        
        public Student? Student { get; set;}

}


