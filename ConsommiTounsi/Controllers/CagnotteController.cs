using ConsommiTounsi.Models.Evenement;
using ConsommiTounsi.Models.User;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class CagnotteController : Controller
    {
        // GET: Cagnotte
        public ActionResult CagnotteList()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("Cagnottes").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Cagnotte>>().Result);
        }

     
        public ActionResult CagnotteListAdmin()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("Cagnottes").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Cagnotte>>().Result);
        }

        
    
        public ActionResult Bet(long cagnotteId)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            User user = (User)Session["user"];
            if (user == null) {
                return RedirectToAction("Login", "User");

            }
            else
            {
                long userId = user.id;
                string url = "bet/" + userId + "/" + cagnotteId;
                HttpResponseMessage response = httpClient.PostAsJsonAsync<Ticket>(url, new Ticket()).Result;
                response.EnsureSuccessStatusCode();
                return RedirectToAction("CagnotteList", "Cagnotte");
            }    
        }
       

        public ActionResult AddCagnotte()
        {
            HttpClient httpClient = HttpClientBuilder.Get();
       
            HttpResponseMessage response = httpClient.PostAsJsonAsync<Cagnotte>("AddCagnotte", new Cagnotte()).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("CagnotteListAdmin", "Cagnotte");
        }

       
        public ActionResult Tickets()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "User");

            }
            long userId = user.id;
            string url = "Tickets/" + userId;
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Ticket>>().Result);
        }

        public ActionResult WinTickets()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            User user = (User)Session["user"];
            HttpResponseMessage response = httpClient.GetAsync("Tickets").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Ticket>>().Result);
        }


     
        public ActionResult Winner(int cagnotteId)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            User user = (User)Session["user"];
           
                
                string url = "winner/" + cagnotteId;
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
               return RedirectToAction("CagnotteListAdmin", "Cagnotte");
            
        }

      
  
        public ActionResult DeleteTicket(int id)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "deleteTicket/" + id;
            HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Tickets", "Cagnotte");
        }
    }
}
