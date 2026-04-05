using UnityEngine;

public class TutorialScroll : MonoBehaviour
{
    [SerializeField] private float betweenTime;
    [SerializeField] private float betweenCiclesTime;
    [SerializeField] private GameObject[] scrollList;


    private void Start()
    {
        for(int i =0; i < scrollList.Length; i++)
        {
            scrollList[i].SetActive(true);
            
            new WaitForSeconds(betweenTime);


        }

        new WaitForSeconds(betweenCiclesTime);

        for (int i = 0; i < scrollList.Length; i++)
        {
            scrollList[i].SetActive(false);
        }


    }
}
