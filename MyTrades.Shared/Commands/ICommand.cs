using System;

namespace MyTrades.Shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}
