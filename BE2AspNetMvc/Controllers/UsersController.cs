using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BE2AspNetMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE2AspNetMvc.Controllers
{
    public class UsersController : Controller
    {
        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var http = new HttpClient();
            var users = await http.GetFromJsonAsync<List<User>>("https://be1-webapi.azurewebsites.net/api/users");

            return View(users);
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var http = new HttpClient();
            var user = await http.GetFromJsonAsync<User>($"https://be1-webapi.azurewebsites.net/api/users/{id}");

            return View(user);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                var client = new HttpClient();
                await client.PostAsJsonAsync("https://be1-webapi.azurewebsites.net/api/users", user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {

            try
            {
                var client = new HttpClient();
                await client.PutAsJsonAsync($"https://be1-webapi.azurewebsites.net/api/users/{id}", collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }


        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var client = new HttpClient();
                await client.DeleteAsync($"https://be1-webapi.azurewebsites.net/api/users/{id}");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
