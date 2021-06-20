using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public GameObject cube;
    string savestring;
    public const string TextSeperator = "Seperate";
    // Start is called before the first frame update
    void Start()
    {
         savestring = Application.dataPath + "/data.txt";
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadData()
    {
        if(File.Exists(savestring))
        {
            string LoadString = File.ReadAllText(savestring);
            string[] contents = LoadString.Split(new[] { TextSeperator }, System.StringSplitOptions.None);
            string Posx = contents[0];
            string Posy = contents[1];
            string Posz = contents[2];
            string PlayerName = contents[3];
            string playerHealth = contents[4];
            cube.transform.position = new Vector3(float.Parse(Posx), float.Parse(Posy), float.Parse(Posz));
            Debug.Log("playerPosition= " + Posx+Posy+Posz + "\n" +
                "PlayerName= " + PlayerName + "\n" +
                "PlayerHealth= " + playerHealth.ToString());
        }
        
    }
    void SaveData()
    {
        float cubePositionX = cube.transform.position.x;
        float cubePositionY = cube.transform.position.y;
        float cubePositionZ = cube.transform.position.z;
        string playerName = "Mac";
        int PlayerHealth = 2;

        string[] contents = new string[]
        {
            cubePositionX.ToString()," "
            +cubePositionY.ToString()," "
            +cubePositionZ.ToString()," "
            + playerName," "
            + PlayerHealth
        };
        string saveDt = string.Join(TextSeperator, contents);
        File.WriteAllText(savestring, saveDt);
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
