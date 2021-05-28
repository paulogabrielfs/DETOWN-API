using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DETOWN.Application.ViewModels
{
    public class NewsViewModel
    {
        [Key]
        public Guid Id {get; set;}

        [Required(ErrorMessage ="The title is required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string Title {get; set;}

        [Required(ErrorMessage = "The publication Date is required")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage ="Invalid date format")]
        [DisplayName("Publication Date")]
        public DateTime PublicationDate {get; set;}

        [MinLength(2)]
        [DisplayName("Header Text")]
        public string Header {get; set;}

        [Required(ErrorMessage ="The description is required")]
        [MinLength(2)]
        [DisplayName("Description")]
        public string Description {get; set;}
    }
}