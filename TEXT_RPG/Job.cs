using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Job
    {
        public int ID { get; set; }                 //아이디
        public string Name { get; set; }            //이름
        public int MaxHP { get; set; }              //기초체력
        public int MaxMP { get; set; }              //기초마나
        public float Attack { get; set; }           //기초공격력
        public float Defense { get; set; }          //기초방어력
        public int speed { get; set; }              //기초속도
        public List<Skill> SkillList { get; set; }  //기초 스킬목록
        public string skill { get; set; }           //?

        public void Init()
        {
            SkillList = new List<Skill>();
            string skill = "";
            string[] a = skill.Split(',');
            foreach (string n in a)
            {
                SkillList.Add(DataManager.Instance().MakeSkill(int.Parse(n)));
            }
        }

        public string showInfo()
        {
            SkillList = new List<Skill>();
            string skill = "";
            string[] a = skill.Split(',');
            foreach (string n in a)
            {
                SkillList.Add(DataManager.Instance().MakeSkill(int.Parse(n)));
            }

            string str = "\n";
            str += $"HP: {MaxHP}\n";
            str += $"MP: {MaxMP}\n";
            str += $"ATK: {Attack}\n";
            str += $"DEF: {Defense}\n";
            str += $"SPEED: {speed}\n";
            foreach (Skill s in SkillList)
            {
                str += $"{s.Name}: {s.Description} DMG: {s.Damage} {s.TargetNum}명\n";
            }
            return str;
        }
    }
}
