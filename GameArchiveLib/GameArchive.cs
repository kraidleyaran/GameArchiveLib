using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GameArchiveLib
{

    public sealed class GameArchive
    {

        private static readonly GameArchive instance = new GameArchive();

        static GameArchive()
        {
            
        }

        private GameArchive()
        {
            
        }

        public static GameArchive Instance
        {
            get { return instance;}
        }

        public void SaveData<DataType>(DataType gameData, string filePath)
        {
            FileStream stream = File.Create(filePath);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, gameData);
            stream.Close();
        }

        public DataType LoadData<DataType>(string filePath)
        {
            FileStream stream = File.OpenRead(filePath);
            BinaryFormatter formatter = new BinaryFormatter();
            DataType returnData = (DataType)formatter.Deserialize(stream);
            stream.Close();
            return returnData;
        }
    }

    
}
