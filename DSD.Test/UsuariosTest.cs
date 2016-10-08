using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;

namespace UsuariosTest
{
    [TestClass]
    public class UsuariosTest
    {
        [TestMethod]
        public void insertarUsuario()
        {
            string usuario;
            byte[] data;
            HttpWebRequest req;
            StreamReader reader;
            string usuarioJson;
            HttpWebResponse res;
            JavaScriptSerializer js;

            // Prueba de creación de usuario 
            usuario = "{\"Apellidos\":\"ZAMBRANO\",\"Celular\":\"992330838\",\"Direccion\":\"su casa\",\"Dni\":\"10243090\",\"Mail\":\"jurguenzambrano@gmail.com\",\"Nombres\":\"Jurguen\",\"Estado\":\"0\",\"Clave\":\"perico\"}";
            data = Encoding.UTF8.GetBytes(usuario);

            req = (HttpWebRequest)WebRequest.Create("http://sistemas.apphb.com/UsuariosService.svc/usuarios");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                reader = new StreamReader(res.GetResponseStream());
                usuarioJson = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                Usuario usuarioCreado = js.Deserialize<Usuario>(usuarioJson);
                Assert.AreEqual("10243090", usuarioCreado.Dni);
                Assert.AreEqual("ZAMBRANO", usuarioCreado.Apellidos);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Número de DNI ya registrado", mensaje);
            }
        }

        [TestMethod]
        public void insertarUsuarioDuplicado()
        {
            string usuario;
            byte[] data;
            HttpWebRequest req;
            StreamReader reader;
            string usuarioJson;
            HttpWebResponse res;
            JavaScriptSerializer js;

            // Prueba de creación de usuario 
            usuario = "{\"Apellidos\":\"ZAMBRANO\",\"Celular\":\"992330838\",\"Direccion\":\"su casa\",\"Dni\":\"10243091\",\"Mail\":\"jurguenzambrano@gmail.com\",\"Nombres\":\"Jurguen\",\"Estado\":\"0\",\"Clave\":\"perico\"}";
            data = Encoding.UTF8.GetBytes(usuario);

            req = (HttpWebRequest)WebRequest.Create("http://sistemas.apphb.com/UsuariosService.svc/usuarios");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                reader = new StreamReader(res.GetResponseStream());
                usuarioJson = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                Usuario usuarioCreado = js.Deserialize<Usuario>(usuarioJson);
                Assert.AreEqual("10243091", usuarioCreado.Dni);
                Assert.AreEqual("ZAMBRANO", usuarioCreado.Apellidos);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Número de DNI ya registrado", mensaje);
            }
        }
        
        [TestMethod]
        public void loginUsuario()
        {
            string usuario;
            byte[] data;
            HttpWebRequest req;
            StreamReader reader;
            string usuarioJson;
            HttpWebResponse res;
            JavaScriptSerializer js;

            // Prueba de creación de usuario 
            usuario = "{\"Mail\":\"jurguenzambrano@gmail.com\",\"Clave\":\"perico\"}";
            data = Encoding.UTF8.GetBytes(usuario);

            req = (HttpWebRequest)WebRequest.Create("http://sistemas.apphb.com/AccesosService.svc/accesos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                reader = new StreamReader(res.GetResponseStream());
                usuarioJson = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                Usuario usuarioCreado = js.Deserialize<Usuario>(usuarioJson);
                Assert.AreEqual("10243090", usuarioCreado.Dni);
                Assert.AreEqual("ZAMBRANO", usuarioCreado.Apellidos);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Usuario no confirmado", mensaje);
            }
        }

        [TestMethod]
        public void loginUsuarioClaveIncorrecta()
        {
            string usuario;
            byte[] data;
            HttpWebRequest req;
            StreamReader reader;
            string usuarioJson;
            HttpWebResponse res;
            JavaScriptSerializer js;

            // Prueba de creación de usuario 
            usuario = "{\"Mail\":\"jurguenzambrano@gmail.com\",\"Clave\":\"pericod\"}";
            data = Encoding.UTF8.GetBytes(usuario);

            req = (HttpWebRequest)WebRequest.Create("http://sistemas.apphb.com/AccesosService.svc/accesos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                reader = new StreamReader(res.GetResponseStream());
                usuarioJson = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                Usuario usuarioCreado = js.Deserialize<Usuario>(usuarioJson);
                Assert.AreEqual("10243090", usuarioCreado.Dni);
                Assert.AreEqual("ZAMBRANO", usuarioCreado.Apellidos);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Usuario no confirmado", mensaje);
            }
        }

        [TestMethod]
        public void loginUsuarioCorreoIncorrecto()
        {
            string usuario;
            byte[] data;
            HttpWebRequest req;
            StreamReader reader;
            string usuarioJson;
            HttpWebResponse res;
            JavaScriptSerializer js;

            // Prueba de creación de usuario 
            usuario = "{\"Mail\":\"jurguenzambranosss@gmail.com\",\"Clave\":\"perico\"}";
            data = Encoding.UTF8.GetBytes(usuario);

            req = (HttpWebRequest)WebRequest.Create("http://sistemas.apphb.com/AccesosService.svc/accesos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                reader = new StreamReader(res.GetResponseStream());
                usuarioJson = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                Usuario usuarioCreado = js.Deserialize<Usuario>(usuarioJson);
                Assert.AreEqual("10243090", usuarioCreado.Dni);
                Assert.AreEqual("ZAMBRANO", usuarioCreado.Apellidos);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Correo Electrónico no registrado", mensaje);
            }
        }
    }
}
