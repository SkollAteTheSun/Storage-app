using System.IO;
using System.Xml;
using System.Text.Json;
using Classses;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(1, 2, 2, 4, 3, new DateTime(2023, 2, 10)); 
            Box box2 = new Box(2, 3, 3, 4, 3, new DateTime(2023, 2, 10));
            Box box3 = new Box(3, 1, 1, 1, 2, new DateTime(2023, 2, 10));
            Box box4 = new Box(4, 4, 3, 1, 1, new DateTime(2023, 2, 4));
            Box box5 = new Box(5, 3, 5, 1, 1, new DateTime(2023, 2, 4));
            Box box6 = new Box(6, 5, 5, 5, 2, new DateTime(2023, 2, 4));
            Box box7 = new Box(7, 5, 5, 5, 2, new DateTime(2023, 2, 4));
            Box box8 = new Box(8, 1, 1, 1, 2, new DateTime(2023, 6, 1));
            Box box9 = new Box(9, 1, 2, 2, 4, new DateTime(2023, 6, 2));
            Box box10 = new Box(10, 2, 2, 1, 4, new DateTime(2023, 6, 13));

            Pallet pallet1 = new Pallet(1, 20, 15, 100);
            pallet1.AddBox(box1);
            pallet1.AddBox(box2);
            pallet1.AddBox(box3);
            Pallet pallet2 = new Pallet(2, 20, 25, 20);
            pallet2.AddBox(box4);
            pallet2.AddBox(box5);
            pallet2.AddBox(box6);
            Pallet pallet3 = new Pallet(3, 10, 15, 50);
            pallet3.AddBox(box7);
            pallet3.AddBox(box8);
            pallet3.AddBox(box9);
            Pallet pallet4 = new Pallet(4, 10, 15, 50);
            pallet4.AddBox(box10);

            List<Pallet> pallets = new List<Pallet> { pallet1, pallet2, pallet3, pallet4 };

            Storage storage = new Storage(pallets);

            storage.GroupAndSortPallets();
            storage.GetTopPalletsonDate();
            //storage.PrintAllBoxes();
                        
            Console.WriteLine("-------------------------------------------------------------------");
            string filePath = "Storage1.json";

            //Serialize the Storage to a JSON file
            storage.SerializeStorage(filePath);

           
            // Deserialize the Storage from the JSON file
            Storage deserializedStorage = Storage.DeserializeStorage(filePath);

            if (deserializedStorage != null)
            {
                deserializedStorage.GroupAndSortPallets();
                deserializedStorage.GetTopPalletsonDate();
                deserializedStorage.PrintAllBoxes();
            }
            
        }

    }
}

