using System;
using System.Runtime.InteropServices;

namespace NGDG2
{
    /// <summary>
    /// 권장 콘솔창 크기 100 * 40
    /// 폰트: 굴림체
    /// </summary>
    class Program
    {
        const int SWP_NOSIZE = 0x0001;
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr MyConsole = GetConsoleWindow();
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        static void Main(string[] args)
        {
            // 임시로 3000 * 100을 콘솔 시작 위치로 잡아놓음(개발자 편의)
            SetWindowPos(MyConsole, 0, 3000, 100, 0, 0, SWP_NOSIZE);

            // 게임 엔진을 만들어서 돌림
            GameEngine engine = new GameEngine("게임엔진1", 100);
            engine.Start();
        }
    }
}
