﻿using System;

namespace NGDG2
{
    public class ScreenUtil
    {
        /// <summary>
        /// 맨 왼쪽 좌표
        /// </summary>
        public static int Left = 3;

        /// <summary>
        /// 콘솔창 기본 테두리를 그린다.
        /// </summary>
        public static void DrawBorder()
        {
            CHelper.Write("┌─────────────────────────────────────────────────────────────────────────────────────────────────┐", 0, 0);
            for (int i = 1; i <= 38; i++)
            {
                CHelper.Write("│", 0, i);
                CHelper.Write("│", 98, i);
            }
            CHelper.Write("└─────────────────────────────────────────────────────────────────────────────────────────────────┘", 0, 39);
        }

        /// <summary>
        /// 콘솔창 구분자를 그린다.
        /// </summary>
        /// <param name="y"></param>
        public static void DrawSeparator(int y)
        {
            CHelper.Write("├─────────────────────────────────────────────────────────────────────────────────────────────────┤", 0, y);
        }

        /// <summary>
        /// 콘솔창 타이틀을 그린다.
        /// </summary>
        public static void DrawTitle(string titleText, ConsoleColor color = ConsoleColor.White)
        {
            CHelper.Write(titleText, Left, 1, color);
            DrawSeparator(2);
        }

        /// <summary>
        /// 문자열을 스택모드로 출력한다.
        /// 문자열이 스택처럼 쌓여간다.
        /// 이 기능을 사용하면 귀찮게 좌표를 넣어줄 필요가 없다.
        /// 아주 좋다.
        /// </summary>
        /// <param name="text">문자열</param>
        /// <param name="color">색상</param>
        public static void Stack(string text, ConsoleColor color = ConsoleColor.White)
        {
            CHelper.Write(text, Left, ScreenManager.WritePointer++, color);
        }

        /// <summary>
        /// 문자열을 스택모드로 출력한다.(하이라이트)
        /// 문자열이 스택처럼 쌓여간다.
        /// 이 기능을 사용하면 귀찮게 좌표를 넣어줄 필요가 없다.
        /// 아주 좋다.
        /// </summary>
        /// <param name="text">문자열</param>
        /// <param name="color">색상</param>
        /// <param name="highlightColor">하이라이트 색상</param>
        /// <param name="highlightDuration">하이라이트 유지시간</param>
        public static void StackHighlight(string text, HighlightEffect highlightEffect)
        {
            CHelper.WriteHighlight(text, Left, ScreenManager.WritePointer++, highlightEffect);
        }
    }
}
