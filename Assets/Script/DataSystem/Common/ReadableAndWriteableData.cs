using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DataSystem
{
    public abstract partial class ReadableAndWriteableData : IReadableData , IWriteableData
    {
        [JsonIgnore] public abstract string Path { get; }

        public void Serialization()
        {
            if (File.Exists(Path)) File.Delete(Path);
            File.Create(Path).Dispose();

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            File.WriteAllText(Path, JsonConvert.SerializeObject(this, Formatting.Indented, settings));
        }
        
        public virtual ReadableData DeSerialization()
        {
            if (string.IsNullOrEmpty(Path) || !File.Exists(Path)) return null;

            var file = File.ReadAllText(Path);
            if (string.IsNullOrEmpty(file)) return null;

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.DeserializeObject<ReadableData>(file, settings);
        }

        public virtual T DeSerialization<T>() where T : new()
        {
            if (string.IsNullOrEmpty(Path) || !File.Exists(Path)) return new T();
            
            var file = File.ReadAllText(Path);
            if (string.IsNullOrEmpty(file)) return new T();

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
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
}