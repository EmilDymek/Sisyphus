using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public GameObject[] spriteMan;
    public GameObject[] spriteManJump;
    public GameObject[] spriteRock;
    public GameObject[] spriteCrack;

    public int manIndex = 0;
    public int rockIndex = 0;
    public int manJumpIndex = 0;
    public float timer = 0;



    void Start()
    {
        foreach(GameObject g in spriteMan)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in spriteManJump)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in spriteRock)
        {
            g.SetActive(false);
        }
        spriteMan[0].SetActive(true);
        spriteRock[0].SetActive(true);
    }

    void Update()
    {
        //Todo: Make ball fall back with timer if the player doesn't move with it in time
        GetInput();
    }

    void GetInput()
    {
        if (manIndex == 4 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SpriteUpdateJump();
            Debug.Log("Checkpoint1");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            manIndex++;
            SpriteUpdate();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (manIndex >= 0)
            {
                manIndex--;
                SpriteUpdate();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (manIndex == rockIndex)
            {
                rockIndex++;
                SpriteUpdate();
            }
        }

    }

    void SpriteUpdate()
    {
        foreach (GameObject g in spriteMan)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in spriteManJump)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in spriteRock)
        {
            g.SetActive(false);
        }

        spriteMan[manIndex].SetActive(true);
        spriteRock[rockIndex].SetActive(true);
    }

    void SpriteUpdateJump()
    {
        foreach (GameObject g in spriteMan)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in spriteManJump)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in spriteRock)
        {
            g.SetActive(false);
        }

        if (manJumpIndex == 0)
        {
            spriteManJump[0].SetActive(true);
            spriteRock[rockIndex].SetActive(true);
        }
    }
}
