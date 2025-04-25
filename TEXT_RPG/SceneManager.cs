﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class SceneManager
    {
        private static SceneManager instance;
        public static SceneManager Instance()
        {
            if (instance == null)
                instance = new SceneManager();
            return instance;
        }
        Layout battlelayout;
        Layout Menulayout;
        Layout playerlayout;
        Layout Lobbylayout;
        Layout charaLayout;
<<<<<<< Updated upstream
        public int SetLobbyScene() //로비 
=======
        Layout shopLayout;
        Layout questLayout;
        Layout dungeonLayout;
        public int SetLobbyScene() //로비 씬 시작 
>>>>>>> Stashed changes
        {
            Lobbylayout= new Layout();
            Lobbylayout.SplitRows(new Layout(new Panel(
                new FigletText("TEXT MAPLE RPG")).Expand().SquareBorder()).Ratio(3), 
                new Layout("Start").Ratio(1),
                new Layout("End").Ratio(1));
            int index = 0;
            ConsoleKeyInfo key;
            bool isEnd = false;

      
            while (!isEnd)
            {
                if (index == 0)
                {
                    Lobbylayout["Start"].Update(
                 new Panel("[blink]시작[/]").AsciiBorder()
                    .Padding(1, 1));
                    Lobbylayout["End"].Update(
                 new Panel("종료").AsciiBorder()
                    .Padding(1, 1));

                }
                if (index == 1)
                {
                    Lobbylayout["Start"].Update(
                 new Panel("시작").AsciiBorder()
                    .Padding(1, 1));
                    Lobbylayout["End"].Update(
                 new Panel("[blink]종료[/]").AsciiBorder()
                    .Padding(1, 1));
                }
                AnsiConsole.Clear();
                AnsiConsole.Write(Lobbylayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index=1-index;
                        break;

                    case ConsoleKey.DownArrow:
                        index = 1 - index;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
            }

            return index;
        }
<<<<<<< Updated upstream
        public void CharaLayout()
=======
        public void InitCharaMake() //캐릭터 선택 창
>>>>>>> Stashed changes
        {
            charaLayout = new Layout();
            charaLayout.SplitRows(new Layout("menu").Ratio(1), new Layout("name").Ratio(1),new Layout().SplitColumns(new Layout("status").Ratio(3),new Layout("select").Ratio(1)).Ratio(5)
                );
            charaLayout["menu"].Update(new Panel(new Text("이름 입력").Centered()).Expand());
            charaLayout["name"].Update(new Panel(new Text("").Centered()).Expand());
            charaLayout["status"].Update(new Panel(new Text("").Centered()).Expand());
            charaLayout["select"].Update(new Panel(new Text("").Centered()).Expand());
            AnsiConsole.Console.Clear();
            AnsiConsole.Write(charaLayout);
        }
        public string setName()
        {
            ConsoleKeyInfo key;
            string input="";
            while (true) {
                key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Backspace &&input.Length > 0)
            {
                input =input.Remove(input.Length - 1);
                
            }
            else if(key.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if(!char.IsControl(key.KeyChar)&&key.KeyChar != ' ')
                    input+=key.KeyChar;

                AnsiConsole.Console.Clear();
                charaLayout["name"].Update(new Panel(new Text("\n"+input).Centered()).Expand());
                AnsiConsole.Write(charaLayout);

            }
            return input;
        }
        public int SetJob(List<string> menu)
        {
            bool isEnd = false;
            int i=-1;
            while (!isEnd) { 
                i = makeSelect(menu, charaLayout["select"]); 
            }
            return i;
        }
<<<<<<< Updated upstream
       
        public int MenuLayout()
=======
        public void InitDungeon()
        {
            dungeonLayout = new Layout();
            dungeonLayout.SplitRows(
                           new Layout(new Panel(new Text("Dungeon").Centered()).Expand()).Size(3),
                           new Layout("Middle")
                    .SplitRows(new Layout().SplitRows(
                        new Layout("dungeon"),
                        new Layout("room1"), new Layout("room2"), new Layout("room3")).Ratio(5), new Layout("Text").Ratio(1), new Layout("Order").Ratio(2))
                );
        }
        public int SelectDungeon()
        {
            int index=0;
            ConsoleKeyInfo key;
            bool isEnd = false;


            while (!isEnd)
            {
                switch (index)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
                if (index == 0)
                {
                   dungeonLayout["room1"].Update(
                 new Panel("[blink]던전 1[/]").AsciiBorder()
                    .Padding(1, 1));
                    dungeonLayout["room2"].Update(
                 new Panel("던전 2").AsciiBorder()
                    .Padding(1, 1));
                    dungeonLayout["room3"].Update(
                new Panel("던전 2").AsciiBorder()
                   .Padding(1, 1));

                }
                if (index == 1)
                {
                    dungeonLayout["room1"].Update(
                 new Panel("[blink]던전 1[/]").AsciiBorder()
                    .Padding(1, 1));
                    dungeonLayout["room2"].Update(
                 new Panel("던전 2").AsciiBorder()
                    .Padding(1, 1));
                    dungeonLayout["room3"].Update(
                new Panel("던전 2").AsciiBorder()
                   .Padding(1, 1));
                }
                AnsiConsole.Clear();
                AnsiConsole.Write(Lobbylayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index = 1 - index;
                        break;

                    case ConsoleKey.DownArrow:
                        index = 1 - index;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
            }

            return index;
            return 0;
        }
        public void InitQuest()
        {
            questLayout = new Layout();
            questLayout.SplitRows(
                new Layout(new Panel(new Text("퀘스트").Centered()).Expand()).Size(3),
                new Layout("questList").Ratio(5)
                    , new Layout("Order").Ratio(2)
                );
        }
        public int SelectQMenu()
        {
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            List<string> menu = new List<string>();
            menu.Add("퀘스트");
            menu.Add("히든 업적");
            menu.Add("뒤로");
            Layout layout = questLayout["Order"];
            while (!isEnd)
            {
                string a = "\n";
                for (int i = 0; i < menu.Count; i++)
                {
                    if (i + 1 == index)
                        a += ("[bold]-> " + menu[i] + "[/]\n");
                    else
                        a += (" " + menu[i] + "\n");
                }
                layout.Update(
                new Panel(a)
                   .Expand()
                   .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(questLayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        break;

                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
                if (index < 1)
                    index = menu.Count;
                if (index > menu.Count)
                    index = 1;
            }
            return index;
        }

        public Quest SelectQuest()
        {
            int index = 0;
            int page = 1;

            int num = 10;
            int maxIndex = QuestManager.Instance().Quests.Count - 1;

            int maxPage = maxIndex / num + 1;
            if (maxIndex % num == 0)
                maxPage--;

            bool isEnd = false;
            questLayout["Order"].Update(
                new Panel("")
                   .Expand()
                   .Padding(0, 0));
            AnsiConsole.Clear();
            AnsiConsole.Write(questLayout);
            while (!isEnd)
            {
                string txt = "";
                if (maxIndex > page * num)
                {
                    for (int i = (page - 1) * num; i <= page * num; i++)
                    {

                        if (index == i)
                            txt += "[bold]->" + QuestManager.Instance().Quests[i].show() + "[/]\n\n";
                        else
                            txt += QuestManager.Instance().Quests[i].show() + "\n\n";
                    }
                }
                else
                {
                    for (int i = (page - 1) * num; i <= maxIndex; i++)
                    {
                        if (index == i)
                            txt += "[bold]->" + QuestManager.Instance().Quests[i].show() + "[/]\n\n";
                        else
                            txt += QuestManager.Instance().Quests[i].show() + "\n\n";
                    }
                }

                questLayout["questList"].Update(
                  new Panel(txt)
                     .Expand()
                     .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(questLayout);
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < page * num)
                            index++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (page > 1)
                        {

                            page--;
                            index = (page - 1) * num;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (page < maxPage)
                            page++;
                        index = (page - 1) * num;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
            }
        
            return QuestManager.Instance().Quests[index];
        }

        public void confirmQuest(Quest quest)
        {
          
            List<string> menu;
            if (quest.IsClear)
            {
                menu = new List<string> { "보상받기", "돌아가기" };
                int i = makeSelect(menu, questLayout["Order"], questLayout);
                if (i == 1)
                {
                    QuestManager.Instance().Reward(quest);
                    quest.IsComplete = true;
                    QuestManager.Instance().Quests.Remove(quest);
                }
            }
            else
            {
                if (!quest.IsActive)
                {
                    menu = new List<string> { "수락", "거절" };

                    int i = makeSelect(menu, questLayout["Order"], questLayout);
                    if (i == 1)
                        quest.IsActive = true;
                }
                else
                {
                    menu = new List<string> { "포기하기", "돌아가기" };

                    int i = makeSelect(menu, questLayout["Order"], questLayout);
                    if (i == 1)
                        quest.IsActive = false;
                }
            }

        }
        public int MenuLayout() //메뉴
>>>>>>> Stashed changes
        {
            var layout = new Layout();

            layout.SplitRows(
                new Layout(new Panel(new Text("MENU").Centered()).Expand()).Size(3),
                new Layout("Middle")
                    .SplitColumns(new Layout().SplitRows(
                        new Layout("dungeon"),
                        new Layout("shop"),new Layout("player"),new Layout("quest")).Ratio(1),new Layout("MAP").Ratio(4))
                );
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            while (!isEnd)
            {
                switch (index)
                {
                    case 1:
                  layout["dungeon"].Update(new Panel("[blink]던전[/]") .Expand()  .Padding(0, 0));
                        layout["shop"].Update(new Panel("상점").Expand().Padding(0, 0));
                        layout["player"].Update(new Panel("플레이어 정보").Expand().Padding(0, 0));
                        layout["quest"].Update(new Panel("퀘스트").Expand().Padding(0, 0));
                        break;
                    case 2:
                        layout["dungeon"].Update(new Panel("던전").Expand().Padding(0, 0));
                        layout["shop"].Update(new Panel("[blink]상점[/]").Expand().Padding(0, 0));
                        layout["player"].Update(new Panel("플레이어 정보").Expand().Padding(0, 0));
                        layout["quest"].Update(new Panel("퀘스트").Expand().Padding(0, 0));
                        break;
                    case 3:
                        layout["dungeon"].Update(new Panel("던전").Expand().Padding(0, 0));
                        layout["shop"].Update(new Panel("상점").Expand().Padding(0, 0));
                        layout["player"].Update(new Panel("[blink]플레이어 정보[/]").Expand().Padding(0, 0));
                        layout["quest"].Update(new Panel("퀘스트").Expand().Padding(0, 0));
                        break;
                    case 4:
                        layout["dungeon"].Update(new Panel("던전").Expand().Padding(0, 0));
                        layout["shop"].Update(new Panel("상점").Expand().Padding(0, 0));
                        layout["player"].Update(new Panel("플레이어 정보").Expand().Padding(0, 0));
                        layout["quest"].Update(new Panel("[blink]퀘스트[/]").Expand().Padding(0, 0));
                        break;
                }
                
                AnsiConsole.Clear();
                AnsiConsole.Write(layout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        break;

                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
                if (index < 1)
                    index = 4;
                if (index > 4)
                    index = 1;
            }
            return index;

        }
        public int PlayerLayout()
        {
           

            playerlayout.SplitRows(
                new Layout(new Panel(new Text("MENU").Centered()).Expand()).Size(3),
                new Layout("Middle")
                    .SplitColumns(new Layout().SplitRows(
                        new Layout("status"),
                        new Layout("item"), new Layout(""), new Layout("")).Ratio(1), new Layout("MAP").Ratio(4))
                );
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            while (!isEnd)
            {
                switch (index)
                {
                    case 1:
                        playerlayout["status"].Update(new Panel("[blink]스테이터스[/]").Expand().Padding(0, 0));
                        playerlayout["item"].Update(new Panel("아이템").Expand().Padding(0, 0));
      
                        break;
                    case 2:
                        playerlayout["status"].Update(new Panel("[blink]스테이터스[/]").Expand().Padding(0, 0));
                        playerlayout["item"].Update(new Panel("아이템").Expand().Padding(0, 0));    
                        break;
                 
                }

                AnsiConsole.Clear();
                AnsiConsole.Write(playerlayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        break;

                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
                if (index < 1)
                    index = 2;
                if (index > 2)
                    index = 1;
            }
            return index;

        }
<<<<<<< Updated upstream
        private int ScrollMenu(List<Item> items,Layout lay)
        {
            int input=0;
            return input;
=======
        public void InitShop() //샵 레이아웃
        {
            
            shopLayout = new Layout();

            shopLayout.SplitRows(
                new Layout(new Panel(new Text("상점").Centered()).Expand()).Size(3),
                new Layout("ItemList").Ratio(5)
                    , new Layout("Order").Ratio(2)
                );
  
        }
        public Item ShopBuy(Shop shop)
        {
            int index = 0;


            int page = 1;

            int num = 10;
            int maxIndex = shop.shopItems.Count - 1;
            int maxPage = maxIndex / num + 1;
            if (maxIndex % num == 0)
                maxPage--;

            bool isEnd = false;
            while (!isEnd)
            {
                string txt = "";
                if (maxIndex > page * num)
                {
                    for (int i = (page - 1) * num; i <= page * num; i++)
                    {

                        if (index == i)
                            txt += "[bold]->" + shop.shopItems[i].show(1) + "[/]\n\n";
                        else
                            txt += shop.shopItems[i].show(1) + "\n\n";
                    }
                }
                else
                {
                    for (int i = (page - 1) * num; i <= maxIndex; i++)
                    {
                        if (index == i)
                            txt += "[bold]->" + shop.shopItems[i].show(1) + "[/]\n\n";
                        else
                            txt += shop.shopItems[i].show(1) + "\n\n";
                    }
                }

                shopLayout["ItemList"].Update(
                  new Panel(txt)
                     .Expand()
                     .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(shopLayout);
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < page * num)
                            index++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (page > 1)
                        {

                            page--;
                            index = (page - 1) * num;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (page < maxPage)
                            page++;
                        index = (page - 1) * num;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }




            }
            return shop.shopItems[index];
        } //상점
        public int SelectShop() //선택
        {
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            List<string> menu = new List<string>();
            menu.Add("구매");
            menu.Add("판매");
            menu.Add("뒤로");
            Layout layout = shopLayout["Order"];
            while (!isEnd)
            {
                string a = "\n";
                for (int i = 0; i < menu.Count; i++)
                {
                    if (i + 1 == index)
                        a += ("[bold]-> " + menu[i] + "[/]\n");
                    else
                        a += (" " + menu[i] + "\n");
                }
                layout.Update(
                new Panel(a)
                   .Expand()
                   .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(shopLayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        break;

                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
                if (index < 1)
                    index = menu.Count;
                if (index > menu.Count)
                    index = 1;
            }
            return index;
        }
        public void ShopResult(string message,Shop shop) //실패
        {
            shopLayout["Order"].Update(
              new Panel(message)
                 .Expand()
                 .Padding(0, 0));
            int maxIndex = shop.shopItems.Count - 1;
            string txt = "";

            if (maxIndex > 5)
            {
                for (int i = 0; i < 5; i++)
                {

                    if (0 == i)
                        txt += "[bold]->" + shop.shopItems[i].show(1) + "[/]\n\n";
                    else
                        txt += shop.shopItems[i].show(1) + "\n\n";
                }
            }
            else
            {
                for (int i = 0; i <= maxIndex; i++)
                {
                    if (0 == i)
                        txt += "[bold]->" + shop.shopItems[i].show(1) + "[/]\n\n";
                    else
                        txt += shop.shopItems[i].show(1) + "\n\n";
                }
            }
            shopLayout["ItemList"].Update(
               new Panel(txt)
                  .Expand()
                  .Padding(0, 0));


            AnsiConsole.Clear();
            AnsiConsole.Write(shopLayout);
            Thread.Sleep(1000);
        }
        public int ShopSellConfirm(string message)
        {
            int index =1;
            bool isEnd = false;
            
            Layout layout = shopLayout["Order"];
            List<String> menu = new List<String>();
            ConsoleKeyInfo key;
            menu.Add("네");
            menu.Add("아니오");
            while (!isEnd)
            {
                string a = message+"\n";
                for (int i = 0; i < menu.Count; i++)
                {
                    if (i + 1 == index)
                        a += ("[bold]->" + menu[i] + "[/]\n\n");
                    else
                        a += ( menu[i] + "\n\n");
                }
                layout.Update(
                new Panel(a)
                   .Expand()
                   .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(shopLayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        break;

                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
                if (index < 1)
                    index = menu.Count;
                if (index > menu.Count)
                    index = 1;
            }
            return index;
        }
        public Item ShopSell(Player player)
        {
            int index = 0;


            int page = 1;

            int num = 10;
            int maxIndex = player.inventory.Count - 1;
            int maxPage = maxIndex / num + 1;
            if (maxIndex % num == 0)
                maxPage--;

            bool isEnd = false;
            while (!isEnd)
            {
                string txt = "";
                if (maxIndex > page * num)
                {
                    for (int i = (page - 1) * num; i <= page * num; i++)
                    {

                        if (index == i)
                            txt += "[bold]->" + player.inventory[i].show(0) + "[/]\n\n";
                        else
                            txt += player.inventory[i].show(0) + "\n\n";
                    }
                }
                else
                {
                    for (int i = (page - 1) * num; i <= maxIndex; i++)
                    {
                        if (index == i)
                            txt += "[bold]->" + player.inventory[i].show(1) + "[/]\n\n";
                        else
                            txt += player.inventory[i].show(1) + "\n\n";
                    }
                }

                shopLayout["ItemList"].Update(
                  new Panel(txt)
                     .Expand()
                     .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(shopLayout);
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < page * num)
                            index++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (page > 1)
                        {

                            page--;
                            index = (page - 1) * num;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (page < maxPage)
                            page++;
                        index = (page - 1) * num;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }




            }
            return player.inventory[index];
        }
        public Item InvenLayout(Player player) //인벤토리 보여줌 클릭한 물체의 인덱스 보내줌
        {
            int input = 0;
          

            int index = 0;
            int page = 1;

            int num = 5;
            int maxIndex = player.inventory.Count - 1;
            if (maxIndex == -1)
                return null;
            int maxPage = maxIndex / num + 1;
            if (maxIndex % num == 0)
                maxPage--;

            bool isEnd = false;
            while (!isEnd)
            {
                string txt = "";
                if (maxIndex > page*num)
                {
                    for (int i = (page - 1) * num; i <= page * num; i++)
                    {
                        if (input == i)
                            txt += "[bold]->" + player.inventory[i].show(0) + "[/]\n\n";
                        else
                            txt += player.inventory[i].show(0) + "\n\n";
                    }
                }
                else
                {
                    for (int i = (page - 1) * num; i <= maxIndex; i++)
                    {
                        if (input == i)
                            txt += "[bold]->" + player.inventory[i].show(0) + "[/]\n\n";
                        else
                            txt += player.inventory[i].show(0) + "\n\n";
                    }
             }

                playerlayout["map"].Update(
                  new Panel(txt)
                     .Expand()
                     .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(playerlayout);
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (input > 0)
                            input--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (input < maxIndex)
                            input++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (page > 1)
                        {

                            page--;
                            input = (page - 1) * num;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (page < maxPage)
                            page++;
                        input = (page - 1) * num;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                    case ConsoleKey.Backspace:
                        return null;
                }




            }
            return player.inventory[input];
        }
        public void StatLayout(Player player) //플레이어 스테이터스 보여줌
        {
            AnsiConsole.Clear();
            playerlayout["map"].Update(
                  new Panel(player.showInfo())
                     .Expand()
                     .Padding(0, 0));
            AnsiConsole.Write(playerlayout);
            
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                    break;
            }


        }
        public void PSkillLayout(Player player) //스킬 보여줌
        {
            AnsiConsole.Clear();
            playerlayout["map"].Update(
                  new Panel(player.ShowSkillListS())
                     .Expand()
                     .Padding(0, 0));
            AnsiConsole.Write(playerlayout);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                    break;
            }
        }
        private T ScrollMenu<T>(List<T> list,Layout lay,Layout orign,int size,int mode,bool detail) where T : IShow
        {
            int index=0;
            string txt = "";
            
            int index = 0;
            int page = 1;
            
            int num = 5;
            int maxIndex = list.Count-1;
            int maxPage = maxIndex / num+1;
            if (maxIndex % num == 0)
                maxPage--;
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Backspace)
            {
                if (maxIndex > page)
                {
                    for (int i = (page-1)*num; i < page * num; i++)
                    {
                        if (index == 1)
                            txt = "[bold]->" + list[i].show(mode) + "[/]\n";
                        else
                            txt += list[i].show(mode) + "\n";
                    }
                }
                else
                {
                    for (int i = (page - 1) * num; i < maxIndex; i++)
                    {
                        if (index == 1)
                            txt = "[bold]->" + list[i].show(mode) + "[/]\n";
                        else
                            txt += list[i].show(mode) + "\n";
                    }



                }

                lay.Update(
                  new Panel(txt)
                     .Expand()
                     .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(charaLayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(index>0)
                        index--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (index < maxIndex)
                            index++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (page > 1)
                        {
                            
                            page--;
                            index =(page - 1)*num;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (page <maxPage )
                            page++;
                        index = (page - 1) * num;
                        break;
                    case ConsoleKey.Enter:
                        break;
                }
            



            }
            return list[in];
>>>>>>> Stashed changes
        }

        public void InitBattleScene(List<Monster> mons,string room,Player player,string a)
        {
            AnsiConsole.Clear();
            CreateBattleLayout(EnemyPanel(mons),RoomPanel(room),INFOPanel(player),DiagLog(a));
            AnsiConsole.Write(battlelayout);
            //Console.ReadKey(true);

        }
        
        public void UpdateBattleScene(Player player)
        {
            
        }
        private int makeSelect(List<string> menu,Layout layout,Layout big)
        {
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            while (!isEnd)
            {
                string a = "\n";
                for (int i = 0; i < menu.Count; i++)
                {
                    if (i + 1 == index)
                        a += ("[bold]-> " + i + ": " + menu[i] + "[/]\n\n");
                    else
                        a += (i + ": " + menu[i] + "\n\n");
                }
                layout.Update(
                new Panel(a)
                   .Expand()
                   .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(big);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index++;
                        break;

                    case ConsoleKey.DownArrow:
                        index--;
                        break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                }
                if (index < 1)
                    index = menu.Count;
                if (index > menu.Count)
                    index = 1;
            }
            return index;
        }
        public int UpdatePlayerScene(List<string> menu)
        {
            int index = 1;
            ConsoleKeyInfo key;
            bool isEnd = false;
            while (!isEnd)
            {
                string a="\n";
                for(int i=0;i<menu.Count; i++)
                {
                    if (i + 1 == index)
                        a += ("[bold]-> "+i+": " + menu[i] + "[/]\n\n");
                    else
                        a += (i + ": " + menu[i]+"\n\n");
                }
                battlelayout["OrderInfo"].Update(
                new Panel(a)
                   .Expand()
                   .Padding(0, 0));
                AnsiConsole.Clear();
                AnsiConsole.Write(battlelayout);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index++;
                    break;

                    case ConsoleKey.DownArrow:
                        index--;
                    break;
                    case ConsoleKey.Enter:
                        isEnd = true;
                        break;
                } 
                if(index<1)
                    index=menu.Count;
                if(index>menu.Count)
                    index=1;
            }
            return index;
        }

        private  void CreateBattleLayout(Panel Mon, Panel room, Panel info, Panel dialog)
        {
            battlelayout = new Layout();

            battlelayout.SplitRows(
                new Layout("RoomInfo").Size(3),
                new Layout("Middle").SplitColumns(                      
                    new Layout("MonInfo").Ratio(3), 
                    new Layout("RightRight").Ratio(1)),
                new Layout("Bottom")
                    .SplitColumns(
                        new Layout("OrderInfo"),
                        new Layout("DataInfo").Ratio(2))
                );
            battlelayout["RoomInfo"].Update(
                room);
            battlelayout["OrderInfo"].Update(
                new Panel("")
                     .Expand()
                     .Padding(0, 0));

            battlelayout["DataInfo"].Update(
             info);

            battlelayout["RightRight"].Update(
                dialog);

            battlelayout["MonInfo"].Update(
            Mon);

         
        }
        static Panel DiagLog(string a)
        {
            return new Panel(new Text(a).Centered())
                     .Expand()
                     .BorderColor(Color.Red)
                     .Padding(0, 0);
        }
        static Panel EnemyPanel(List<Monster> mons)
        {
            Panel panel;
            string monInfos = "\n";
            foreach (Monster mon in mons)
            {
                monInfos += $"{mon.Name} HP:{mon.CurrentHP}/{mon.MaxHp}\n\n";
            }

            panel = new Panel(new Text(monInfos).Centered()).Expand();

            return panel;
        }
        static Panel RoomPanel(string room)
        {
            return new Panel(new Text("Room 1").Centered())
                     .Expand()
                     .BorderColor(Color.Yellow)
                     .Padding(0, 0);
        }
        static Panel INFOPanel(Player player)
        {


            return new Panel($"\n{player.Name}({player.Job.ToString()}) HP: {player.CurrentHP}/{player.MaxHP} 마나: {player.CurrentMP}/{player.MaxMP} ")
                     .Expand()
                     .Padding(0, 0);
        }
      
    }
}
