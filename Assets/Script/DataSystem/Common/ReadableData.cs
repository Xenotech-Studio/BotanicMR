using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DataSystem
{
    public abstract partial class ReadableData
    {
        [JsonIgnore] public abstract string Path { get; }

        public virtual T DeSerialization<T>() where T : new()
        {
            if (string.IsNullOrEmpty(Path) || !File.Exists(Path)) return new T();

            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(Path), settings);
        }

        public virtual bool Validation<T>(out T value) where T : new()
        {
            value = new T();
            try
            {
                // Ability of reading
                value = DeSerialization<T>();
                
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }
        }
    }

    public partial class ReadableData
    {
        public static T DeSerialization<T>(string _path) where T : new()
        {
            if (string.IsNullOrEmpty(_path) || !File.Exists(_path)) return new T();

            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(_path), settings);
        }

        public static bool Validation<T>(string _path, out T value) where T : new()
        {
            value = new T();
            try
            {
                // Ability of reading
                value = DeSerialization<T>(_path);
                
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }
        }
    }

    public interface IReadableData
    {
        public abstract ReadableData DeSerialization();

        public abstract T DeSerialization<T>() where T : new();

        public abstract bool Validation<T>(out T value) where T : new();
    }
}