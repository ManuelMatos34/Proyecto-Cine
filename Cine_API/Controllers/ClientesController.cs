using Microsoft.AspNetCore.Mvc;
using Cine_API.Models;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net.Mime;

namespace Cine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly CineContext _context;

        public ClientesController(CineContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(string user, string pass) // iniciar sesion
        {
            var passEncrypt = GetSHA256(pass);
            var userExist = _context.Clientes.Where(x => x.Usuario == user && x.Password == passEncrypt).FirstOrDefault();

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status200OK, userExist);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "El usuario no existe");

            }
        }

        [HttpPost]
        [Route("PostUser")]
        public async Task<IActionResult> PostUser(Cliente cliente) // registrar usuario
        {
            if (cliente == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Regístrese por favor o ingrese los datos correctamente");
            }

            var existingUser = _context.Clientes.FirstOrDefault(x => x.Usuario == cliente.Usuario);

            if (existingUser != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "El usuario ya existe");
            }

            cliente.Status = "A";
            cliente.Rol = "cliente";
            var passEncrypt = GetSHA256(cliente.Password);
            cliente.Password = passEncrypt;
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Registrado correctamente");
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        [HttpGet]
        [Route("GetUser2")]
        public IActionResult GetUser2(string user, string pass) // enviar correo
        {
            Cliente para = _context.Clientes.Where(x => x.Usuario == user).FirstOrDefault();
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(para.CorreoElectronico, ""));
            mail.From = new MailAddress("josembp18@hotmail.com");
            mail.Subject = "Confirmacion de pago";

            string html2 = "<!DOCTYPE html> <html> <head> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"> </head> <body " +
                "style=\"margin: 0; font-family: Arial, Helvetica, sans-serif;\"> <div style=\"overflow: hidden; background-color: #f1f1f1; padding: " +
                "20px 10px;\" class=\"header\"> <a class=\"logo\">CompanyLogo</a> <div class=\"header-right\"> <a class=\"active\">Home</a> <a>Contact</a> " +
                "<a>About</a> </div> </div> <div style=\"padding-left:20px\"> <h1>Plantilla para Correos</h1> <p>" + pass + "</p> " +
                "<p>Cualquier cosa......</p> </div> </body> <footer style=\"text-align: center; padding: 3px; background-color: #f1f1f1; color: white;\"> " +
                "<p style=\"color:blue\">Author: Hege Refsnes<br> <p style=\"color:blue\">hege@example.com</p> </p> </footer> </html>";

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(html2, Encoding.UTF8, MediaTypeNames.Text.Html);
            mail.AlternateViews.Add(alternateView);
            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("josembp18@hotmail.com", "unphu2020");
            smtp.Send(mail);

            return StatusCode(StatusCodes.Status200OK, "Pago correcto revise su correo");

        }
    }
}
