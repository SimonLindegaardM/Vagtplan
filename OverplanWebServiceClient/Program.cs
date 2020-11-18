using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using VagtplanWebService;

namespace OverplanWebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ensure tha this is the same URL as applied under 
            //Properties->Web->Project URL in the web service project 
            const string serverUrl = "http://localhost:57886/";

            //Setup client handler
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                //Initialize client
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //Request JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //Get all the hotels from the database
                    var getMedarbejderResponse = client.GetAsync("api/Medarbejdersplan").Result;

                    //Check response -> throw exception if NOT successful
                    getMedarbejderResponse.EnsureSuccessStatusCode();

                    //Get the hotels as a IEnumerable
                    var medarbejder = getMedarbejderResponse.Content.ReadAsAsync<ICollection<Medarbejdersplan>>().Result;

                    //List hotels on the screen
                    foreach (var index in medarbejder)
                    {
                        Console.WriteLine(medarbejder);
                    }

                    //Prepare the next hotel primary key

                    //Should be 1, if NO hotels exists in the database

                    int nextMedarbejderKey = 1;
                    if (medarbejder.Count<Medarbejdersplan>() > 0)
                    {
                        //There is at least one hotel in the database -> take the next key after max  
                        nextMedarbejderKey = medarbejder.Max<Medarbejdersplan>(medarbejder => medarbejder.MedarbejderID) + 1;
                    }

                    //Create the new hotel object
                    Medarbejdersplan newMedarbejder = new Medarbejdersplan()
                    {
                        MedarbejderID = nextMedarbejderKey,
                        Adresse = "Maglegaardsvej 2, 4000 Roskilde",
                        Navn = "The Academy",
                        Telefon = 56565656
                    };

                    //Post the new hotel to the database
                    var postResponse = client.PostAsJsonAsync<Medarbejdersplan>("api/Medarbejdersplan", newMedarbejder).Result;

                    //Check response -> throw exception if NOT successful
                    postResponse.EnsureSuccessStatusCode();

                    //Fetch the hotel from the database 
                    var getMedarbejdersResponse = client.GetAsync($"api/Medarbejdersplan/{nextMedarbejderKey}").Result;

                    //Check response -> throw exception if NOT successful
                    getMedarbejdersResponse.EnsureSuccessStatusCode();

                    //Update the hotel object
                    Medarbejdersplan medarbejderToBeUpdated = getMedarbejdersResponse.Content.ReadAsAsync<Medarbejdersplan>().Result;
                    medarbejderToBeUpdated.Navn += " Update";

                    //Put the updated hotel object back into the database
                    var putResponse = client.PutAsJsonAsync<Medarbejdersplan>($"api/Medarbejdersplan/{medarbejderToBeUpdated.MedarbejderID}", medarbejderToBeUpdated).Result;

                    //Check response -> throw exception if NOT successful
                    putResponse.EnsureSuccessStatusCode();


                    getMedarbejdersResponse = client.GetAsync($"api/Medarbejdersplan/{medarbejderToBeUpdated.MedarbejderID}").Result;

                    //Check response -> throw exception if NOT successful
                    getMedarbejdersResponse.EnsureSuccessStatusCode();

                    //Delete the hotel object in the database
                    Medarbejdersplan hotelToBeDeleted = getMedarbejdersResponse.Content.ReadAsAsync<Medarbejdersplan>().Result;
                    var deleteResponse = client.DeleteAsync($"api/Medarbejdersplan/{hotelToBeDeleted.MedarbejderID}").Result;

                    //Check response -> throw exception if NOT successful
                    deleteResponse.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}

