using UnityEngine;

namespace View
{
    public class HandleHighlighter
    {
        private GameObject _highlightCircle;

        public HandleHighlighter(GameObject highlightCircle)
        {
            _highlightCircle = highlightCircle;
        }

        public void SetState(bool isActive)
        {
            _highlightCircle.SetActive(isActive);
        }
    }
}