using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace l3.Models
{
    public class DictObjectContext
    {
        public List<DictObj> GetAll()
        {
            List<DictObj> dictObjects = JsonConvert.DeserializeObject<List<DictObj>>(File.ReadAllText("D://универ//ПИС//лаба//l3//l3//user.json", Encoding.UTF8));
            return dictObjects;
        }
        public bool Add(DictObj dictObject)
        {
            try
            {
                List<DictObj> dictObjects = GetAll();
                dictObjects.Add(dictObject);
                File.WriteAllText("D://универ//ПИС//лаба//l3//l3//user.json", JsonConvert.SerializeObject(dictObjects));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(DictObj dictObject)
        {
            try
            {
                List<DictObj> dictObjects = GetAll();
                foreach (DictObj dict in dictObjects)
                {
                    if (dict.Id == dictObject.Id)
                    {
                        dict.FIO = dictObject.FIO;
                        dict.Telephone = dictObject.Telephone;
                    }
                }
                File.WriteAllText("D://универ//ПИС//лаба//l3//l3//user.json", JsonConvert.SerializeObject(dictObjects));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                List<DictObj> dictObjects = GetAll();
                dictObjects.Remove(dictObjects.Find(x => x.Id == id));
                File.WriteAllText("D://универ//ПИС//лаба//l3//l3//user.json", JsonConvert.SerializeObject(dictObjects));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DictObj Find(int id)
        {
            List<DictObj> dictObjects = GetAll();
            return dictObjects.Find(x => x.Id == id);
        }
    }
}