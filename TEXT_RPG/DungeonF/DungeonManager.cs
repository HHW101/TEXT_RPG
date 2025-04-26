﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Spectre.Console;

namespace TEXT_RPG
{
    internal class DungeonManager
    {
        public int Floor = 1;
        public int nowFloor = 1;
        public int highFloor;
  
        Dungeon dungeon;
        Player player;

        Scene dungeonScene;


        //public void StartDungoen(Player player)//로비에서 첫번째로 던전을 눌렀을때
        //{
        //    Console.WriteLine("던전에 입장하였습니다.");
        //    bool isWin = dungeon.GoBattletF(player, dungeon.GetMonsterList(nowFloor));
        //    if (isWin)//승리씬?
        //    {
        //        Console.WriteLine("승리하셨습니다.");
        //        Console.WriteLine($"현재 층수 = {nowFloor}층");
        //        Console.WriteLine($"Lv : {player.Level} {player.Name}\nHP : {player.CurrentHP} / {player.TotalMaxHP}\n ");
        //        nowFloor++;
        //        FloorCheck();
        //        //ChoiceDungeon(nowFloor);
        //    }
        //    else
        //    {
        //        Console.WriteLine("패배하셨습니다.");
        //        Console.WriteLine($"Lv : {player.Level} {player.Name}\nHP : 0 / {player.TotalMaxHP}\n ");
        //        Console.WriteLine($"최고층수 : {nowFloor}");
        //        Console.WriteLine("\n잠시 후 처음으로 돌아갑니다.");
        //        nowFloor = 0;
        //        Thread.Sleep(10000);
        //        SceneManager.Instance().InitStartScene();
        //    }
        //}
        public void FloorCheck()//최고층수 갱신용
        {
            if (highFloor<nowFloor)
            {
                highFloor= nowFloor;
            }
        }
        public Dungeon makeDungeon()
        {
             dungeon = new BattleD();
            dungeon.Init(Floor);
            return dungeon;
        }
        public void Init(Player player)
        {
            this.player = player;
           InitDungeon();
        }
        public void Run()
        {
            bool isRun=true;
            while (isRun) {

                dungeonScene.Text("head", $"{nowFloor} 층");
                Dungeon nowD = SelectDungeon();


                if (nowD.Run(player))
                {
                    Floor++;
                }
                else break;

                if (Floor == 5)
                    break;
               
            }
        }



        //public bool DungeonRun(string type, int nowFloor)//던전을 한번 실행한다
        //{
        //    dungeon = new Dungeon();
        //    bool isWin;

        //    if (type == "전투층으로 진행")//전투방
        //    {
        //        isWin = dungeon.GoBattletF(player, dungeon.GetMonsterList(nowFloor));
        //    }
        //    else if (type == "이벤트층으로 진행")//이벤트방?
        //    {
        //        dungeon.GOEventF(player);
        //        return true;
        //    }
        //    else if (type == "휴식층으로 진행")//휴식방
        //    {
        //        dungeon.GoRestF(player);
        //        return true;
        //    }
        //    else //보상방
        //    {
        //        dungeon.GORewardF(player);
        //        return true;
        //    }
        //    return isWin;
        //}
        public void ChoiceDungeon()//선택지를 3개주어지게 하는 메서드
        {

            Random rnd = new Random();
        
            string[] arr = new string [3];

            for (int i = 0; i < 3; i++)
            {
                string message;
                    int dungeonNum = rnd.Next(1, 100);
                if (dungeonNum >= 0 && dungeonNum < 45)//전투방
                {
                    Console.WriteLine("전투방 입니다.");
                    message = "전투방";
                    
                }
                else if (dungeonNum >= 45 && dungeonNum < 75)//이벤트방?
                {
                    Console.WriteLine("이벤트방 입니다.");
                    message = "이벤트방";
                }
                else if (dungeonNum >= 75 && dungeonNum < 90)//휴식방
                {
                    Console.WriteLine("휴식방 입니다.");
                    message = "휴식방";
                }
                else //보상방
                {
                    Console.WriteLine("보상방입니다");
                    message = "보상방";
                }
               arr[i] = message;
            }
            foreach (string str in arr)
            {
                Console.WriteLine(str);
            }
        }


        //public bool ChoiceDungeon(int nowFloor)//선택지를 3개주어지게 하는 메서드
        //{

