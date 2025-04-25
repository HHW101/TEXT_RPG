﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Acessory : Item
    {
        public Acessory(Item item) //가격,착용레벨,소지 여부, 장착 여부
           : base(item.ID, item.Name, item.Type, item.Atk??0, item.Def??0,
                 0, 0, item.HP??0, item.MP ?? 0, 0, 0, item.Price ?? 0, item.Level ?? 0,
                 item.IsHave, item.IsEquipped, item.MainType) 
        {
        }


       

        public override string show(int i)
        {
          
            string display = "";
            if (i == 0)
            {
                if (IsEquipped)
                    display = ($"[red][[E]][/]{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");
                else
                    display = ($"{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");
            }
            else
            {
                if (IsHave)
                    display += ($"[gray]{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 판매완료[/]");
                else
                    display = ($"{Name,-15} | {Type,-5} | 공격력 : {Atk,-5} | 방어력 : {Def,-5} | 치명타율 : {Critical,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price} ");

            }
            return display;
        }
        


    }
}
