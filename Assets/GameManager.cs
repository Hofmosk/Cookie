using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Cookie cookie;
    public Text CookieText;
    public Text CookerButtonText;
    public Text OvenButtonText;
    public Text BakeriesButtonText;
    public GameObject uigameover;
    

    public int Cookie {get; set; }

    public List<int> Number = new List<int>();
    public List<int> Cost = new List<int>();
    public List<int> Cooldowns = new List<int>();
    public List<int> Rate = new List<int>();
    public List<string> Name = new List<string>();

    private List<float> Counters = new List<float>() { 0, 0, 0 };

    public float cooldown;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        uigameover.SetActive(false);
        Cookie = 0;
        counter = 0;
    }
    public void BuyCooker()
    {
        if(Cookie >= Cost[0])
        {
            Cookie -= Cost[0];
            Number[0]++;
            CookerButtonText.text = Name[0] + "      " + Number[0].ToString();
        }
    }

    public void BuyOven()
    {
        if (Cookie >= Cost[1])
        {
            Cookie -= Cost[1];
            Number[1]++;
            OvenButtonText.text = Name[1] + "      " + Number[1].ToString();
        }
    }

    public void BuyBakeries()
    {
        if (Cookie >= Cost[2])
        {
            Cookie -= Cost[2];
            Number[2]++;
            BakeriesButtonText.text = Name[2] + "      " + Number[2].ToString();
        }
    }



    public void ManualIncrement()
    {
        Cookie = Increment(1);
    }

    public int Increment(int value)
    {
        int total = Cookie + value;
        UpdateCookieDisplay(total);
        return total;
    }

    // Update is called once per frame
    void Update()
    {
            
        counter += Time.deltaTime;

        Counters[0] += Time.deltaTime;
        Counters[1] += Time.deltaTime;
        Counters[2] += Time.deltaTime;
        
        if (counter>=cooldown)
        {
            
            counter -= cooldown;
        }
        

        if (Number[0] >= 1)
        {
            if (Counters[0] >= Cooldowns[0])
            {
                Cookie = Increment(Rate[0] * Number[0]);
                Counters[0] -= Cooldowns[0];
            }
        }

        if (Number[1] >= 1)
        {
            if (Counters[1] >= Cooldowns[1])
            {
                Cookie = Increment(Rate[1] * Number[1]);
                Counters[1] -= Cooldowns[1];
            }
        }

        if (Number[2] >= 2)
        {
            if (Counters[2] >= Cooldowns[2])
            {
                Cookie = Increment(Rate[2] * Number[2]);
                Counters[2] -= Cooldowns[2];
            }
        }

        
        if(cookie.gameover == true)
        {
            uigameover.SetActive(true);
            Debug.Log("dedfef");
        }
    }

    private void UpdateCookieDisplay(int newNumber)
    {
        CookieText.text = ("Cookies : " + Cookie.ToString());
    }
}
