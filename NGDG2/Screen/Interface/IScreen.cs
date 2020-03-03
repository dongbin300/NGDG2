using System;

namespace NGDG2
{
    interface IScreen
    {
        void Show();

        string React(ConsoleKey key);
    }
}
