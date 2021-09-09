using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xmlLoad : MonoBehaviour
{
    public TextAsset txt;
    public string[,] sentence;
    public int lineSize, rowSize;
    // Start is called before the first frame update
    void Awake()
    {
        string currentText = txt.text.Substring(0, txt.text.Length - 1);

        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        sentence = new string[lineSize, rowSize];
        for (int i = 1; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for (int j = 0; j < rowSize; j++)
            {
                sentence[i, j] = row[j];
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
