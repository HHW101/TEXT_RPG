using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Potion : Item
    {
        public Potion(Item item) // 이름 ,타입 ,회복량 ,가격, 소지 여부
            : base(item.ID, item.Name, item.Type, 0, 0, 0, 0, 0, 0, item.RecoverHP??0, item.RecoverMP??0, item.Price??0, 0, item.IsHave, false, item.MainType)
        {

        }
    }
}
