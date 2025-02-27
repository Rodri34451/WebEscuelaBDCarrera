using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    internal partial class Datos2 : IParentSingleton<Carrera>
    {
        private static List<Carrera> listaCarreras;
        private static int lastId;
        private static void Read()
        {
            try
            {

                string path = "C:\\Users\\Rodrigo\\Desktop\\FinalAlgoritmos2ConCarrera\\WebEscuelaBD-main\\CapaDeNegocio\\Datos\\carreras.json";
                string json = File.ReadAllText(path);
                listaCarreras = JsonSerializer.Deserialize<List<Carrera>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Write()
        {

            try
            {
                string path = "C:\\Users\\Rodrigo\\Desktop\\FinalAlgoritmos2ConCarrera\\WebEscuelaBD-main\\CapaDeNegocio\\Datos\\carreras.json";
                string json = JsonSerializer.Serialize(listaCarreras);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Clear()
        {
            listaCarreras.Clear();
        }
        public void Add(Carrera data)
        {
            Read();
            string pathID = @"C:\Users\Rodrigo\Desktop\FinalAlgoritmos2ConCarrera\WebEscuelaBD-main\CapaDeNegocio\Datos\carreraLastId.txt";
            lastId = int.Parse(File.ReadAllText(pathID));
            data.ID = ++lastId;
            File.WriteAllText(pathID, lastId.ToString()); // guarda el ultimo ID en el archivo de texto
            listaCarreras.Add(data);
            Write();
            Clear();




        }

        public void Erase(Carrera data)
        {
            Read();
            foreach (Carrera c in listaCarreras)
            {
                if (data.ID == c.ID)
                {
                    listaCarreras.Remove(data);
                    Write();
                    Clear();
                    return;


                }

            }
            Clear();
            throw new Exception("No se encontró el usuario a elimnar");



        }

        public Carrera Find(Carrera data)
        {
            Read();
            foreach (Carrera c in listaCarreras)
            {
                if (data.ID == c.ID)
                {
                    Clear();
                    return c;

                }

            }
            Clear();
            throw new Exception("No se encontró el usuario");
        }

        public void Modify(Carrera data)
        {
            Read();
            for (int i = 0; i < listaCarreras.Count; i++)
            {
                if (listaCarreras[i].ID == data.ID)
                {
                    listaCarreras[i].nombre = data.nombre;
                    Write();
                    Clear();
                    return;

                }
            }
            throw new Exception("No se puede modificar el Usuario: no se encuentra en la lista");


        }

        public string List()
        {
            Read();
            string json = JsonSerializer.Serialize(listaCarreras);
            return json;
        }
    }
}
