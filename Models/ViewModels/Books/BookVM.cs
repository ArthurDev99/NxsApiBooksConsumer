using APIConsumer.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIConsumer.Models.ViewModels.Books
{
    public class BookVM
    {
        [StringLength(80, ErrorMessage = "El título debe contener desde {2} hasta {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Título")]
        [Required(ErrorMessage = "El título es requerido.")]
        public string Title { get; set; }

        [RangeValidatorYear(1000, ErrorMessage = "El año de publicación debe estar entre {1} y {2}.")]
        [Required(ErrorMessage = "El año de publicación del libro es requerido.")]
        [DisplayName("Año de publicación")]
        public decimal PublicationYear { get; set; }

        [StringLength(30, ErrorMessage = "El género debe contener desde {2} hasta {1} caracteres.", MinimumLength = 3)]
        [Required(ErrorMessage = "El género del libro es requerido.")]
        [DisplayName("Género")]
        public string Gender { get; set; }

        [Range(1, 1000, ErrorMessage = "El número de páginas debe estar entre {1} y {2}.")]
        [Required(ErrorMessage = "El número de páginas es requerido.")]
        [DisplayName("Número de páginas")]
        public decimal NumberPages { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El campo author_id debe ser mayor a 0.")]
        [Required(ErrorMessage = "El autor del libro es requerido")]
        public decimal AuthorId { get; set; }
    }
}