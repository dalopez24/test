using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using test.ViewModels;

namespace test.Controllers
{
    public class UsuarioController : Controller
    {
        string connectionstring = "Data Source=DESKTOP;Initial Catalog=ejemploabc;User id=db;Password=daniel123();";



        public ActionResult Index()
        {
            List<UsuarioViewModel> Usuarios = new List<UsuarioViewModel>();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from USUARIOS_Nombre case when Estado = 0 then 'NO' when Estado = 1 then 'SI'", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var name = reader.GetString(1);
                        var pass = reader.GetString(2);
                        var mail = reader.GetString(3);
                        var gen = reader.GetString(4);
                      //   var est = reader.GetBoolean(5); //reader.GetString(1);
                        Usuarios.Add(new UsuarioViewModel() {
                            Nombre = name,
                            Contraseña = pass,
                            Correo = mail,
                            Genero = gen
                      //      Estado = est
                        });
                    }
                }
                using (SqlCommand cmd = new SqlCommand("", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var 
                    }

                }
                

                    con.Close();
            }
            return View(Usuarios);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
                return View();

            List<LoginViewModel> Usuarios = new List<LoginViewModel>(); 

            using (SqlConnection con = new SqlConnection(connectionstring))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from USUARIOS_Nombre ", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        var pass = reader.GetString(1);
                        Usuarios.Add(new LoginViewModel() {usuario = name, contraseña = pass });
                    }
                }
                con.Close();
            }

             var user = Usuarios.FirstOrDefault(m => m.usuario == model.usuario && m.contraseña == model.contraseña);

            if (user == null)
            {
                ModelState.AddModelError("usuario", "User or password incorrect");
                return View();
            }
                


            return Redirect("Index");
        }


        public ActionResult Crear()
        {
            var generos = new List<string>();
            generos.Add("Masculino");
            generos.Add("Femenino");
            ViewBag.generos = generos;

            return View();
        }
        [HttpPost]
        public ActionResult Crear(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into USUARIOS_Nombre values('"+model.Nombre+"','"
                                                + model.Contraseña+"','"+model.Correo+"','"+ model.Genero+"','"+ model.Estado+"' )", con);


                cmd.ExecuteNonQuery();
                con.Close();
            }

            return Redirect("Index");

        }


    }
}