using Microsoft.AspNetCore.Mvc; //  Provides tools to build web applications (controllers, views, etc.).
using MiniQuizApp.Models; // Gives us access to our model classes, like Question.
using Microsoft.EntityFrameworkCore; //Needed for async queries
using MiniQuizApp.Data;
using MiniQuizApp.Dtos;

namespace MiniQuizApp.Controllers
{
    // This class handles web requests related to "Questions".
    public class QuestionController : Controller // inherits from Controller, gives it methods to Handle Http actions

    {
        private readonly AppDbContext _context; // Dependency ijection, gives us accesss to the DB

        public QuestionController(AppDbContext context){ // constructor that assigns injected db context
            _context = context;
        }

        //Get: /Question
        public async Task<IActionResult> Index(){
            // fetch all questions from the db (async = non-blocking)
            var questions = await _context.Questions.ToListAsync(); // gets all questions from the database as a list

            // This part goes through each question in the list (using foreach-lie statement) 
            var dtoList = questions.Select(q => new QuestionDto // for each question q, create a QuestionDto, which contains only specfic information
            {
                Id = q.Id,
                Text = q.Text,
                OptionA = q.OptionA,
                OptionB = q.OptionB,
                OptionC = q.OptionC,
                OptionD = q.OptionD,
             }).ToList();

            return View(dtoList);
        }


        // responds to GET requests at the URL /Question/Create
        public IActionResult Create()
        {
            //returns a view with a form that allows users to create a new question
            return View(); //return the view that contains the form for creating a question
        }

        // POST: /Question/Create
        [HttpPost] //responds to POST requests at /Question/Create, called when user submits the form to create a new question
        public async Task<IActionResult> Create(CreateQuestionDto dto){
            if (!ModelState.IsValid){ //check if submitted data matches the rules defined in the Question model
                //if the data is not valid, return the same view with the current data
                //so the user can see error messages and fix their input
                return View(dto);
            }
            //Map DTO -> actual Question model
            var question = new Question{
                Text  =dto.Text,
                OptionA = dto.OptionA,
                OptionB = dto.OptionB,
                OptionC = dto.OptionC,
                OptionD = dto.OptionD,
                CorrectAnswer = dto.CorrectAnswer
            };
            
            

            // Add the question to Db
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

// Cheat Sheet

// Question	- The model (class) representing the DB table
// question	- A specific object created from form input
// AppDbContext -	Your bridge to the database
// _context -	The field in your controller that stores that bridge
// ToListAsync() -	Fetch all records from DB
// Add() -	Add new row
// SaveChangesAsync() -	Commit changes to DB