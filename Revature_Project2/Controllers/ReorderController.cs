using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Revature_Project2.Controllers
{
    [Authorize]
    public class ReorderController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public ReorderController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

     
        // GET: Reorder
        public async Task<IActionResult> Index()
        {
            // Sample GET Request
            //var usersessionid = _userManager.GetUserId();
            int id = Convert.ToInt32(User.FindFirstValue("customerID"));
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/reorders/" + id);
            // Must include these headers for GET
            request.Headers.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
            request.Headers.Add("accept-encoding", "gzip, deflate");
            //request.Headers.Add("content-type", "application/json");
            request.Headers.Add("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.142 Safari/537.36");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine(response.Content);
                var orders = await response.Content
                    .ReadAsAsync<IEnumerable<Order>>();
                return View(orders);
            }
            else
            {
                //GetBranchesError = true;
                System.Diagnostics.Debug.WriteLine("you didn't order anythin");
                return View();
                //Branches = Array.Empty<Customer>();
            }

        }

        // GET: Reorder/Details/5
        public async Task<ActionResult> Details(int id)
        {
            // Sample GET Request
            //var usersessionid = _userManager.GetUserId();
            //int id = Convert.ToInt32(User.FindFirstValue("customerID"));
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44376/api/reorders/Detail/" + id);
            // Must include these headers for GET
            request.Headers.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
            request.Headers.Add("accept-encoding", "gzip, deflate");
            //request.Headers.Add("content-type", "application/json");
            request.Headers.Add("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.142 Safari/537.36");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
               //System.Diagnostics.Debug.WriteLine(response.Content);
                var item = await response.Content
                    .ReadAsAsync<IEnumerable<Pizza>>();
                return View(item);
            }
            else
            {
                //GetBranchesError = true;
                System.Diagnostics.Debug.WriteLine("you didn't order anythin");
                return View();
                //Branches = Array.Empty<Customer>();
            }
        }
        //not working 
        public async Task<ActionResult> Reorder(Pizza Item)
        {         

                var client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("authorization", "Bearer " + User.FindFirstValue("access_token"));
                string var = JsonConvert.SerializeObject(Item);
                var httpContent = new StringContent(var, Encoding.UTF8, "application/json");
                //string id = User.FindFirstValue("customerID");
                var response2 = await client.PutAsync("https://localhost:44376/api/Orders/", httpContent);


                if (response2.IsSuccessStatusCode)
                {
                    //Branches = await response.Content
                    //    .ReadAsAsync<IEnumerable<Customer>>();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("DAMN");
                    return RedirectToAction(nameof(Index));
                }
        }

        // POST: Reorder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: Reorder/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Reorder/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Reorder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reorder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}