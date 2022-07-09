using ContactBook.Mappers;
using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Repositories
{
    public class AddressRepository
    {
        private string filePath = "../ContactBook/Files/Address.txt";
        public Address AddOrUpdate(Address address)
        {
            if (address == null)
            {
                throw new Exception("Adress is null!");
            }
            if (address.ID <= 0)
            {
                long lastID = this.GetLastID();
                if (lastID >= 0)
                {
                    address.ID = lastID + 1;
                    if (File.Exists(filePath))
                    {
                        using (StreamWriter sw = File.AppendText(filePath))
                        {
                            sw.WriteLine($"{address.ID}/" +
                              $"{address.Country}/" +
                              $"{address.PostCode}/" +
                              $"{address.City}/" +
                              $"{address.StreetName}/" +
                              $"{address.StreetNumber}/" + 
                              $"{address.ContactID}");
                        }
                    }
                }
            }
            else
            {
                string updateAddress = String.Format($"{address.ID}/" +
                              $"{address.Country}/" +
                              $"{address.PostCode}/" +
                              $"{address.City}/" +
                              $"{address.StreetName}/" +
                              $"{address.StreetNumber}/" +
                              $"{address.ContactID}");
                if (File.Exists(filePath))
                {
                    List<string> addreses = File.ReadAllLines(filePath).ToList();
                    int index = addreses.FindIndex(s => s.StartsWith($"{address.ID}/"));
                    if (index != -1)
                    {
                        addreses[index] = updateAddress;
                    }
                    File.WriteAllLines(filePath, addreses);
                }
            }
            return address;
        }
        public List<Address> GetAllAddresses()
        {
            List<Address> address = new List<Address>();
            using (StreamReader sr = File.OpenText(filePath))
            {
                string result;
                while ((result = sr.ReadLine()) != null)
                {
                    address.Add(AddressMapper.mapStringToAddress(result));
                }
            }
            return address;
        }

        public bool DeleteAddress(long addressID)
        {
            if (File.Exists(filePath))
            {
                List<string> addresses = File.ReadAllLines(filePath).ToList();
                int index = addresses.FindIndex(s => s.StartsWith($"{addressID}/"));
                if (index != -1)
                {
                    addresses.RemoveAt(index);
                }
                File.WriteAllLines(filePath, addresses);
                return true;
            }
            return false;
        }
        private long GetLastID()
        {
            return this.GetAllAddresses().OrderBy(c => c.ID).LastOrDefault().ID;
        }

        public bool DeleteAddresses(long contactID)
        {
            if (File.Exists(filePath))
            {
                List<string> addresess = File.ReadAllLines(filePath).ToList();

                for (int i = 0; i < addresess.Count; i++)
                {
                   
                    if (addresess[i].EndsWith($"{contactID}"))
                    {
                        addresess.Remove(addresess[i]);
                    }
                }


                File.WriteAllLines(filePath, addresess);
                return true;
            }
            return false;
        }
    }
}
