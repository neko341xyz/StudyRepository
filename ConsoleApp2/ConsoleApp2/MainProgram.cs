﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    static class MainProgram
    {
        static void Main(string[] args)
        {

            Player player = new Player();
            GameSystem gamesystem = new GameSystem();
            bool createdPlayerFlg = false;

            while (!createdPlayerFlg)
            {
                //コンソールで入力した値をハッシュ値にする
                Console.WriteLine("ニックネームを入力してください");
                player.hash = gamesystem.HashGanerator(Console.ReadLine());

                //ハッシュ値を文字に置き換えて配列に格納
                string[] hashChar = player.hash.MySplit(1);
                

                //ハッシュ値をステータスに変換
                player.status = gamesystem.ConvertHashToStatus(hashChar);

                //ステータスを全て出力
                Display.ShowStatus(Const.statusStringArray, player);

                //キャラクター作成確認
                createdPlayerFlg = Display.LoopCreateCharacter(createdPlayerFlg);                
            }
            
        }
        //文字分割メソッド
        static string[] MySplit(this string str, int count)
        {
            //リスト型のlistを作成
            var list = new List<string>();
            //文字の長さを格納
            int length = (int)Math.Ceiling((double)str.Length / count);

            //文字の長さ分分割
            for (int i = 0; i < length; i++)
            {
                int start = count * i;
                if (str.Length <= start)
                {
                    break;
                }
                if (str.Length < start + count)
                {
                    list.Add(str.Substring(start));
                }
                else
                {
                    list.Add(str.Substring(start, count));
                }
            }
            return list.ToArray();
        }
    }

}
