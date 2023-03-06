using UnityEngine.Events;

namespace GridSystem
{
    public interface ISelectable
    {
        public static UnityAction<Tile> OnSelect;
        bool IsSelected { get; set; }
        void Select();
        void Deselect();
    }
}