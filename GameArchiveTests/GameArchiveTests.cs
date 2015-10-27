using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameArchiveLib;
using GameDataLib;
using GameObjectLib;
using GameObserverLib;
using NUnit.Framework;

namespace GameArchiveTests
{
    [TestFixture]
    public class GameArchiveTests
    {
        [TestCase(TestName = "Saving GameData via SaveData() method works correctly")]
        public void SaveDataToDrive()
        {
            GameObject gameObject = new GameObject("new game object");
            Property newProperty = new Property(PropertyType.String, "new property", "new value");
            gameObject.AddProperty(newProperty);
            GameObserver Observer = GameObserver.Instance;
            Observer.ObserveGameObject(gameObject, ObjectStatus.Active);
            GameData gameData = new GameData(Observer.GetObserverData());
            GameArchive Archive = GameArchive.Instance;
            Archive.SaveData(gameData, "C:\\GameCraftData\\testgamedata.gcd");
            Assert.IsTrue(true);
        }

        [TestCase(TestName = "Loading GameData via LoadData() method works correctly")]
        public void LoadDataFromDrive()
        {
            GameObject gameObject = new GameObject("new game object");
            Property newProperty = new Property(PropertyType.String, "new property", "new value");
            gameObject.AddProperty(newProperty);
            GameObserver Observer = GameObserver.Instance;
            Observer.ObserveGameObject(gameObject, ObjectStatus.Active);
            GameData gameData = new GameData(Observer.GetObserverData()); 
            GameArchive Archive = GameArchive.Instance;
            Archive.SaveData(gameData,"C:\\GameCraftData\\testgamedata.gcd");

            GameData loadData = Archive.LoadData <GameData>("C:\\GameCraftData\\testgamedata.gcd");
            Assert.IsTrue(loadData.ObserverData.ActiveObjects["new game object"].Name == gameObject.Name);
        }
    }
}
