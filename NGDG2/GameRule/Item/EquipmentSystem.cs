using System.Collections.Generic;
using System.Linq;

namespace NGDG2
{
    /// <summary>
    /// 장비 아이템 체계
    /// 캐릭터가 장착하는 장비 아이템은 이 규칙을 따른다.
    /// </summary>
    public class EquipmentSystem
    {
        /// <summary>
        /// 장착중인 장비
        /// </summary>
        public List<Equipment> equipments;

        public EquipmentSystem()
        {
            equipments = new List<Equipment>();
        }

        /// <summary>
        /// 장착중인 장비를 추가한다.
        /// 이 메서드는 캐릭터 데이터를 불러올 경우에만 호출한다.
        /// </summary>
        /// <param name="equipment">장비</param>
        public void Add(Equipment equipment)
        {
            equipments.Add(equipment);
        }

        /// <summary>
        /// 장비를 장착한다.
        /// </summary>
        /// <param name="newEquipment">장착할 장비</param>
        /// <returns>장착에 성공하면 true, 실패하면 false</returns>
        public bool Equip(Equipment newEquipment)
        {
            // 장착하는 장비가 없음
            if (newEquipment == null)
                return false;

            // 직업 제한
            if (newEquipment.EqType == Equipment.EquipmentType.Sword && Character.Class.ClassType != Class.Type.Warrior)
                return false;
            if (newEquipment.EqType == Equipment.EquipmentType.Staff && Character.Class.ClassType != Class.Type.Magician)
                return false;
            if (newEquipment.EqType == Equipment.EquipmentType.Gun && Character.Class.ClassType != Class.Type.Gunner)
                return false;

            // 레벨 제한
            if (newEquipment.Level > Character.Level)
                return false;

            /* 장비 장착 */
            // 같은 부위의 장비
            var samePartEquipment = equipments.Find(eq => eq.Part.Equals(newEquipment.Part));

            // 새로운 장비 장착
            equipments.Add(newEquipment);
            Character.Inventory.Remove(newEquipment, 1);

            // 같은 부위의 장비를 장착하고 있었다면 장비를 해제
            if (samePartEquipment != null)
            {
                Release(samePartEquipment);
            }

            // 장비 장착 성공
            return true;
        }

        /// <summary>
        /// 장비를 해제한다.
        /// </summary>
        /// <param name="equipment">해제할 장비</param>
        /// <returns>해제에 성공하면 true, 실패하면 false</returns>
        public bool Release(Equipment equipment)
        {
            // 해제하는 장비가 없음
            if (equipment == null)
                return false;

            // 인벤토리에 빈 공간이 없음
            if (Character.Inventory.Slots.Count(s => s.IsEmpty()) <= 0)
                return false;

            // 장착했던 장비를 인벤토리로 꺼냄(장비 해제)
            equipments.Remove(equipment);
            Character.Inventory.Add(equipment, 1);

            // 장비 해제 성공
            return true;
        }

        /// <summary>
        /// 장비를 해제한다.
        /// </summary>
        /// <param name="part">해제할 부위</param>
        /// <returns>해제에 성공하면 true, 실패하면 false</returns>
        public bool Release(Equipment.EquipmentPart part)
        {
            return Release(GetEquipment(part));
        }

        /// <summary>
        /// 해당 부위의 장비를 얻는다.
        /// </summary>
        /// <param name="part">장비 부위</param>
        /// <returns>해당 부위의 장비</returns>
        public Equipment GetEquipment(Equipment.EquipmentPart part)
        {
            var equipment = equipments.Find(eq => eq.Part.Equals(part));

            return equipment == null ? new Equipment("없음") : equipment;
        }
    }
}
