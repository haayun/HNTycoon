﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// 각 장비 이름 넣기
// 각 중급, 고급 해녀 -> 중간바다 깊은바다


public class equipment_upgrade : MonoBehaviour
{
    // 스크롤 이펙트 관련
    public RectTransform[] List;
    public int count;
    private float suit_pos, goggle_pos, flipper_pos;
    private float suit_movepos, goggle_movepos, flipper_movepos;
    private bool suit_IsScroll = false, goggle_IsScroll = false, flipper_IsScroll = false;
    // 사운드 이펙트
    public AudioSource bgm, upgrade_click;

    public Text Haenyeo_money;
    public GameObject playerprefs_delete;

    public equipment_info[] suits;
    public equipment_info[] goggles;
    public equipment_info[] flippers;

    public Text[] suit_upgrade_price_text;        // 업그레이드에 필요한 가격 텍스트. 활성화,비활성화 2개
    public Text[] goggle_upgrade_price_text;
    public Text[] flipper_upgrade_price_text;

    public GameObject suit_enable_button;      // 해녀복 활성화 버튼
    public GameObject suit_disable_button;     // 해녀복 비활성화 버튼
    public GameObject goggle_enable_button;    // 물안경 활성화 버튼
    public GameObject goggle_disable_button;   // 물안경 비활성화 버튼
    public GameObject flipper_enable_button;   // 오리발 활성화 버튼
    public GameObject flipper_disable_button;  // 오리발 비활성화 버튼


    // 해녀가 장착하고 있는 장비
    public static int my_suit = 0;
    public static int my_goggle = 0;
    public static int my_flipper = 0;


    //IEnumerator upgrade_effect()
    
    public void return_to_farm()
    {
        data_save();
        SceneManager.LoadScene("farm");
    }

    void Update()
    {
        init_equipment();
        if((Haenyeo.money >= suits[my_suit].next_upgrade_price))
        {
            suit_disable_button.SetActive(false);
            suit_enable_button.SetActive(true);
        }
        else
        {
            suit_disable_button.SetActive(true);
            suit_enable_button.SetActive(false);
        }
        if ((Haenyeo.money >= goggles[my_suit].next_upgrade_price))
        {
            goggle_disable_button.SetActive(false);
            goggle_enable_button.SetActive(true);
        }
        else
        {
            goggle_disable_button.SetActive(true);
            goggle_enable_button.SetActive(false);
        }
        if ((Haenyeo.money >= flippers[my_suit].next_upgrade_price))
        {
            flipper_disable_button.SetActive(false);
            flipper_enable_button.SetActive(true);
        }
        else
        {
            flipper_disable_button.SetActive(true);
            flipper_enable_button.SetActive(false);
        }
    }
    public void scroll_up(int index)
    {
        switch (index)
        {
            case 0:
                if (List[index].rect.yMin - List[index].rect.yMax / count == suit_movepos)
                {

                }
                else
                {
                    List[0].gameObject.SetActive(true);
                    suit_IsScroll = true;
                    suit_movepos = suit_pos - List[index].rect.height / count;
                    suit_pos = suit_movepos;
                    StartCoroutine(scroll(index));
                }
                break;
            
            case 1:
                if (List[index].rect.yMin - List[index].rect.yMax / count == goggle_movepos)
                {

                }
                else
                {
                    List[1].gameObject.SetActive(true);
                    goggle_IsScroll = true;
                    goggle_movepos = goggle_pos - List[index].rect.height / count;
                    goggle_pos = goggle_movepos;
                    StartCoroutine(scroll(index));
                }
                break;
            
            case 2:
                if (List[index].rect.yMin - List[index].rect.yMax / count == flipper_movepos)
                {

                }
                else
                {
                    List[2].gameObject.SetActive(true);
                    flipper_IsScroll = true;
                    flipper_movepos = flipper_pos - List[index].rect.height / count;
                    flipper_pos = flipper_movepos;
                    StartCoroutine(scroll(index));
                }
                break;
        }
        
    }

