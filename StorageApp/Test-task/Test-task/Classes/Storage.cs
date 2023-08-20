using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Classses
{
    class Storage // класс, описывающий склад
    {
        public List<Pallet> Pallets { get;}

        public Storage(List<Pallet> pallets)
        {
            Pallets = pallets;
        }

        public void PrintAllBoxes()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("All Boxes with details");
            foreach (var pallet in Pallets)
            {
                foreach (var box in pallet.Boxes)
                {
                    Console.WriteLine($"Box ID: {box.Id}");
                    Console.WriteLine($"Width: {box.Width}, Height: {box.Height}, Depth: {box.Depth}");
                    Console.WriteLine($"Weight: {box.Weight}, Expiration Date: {box.ExpirationDate}");
                    Console.WriteLine($"Pallet ID: {pallet.Id}");
                    Console.WriteLine();
                }
            }

        }

        public void GroupAndSortPallets()
        {
            var groupedPallets = Pallets.GroupBy(pallet => pallet.CalculateExpirationDate())
                                        .OrderBy(group => group.Key);


            foreach (var group in groupedPallets)
            {
                Console.WriteLine($"Expiration Date: {group.Key}");
                var sortedPallets = group.OrderBy(pallet => pallet.CalculateWeight());
                foreach (var pallet in sortedPallets)
                {
                    Console.WriteLine($"Pallet ID: {pallet.Id}, Weight: {pallet.CalculateWeight()}");
                }
                Console.WriteLine();
            }
        }

        public void GetTopPalletsonDate()
        {
            var palletsByDate = Pallets.OrderByDescending(pallet => pallet.CalculateExpirationDate())
                                     .ThenBy(pallet => pallet.CalculateVolume())
                                     .Take(3);

            var palletsByVolume = palletsByDate.OrderByDescending(pallet => pallet.CalculateVolume());

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Top 3 Pallets with Highest Expiration Date");
            foreach (var pallet in palletsByVolume)
            {
                Console.WriteLine($"Pallet ID: {pallet.Id}, Volume: {pallet.CalculateVolume()},  Expiration Date: {pallet.CalculateExpirationDate()}");
            }

        }

        public void SerializeStorage(string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Storage serialized to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to serialize Storage: {ex.Message}");
            }
        }

        public static Storage DeserializeStorage(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    Storage? storage = JsonSerializer.Deserialize<Storage>(json);
                    if (storage != null)
                    {
                        Console.WriteLine($"Storage deserialized from {filePath}");
                        return storage;
                    }
                }

                Console.WriteLine($"Failed to deserialize Storage from {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to deserialize Storage: {ex.Message}");
            }

            return null;
        }

    }

}

