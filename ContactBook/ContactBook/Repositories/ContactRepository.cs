using ContactBook.Mappers;
using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Repositories
{
    public class ContactRepository
    {
        private string filePath = "D:/Files/Contact.txt";
        public Contact AddOrUpdate(Contact contact)
        {
            if (contact == null)
            {
                throw new Exception("Contact is null!");
            }
            if (contact.ID <= 0)
            {
                long lastID = this.GetLastID();
                if (lastID >= 0)
                {
                    contact.ID = lastID + 1;
                    if (File.Exists(filePath))
                    {
                        using (StreamWriter sw = File.AppendText(filePath))
                        {
                            sw.WriteLine($"{contact.ID}/" +
                              $"{contact.FirstName}/" +
                              $"{contact.MiddleName}/" +
                              $"{contact.LastName}/" +
                              $"{contact.Age}/" +
                              $"{contact.Email}/" +
                              $"{contact.Gender}");
                        }
                    }
                }
            }
            else
            {
                string updateContact = String.Format($"{contact.ID}/" +
                                $"{contact.FirstName}/" +
                                $"{contact.MiddleName}/" +
                                $"{contact.LastName}/" +
                                $"{contact.Age}/" +
                                $"{contact.Email}/" +
                                $"{contact.Gender}");
                if (File.Exists(filePath))
                {
                    List<string> contacts = File.ReadAllLines(filePath).ToList();
                    int index = contacts.FindIndex(s => s.StartsWith($"{contact.ID}/"));
                    if (index != -1)
                    {
                        contacts[index] = updateContact;
                    }
                    File.WriteAllLines(filePath, contacts);
                }
            }
            return contact;
        }
        public List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
            using (StreamReader sr = File.OpenText(filePath))
            {
                string result;
                while ((result = sr.ReadLine()) != null)
                {
                    contacts.Add(ContactMapper.mapStringToContact(result));
                }
            }
            return contacts;
        }

        public bool DeleteContact(long contactID)
        {
            if (File.Exists(filePath))
            {
                List<string> contacts = File.ReadAllLines(filePath).ToList();
                int index = contacts.FindIndex(s => s.StartsWith($"{contactID}/"));
                if (index != -1)
                {
                    contacts.RemoveAt(index);
                }
                File.WriteAllLines(filePath, contacts);

                return true;
            }

            return false;
        }
        private long GetLastID()
        {
            return this.GetAllContacts().OrderBy(c => c.ID).LastOrDefault().ID;
        }

      
    }
}

