using Classses;
using NUnit.Framework;

namespace Test_taskTests

{
    public class Tests
    {
    
        [Test]
        public void boxExperationDateCalculation_0101_1104returned()
        {
            Box box1 = new Box(1, 2, 2, 4, 3, new DateTime(2023, 1, 1));
            DateTime expectedExpirationDate = new DateTime(2023, 4, 11);
            DateTime actualExpirationDate = box1.ExpirationDate;
            Assert.AreEqual(expectedExpirationDate, actualExpirationDate);
        }
        
        [Test]
        public void boxVolueCalculation_2and2and2_8returned()
        {
            Box box1 = new Box(1, 2, 2, 2, 10, new DateTime(2023, 1, 1));    
            double expectedVolume = 8;
            double actualVolume = box1.CalculateVolume();
            Assert.AreEqual(expectedVolume, actualVolume);
        }

        [Test]
        public void palleteDateCalculation_3dates_smalestDateRerurned()
        {
            Box box8 = new Box(1, 2, 2, 4, 3, new DateTime(2019, 1, 1)); 
            Box box9 = new Box(2, 3, 3, 4, 3, new DateTime(2018, 1, 1));
            Box box10 = new Box(3, 1, 1, 1, 2, new DateTime(2017, 1, 1));
            Pallet pallet1 = new Pallet(1, 10, 10, 10);
            pallet1.AddBox(box8);
            pallet1.AddBox(box9);
            pallet1.AddBox(box10);
            DateTime expectedDate = new DateTime(2017, 4, 11); // Наименьший срок годности коробки
            DateTime actualDate = pallet1.CalculateExpirationDate();

            Assert.AreEqual(expectedDate, actualDate);

        }

        [Test]
        public void palletTotalVolumeCalculation_8and27and1000_1035returned()
        {
            Box box1 = new Box(1, 2, 2, 2, 10, new DateTime(2023, 1, 1));
            Box box2 = new Box(2, 3, 3, 3, 15, new DateTime(2023, 1, 1));
            Pallet pallet1 = new Pallet(1, 10, 10, 10);
            pallet1.AddBox(box1);
            pallet1.AddBox(box2);
            double expectedTotalVolume = box1.CalculateVolume() + box2.CalculateVolume() + 10 * 10 * 10;
            Assert.AreEqual(expectedTotalVolume, pallet1.CalculateVolume());
        }

        [Test]
        public void palletTotalWeightCalculation_10and20_60returned()
        {
            Box box1 = new Box(1, 2, 2, 2, 10, new DateTime(2023, 1, 1));
            Box box2 = new Box(2, 3, 3, 3, 20, new DateTime(2023, 1, 1));
            Pallet pallet1 = new Pallet(1, 10, 20, 10);
            pallet1.AddBox(box1);
            pallet1.AddBox(box2);
            double expectedTotalWeight = box1.Weight + box2.Weight + 30;
            Assert.That(pallet1.CalculateWeight, Is.EqualTo(expectedTotalWeight));
        }

        public void TestCleanUp() { 
            
        }
    }
}