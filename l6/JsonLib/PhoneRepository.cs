using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Interface;
using PhoneDictionary;

namespace JsonLib
{
    public class PhoneRepository : IPhoneDictionary
    {
        public PhoneRepository(){}
        private const string File = @"C:/Users/User/Desktop/Новая папка/asp/Lab6/JsonLib/PD.json";
        private static List<Phone> Phones { get; set; }

        public void Create(Phone item)
        {
            if (item == null) return;
            if (Get(item.Id) != null) return;

            var id = Phones.Count + 1;
            Phones.Add(new Phone { Id = id, Name = item.Name, Number = item.Number });
            Save();
        }

        public Phone Get(int id)
        {
            var jsonString = System.IO.File.ReadAllText(File);
            Phones = JsonConvert.DeserializeObject<List<Phone>>(jsonString).ToList();
            return Phones.Find(c => c.Id == id);
        }

        public IEnumerable<Phone> GetAll()
        {
            var jsonString = System.IO.File.ReadAllText(File);
            Phones = JsonConvert.DeserializeObject<List<Phone>>(jsonString).ToList();

            return Phones.OrderBy(c => c.Name).ToList();
        }

        public void Remove(Phone item)
        {
            if (item == null) return;

            Phones.Remove(item);

            Save();
        }

        public void Update(Phone item)
        {
            if (item != null)
            {
                var newContact = Get(item.Id);
                newContact.Name = item.Name;
                newContact.Number = item.Number;

                Save();
            }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(Phones);
            System.IO.File.WriteAllText(File, json);
        }
    }
}
