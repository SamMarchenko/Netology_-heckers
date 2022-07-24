using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Checker
{
    public class CheckerView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CheckerType _checkerType;
        public CheckerType CheckerType => _checkerType;
        
        public delegate void ClickEventHandler(CheckerView component);

        public event ClickEventHandler OnCheckerClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnCheckerClick?.Invoke(this);
        }

        public IEnumerator MoveRoutine(Vector3 endPosition)
        {
            while (transform.position != endPosition)
            {
                transform.position = Vector3.Lerp(transform.position, endPosition, 1f);
                yield return null;
            }
        }
    }
}