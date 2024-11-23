using UnityEngine;

namespace View
{
    public class HandleHighlighter : MonoBehaviour
    {
        [SerializeField] private GameObject _highlightCircle;

        public void SetState(bool isActive)
        {
            _highlightCircle.SetActive(isActive);
        }
    }
}