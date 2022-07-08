using ContactBook.Mappers;
using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Repositories
{
    public class PhoneRepository
    {
        private string filePath = "D:/Files/Phone.txt";
        public Phone AddOrUpdate(Phone phone)
        {
            if (phone == null)
            {
                throw new Exception("phone is null!");
            }
            if (phone.ID <= 0)
            {
                long lastID = this.GetLastID();
                if (lastID >= 0)
                {
                    phone.ID = lastID + 1;
                    if (File.Exists(filePath))
                    {
                        using (StreamWriter sw = File.AppendText(filePath))
                        {
                            sw.WriteLine($"{phone.ID}/" +
                              $"{phone.Number}/" +
                              $"{phone.Type}/" + 
                              $"{phone.ContactID}");
                        }
                    }
                }
            }
            else
            {
                string updatePhone = String.Format($"{phone.ID}/" +
                              $"{phone.Number}/" +
                              $"{phone.Type}/" +
                              $"{phone.ContactID}");
                if (File.Exists(filePath))
                {
                    List<string> phones = File.ReadAllLines(filePath).ToList();
                    int index = phones.FindIndex(s => s.StartsWith($"{phone.ID}/"));
                    if (index != -1)
                    {
                        phones[index] = updatePhone;
                    }
                    File.WriteAllLines(filePath, phones);
                }
            }
            return phone;
        }
        public List<Phone> GetAllPhones()
        {
            List<Phone> phones = new List<Phone>();
            using (StreamReader sr = File.OpenText(filePath))
            {
                string result;
                while ((result = sr.ReadLine()) != null)
                {
                    phones.Add(PhoneMapper.mapStringToPhone(result));
                }
            }
            return phones;
        }

        public bool DeletePhone(long phoneID)
        {
            if (File.Exists(filePath))
            {
                List<string> phones = File.ReadAllLines(filePath).ToList();
                int index = phones.FindIndex(s => s.StartsWith($"{phoneID}/"));
                if (index != -1)
                {
                    phones.RemoveAt(index);
                }
                File.WriteAllLines(filePath, phones);
                return true;
            }
            return false;
        }
        private long GetLastID()
        {
            return this.GetAllPhones().OrderBy(c => c.ID).LastOrDefault().ID;
        }

        public bool DeletePhones(long contactID)
        {
            if (File.Exists(filePath))
            {
                List<string> phones = File.ReadAllLines(filePath).ToList();

                for (int i = 0; i < phones.Count; i++)
                {
                    int index = phones.FindIndex(s => s.StartsWith($"{contactID}/"));
                    if (phones[i].EndsWith($"{contactID}"))
                    {
                        phones.Remove(phones[i]);
                    }
                }


                File.WriteAllLines(filePath, phones);
                return true;
            }
            return false;
        }
    }
}
