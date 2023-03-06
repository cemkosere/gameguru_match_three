using UnityEngine;
using UnityEngine.Events;

namespace GridSystem
{
    public class Tile : MonoBehaviour, ISelectable
    {
        public static UnityAction<Tile> OnSelectTile = delegate {  };
        public Vector2Int Index { get; set; }
        
        [SerializeField] private GameObject selectIcon;
        
        public void Initialize(Vector2Int index)
        {
            Index = index;
        }
        private void OnMouseDown()
        {
            if (IsSelected)
            {
                Deselect();
            }
            else
            {
                Select();
            }
        }

        #region ISelectable
        public bool IsSelected { get; set; }
        public void Select()
        {
            if(IsSelected) return;
            IsSelected = true;
            selectIcon.SetActive(true);
            OnSelectTile?.Invoke(this);
            Debug.Log("IsSelected: " + IsSelected);
        }

        public void Deselect()
        {
            if(!IsSelected) return;
            IsSelected = false;
            selectIcon.SetActive(false);
            Debug.Log("IsSelected: " + IsSelected);
        }
        #endregion

        
    }
}