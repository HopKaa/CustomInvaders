using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int score = 0; // ���� ������

    public static void AddScore(int scoreValue)
    {
        score += scoreValue;
        Debug.Log("Score: " + score);
    }
}

