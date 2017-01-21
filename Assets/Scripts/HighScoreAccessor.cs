using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScoreAccessor : MonoBehaviour {
    int score = 0;

    private void Awake()
    {
        string fullPath = Application.streamingAssetsPath + Path.DirectorySeparatorChar + "hiscore";

        if (File.Exists(fullPath))
        {
            using (var sr = new StreamReader(fullPath))
            {
                int.TryParse(sr.ReadLine(), out score);
            }
        }

        if (GameManager.Instance.CurrentScore > score)
        {
            score = GameManager.Instance.CurrentScore;

            using (var sw = new StreamWriter(fullPath))
            {
                sw.WriteLine(score);
            }
        }

        var tm = GetComponent<TextMesh>();
        tm.text = score.ToString("0000");
    }
}