    IEnumerator scroll(int index)
    {
        switch (index)
        {
            case 0:
                while (suit_IsScroll)
                {
                    List[index].localPosition = Vector2.Lerp(List[index].localPosition, new Vector2(0, suit_movepos), Time.deltaTime * 5);
                    if (Vector2.Distance(new Vector2(0, suit_movepos), List[index].localPosition) < 0.1f)
                    {
                        suit_IsScroll = false;
                    }
                    yield return null;
                }
                break;
            
            case 1:
                while (goggle_IsScroll)
                {
                    List[index].localPosition = Vector2.Lerp(List[index].localPosition, new Vector2(0, goggle_movepos), Time.deltaTime * 5);
                    if (Vector2.Distance(new Vector2(0, goggle_movepos), List[index].localPosition) < 0.1f)
                    {
                        goggle_IsScroll = false;
                    }
                    yield return null;
                }
                break;
            case 2:
                while (flipper_IsScroll)
                {
                    List[index].localPosition = Vector2.Lerp(List[index].localPosition, new Vector2(0, flipper_movepos), Time.deltaTime * 5);
                    if (Vector2.Distance(new Vector2(0, flipper_movepos), List[index].localPosition) < 0.1f)
                    {
                        flipper_IsScroll = false;
                    }
                    yield return null;
                }
                break;
        }
    }

