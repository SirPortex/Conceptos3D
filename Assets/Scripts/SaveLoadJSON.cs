using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable] //un objeto que es capaz de convertirse de obejto a archivo y viceversa se denomina "SERIALIZABLE" -> "SERIALIZADO2
struct PlayerData
{
    public Vector3 position; 
}
public class SaveLoadJSON : MonoBehaviour
{
    public string fileName = "test.json";

    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.persistentDataPath + '\\' + fileName;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Save();
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    private void Save()
    {
        StreamWriter streamWritter = new StreamWriter(fileName);
        PlayerData playerData = new PlayerData(); //instancio el objeto que vamos a guardar
        playerData.position = transform.position; //rellenamos la info del objeto

        string json =  JsonUtility.ToJson(playerData); //"To.Json" -> recibe un objeto serializable y nos genera un string de ese objeto serializable.
        streamWritter.Write(json);

        streamWritter.Close();
    }

    private void Load()
    {
        if (File.Exists(fileName)) //Si el archivo existe se guarda
        {
            StreamReader streamReader = new StreamReader(fileName);

            string json = streamReader.ReadToEnd();
            streamReader.Close();

            try
            {
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(json); // "FromJson" -> De JSON a objeto. Leemos todo de principio a fin. Te devuelve en formato JSON
                transform.position = playerData.position;
            }
            catch(System.Exception e)
            {
                //Sacar al topo de Animal Crossing
                Debug.Log(e.Message);
            }
        }
    }
}
