﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Unit :IShow
    {
        public int ID { get; set; } //유닛 별 ID 
        public string Name { get; set; } // 플레이어 이름
        public int Level { get; set; } = 1; // 플레이어 레벨
        public int Exp { get; set; } // 현재 경험치
        public float ATK { get; set; } // 기본 공격력
        public float DEF { get; set; } // 기본 방어력`
        public int MaxHp { get; set; } // 최대 체력
        public int CurrentHP { get; set; } // 현재 체력
        public int MaxMp { get; set; } // 최대 마나
        public int CurrentMP { get; set; } // 현재 마나
        public int Gold { get; set; } // 소지 골드
        public int Speed { get; set; } // 속도... 선턴 잡습니다...
        public bool IsWeak { get; set; } // 약점 찌름 당함...
        public float Evasion { get; set; } // 회피율
        public float Critical { get; set; } // 치명타율
        public string? IMG {  get; set; }
        public string? skill { get; set; }

        public TYPE WeakType { get; set; } = TYPE.Normal;

        public List<Skill> skills = new(); // 보유 스킬 리스트
        public bool IsAlive => CurrentHP > 0;
        public virtual float showAtk()
        {
            return ATK;
        }
        public List<Item> items;
        public void Init()
        {
            CurrentMP = MaxMp;
            CurrentHP = MaxHp;
        }
        public Monster clone()
        {
            return new Monster();
        }
        public virtual bool TakeDamage(int atkD)
        {


            CurrentHP -= atkD;
            
            if (CurrentHP <= 0) {
                Dead();
                return true;
            }
            return false;
        }
        public virtual void ShowSimple()
        {
            if (!IsAlive) { 
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Lv.{Level} {Name} 기절");
            Console.ResetColor(); 
          }
            else Console.WriteLine($"Lv.{Level} {Name} HP {CurrentHP}/{MaxHp}");
        }
        


        protected virtual void Dead() {
            Console.WriteLine($"{Name} 사망");
            //아마 여기            
            QuestManager.Instance().DeadCheck(ID);
        }

        public virtual string show(int mode)
        {
            string x = IMG;
            x += "\n\n";
            if (!IsAlive)
            {
                
                x+=$" [gray]Lv.{Level} {Name}\n 기절[/]";
            
            }
            else x+=$" Lv.{Level} {Name}\n HP {CurrentHP}/{MaxHp}";
            return x;
        }

        public string showDetail()
        {
            string x = $"Lv.{Level} {Name} HP {CurrentHP}/{MaxHp}\n";
            x += $"공격력:{ATK} 방어력: {DEF}\n";
            x += $"속도:{Speed} 치명률: {Critical}\n";
            x += $"회피율:{Evasion} 속성: {WeakType.ToString()}\n";
            return x;
        }
    }
}
