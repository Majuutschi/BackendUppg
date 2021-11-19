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
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var http = new HttpClient();
            var products = await http.GetFromJsonAsync<List<Product>>("https://be1-webapi.azurewebsites.net/api/products");

            return View(products);
        }



        // GET: ProductsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var http = new HttpClient();
            var product = await http.GetFromJsonAsync<Product>($"https://be1-webapi.azurewebsites.net/api/products/{id}");
            
            return View(product);
        }


        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                var client = new HttpClient();
                await client.PostAsJsonAsync("https://be1-webapi.azurewebsites.net/api/products", product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {

            try
            {
                var client = new HttpClient();
                await client.PutAsJsonAsync($"https://be1-webapi.azurewebsites.net/api/products/{id}", collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

            
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
