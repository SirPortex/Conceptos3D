using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaveLoadTXT : MonoBehaviour
{
    public string fileName = "test.txt";
    // Start is called before the first frame update
    void Start()
    {
        
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

        void Save()
        {
            //guardar
            StreamWriter streamWritter = new StreamWriter(Application.persistentDataPath + '\\' + fileName);
            streamWritter.WriteLine("Archivo de guardado");
            streamWritter.WriteLine(Random.Range(0, 100));
            streamWritter.WriteLine(transform.position.x);
            streamWritter.WriteLine(transform.position.y);
            streamWritter.WriteLine(transform.position.z);
            streamWritter.Close(); //IMPORTANTE !!! CERRAR
        }

        void Load()
        {
            if (File.Exists(Application.persistentDataPath + '\\' + fileName))
            {
                try
                {
                    //Cargar informacion
                    StreamReader streamReader = new StreamReader(Application.persistentDataPath + '\\' + fileName);
                    streamReader.ReadLine(); //La primera linea no es importante, movemos el cursor del archivo a la siguiente linea
                    streamReader.ReadLine();
                    float x = float.Parse(streamReader.ReadLine()); //Parse -> Pasar de un string a otro tipo. EJ: pasar de string a float.
                    float y = float.Parse(streamReader.ReadLine());
                    float z = float.Parse(streamReader.ReadLine());

                    streamReader.Close();

                    transform.position = new Vector3(x, y, z);
                }
                catch (System.Exception e) //como no guardamos la info en ningun server, guardamos en LOCAL.
                {                         // No tenemos control sobre los archivos del usuario. Nos aseguramos de que si algo va mal, este todo controlado.
                    //sacar al topo de AC
                    Debug.Log(e.Message);
                }
            }
        }
    }
}
