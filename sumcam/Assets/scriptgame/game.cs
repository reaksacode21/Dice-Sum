using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class game : MonoBehaviour
{
    public List<Button> buttons;
    public List<Image> ResultImge;
    public int[] value;
    public List<Sprite> sprites;
    int sumImagewin;
    public Text[] txtfackResult,resultdesplay;
    int fack1, fack2;
    int[] fackresult=new int[3];
    //time of the game process
    bool isOn,isOnAi;
    float startTime = 5f;
    public Text textTime,txttime1;
    int answer1, answer2, answer3;
    //varaible of random
    int Ai_User;
    public Animator Rright, Rleft;
    public audioScript soundgame= new audioScript();

   //Ramdome ia and user of game
   public void blockAi()
    {


        randomevaleu();
        countvalueai();


    }

    private void Awake()
    {
        //Rleft.Play("rolling");
    }

    void randomevaleu()
    {
        for (int i = 0; i < 2; i++)
        {
            int ran = Random.Range(1, 7);
            value[i] = ran;

            sumImagewin += value[i];
            
        }

        changeImge();
        fack1 = value[0];
        fack2 = value[1];
        print("sum:"+ sumImagewin);
        print("resut1:" +fack1);
        print("result2:" + fack2);
        resultdesplay[0].text = fack1.ToString();
        resultdesplay[1].text = fack2.ToString();
        resultdesplay[2].text= sumImagewin.ToString();
        fackvalue();



        //printext to resut
        //for(int i = 0; i < fackresult.Length; i++)
        //{
        //    txtfackResult[i].text = fackresult[i].ToString();
        //}
        //txtfackResult[0].text = fackresult[0].ToString();
        //txtfackResult[1].text = fackresult[1].ToString();
        //txtfackResult[2].text = fackresult[2].ToString();
    }
    void fackvalue()
    {
        fackresult[0] = fack1+fack2+1;
        fackresult[1] = fack2+9;
        fackresult[2] = sumImagewin;
        shuffle(fackresult);
        txtfackResult[0].text= fackresult[0].ToString();
        txtfackResult[1].text= fackresult[1].ToString();
        txtfackResult[2].text = fackresult[2].ToString();

        //for (int i = 0; i < fackresult.Length; i++)
        //{
        //    txtfackResult[i].text = fackresult[i].ToString();
        //}
       
    }
    void changeImge()
    {
        for (int i = 0; i < value.Length; i++)
        {
            for (int j = 0; j < sprites.Count; j++)
            {
                if (value[i] - 1 == j)
                {
                    ResultImge[i].sprite = sprites[j];
                }
            }
        }

    }
    public GameObject ai, you,btnplay1;
   
    void downtime()
    {

        if (isOn)
        {
            
            
            btnplay1.SetActive(false);
            you.SetActive(true);
            ai.SetActive(false);
            isOnAi = false;
            startTime -= Time.deltaTime;
            textTime.text = Mathf.Round(startTime).ToString();
            soundgame.sfxsound[5].Play();

            if (startTime < 0)
            {
                StartCoroutine(setPlay());
                Rleft.Play("idl");
                Rright.Play("idl");
                isOn = false;
                randomevaleu();
                // countvalue();
                // Time.timeScale = 0.0f;
                StartCoroutine(waitagain());
                isOnAi =false;
                StartCoroutine(wait());
               // waitagain();  
                //Time.timeScale = 1.0f;
                //startTime = 5;
                //isOnAi = true;



            }
        }
       
        if (isOnAi)
        {
            btntall.SetActive(false);
            Rleft.Play("rolling");
            Rright.Play("rigth_dice");
            
            btnplay1.SetActive(false);
            isOn = false;
            ai.SetActive(true);
            you.SetActive(false);
            startTime -= Time.deltaTime;
            textTime.text = Mathf.Round(startTime).ToString();
            soundgame.sfxsound[5].Play();

            if (startTime < 0)
            {
                StartCoroutine(setPlay());

                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].enabled = false;
                }
                isOnAi = false;
                Rleft.Play("idl");
                Rright.Play("idl");


                btntall.SetActive(true);
                //StartCoroutine(waitagain());
                StartCoroutine(waitbtn());
                blockAi();
                startTime = 5;
                
                //waitagain();

               
                // StartCoroutine(waitagain());

            }

        }


    }
    
    public GameObject fire1,fire2;
    IEnumerator setPlay()
    {
        fire1.SetActive(true);
        fire2.SetActive(true);
        yield return new WaitForSeconds(3f);
        fire1.SetActive(false);
        fire2.SetActive(false);
    }
    
    //subfle data
    public void shuffle(int[] arr)
    {
        var n = arr.Length - 1;
        while (n >= 0)
        {
            var k = Random.Range(0, n);
            var temp = arr[k];
            arr[k] = arr[n];
            arr[n] = temp;
            n--;
        }
    }
    IEnumerator waitbtn()
    {
        yield return new WaitForSeconds(3f);
        btnplay1.SetActive(true);
        ai.SetActive(false);
    }
    public GameObject btntall;
    IEnumerator waitagain()
    {
        yield return new WaitForSeconds(2f);
        btntall.SetActive(true);
        isOnAi = false;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
       
        //isOn = true;
        startTime = 5;
        
       


    }
    //btn tap to start
    public void btnplay()
    {
      
        btntall.SetActive(false);
        Rright.Play("rigth_dice");
        Rleft.Play("rolling");
        btnplay1.SetActive(false);
        isOn =true;
        isOnAi=false; 
       clearValue();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].enabled = true;
        }

        //blockRandome();
    }
    public void bntplayagain()
    {
        for(int i = 0; i < 5; i++)
        {
            btn1[i].SetActive(false);
            btn2[i].SetActive(false);
            btn3[i].SetActive(false);
            btn3[i].SetActive(false);
            btn4[i].SetActive(false);
            btn5[i].SetActive(false);
            btn6[i].SetActive(false);
            btn7[i].SetActive(false);
            btn8[i].SetActive(false);
            btn9[i].SetActive(false);
            btn10[i].SetActive(false);
            btn11[i].SetActive(false);
            btn12[i].SetActive(false);
            btnw1[i].SetActive(false);
            btnw2[i].SetActive(false);
            btnw3[i].SetActive(false);
            btnw4[i].SetActive(false);
            btnw5[i].SetActive(false);
            btnw6[i].SetActive(false);
            btnw7[i].SetActive(false);
            btnw8[i].SetActive(false);
            btnw9[i].SetActive(false);
            btnw10[i].SetActive(false);
            btnw11[i].SetActive(false);
            btnw12[i].SetActive(false);
        }
        a = -1; b = -1; c = -1; d = -1; e = -1; f = -1; g = -1; h = -1; i = -1; j = -1; k = -1; l = -1;
        a1 = -1; b1 = -1; c1 = -1; d1 = -1; e1 = -1; f1 = -1; g1 = -1; h1 = -1; i1 = -1; j1 = -1; k1 = -1; l1 = -1;
        clearValue();
        youWin.SetActive(false);
        aiwin.SetActive(false);

    }
    void clearValue()
    {
        for(int i = 0;i <3; i++)
        {
            fackresult[i]= 0;
            txtfackResult[i].text = " ";
            resultdesplay[i].text = " ";
        }
        sumImagewin = 0;
        fack2 = fack2 = 0;

    }
    //make btn value
    public void  btnvalue(int n)
    {
       
        isOnAi = true;
        //waitagain();
        switch (n)
        {
            case 0:
               
                answer1 = fackresult[0];
                
                print(fackresult[0]);
                break;
            case 1:
               
                answer2 = fackresult[1];
                
                print(fackresult[1]);
                break;
            case 2:
               
                answer3 = fackresult[2];
                
                print(fackresult[2]);
                break;
        }
        checkCondition();
        
        clearValue();
    }
    public GameObject AnTrue, AnFale;
    IEnumerator rightGame()
    {
        AnTrue.SetActive(true);
        yield return new WaitForSeconds(1f);
        AnTrue.SetActive(false);
    }
    IEnumerator falseGame()
    {
        AnFale.SetActive(true);
        yield return new WaitForSeconds(1f);
        AnFale.SetActive(false);
    }
    public void checkCondition()
    {
        
        if (answer1 == sumImagewin)
        {
           StartCoroutine(rightGame());
            soundgame.sfxsound[3].Play();
            countvalue();
            clearValue();
            clearValue();
            print("win");
        }
        else if (answer2 == sumImagewin)
        {

            StartCoroutine(rightGame());
            soundgame.sfxsound[3].Play();
            countvalue();
            clearValue();
            print("win");
        }else if(answer3 == sumImagewin)
        {
            StartCoroutine(rightGame());
            soundgame.sfxsound[3].Play();
            countvalue();
            clearValue();
            print("win");
        }
        else
        {
            StartCoroutine (falseGame());   
            soundgame.sfxsound[4].Play();
            clearValue();
            print("lose");
        }
    }
    public GameObject[] btn1=new GameObject[5];
    public GameObject[] btn2=new GameObject[5];
    public GameObject[] btn3=new GameObject[5];
    public GameObject[] btn4=new GameObject[5]; 
    public GameObject[] btn5=new GameObject[5];
    public GameObject[] btn6=new GameObject[5];
    public GameObject[] btn7=new GameObject[5];
    public GameObject[] btn8=new GameObject[5];
    public GameObject[] btn9 = new GameObject[5];
    public GameObject[] btn10 = new GameObject[5];
    public GameObject[] btn11 = new GameObject[5];
    public GameObject[] btn12 = new GameObject[5];
    

    int a = -1, b = -1, c = -1, d = -1, e = -1,f=-1,g=-1,h=-1,i=-1,j=-1,k=-1,l=-1;
    public GameObject youWin,aiwin,txtwin,txtlost;
    public Text[] txtplayer,txtai;
    public void  countvalue()
    {
        
        int op;
        op = sumImagewin;
        switch (op)
        {
            case 1:
                a++;
                btn1[a].SetActive(true);
                if (a == 4)
                {
                    soundgame.sfxsound[1].Play();
                    youWin.SetActive(true);
                    print("you win");
                }
              //  txtplayer[a].text = a+1.ToString();
              
                break;
            case 2:
                b++;
                
                if (b == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                   // txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn2[b].SetActive(true);
                int s1 = 1 + b;
               
                txtplayer[0].text = s1.ToString();
                break;
            case 3: 
                c++;
                
               
                if (c == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                   // txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn3[c].SetActive(true);
                int s2 = 1 + c;
                txtplayer[1].text = s2.ToString();
              
                break;
            case 4:
                d++;
               
                if (d == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                    //txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn4[d].SetActive(true);
                int s3 = 1 + d;
                txtplayer[2].text = s3.ToString();
               
                break;
            case 5:

                e++;
                if (e == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                   // txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn5[e].SetActive(true);
                int s4 = 1 + e;
                txtplayer[3].text = s4.ToString();
             
                break;
            case 6:
                f++;

                

               
                if (f== 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                   // txtlost.SetActive(false);

                    youWin.SetActive(true);
                    print("you win");
                }
                btn6[f].SetActive(true);
                int s5 = 1 + f;
                txtplayer[4].text = s5.ToString();
               
                break;
            case 7:
                g++;
               
               
                if (g == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                   // txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn7[g].SetActive(true);
                int s6 = 1 + g;
                txtplayer[5].text = s6.ToString();
               
                break;
            case 8:
                h++;
               
               
                if (h == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                   // txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn8[h].SetActive(true);
                int s7 = 1 + h;
                txtplayer[6].text = s7.ToString();
               
                break;
            case 9:
                i++;
                

               
                if (i == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                    //txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn9[i].SetActive(true);
                int s8 = 1 + i;
                txtplayer[7].text = s8.ToString();
                break;
            case 10:
                j++;
               
                if (j == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                   // txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn10[j].SetActive(true);
                int s9 = 1 + j;
                txtplayer[8].text = s9.ToString();
               
            break;  
            case 11:

                k++;

                
                if (k == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                   // txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn11[k].SetActive(true);
                int s10 = 1 + k;
                txtplayer[9].text =s10.ToString();
               
                break;
            case 12:
                l++;
                
                if (l == 4)
                {
                    soundgame.sfxsound[1].Play();
                    txtwin.SetActive(true);
                   // txtlost.SetActive(false);
                    youWin.SetActive(true);
                    print("you win");
                }
                btn12[l].SetActive(true);
                int s11 = 1 + k;
                txtplayer[10].text = s11.ToString();
               
                break;
            default:
                print("not true");
                break;
        }


    }


    public GameObject[] btnw1 = new GameObject[5];
    public GameObject[] btnw2 = new GameObject[5];
    public GameObject[] btnw3 = new GameObject[5];
    public GameObject[] btnw4 = new GameObject[5];
    public GameObject[] btnw5 = new GameObject[5];
    public GameObject[] btnw6 = new GameObject[5];
    public GameObject[] btnw7 = new GameObject[5];
    public GameObject[] btnw8 = new GameObject[5];
    public GameObject[] btnw9 = new GameObject[5];
    public GameObject[] btnw10 = new GameObject[5];
    public GameObject[] btnw11 = new GameObject[5];
    public GameObject[] btnw12 = new GameObject[5];

    int a1 = -1, b1 = -1, c1 = -1, d1 = -1, e1 = -1, f1 = -1, g1 = -1, h1 = -1, i1 = -1, j1 =-1, k1 = -1, l1 = -1;
    public void countvalueai()
    {

        int op;
        op = sumImagewin;
        switch (op)
        {
            case 1:
                a1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (a1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    // txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    
                    print("you win");
                }
                btnw1[a1].SetActive(true);

                break;
            case 2:
                b1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (b1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    // txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw2[b1].SetActive(true);
                int p2 = 1 + b1;
                txtai[0].text=p2.ToString();
                break;
            case 3:
                c1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (c1 ==4)
                {
                    soundgame.sfxsound[2].Play();
                    // txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw3[c1].SetActive(true);
                int p3 = 1 + c1;
                txtai[1].text = p3.ToString();
                break;
            case 4:
                d1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (d1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");

                }
                btnw4[d1].SetActive(true);
                int p4 = 1 + d1;
                txtai[2].text = p4.ToString();
                break;
            case 5:
                e1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (e1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw5[e1].SetActive(true);
                int p5 = 1 + e1;
                txtai[3].text = p5.ToString();
                break;
            case 6:
                f1++;

                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (f1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw6[f1].SetActive(true);
                int p6 = 1 + f1;
                txtai[4].text = p6.ToString();
                break;
            case 7:
                g1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (g1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw7[g1].SetActive(true);
                int p7 = 1 + g1;
                txtai[5].text = p7.ToString();
                break;
            case 8:
                h1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (h1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw8[h1].SetActive(true);
                int p8 = 1 + h1;
                txtai[6].text = p8.ToString();
               
                break;
            case 9:
                i1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (i1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw9[i1].SetActive(true);
                int p9 = 1 + b1;
                txtai[7].text = p9.ToString();
              
                break;
            case 10:
                j1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (j1 ==4)
                {
                    soundgame.sfxsound[2].Play();
                    txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw10[j1].SetActive(true);
                int p10 = 1 + b1;
                txtai[8].text = p10.ToString();
               
                break;
            case 11:
                k1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (j1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw11[k1].SetActive(true);
                int p11 = 1 + b1;
                txtai[9].text = p11.ToString();
                
                break;
            case 12:
                l1++;
                StartCoroutine(rightGame());
                soundgame.sfxsound[3].Play();
                if (l1 == 4)
                {
                    soundgame.sfxsound[2].Play();
                    txtwin.SetActive(false);
                    txtlost.SetActive(true);
                    aiwin.SetActive(true);
                    print("you win");
                }
                btnw12[l1].SetActive(true);
                int p12 = 1 + b1;
                txtai[10].text = p12.ToString();
              
                break;
        }


    }
    
    // Start is called before the first frame update
    void Start()
    {
        Rright.Play("idl");
        Rleft.Play("idl");


    }

    // Update is called once per frame
    void Update()
    {
        downtime();
       
    }
}
