﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TEXT_RPG.DungeonManager;

namespace TEXT_RPG
{ }

//            internal class Dungeon
//            {
//                public string DungeonSelect { get; set; }
//                Player player;
//                BattleManager bm;
//                bool isEnd = false;
//                //전투 장면은 배틀씬에서 할 듯합니다 몬스터의 배열과 방 선택등을 구현해주시면 감사하겠습니다.
//                //일단 임시로 만들어 보았습니다... 원하는대로 수정하세요
//                //던전매니저를 만들고 던전들의 속성을 클래스에서 관리하는 것도 가능할지도...... 그치만 이런식으로 하고 문자열로 나누는 게 더 나을수도 있습니다 자유롭게.
//                public void DungeonRun(Player _player)
//                {
//                    bm = new BattleManager(); //이 앞에 던전 진입시 나오는 문구를 넣으면 됩니다.
//                    player = _player;
//                    isEnd = false;
//                    while (!isEnd)
//                    {                          //이 안에 던전의 문구를 넣으시면 됩니다.
//                        bool isWin = bm.Battle(player); //배틀매니저의 실행입니다. 여기에 특정값(ex: 몬스터들,방 특성)들을 넣어주시면 됩니다.
//                                                        //또한 배틀씬을 보고 싶지 않은 경우 bm.Battle을 보고 싶은 값으로 변경해주세요 (ex: 승리시 true 패배시 false)
//                        if (isWin) //승리시 true 패배시 false. 만약 도주나 다른 값을 넣고 싶으면 말씀해주세요 enum등으로 변경하면 됩니다.
//                        {
//                            isEnd = true;
//                            VictoryScene();
//                            //승리시... 기타등등
//                        }
//                        else
//                        {
//                            isEnd = true;
//                            LoseScene();
//                        }
//                    }
//                }

//                public enum Dungeonenum//상자방의 확률 조정용
//                {
//                    상자방 = 1,
//                    상점,
//                    약한몬스터,
//                    약한몬스터1,
//                    약한몬스터2,
//                    약한몬스터3,
//                    일반몬스터,
//                    일반몬스터1,
//                    일반몬스터2,
//                    일반몬스터3,
//                    일반몬스터4,
//                    엘리트몬스터,
//                    엘리트몬스터1,
//                    이벤트,
//                    휴식

//                }


//                private List<int> selectedDungeons = new List<int>();

//                public void DungeonSet()//던전 리스트를 랜덤하게 바꿔주는 메서드
//                {

//                    Random random = new Random();

//                    selectedDungeons = Enumerable.Range(1, 15)                  // Linq에서 제공하는 메서드. 1~15 사이의 리스트 만들기
//                                                  .OrderBy(x => random.Next())    // .OrderBy = ()를 기준으로 무작위 정렬   x => rand.Next() = 각 항목에 대해 난수부여, 난수를 기준으로 순서를 섞기
//                                                  .Take(3)                      // 섞인 리스트에서 앞에 ()개수만 가져온다
//                                                  .ToList();                    //IEnumerable<int>을 List<int>로 변환 저장할 수 있게 함.
//                }

//                public void WarpManager(int DungeonEnum)//워프 추가 필요 // 일단 몬스터는 완료
//                {
//                    Dungeonenum dungeon = (Dungeonenum)DungeonEnum;

//                    if (Floor.Instance().nowfloor % 10 == 0)//보스 스테이지
//                    {
//                        Thread.Sleep(1000);
//                        Console.WriteLine("앞쪽에서 사악한 기운이 느껴집니다!!");
//                        Thread.Sleep(1500);
//                        Console.WriteLine("보스 스테이지로 강제로 이동됩니다!!");


//                    }
//                    else if (Floor.Instance().nowfloor % 10 == 1)//마을
//                    {

//                    }
//                    else//일반 스테이지
//                    {
//                        if (DungeonEnum == 1)
//                        {
//                            Console.Clear();
//                            Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//                            chestWarp();

//                        }
//                        else if (DungeonEnum == 2)
//                        {
//                            Console.Clear();
//                            Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//                            shopWarp();
//                        }
//                        else if (DungeonEnum >= 3 && DungeonEnum <= 6)
//                        {
//                            Console.Clear();
//                            Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//                            weakmobWarp();
//                        }
//                        else if (DungeonEnum >= 7 && DungeonEnum <= 11)
//                        {
//                            Console.Clear();
//                            Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//                            commonmobWarp();
//                        }
//                        else if (DungeonEnum >= 12 && DungeonEnum <= 13)
//                        {
//                            Console.Clear();
//                            Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//                            elitemobWarp();
//                        }
//                        else if (DungeonEnum == 14)
//                        {
//                            Console.Clear();
//                            Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//                            eventWarp();
//                        }
//                        else
//                        {
//                            Console.Clear();
//                            Console.WriteLine($"{dungeon} 층으로 이동합니다.");
//                            RestFloor();
//                            Thread.Sleep(500);
//                            Warp();
//                        }
//                    }
//                }

//                public void Warp()
//                {
//                    DungeonSet();

//                    Console.WriteLine($"1.{(Dungeonenum)selectedDungeons[0]}으로 진행하기");
//                    Console.WriteLine($"2.{(Dungeonenum)selectedDungeons[1]}으로 진행하기");
//                    Console.WriteLine($"3.{(Dungeonenum)selectedDungeons[2]}으로 진행하기");
//                    Console.WriteLine("");
//                    Console.WriteLine("0 - 마을귀환주문서 사용하기");
//                    Console.WriteLine(">>");

