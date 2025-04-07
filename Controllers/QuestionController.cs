using Microsoft.AspNetCore.Mvc; //  Provides tools to build web applications (controllers, views, etc.).
using MiniQuizApp.Models; // Gives us access to our model classes, like Question.
using Microsoft.EntityFrameworkCore; //Needed for async queries
using MiniQuizApp.Data;

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
            var questions = await _context.Questions.ToListAsync();
            return View(questions);
        }


        // responds to GET requests at the URL /Question/Create
        public IActionResult Create()
        {
            //returns a view with a form that allows users to create a new question
            return View(); //return the view that contains the form for creating a question
        }

        // POST: /Question/Create
        [HttpPost] //responds to POST requests at /Question/Create, called when user submits the form to create a new question
        public async Task<IActionResult> Create(Question question){
            if (!ModelState.IsValid){ //check if submitted data matches the rules defined in the Question model
                //if the data is not valid, return the same view with the current data
                //so the user can see error messages and fix their input
                return View(question);
            }

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