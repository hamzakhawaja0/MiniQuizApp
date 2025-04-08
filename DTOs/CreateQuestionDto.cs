using System.ComponentModel.DataAnnotations;

namespace MiniQuizApp.Dtos{
    public class CreateQuestionDto{
        [Required]
        public string Text{get; set;}

        [Required]
        public string OptionA{get; set;}

        [Required]
        public string OptionB{get; set;}

        [Required]
        public string OptionC{get; set;}

        [Required]
        public string OptionD{get; set;}

        [Required]
        public string CorrectAnswer{get; set;}
    }
}
