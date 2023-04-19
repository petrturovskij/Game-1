using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public float HP = 1;
    private float HPBottle = 0;
    public Image HPImage;
    public Text hpItemText ;


   
    void Update()
    {
        HPImage.fillAmount= HP;  
        hpItemText.text = " " + HPBottle;
        if (Input.GetButtonDown("Fire2") & HPBottle >0 & HP < 100)
        {
            HP += 20;
            HPBottle -= 1;
            if(HP > 100 ) 
            { 
                HP = 100;
            }
        }
        

    }
    public void Hit(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);

        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "HP" & Input.GetKeyDown(KeyCode.E))
        {
            HPBottle += 1;
        }
    }

}
