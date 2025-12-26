using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image[] heartImages;
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite threeQuartersHeart;
    [SerializeField] private Sprite halfHeart;
    [SerializeField] private Sprite quarterHeart;
    [SerializeField] private Sprite emptyHeart;
    private Heart currentHeart;
    private readonly List<Heart> hearts = new();

    public void Awake()
    {
        foreach (Image heartImage in heartImages)
        {
            hearts.Add(new Heart(heartImage, this, 1));
        }

        currentHeart = hearts[healthManager.MaxHearts - 1];
        DisplayHearts();
    }

    //Update health ui after damage is taken or player is healed.
    public void DamageUI(float lostHp)
    {
        Heart currentHeart;

        for (int i = healthManager.MaxHearts - 1; i >= 0; i--)
        {
            currentHeart = hearts[i];

            //If lost hp is greater than the number of fragments in the current heart. set the fragments minus the fragments and move on to next heart.
            if (lostHp > currentHeart.Fragments)
            {
                lostHp -= currentHeart.Fragments;
                currentHeart.SetHeartFragments(0);
                print("1 lost " + currentHeart.Fragments);
            }
            //If lost hp is less than current fragments, remove lost hp from heart and exit loop.
            else
            {
                currentHeart.SetHeartFragments(currentHeart.Fragments - lostHp);
                print("2 lost " + currentHeart.Fragments);
                //if(currentHeart.Fragments == 0 && currentHeart != hearts[0])
                //{
                  //  currentHeart = hearts[i-1];
               // }

                break;
            }
        }
    }

    public void RegenSingleUI()
    {   
        Heart currentHeart;
        float remainderToHeal = 1;

        for(int i = 0; i < healthManager.MaxHearts; i ++)
        {
            currentHeart = hearts[i];

            if(currentHeart.Fragments == 0)
            {
                currentHeart.SetHeartFragments(remainderToHeal);
                break;
            }
            else if(currentHeart.Fragments > 0 && currentHeart.Fragments < 1)
            {
                remainderToHeal = 1 - currentHeart.Fragments;
                currentHeart.SetHeartFragments(1); 
            }
        }
    } 

    //Display all available hearts up to the maxHearts from healthManager.
    public void DisplayHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i <= healthManager.MaxHearts - 1)
            {
                hearts[i].HeartImage.enabled = true;
            }
            else
            {
                hearts[i].HeartImage.enabled = false;
            }
        }
    }

    //Represents a single heart.
    public class Heart
    {
        private readonly Image heartImage;
        private readonly HealthUI ui;
        private float fragments;

        public Heart(Image heartImage, HealthUI ui, float fragments)
        {
            this.heartImage = heartImage;
            this.ui = ui;
            this.fragments = fragments;
        }

        public Image HeartImage { get { return heartImage; } }
        public float Fragments { get { return fragments; } }

        public void SetHeartFragments(float fragments)
        {
            switch (fragments)
            {
                case 0.25f:
                    heartImage.sprite = ui.quarterHeart;
                    break;
                case 0.5f:
                    heartImage.sprite = ui.halfHeart;
                    break;
                case 0.75f:
                    heartImage.sprite = ui.threeQuartersHeart;
                    break;
                case 1f:
                    heartImage.sprite = ui.fullHeart;
                    break;
                case 0f:
                    heartImage.sprite = ui.emptyHeart;
                    break;
            }

            this.fragments = fragments; 
        }
    }
}


