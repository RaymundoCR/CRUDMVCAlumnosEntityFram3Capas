using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace Negocio
{
    public class NEstatusAlumno
    {
        private static readonly HttpClient _client = new HttpClient();
        private string _UrlapiEA;

        public NEstatusAlumno()
        {
            _UrlapiEA = ConfigurationManager.AppSettings["apiEA"].ToString();
        }
        public List<EstatusAlumnos> Consultar()
        {
            var estatus = new List<EstatusAlumnos>();
            try
            {
                using (var client = new HttpClient())
                {
                    Task<HttpResponseMessage> responseTask = client.GetAsync("http://localhost:12466/api/EstatusAlumnos");

                    responseTask.Wait();
                    HttpResponseMessage result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        //obtenemos el string del objeto json
                        string json = readTask.Result;
                        estatus = JsonConvert.DeserializeObject<List<EstatusAlumnos>>(json);
                    }
                    else
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }
            return estatus;
        }

        public EstatusAlumnos Consultar(int id)
        {
            EstatusAlumnos estatus = null;
            try
            {
                using(var client = new HttpClient())
                {
                    var responseTask = client.GetAsync(_UrlapiEA + $"/{id}");
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string json = readTask.Result;
                        estatus = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else
                    {
                        throw new Exception($"WebApi. Respondio con error.{result.StatusCode}");
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception($"WebApi. Respondio con error.{ex.Message}");
            }
            return estatus;
        }

        public EstatusAlumnos Agregar(EstatusAlumnos estatus)
        {
            try
            {
                using(var client =new HttpClient())
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(estatus), Encoding.UTF8);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var postTask = client.PostAsync(_UrlapiEA, httpContent);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string json = readTask.Result;
                        estatus = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else
                    {
                        throw new Exception($"WebApi Respondio con error.{result.StatusCode}");
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"WebApi Respondio con error.{ex.Message}");
            }
            return estatus;
        }

        public void Actualizar(EstatusAlumnos estatus)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(estatus), Encoding.UTF8);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var postTask = client.PutAsync(_UrlapiEA +$"/{estatus.id}", httpContent);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string json = readTask.Result;
                        estatus = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else
                    {
                        throw new Exception($"WebApi Respondio con error.{result.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"WebApi Respondio con error.{ex.Message}");
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var responseTask = client.DeleteAsync(_UrlapiEA + $"/{id}");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        throw new Exception($"WebApi Respondio con error.{result.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"WebApi Respondio con error.{ex.Message}");
            }
        }
    }
}
