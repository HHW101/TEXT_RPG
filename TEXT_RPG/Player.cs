﻿using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Player :Unit
    {
     
        //공격 처리를 위하여 Unit에게 상속 받게 함.

        public Job Job { get; set; } // 플레이어 직업


        public float TotalAttack => ATK + CalculateEquippedBonuses().Attack; //최종 공격력
        public float TotalDefense => DEF + CalculateEquippedBonuses().Defense; //최종 방어력

        public int TotalMaxHP => MaxHP + CalculateEquippedBonuses().MaxHP; //최종 최대 체력
        public int MaxHP { get; set; } // 기본 최대 체력
        public int TotalMaxMP => MaxMP + CalculateEquippedBonuses().MaxMP; //최종 최대 마나
        public int MaxMP { get; set; } // 기본 최대 마나

       


        public bool IsAlive => CurrentHP > 0; //살아있나 확인...

        public List<Item> equippedItems = new();//착용한 아이템 리스트
        public List<Item> inventory = new(); // 인벤토리 아이템 리스트
      
        public void SetJob(Dictionary<string, object> data)
        {
            Job = (Job)Enum.Parse(typeof(Job), (string)data["Name"]);
            MaxHP = Convert.ToInt32(data["MaxHP"]); //(int)로 변환시 에러 발생
            CurrentHP = MaxHP;
            MaxMP = Convert.ToInt32(data["MaxMP"]);
            CurrentMP = MaxMP;
            ATK = Convert.ToSingle(data["Attack"]);
            DEF = Convert.ToSingle(data["Defense"]);
            Speed = Convert.ToInt32(data["Speed"]);
            WeakType = TYPE.Dark;
            string skiD = (string)data["skill"];
            string[] a = skiD.Split(',');
            foreach(string n in a){
               skills.Add( DataManager.Instance().MakeSkill(int.Parse(n)));
            }
        }
        public void ShowStat() //플레이어 스텟 보여주기
        {
            BonusStat bonus = CalculateEquippedBonuses();

            Console.WriteLine($"Lv.{Level}");
            Console.WriteLine($"{Name} ( {Job.ToString()} )");
            Console.WriteLine($"공격력 : {TotalAttack} (+{bonus.Attack})");
            Console.WriteLine($"방어력 : {TotalDefense} (+{bonus.Defense})");
            Console.WriteLine($"HP : {CurrentHP} / {TotalMaxHP} (+{bonus.MaxHP})");
            Console.WriteLine($"MP : {CurrentMP} / {TotalMaxMP} (+{bonus.MaxMP})");
            Console.WriteLine($"회피율 : {Evasion} (+{bonus.Evasion})");
            Console.WriteLine($"치명타율 : {Critical} (+{bonus.Critical})");
            Console.WriteLine($"Gold : {Gold} G");
        }
        public BonusStat CalculateEquippedBonuses()//플레이어 장착 아이템 능력치 총합 계산
        {
            BonusStat bonus = new();

            foreach (var item in equippedItems)
            {
                switch (item.Type)
                {
                    case "weapon":
                        bonus.Attack += item.Atk ?? 0f;
                        bonus.Critical += item.Critical ?? 0f;
                        break;
                    case "armor":
                        bonus.Defense += item.Def ?? 0f;
                        bonus.Evasion += item.Dodge ?? 0f;
                        bonus.MaxHP += item.HP ?? 0;
                        bonus.MaxMP += item.MP ?? 0;
                        break;
                    default:
                        bonus.Evasion += item.Dodge ?? 0f;
                        bonus.Critical += item.Critical ?? 0f;
                        bonus.MaxHP += item.HP ?? 0;
                        bonus.MaxMP += item.MP ?? 0;
                        break;
                }
            }

            return bonus;
        }

        public void ShowInventory() { }
        public void ShowSkillList() //플레이어 스킬 목록 표시
        {
            Console.WriteLine($"[{Name}]의 스킬 목록:");
            for (int i = 0; i < skills.Count; i++)
            {
                Skill skill = skills[i];
                Console.WriteLine($"{i + 1}. {skill.Name} - {skill.Description} (MP: {skill.MPCost})");
            }
        }
        public void LevelUp() //플레이어 레벨업
        {
            Level++;
            ATK += 1;
            DEF += 1;
            MaxHP += 1;
            MaxMP += 1;
            CurrentHP = TotalMaxHP;
            CurrentMP = TotalMaxMP;
            //레벨업시 추가 요소 여기다 작성

        }
     
        protected override void Dead()//플레이어 죽음
        {
            //마을(타이틀)로 돌아감
            //패널티가 있다면 여기에
            base.Dead();

        }

        public Skill UseSkill()//스킬 선택 후 사용
        {
            if (skills == null || skills.Count == 0)
            {
                Console.WriteLine("사용 가능한 스킬이 없습니다.");
                return null;
            }
            List<int> validInputs = new List<int>();
            for (int i = 0; i < skills.Count; i++)
            {
                Skill skill = skills[i];
                Console.WriteLine($"{i + 1}. {skill.Name} 피해량 : {(int)TotalAttack * skill.Damage} 타겟수:{skill.TargetNum} (MP: {skill.MPCost})");
                validInputs.Add(i + 1);

            }
            int a = GameManager.GetValidInput(validInputs) - 1;

            return skills[a];
        }

        public void GetItem(Item item)//아이템 획득
        {
            inventory.Add(item);
        }

        public void UseItem(Item item) // 포션 사용
        {
            if (item.Type == "HP" && CurrentHP < TotalMaxHP && item.IsHave)
            {
                CurrentHP += item.RecoverHP ?? 0;
                if (CurrentHP > TotalMaxHP)
                    CurrentHP = TotalMaxHP;

                Console.WriteLine($"{Name}을 사용하여 HP {item.RecoverHP} 회복했습니다.");
            }
            else if (item.Type == "MP" && CurrentMP < TotalMaxMP && item.IsHave)
            {
                CurrentMP += item.RecoverMP ?? 0;
                if (CurrentMP > TotalMaxMP)
                    CurrentMP = TotalMaxMP;

                Console.WriteLine($"{Name}을 사용하여 MP {item.RecoverMP} 회복했습니다.");
            }
            else
            {
                Console.WriteLine($"{Name}을 사용할 수 없습니다.");
            }
        }
    }

}
