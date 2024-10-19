using BindingWithApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BindingWithApi.Controllers
{
    public class EStudentController : Controller
    {
        private string url = "https://localhost:7259/api/Estudents/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<EStudent> students = new List<EStudent>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data =JsonConvert.DeserializeObject<List<EStudent>>(result);
                if(data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EStudent std)
        {
            string data =JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["insertmessage"] = "Data inserted..";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            EStudent std = new EStudent();
            HttpResponseMessage response = client.GetAsync(url +id).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<EStudent>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(EStudent std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url+std.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["updatemessage"] = "Data updated..";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            EStudent std = new EStudent();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<EStudent>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            EStudent std = new EStudent();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<EStudent>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["deletemessage"] = "Data deleted..";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
