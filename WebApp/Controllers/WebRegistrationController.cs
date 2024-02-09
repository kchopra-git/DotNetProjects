using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class WebRegistrationController : Controller
    {
        private readonly RestClient _client;
        private readonly string _baseUrl = "http://localhost:7001/api/";
        //private IActionResult HandleError(string errorMessage)
        //{
        //    ViewBag.ErrorMessage = errorMessage;
        //    return View("Error");
        //}
        public WebRegistrationController()
        {
            _client = new RestClient(_baseUrl);
        }
        public ActionResult AddUser()
        {
            return View();
        }
     
        [HttpGet]
        public IActionResult Index()
        {
            string baseUrl = null;

            // Your desired API endpoint path
            string apiEndpointPath = "https://localhost:7001/api/Registration";

            // Create a RestClient with the base URL
            var client = new RestClient(baseUrl + apiEndpointPath);

            // Create a RestRequest and set the resource (API endpoint path)
            var request = new RestRequest(apiEndpointPath, Method.GET);

            // Execute the request
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error: {response.ErrorMessage}, Content: {response.Content}");

                // Handle the error, log, and possibly return an error view
                return View("ErrorView");
            }

            var registrationsJson = response.Content;
            var registrations = JsonConvert.DeserializeObject<IEnumerable<Registration>>(registrationsJson);

            return View(registrations);
        }

        [HttpPost]
        public IActionResult AddUser(Registration registration)
        {
            // Full URL of the API endpoint
            string apiUrl = "https://localhost:7001/api/Registration";

            // Create a RestClient with the API endpoint URL
            var client = new RestClient(apiUrl);

            // Create a RestRequest and set the HTTP method to POST
            var request = new RestRequest(Method.POST);

            // Set the request content type (assuming it's JSON)
            request.AddHeader("Content-Type", "application/json");

            // Convert the Registration object to JSON and set it as the request body
            request.AddJsonBody(registration);

            // Execute the request
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error: {response.ErrorMessage}, Content: {response.Content}");

                // Handle the error, log, and possibly return an error view
                return View("ErrorView");
            }

            // Assuming the API returns a single Registration object for a POST request
            var registrationJson = response.Content;
            var registeredUser = JsonConvert.DeserializeObject<Registration>(registrationJson);

            return RedirectToAction("Index"); // Assuming you have an Index2.cshtml view
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            string baseUrl = null;

            // Your desired API endpoint path
            string apiEndpointPath = $"https://localhost:7001/api/Registration/{id}";


            // Create a RestClient with the base URL
            var client = new RestClient(baseUrl + apiEndpointPath);

            // Create a RestRequest and set the resource (API endpoint path)
            var request = new RestRequest(apiEndpointPath, Method.GET);

            // Execute the request
            var response = client.Execute(request);


            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error: {response.ErrorMessage}, Content: {response.Content}");
                return View("ErrorView");
            }

            var registrationJson = response.Content;
            var registration = JsonConvert.DeserializeObject<Registration>(registrationJson);

            return View(registration);
        }

     
        [HttpGet]
        public IActionResult Edit(int id)
        {
            string baseUrl = null;

            // Your desired API endpoint path
            string apiEndpointPath = $"https://localhost:7001/api/Registration/{id}";

            // Create a RestClient with the base URL
            var client = new RestClient(baseUrl + apiEndpointPath);

            // Create a RestRequest and set the resource (API endpoint path)
            var request = new RestRequest(apiEndpointPath, Method.GET);

            // Execute the request
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error: {response.ErrorMessage}, Content: {response.Content}");
                return View("ErrorView");
            }

            var registrationJson = response.Content;
            var registration = JsonConvert.DeserializeObject<Registration>(registrationJson);

            return View(registration);
        }

        [HttpPost]
        public IActionResult Edit(int id, Registration registration)
        {
            string apiUrl = $"https://localhost:7001/api/Registration/{id}";
            var client = new RestClient(apiUrl);
            var request = new RestRequest(apiUrl, Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(registration);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error: {response.ErrorMessage}, Content: {response.Content}");
                return View("ErrorView");
            }


            return RedirectToAction("Index"); // Redirect to Index action
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            string baseUrl = null;

            // Your desired API endpoint path
            string apiEndpointPath = $"https://localhost:7001/api/Registration/{id}";

            // Create a RestClient with the base URL
            var client = new RestClient(baseUrl + apiEndpointPath);

            // Create a RestRequest and set the resource (API endpoint path)
            var request = new RestRequest(apiEndpointPath, Method.GET);

            // Execute the request
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error: {response.ErrorMessage}, Content: {response.Content}");
                return View("ErrorView");
            }

            var registrationJson = response.Content;
            var registration = JsonConvert.DeserializeObject<Registration>(registrationJson);

            return View(registration);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            string apiUrl = $"https://localhost:7001/api/Registration/{id}";
            var client = new RestClient(apiUrl);
            var request = new RestRequest(apiUrl, Method.DELETE);
      
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error: {response.ErrorMessage}, Content: {response.Content}");
                return View("ErrorView");
            }


            return RedirectToAction("Index"); // Redirect to Index action
        }

    }
}