        //    Random rnd = new Random();
        //    string[] arr = new string[3];
        //    int dungeonNum = rnd.Next(1, 100);

        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (dungeonNum >= 0 && dungeonNum < 45)//전투방
        //        {
        //            arr[i] = "전투층으로 진행";

        //        }
        //        else if (dungeonNum >= 45 && dungeonNum < 75)//이벤트방?
        //        {
        //            arr[i] = "이벤트층으로 진행";
        //        }
        //        else if (dungeonNum >= 75 && dungeonNum < 90)//휴식방
        //        {
        //            arr[i] = "휴식층으로 진행";
        //        }
        //        else //보상방
        //        {
        //            arr[i] = "보상층으로 진행";
        //        }
        //    }
        //    Console.WriteLine("다음으로 진행할 층을 선택하세요.");
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        Console.WriteLine($"{i + 1}. {arr[i]}");
        //    }
        //    int input;
        //    while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 3)
        //    {
        //        Console.WriteLine("잘못된 입력입니다.");
        //    }
        //    return DungeonRun(arr[input - 1], nowFloor);
        //}

        public void InitDungeon()
        {
            Layout temp = new Layout();
            Layout head = new Layout("head");
            Layout info = new Layout("Text").Ratio(1);
            Layout btn1 = new Layout("room1");
            Layout btn2 = new Layout("room2");
            Layout btn3 = new Layout("room3");
            Layout order = new Layout("Order").Ratio(2);
            Dictionary<string, Layout> temp2 = new Dictionary<string, Layout>
            { { "btn1", btn1 }, { "btn2", btn2 }, { "btn3", btn3 }, { "head", head },{ "order",order},{ "info",info} };
            temp = new Layout();
            temp.SplitRows(new Layout(new Panel(new Text("Dungeon").Centered()).Expand()).Size(3), head,
                          new Layout().SplitColumns(

                       btn1, btn2, btn3).Ratio(5), order
                );
            dungeonScene = new Scene(temp, "Dungeon", temp2);

            dungeonScene.show();

        }
        public Dungeon SelectDungeon()
        {
            List<Dungeon> duns = new List<Dungeon>();
            for (int i = 0; i < 3; i++)
            {
                duns.Add(makeDungeon());
            }
            List<string> room = new List<string> { "btn1", "btn2", "btn3" };
            return dungeonScene.SelectPanelD(room,duns,"order");
        }

    }
}

       

//public bool DungeonRun(int nowfloor)//던전을 한번 실행한다
//{
//    dungeon = new Dungeon();
//    Random rnd = new Random();
//    int dungeonNum = rnd.Next(1, 100);
//    bool isWin;

//    if (dungeonNum >= 0 && dungeonNum < 45)//전투방
//    {
//        isWin = dungeon.GoBattletF(player, dungeon.GetMonsterList(nowfloor));

//    }
//    else if (dungeonNum >= 45 && dungeonNum < 75)//이벤트방?
//    {
//        dungeon.GOEventF(player);
//        return true;
//    }
//    else if (dungeonNum >= 75 && dungeonNum < 90)//휴식방
//    {
//        dungeon.GoRestF(player);
//        return true;
//    }
//    else //보상방
//    {
//        dungeon.GORewardF(player);
//        return true;
//    }
//    return isWin;
//}
//public void ChoiceDungeon()//선택지를 3개주어지게 하는 메서드
//{

//    Random rnd = new Random();
//    int dungeonNum = rnd.Next(1, 100);
//    string[] arr = new string[3];

//    for (int i = 0; i < 3; i++)
//    {
//        string message;
//        if (dungeonNum >= 0 && dungeonNum < 45)//전투방
//        {
//            Console.WriteLine("전투방 입니다.");
//            message = "전투방으로 진행";

//        }
//        else if (dungeonNum >= 45 && dungeonNum < 75)//이벤트방?
//        {
//            Console.WriteLine("이벤트방 입니다.");
//            message = "이벤트방으로 진행";
//        }
//        else if (dungeonNum >= 75 && dungeonNum < 90)//휴식방
//        {
//            Console.WriteLine("휴식방 입니다.");
//            message = "휴식방으로 진행";
//        }
//        else //보상방
//        {
//            Console.WriteLine("보상방입니다");
//            message = "보상방으로 진행";
//        }
//        arr[i] = message;
//    }
//    foreach (string str in arr)
//    {
//        Console.WriteLine(str);
//    }
//}
