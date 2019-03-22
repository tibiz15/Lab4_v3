using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace Lab4.models
{
    public enum SortType { name = 1, surname, email, birthDate, adult, zodiac, chinese, birthday };

    enum StrCheck
    {
        name,
        surname,
        email
    };

    //keeps track of the list of users
    class UsersDataModel
    {

        private List<Person> _userData = new List<Person>();

        public List<Person> UserData
        {
            get => _userData;
            set => _userData = value;
        }

        public String SavePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "sharp", "data.xyz");
            }
        }

        public UsersDataModel()
        {

            var savePathStr = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "sharp");

            if (!Directory.Exists(savePathStr))
            {
                Directory.CreateDirectory(savePathStr);
            }

            if (File.Exists(SavePath))
            {
                //check if not empty
                //if empty
                //message box that 50 users will be created

                if (new FileInfo(SavePath).Length == 0)
                {

                    MessageBox.Show("Data file is empty, creating 50 random people!");
                    var random = new Random();
                    for (int i = 0; i < 50; i++)
                    {
                        UserData.Add(RandomPerson(random));
                    }

                    Serialize(SavePath);

                }
                else
                {
                    try
                    {
                        UserData = DeSerialize(SavePath);
                    }
                    catch (SerializationException)
                    {

                        MessageBox.Show("Data file is corrupted, creating 50 random people!");
                        var random = new Random();
                        for (int i = 0; i < 50; i++)
                        {
                            UserData.Add(RandomPerson(random));
                        }

                        Serialize(SavePath);
                    }
                }

            }
            else
            {
                MessageBox.Show("Data file not found, creating 50 random people!");
                FileStream tempFile = File.Create(SavePath);
                var random = new Random();
                for (int i = 0; i < 50; i++)
                {
                    UserData.Add(RandomPerson(random));
                }
                tempFile.Close();//close before serialization
                Serialize(SavePath);
            }

        }




        //make different filter methods

        

        private List<Person> DeSerialize(String filePath)
        {

            using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {

                IFormatter formatter = new BinaryFormatter();

                List<Person> objnew = (List<Person>) formatter.Deserialize(stream);

                stream.Close();

                return objnew;
            }

        }

        public void Serialize(String filePath)
        {

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, UserData);
            stream.Close();



        }

        private Person RandomPerson(Random random)
        {

            var name = RandomStr(random);
            var surname = RandomStr(random);

            var email = name + "." + surname + random.Next(12348) + "@" + RandomStr(random) + "." + RandomStr(random);


            DateTime start = new DateTime(1980, 1, 1);
            int range = (DateTime.Today - start).Days;
            var birthDate = start.AddDays(random.Next(range));

            return new Person(name, surname, birthDate, email);

        }

        private string RandomStr(Random random)
        {
            var chars = "qwertyuiopasdfghjklzxcvbnm";

            string result = "";

            int num = random.Next(5) + 3;

            for (int i = 0; i < num; i++)
            {
                result += chars[random.Next(26)];
            }

            return result;
        }


    }

}
