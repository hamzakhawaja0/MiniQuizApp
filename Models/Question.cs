using System.ComponentModel.DataAnnotations; // contains useful attributes like [Required]. Toolbox full of validation tools

namespace  MiniQuizApp.Models // namespace to group related classes together
{
    public class Question{
        public int Id { get; set;}

        [Required] // This attribute specifies that the following property is mandatory.
        public string Text { get; set;} = string.Empty; // creating getter and setter for Id variable, so that Id can be set and read

        [Required]
        public string OptionA { get; set;} = string.Empty;

        [Required]
        public string OptionB { get; set;} = string.Empty;

        [Required]
        public string OptionC { get; set;} = string.Empty;

        [Required]
        public string OptionD { get; set;} = string.Empty;

        [Required]
        public string CorrectAnswer { get; set;} = string.Empty;

    }
}