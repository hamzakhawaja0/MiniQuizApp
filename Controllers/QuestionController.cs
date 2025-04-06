using Microsoft.AspNetCore.Mvc; //  Provides tools to build web applications (controllers, views, etc.).
using MiniQuizApp.Models; // Gives us access to our model classes, like Question.

namespace MiniQuizApp.Controllers
{
    // This class handles web requests related to "Questions".
    public class QuestionController : Controller // inherits from Controller, gives it methods to Handle Http actions

    {
        // static means this list is shared among all instances of controller
        private static List<Question> _questions = new(); //in-memory database to store questions

        public IActionResult Index() // method responds to Get requests at the URL /Question
        {
            // returns a view (a web page) that displays the list of questions
            return View(_questions); // pass the list of questions to the view so they can be displayed
        }

        // responds to GET requests at the URL /Question/Create
        public IActionResult Create()
        {
            //returns a view with a form that allows users to create a new question
            return View(); //return the view that contains the form for creating a question
        }

        [HttpPost] //responds to POST requests at /Question/Create, called when user submits the form to create a new question
        public IActionResult Create(Question question)
        {
            if (!ModelState.IsValid) //check if submitted data matches the rules defined in the Question model
            {
                //if the data is not valid, return the same view with the current data
                //so the user can see error messages and fix their input
                return View(question);
            }

            // Set a unique ID for the new question
            question.Id = _questions.Count + 1; // ID assigned based on current number of questions plus one

            _questions.Add(question); //add the new question to the in-memory 'database'

            return RedirectToAction("Index"); // after adding the question, redirect the user to the Index action (the list of questions)
        }


    }
}