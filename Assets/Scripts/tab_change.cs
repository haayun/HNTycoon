using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tab_change : MonoBehaviour
{
    public Button change_to_upgrade, change_to_sell;
    public GameObject upgrade_tab, sell_tab;

    public void upgrade_tab_click()
    {
        sell_tab.SetActive(false);
        upgrade_tab.SetActive(true);
    }
    public void sell_tab_click()
    {
        upgrade_tab.SetActive(false);
        sell_tab.SetActive(true);
    }
}