//                    Floor.Instance().nowfloor++;
//                    Floor.Instance().highfloor01();

//                    int input = int.Parse(Console.ReadLine());
//                    switch (input)
//                    {
//                        case 1:
//                            WarpManager(selectedDungeons[0]);
//                            break;
//                        case 2:
//                            WarpManager(selectedDungeons[1]);
//                            break;
//                        case 3:
//                            WarpManager(selectedDungeons[2]);
//                            break;
//                        case 0:
//                            Console.WriteLine("마을귀환주문서를 사용하였습니다.");
//                            Console.WriteLine("마을로 돌아갑니다.");
//                            Thread.Sleep(1000);
//                            //마을로 돌아가는 메서드
//                            break;
//                        default:
//                            Console.WriteLine("입력 오류");
//                            break;
//                    }


//                }

//                public void VictoryScene()
//                {
//                    Console.WriteLine("");
//                    Console.WriteLine("Battle!! - Result");
//                    Console.WriteLine("");
//                    Console.WriteLine("Victory");
//                    Console.WriteLine("던전에서 몬스터를 n마리 잡으셨습니다.");
//                    Console.WriteLine($"LV{player.Level} {player.Name}");
//                    Console.WriteLine($"(플레이어 해당 층 입장체력 ) -> (HP : {player.CurrentHP})");// 해당 층 입장체력 어캐하지

//                    Console.WriteLine("");
//                    Warp();
//                }
//                public void ChooseNext()
//                {

//                }
//                // 층이 보스, 마을층이 아닐때만 이렇게, 보스층 , 마을은 별도 추가

//                public void LoseScene()
//                {
//                    Console.WriteLine("Battle!! - Result");
//                    Console.WriteLine("");
//                    Console.WriteLine("You Lose");
//                    Console.WriteLine($"LV{player.Level} {player.Name}");
//                    Console.WriteLine("(플레이어 해당 층 입장체력 ) -> 0 ");
//                    Console.WriteLine("");
//                    Console.WriteLine("사망하셨습니다.");
//                    Console.WriteLine("0.처음으로 돌아가기");
//                    Console.WriteLine("");
//                    Console.WriteLine(">>");
//                }


//                public void chestWarp()
//                {
//                    Console.WriteLine("상자 층 입니다");
//                }
//                public void eventWarp()
//                {
//                    Console.WriteLine("이벤트 층 입니다.");
//                }
//                public void restWarp()//완?
//                {
//                    Console.WriteLine("휴식의 층 입니다.");

//                    RestFloor();
//                }
//                public void shopWarp()
//                {
//                    Console.WriteLine("상점 층 입니다.");
//                }
//                public void weakmobWarp()
//                {
//                    Console.WriteLine("약한 몬스터 층 입니다.");
//                    Console.WriteLine($"현재 {Floor.Instance().nowfloor}층 입니다.");
//                    Console.WriteLine($"최고층수는 {Floor.Instance().highfloor}층 입니다.");
//                    DungeonRun(player);

//                }
//                public void commonmobWarp()
//                {
//                    Console.WriteLine("몬스터 층 입니다.");
//                    Console.WriteLine($"현재 {Floor.Instance().nowfloor}층 입니다.");
//                    Console.WriteLine($"최고층수는 {Floor.Instance().highfloor}층 입니다.");
//                    DungeonRun(player);

//                }
//                public void elitemobWarp()
//                {
//                    Console.WriteLine("엘리트 몬스터 층 입니다.");
//                    Console.WriteLine($"현재 {Floor.Instance().nowfloor}층 입니다.");
//                    Console.WriteLine($"최고층수는 {Floor.Instance().highfloor}층 입니다.");
//                    DungeonRun(player);


//                }
//                public void townWarp()// 마을은 로비 복사?해서 조금씩 고치면 될거같은데
//                {
//                    Console.WriteLine($"현재 {Floor.Instance().nowfloor}층 입니다.");
//                    Console.WriteLine("마을입니다");
//                }
//                public void RestFloor()
//                {
//                    if (player.CurrentHP >= player.MaxHP / 2)//플레이어의 현재체력이 50%보다 낮다면 
//                    {
//                        player.CurrentHP += player.MaxHP / 2;
//                        Console.WriteLine("충분한 휴식을 취해 체력이 회복되었습니다.");
//                    }
//                    else//플레이어의 체력이 50% 이상이면? 현재체력 + (최대체력-현재체력) = 풀피
//                    {
//                        player.CurrentHP += (player.MaxHP -= player.CurrentHP);
//                        Console.WriteLine("충분한 휴식을 취해 체력이 모두 회복되었습니다.");
//                    }

//                }

//                public void BossWarp()
//                {
//                    Console.WriteLine("보스 등장!");
//                }

//                public void BackTown()
//                {
//                    Console.WriteLine("마을로 귀환합니다.");

//                    Floor.Instance().nowfloor = Floor.Instance().nowfloor - (Floor.Instance().nowfloor % 10) + 1;
//                    townWarp();
//                }

//            }
//        }

//    }
//}

//    }
//}
