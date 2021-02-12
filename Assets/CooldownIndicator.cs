using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownIndicator : MonoBehaviour
{
    public Image img;
    public DashAbility da;
    // Start is called before the first frame update
    void Start()
    {
        img.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        img.enabled = img.fillAmount > 0 && img.fillAmount < 1;
        showCooldown();
        if (da.canDash) img.fillAmount = 1;
    }
    public void showCooldown()
    {
        img.fillAmount -= 1 / da.cooldown * Time.deltaTime;
        
    }
}
