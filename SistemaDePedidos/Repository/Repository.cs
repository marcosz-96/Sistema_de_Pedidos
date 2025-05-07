using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaDePedidos.Repository
{
    public static class Repository<T> where T : class, new()
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions {WriteIndented = true};

        public static void Agregar(string archivo, T entidad)
        {
            // CARGA LISTA EXISTENTE O UNA VACÍA SI NO HAY
            var datos = Cargar(archivo);
            // AGREGA LA NUEVA ENTIDAD A LA CALECCIÓN
            datos.Add(entidad);
            // GUARDA LA COLECCIÓN ACTUALIZADA EN EL ARCHIVO
            Guardar(archivo, datos);
        }

        // Método que trae los archivos almacenados en JSON
        public static List<T> ObtenerTodos(string archivo)
        {
            return Cargar(archivo);
        }

        // Método para eliminar elemento según condición dada
        public static void Eliminar(string archivo, Predicate<T> predicado)
        {
            // CARGA LISTA DE ARCHIVOS ACTUALES
            var datos = Cargar(archivo);
            // ELIMINA DATOS SEGÚN EL PREDICADO
            datos.RemoveAll(predicado);
            // GUARDA LA LISTA ACTUALIZADA
            Guardar(archivo, datos);

        }

        // Método para actualizar un elemento según condición dada
        public static void Actualizar(string archivo, Predicate<T> predicado, T nuevaEntidad)
        {
            // TRAEMOS LA LISTA ACTUAL
            var datos = Cargar(archivo);
            // BUSCAMOS EL PRIMER ELEMENTO QUE CUMPLA CON LA CONDICIÓN DEL PREDICADO
            int index = datos.FindIndex(predicado);
            // SI LO ENCUENTRA, REEMPLAZA EL ELEMENTO POR LA NUEVA ENTIDAD
            if (index != -1)
            {
                datos[index] = nuevaEntidad;
                // GUARDA LOS DATOS ACTUALIZADOS
                Guardar(archivo, datos);
            }
        }

        //Método que serializa y guarda los elementos en un archivo JSON
        private static void Guardar(string archivo, List<T> datos)
        {
            try
            {
                // SERIALIZA OBJETOS A FORMATO JSON
                string json = JsonSerializer.Serialize(datos, options);
                // GUARDA EL CONTENIDO EN EL ARCHIVO, SOBREESCRIBIÉNDOLO SI YA EXISTE
                File.WriteAllText($"{archivo}.json", json);
            }
            catch(IOException ex)
            {
                // EN CASO DE ERROR DE E/S LO INFORMA
                Console.Error.WriteLine($"[ERROR] Error no se pudo guardar el archivo {archivo}.json: {ex.Message}");
            }
        }

        
        // Método que carga la lista desde un archivo JSON
        private static List<T> Cargar(string archivo)
        {
            try
            {
                // DEFINE RUTA DEL ARCHIVO
                string path = $"{ archivo}.json";
                // SI NO EXISTE DEVUELVE LISTA VACÍA
                if (!File.Exists(path)) return new List<T>();
                // SI EXISTE LO LEE COMPLETO
                string json = File.ReadAllText(path);
                // DESERIALZA JSON A UNA LISTA DE OBJETOS
                return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
            }
            catch (IOException ex)
            {
                // EN CASO DE FALLA LO REPORTA Y DEVUELVE UNA LISTA VACÍA
                Console.WriteLine($"[ERROR] Error al cargar archivo {archivo}.json: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
