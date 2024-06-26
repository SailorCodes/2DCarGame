using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform ActiveSets, PassiveSets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckForVisibility());
    }
    private IEnumerator CheckForVisibility()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (!isVisible(ActiveSets.GetChild(0).GetChild(0)))
            {
                Recyle();
            }
        }
    }

        private bool isVisible(Transform obj)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                return renderer.isVisible;
            }
            return false;
        }



        private void Recyle()
        {
            Transform randomSet = PassiveSets.GetChild(Random.Range(0, PassiveSets.childCount));
            randomSet.parent = ActiveSets;
            randomSet.localPosition = ActiveSets.GetChild(ActiveSets.childCount - 2).localPosition + new Vector3(0, 12.5f, 0);
            randomSet.SetAsLastSibling();

            randomSet = ActiveSets.GetChild(0);
            randomSet.parent = PassiveSets;
            randomSet.localPosition = PassiveSets.GetChild(0).localPosition;
        }
}