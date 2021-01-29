using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpriteManager : MonoBehaviour
{
    public GameObject[] spriteMan;
    public GameObject[] spriteRock;
    public GameObject[] spriteCrack;
    public GameObject[] Rocks1;
    public GameObject[] Rocks2;
    public GameObject[] Rocks3;
    public GameObject[] Rocks4;

    public GameObject[] fallman;


    public int manIndex = 0;
    public int rockIndex = 0;

    private int killrock3index = 0;
    private int killrock5index = 0;
    public float killrocktimer = 1f;

    private float time = 0.5f;
    private int jumpplus = 0;
    bool jumped = false;
    bool jumped2 = false;
    private bool turn = false;
    private float rollbacktime = 32f;
    bool victory=false;
    private float falltimer=1f;

    public bool delay = false;
    public float delaytime = 0.5f;

    bool disableinput;

   


    void Start()
    {
        foreach(GameObject g in Rocks1)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in Rocks2)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in Rocks3)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in Rocks4)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in spriteMan)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in spriteRock)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in fallman)
        {
            g.SetActive(false);
        }
        spriteMan[0].SetActive(true);
        spriteRock[0].SetActive(true);
        fallman[3].SetActive(true);
    }

    void Update()
    {
        //Todo: Make ball fall back with timer if the player doesn't move with it in time
        if (delay == false)
        {

            GetInput();
        }
        else
            delayfunc();

        if (rockIndex == 4 || rockIndex==14)
        {

            if (time >= 0)
            {
                time -= Time.deltaTime;
            }

            if (time < 0)
            {
                foreach (GameObject g in spriteRock)
                {
                    g.SetActive(false);
                }
                rockIndex++;
                time = 0.5f;
                spriteRock[rockIndex].SetActive(true);


            }
        }

        if (rockIndex == 30 || victory == true)
        {
            victory = true;
            rollbacktime -= Time.deltaTime;
            if ((int)rollbacktime == rockIndex)
            {
                rockIndex--;
                RockUpdate();
            }
            if (rockIndex <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            

        }

        if (killrocktimer >= 0)
        {
                killrocktimer -= Time.deltaTime;
        }

        if (killrocktimer < 0)
        {

                killrocktimer = 1f;
                killrockUpdate();
            killrock3index++;
            killrock5index++;
            if (killrock3index == 4)
                killrock3index = 0;
            if (killrock5index == 6)
                killrock5index = 0;
        }

        switch (manIndex)
        {
            case 5:
                if (jumped == false)
                {
                    jumpplus++;
                    jumped = true;
                }
                falltimer -= Time.deltaTime;
                if (falltimer <= 0)
                {
                    
                    kill1();
                }

                break;
            case 6:
                falltimer = 1f;
                break;

            case 4:
                if(jumped == true)
                {
                    jumpplus--;
                    jumped = false;
                }
                falltimer = 1f;
                break;
            case 16:
                if(jumped2 == false)
                {
                    jumpplus++;
                    jumped2 = true;
                }
                falltimer -= Time.deltaTime;
                if (falltimer <= 0)
                    kill2();
                break;
            case 15:
                if(jumped2 == true)
                {
                    jumpplus--;
                    jumped2 = false;
                }
                if (killrock3index == 3)
                {
                    kill();
                }
                falltimer = 1f;
                break;
            case 17:
                falltimer = 1f;
                break;
               
            case 3:
            case 23:
                if (killrock3index == 3)
                {
                    kill();
                }
                break;
            case 13:
                if (killrock5index == 5)
                {
                    kill();
                }
                break;
            case 30:
                falltimer -= Time.deltaTime;
                if (falltimer <= 0)
                    kill3();
                break;
                //floor break
        }

 




        
        
   
        void kill1()
        {

            disableinput = true;
           
            foreach (GameObject g in spriteMan)
            {
                g.SetActive(false);
            }
            fallman[0].SetActive(true);
            fallman[3].SetActive(true);
            delaytime -= Time.deltaTime;
            if (delaytime <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
        void kill2()
        {
            disableinput = true;

            foreach (GameObject g in spriteMan)
            {
                g.SetActive(false);
            }
            fallman[1].SetActive(true);
            fallman[3].SetActive(true);

            delaytime -= Time.deltaTime;
            if (delaytime <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        void kill3()
        {
            disableinput = true;

            foreach (GameObject g in spriteMan)
            {
                g.SetActive(false);
            }
            fallman[2].SetActive(true);
            fallman[3].SetActive(false);

            delaytime -= Time.deltaTime;
            if (delaytime <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        void kill()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        void delayfunc()
        {
            delaytime -= Time.deltaTime;
            if (delaytime <= 0)
            { 
                delay = false;
                delaytime = 0.5f;
                return;
            }
        }

        void GetInput()
        { if (disableinput == false)
            {

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (turn == true)
                    {
                        manIndex--;
                        SpriteUpdate();
                    }
                    else
                    {
                        manIndex++;
                        SpriteUpdate();
                    }

                    delay = true;


                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (manIndex >= 0)
                    {
                        if (turn == true)
                        {
                            manIndex++;
                            SpriteUpdate();
                        }
                        else
                        {
                            manIndex--;
                            SpriteUpdate();
                        }

                    }
                    delay = true;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (manIndex == rockIndex + jumpplus)
                    {
                        rockIndex++;
                        RockUpdate();
                    }

                }
            }
        }
        void killrockUpdate()
        {
            foreach (GameObject g in Rocks1)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in Rocks2)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in Rocks3)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in Rocks4)
            {
                g.SetActive(false);
            }
            Rocks1[killrock3index].SetActive(true);
            Rocks2[killrock3index].SetActive(true);
            Rocks3[killrock3index].SetActive(true);
            Rocks4[killrock5index].SetActive(true);
        }

        void RockUpdate()
        {
            foreach (GameObject g in spriteRock)
            {
                g.SetActive(false);
            }
            spriteRock[rockIndex].SetActive(true);
        }
      
        void SpriteUpdate()
        {
            foreach (GameObject g in spriteMan)
            {
                g.SetActive(false);
            }
         

            spriteMan[manIndex].SetActive(true);
      
            switch (manIndex)
            {
                case 10:
                case 20:
                case 27:

                    if (turn == false)
                    {
                        turn = true;
                    }
                    else if (turn == true)
                        turn = false;
                    break;
                case 9:
                case 21:
                case 26:
                    turn = false;
                    break;
                case 19:
                case 11:
                case 28:
                    turn = true;
                    break;

            }


        }
    }
}


