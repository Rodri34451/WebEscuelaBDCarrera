using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDeNegocio;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["accion"] == null) return;
        switch (Request["accion"])
        {

            case "ADDUSUARIO": AddUsuario(); break;
            case "LISTUSUARIOS": ListUsuarios(); break;
            case "DELETEUSER": DeleteUser(); break;
            case "MODIFYUSER": ModifyUser(); break;
            case "FINDUSUARIO": FindUser(); break;

            case "ADDCARRERA": AddCarrera(); break;
            case "LISTCARRERAS": ListCarreras(); break;
            case "DELETECARRERA": DeleteCarrera(); break;
            case "MODIFYCARRERA": ModifyCarrera(); break;
            case "FINDCARRERA": FindCarrera(); break;
            default:
                Response.Write("Invalid action");
                break;
        }
    }

    private void AddUsuario()
    {
        Usuario U = new Usuario();
        U.Nombre = Request["Nombre"];
        U.Mail = Request["Mail"];
        U.Dni = int.Parse(Request["Dni"]);
        try
        {
            U.Add();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }

    }
    private void ListUsuarios()
    {
        Usuario U = new Usuario();
        string lista = U.List();
        Response.Write(lista);

    }

    private void DeleteUser()
    {
        Usuario U = new Usuario();
        U.ID = int.Parse(Request["ID"]);

        try
        {
            U.Erase();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void ModifyUser()
    {
        Usuario U = new Usuario();

        U.ID = int.Parse(Request["ID"]);
        U.Nombre = Request["Nombre"];
        U.Dni = int.Parse(Request["Dni"]);
        U.Mail = Request["Mail"];
        try
        {
            U.Modify();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }

    }

    private void FindUser()
    {
        Usuario U = new Usuario();
        U.ID = int.Parse(Request["ID"]);

        try
        {
            string user = U.Find();
            Response.Write(user);
        }
        catch (Exception er)
        { 
            Response.Write(er.Message); 
        }
    }


    private void AddCarrera()
    {
        Carrera C = new Carrera();
        C.nombre = Request["Nombre"];
        C.sigla = Request["Sigla"];
        C.titulo = Request["Titulo"];
        C.duracion = int.Parse(Request["Duracion"]);
        try
        {
            C.Add();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }

    }

    private void ListCarreras()
    {
        Carrera C = new Carrera();
        string lista = C.List();
        Response.Write(lista);

    }

    private void DeleteCarrera()
    {
        Carrera C = new Carrera();
        C.ID = int.Parse(Request["ID"]);

        try
        {
            C.Erase();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void ModifyCarrera()
    {
        Carrera C = new Carrera();

        C.ID = int.Parse(Request["ID"]);
        C.nombre = Request["Nombre"];
        C.sigla = Request["Sigla"];
        C.titulo = Request["Titulo"];
        C.duracion = int.Parse(Request["Duracion"]);
        try
        {
            C.Modify();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }
    private void FindCarrera()
    {
        Carrera C = new Carrera();
        C.ID = int.Parse(Request["ID"]);

        try
        {
            string carrera = C.Find();
            Response.Write(carrera);
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }
} 

