
namespace MiniQuizApp.Dtos
{
    //This is the public version of question - contains things only we want to expose
    public class QuestionDto{
        public int Id {get; set;}
        public string Text{get; set;}

        public string OptionA {get; set;}
        public string OptionB {get; set;}
        public string OptionC {get; set;}
        public string OptionD {get; set;}

        //Notice, different to the Question Model, theres no correct answer, we dont want students to see that
    }
}