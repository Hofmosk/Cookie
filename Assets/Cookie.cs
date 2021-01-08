using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookie : MonoBehaviour
{   
    public GameManager gameManager;

    public Button ButtonCookie;
    public List<Sprite> SpriteList;
    public bool gameover = false;
    int v = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnEat()
    {
        v++;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = SpriteList[v];
        Debug.Log("I "+gameover);
      
        if(v == 3)
        {
            gameover = true;
        }
        
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
            {
                
                
                
            }
    }

    
   
}
