using System;
using System.Net;
using System.Threading.Tasks;

namespace GestionBudget.Components.Services
{
    public class CallbackListener
    {
        private readonly HttpListener _listener = new HttpListener();

        public CallbackListener(string prefix)
        {
            _listener.Prefixes.Add(prefix);
        }

        public async Task StartListening()
        {
            _listener.Start();
            Console.WriteLine("Écoute des connexions...");

            while (true)
            {
                try
                {
                    // Attendre la connexion entrante
                    HttpListenerContext context = await _listener.GetContextAsync();

                    // Extraire la requête
                    HttpListenerRequest request = context.Request;

                    // Obtenir les paramètres de requête
                    var query = request.QueryString;

                    // Traiter les paramètres ici
                    foreach (string key in query.AllKeys)
                    {
                        Console.WriteLine($"{key}: {query[key]}");
                    }

                    // Répondre au client
                    HttpListenerResponse response = context.Response;
                    string responseString = "Paramètres reçus!</body></html>";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);

                    // Fermer la réponse
                    output.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur: {ex.Message}");
                }
            }
        }
    }

}