    void Awake()
    {
        init_equipment();
        if (my_suit == 1)
        {
            suits[0].gameObject.transform.SetAsFirstSibling();
            suits[1].gameObject.transform.SetAsLastSibling();
        }
        if (my_suit == 2)
        {
            suits[2].gameObject.transform.SetAsLastSibling();
        }
        if (my_goggle == 1)
        {
            goggles[0].gameObject.transform.SetAsFirstSibling();
            goggles[1].gameObject.transform.SetAsLastSibling();
        }
        if (my_goggle == 2)
        {
            goggles[2].gameObject.transform.SetAsLastSibling();
        }
        if (my_flipper == 1)
        {
            flippers[0].gameObject.transform.SetAsFirstSibling();
            flippers[1].gameObject.transform.SetAsLastSibling();
        }
        if (my_flipper == 2)
        {
            flippers[2].gameObject.transform.SetAsLastSibling();
        }
        bgm.volume = PlayerPrefs.GetFloat("Bgm_volume", 1);
        upgrade_click.volume = PlayerPrefs.GetFloat("Effect_volume", 1);

            // 임의로 해녀 돈 조정
            //Haenyeo.money += 5000000;

            Haenyeo_money.text = Haenyeo.money.ToString("N0");
 //           init_equipment();

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        suit_pos = List[i].localPosition.y;
                        suit_movepos = List[i].rect.yMax - List[i].rect.yMax / count;
                        break;
                    
                    case 1:
                        goggle_pos = List[i].localPosition.y;
                        goggle_movepos = List[i].rect.yMax - List[i].rect.yMax / count;
                        break;

                    case 2:
                        flipper_pos = List[i].localPosition.y;
                        flipper_movepos = List[i].rect.yMax - List[i].rect.yMax / count;
                        break;

                }
            }
        }

        // 장비 정보 초기화
        public void init_equipment()
        {
            my_suit = PlayerPrefs.GetInt("PLAYER_SUIT", 1);
            my_goggle = PlayerPrefs.GetInt("PLAYER_GOGGLE", 1);
            my_flipper = PlayerPrefs.GetInt("PLAYER_FLIPPER", 1);

            // 해녀복
            for (int i = 0; i < suits.Length; i++)
            {
                if (i == my_suit)
                {
                    // suits[i].gameObject.SetActive(true);
                    suits[i].equip_name.gameObject.SetActive(true);

                    if (suits.Length - 1 == i)    // 업그레이드가 최대치인 경우
                    {
                        suit_enable_button.SetActive(false);
                        suit_disable_button.SetActive(true);
                        for (int j = 0; j < suit_upgrade_price_text.Length; j++)
                        {
                            suit_upgrade_price_text[j].text = "Max";

                        }
                    }
                    else
                    {
                        if (Haenyeo.money >= suits[i].next_upgrade_price) // 업그레이드에 필요한 돈이 충분하다면
                        {
                            suit_enable_button.SetActive(true);
                            suit_disable_button.SetActive(false);
                        }
                        else
                        {
                            suit_enable_button.SetActive(false);
                            suit_disable_button.SetActive(true);
                        }

                        for (int j = 0; j < suit_upgrade_price_text.Length; j++)
                        {
                            suit_upgrade_price_text[j].text = suits[i].next_upgrade_price.ToString("N0");   // "NO" 적으면 돈처럼 콤마 표시. 
                        }
                        //for (int j = 0; j < suits[j].time_up.)
                    }
                }
                else
                {
                    //suits[i].gameObject.SetActive(false);
                    suits[i].equip_name.gameObject.SetActive(false);
                }
                suits[i].equipment_info_obj.SetActive(false);
            }

            // 물안경
            for (int i = 0; i < goggles.Length; i++)
            {
                if (i == my_goggle)
                {
                    //goggles[i].gameObject.SetActive(true);
                    goggles[i].equip_name.gameObject.SetActive(true);
                    if (goggles.Length - 1 == i)    // 업그레이드가 최대치인 경우
                    {
                        goggle_enable_button.SetActive(false);
                        goggle_disable_button.SetActive(true);
                        for (int j = 0; j < goggle_upgrade_price_text.Length; j++)
                        {
                            goggle_upgrade_price_text[j].text = "Max";
                        }
                    }
                    else
                    {
                        if (Haenyeo.money >= goggles[i].next_upgrade_price) // 업그레이드에 필요한 돈이 충분하다면
                        {
                            goggle_enable_button.SetActive(true);
                            goggle_disable_button.SetActive(false);
                        }
                        else
                        {
                            goggle_enable_button.SetActive(false);
                            goggle_disable_button.SetActive(true);
                        }

                        for (int j = 0; j < goggle_upgrade_price_text.Length; j++)
                        {
                            goggle_upgrade_price_text[j].text = goggles[i].next_upgrade_price.ToString("N0");
                        }
                    }
                }
                else
                {
                    // goggles[i].gameObject.SetActive(false);
                    goggles[i].equip_name.gameObject.SetActive(false);
                }
                goggles[i].equipment_info_obj.SetActive(false);
            }

            // 오리발
            for (int i = 0; i < flippers.Length; i++)
            {
                if (i == my_flipper)
                {
                    //flippers[i].gameObject.SetActive(true);
                    flippers[i].equip_name.gameObject.SetActive(true);
                    if (flippers.Length - 1 == i)    // 업그레이드가 최대치인 경우
                    {
                        flipper_enable_button.SetActive(false);
                        flipper_disable_button.SetActive(true);
                        for (int j = 0; j < flipper_upgrade_price_text.Length; j++)
                        {
                            flipper_upgrade_price_text[j].text = "Max";
                        }
                    }
                    else
                    {
                        if (Haenyeo.money >= flippers[i].next_upgrade_price) // 업그레이드에 필요한 돈이 충분하다면
                        {
                            flipper_enable_button.SetActive(true);
                            flipper_disable_button.SetActive(false);
                        }
                        else
                        {
                            flipper_enable_button.SetActive(false);
                            flipper_disable_button.SetActive(true);
                        }

                        for (int j = 0; j < flipper_upgrade_price_text.Length; j++)
                        {
                            flipper_upgrade_price_text[j].text = flippers[i].next_upgrade_price.ToString("N0");
                        }
                    }
                }
                else
                {
                    //flippers[i].gameObject.SetActive(false);
                    flippers[i].equip_name.gameObject.SetActive(false);
                }
                flippers[i].equipment_info_obj.SetActive(false);
            }

        }




        // 해녀복 레이아웃 보이기
        public void suit_info()
        {
            // 해녀 장비의 레이아웃 오브젝트가 꺼져있으면 켜주고 켜져있으면 꺼줌
            if (suits[my_suit].equipment_info_obj.activeSelf == false)
            {
                suits[my_suit].equipment_info_obj.SetActive(true);
            }
            else
            {
                suits[my_suit].equipment_info_obj.SetActive(false);
            }
        }
        // 물안경 레이아웃 켜기/끄기
        public void goggle_info()
        {

            if (goggles[my_goggle].equipment_info_obj.activeSelf == false)
            {
                goggles[my_goggle].equipment_info_obj.SetActive(true);
            }
            else
            {
                goggles[my_goggle].equipment_info_obj.SetActive(false);
            }
        }
        // 오리발 레이아웃 켜기/끄기
        public void flipper_info()
        {

            if (flippers[my_flipper].equipment_info_obj.activeSelf == false)
            {
                flippers[my_flipper].equipment_info_obj.SetActive(true);
            }
            else
            {
                flippers[my_flipper].equipment_info_obj.SetActive(false);
            }
        }


        // 해녀복 업그레이드 버튼 클릭
        public void suit_upgrade_click()
        {
        if (Haenyeo.money >= suits[my_suit].next_upgrade_price&&(my_suit!=2))
        {
            
            upgrade_click.PlayOneShot(upgrade_click.clip);
            Haenyeo.money -= suits[my_suit].next_upgrade_price;
            PlayerPrefs.SetInt("PLAYER_SUIT", my_suit + 1);
            init_equipment();
            scroll_up(0);
            Haenyeo_money.text = Haenyeo.money.ToString("N0");
            for (int i = 0; i < suits.Length; i++)
            {
                if (suits.Length - 1 == i)
                {

                }
                else if (my_suit == i)
                {
                    Haenyeo.diving_time += suits[i].time_up;

                }
            }
        }

        }

        // 물안경 업그레이드 버튼 클릭
        public void goggle_upgrade_click()
        {
        if (Haenyeo.money >= goggles[my_goggle].next_upgrade_price&&(my_goggle!=2))
        {
            upgrade_click.PlayOneShot(upgrade_click.clip);
            Haenyeo.money -= goggles[my_goggle].next_upgrade_price;
            PlayerPrefs.SetInt("PLAYER_GOGGLE", my_goggle + 1);
            init_equipment();
            scroll_up(1);
            Haenyeo_money.text = Haenyeo.money.ToString("N0");
            for (int i = 0; i < goggles.Length; i++)
            {
                if (goggles.Length - 1 == i)
                {

                }
                else if (my_goggle == i)
                {
                    Haenyeo.diving_time += goggles[i].time_up;

                }
            }
        }
        } 


    // 오리발 업그레이드 버튼 클릭
    public void flipper_upgrade_click()
    {
        if (Haenyeo.money >= flippers[my_flipper].next_upgrade_price&&(my_flipper!=2))
        {
            upgrade_click.PlayOneShot(upgrade_click.clip);
            Haenyeo.money -= flippers[my_flipper].next_upgrade_price;
            PlayerPrefs.SetInt("PLAYER_FLIPPER", my_flipper + 1);
            init_equipment();
            scroll_up(2);
            Haenyeo_money.text = Haenyeo.money.ToString("N0");
            for (int i = 0; i < flippers.Length; i++)
            {
                if (flippers.Length - 1 == i)
                {


                }
                else if (my_flipper == i)
                {
                    //Haenyeo.moving_speed *= (int)((flippers[i].speed_up * 0.01) + 1);
                    // 스피드 변수가 int라서... 고민
                    Haenyeo.moving_speed += 1;

                }
            }
        }
    }



    public void delete_click()
    {
        PlayerPrefs.DeleteAll();
    }

    public void data_save()
    {
        //데이터 저장

        PlayerPrefs.SetInt("Haenyeo" + "_" + "money", Haenyeo.money);
        PlayerPrefs.SetInt("Haenyeo_diving_time", Haenyeo.diving_time);
        PlayerPrefs.SetInt("Haenyeo_moving_speed", Haenyeo.moving_speed);
        PlayerPrefs.SetInt("Haenyeo_level", Haenyeo.level);
        PlayerPrefs.SetInt("PLAYER_SUIT", my_suit);
        PlayerPrefs.SetInt("PLAYER_GOGGLE", my_goggle);
        PlayerPrefs.SetInt("PLAYER_FLIPPER", my_flipper);

        PlayerPrefs.Save();
    }    

    public void data_load()
    {

        Haenyeo.money = PlayerPrefs.GetInt("Haenyeo_money", 500000);
        Haenyeo.debt = PlayerPrefs.GetInt("Haenyeo_debt", 10000000);
        Haenyeo.diving_time = PlayerPrefs.GetInt("Haenyeo_diving_time", 60);
        Haenyeo.moving_speed = PlayerPrefs.GetInt("Haenyeo_moving_speed", 5);
        PlayerPrefs.SetInt("PLAYER_SUIT", my_suit);
        PlayerPrefs.SetInt("PLAYER_GOGGLE", my_goggle);
        PlayerPrefs.SetInt("PLAYER_FLIPPER", my_flipper);

    }

}




