using System.Collections;
using UnityEngine;

public class TutorialScroll : MonoBehaviour
{
    [SerializeField] private float betweenTime;
    [SerializeField] private float betweenCiclesTime;
    [SerializeField] private GameObject[] scrollList;


    private void Start()
    {

        StartCoroutine(GoUp());

    }


    private IEnumerator GoUp()
    {
        while (true)
        {
            for (int i = 0; i < scrollList.Length; i++)
            {
                scrollList[i].SetActive(true);

                yield return new WaitForSeconds(betweenTime);


            }

            yield return new WaitForSeconds(betweenCiclesTime);

            for (int i = 0; i < scrollList.Length; i++)
            {
                scrollList[i].SetActive(false);
            }
            
        }
        yield return null;
    }
}
